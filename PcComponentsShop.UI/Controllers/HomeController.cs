using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Infrastructure.Business.ActionValidators;
using PcComponentsShop.Infrastructure.Business.Basic_Actions;
using PcComponentsShop.Infrastructure.Business.Basic_Models;
using PcComponentsShop.Infrastructure.Data.Units;
using PcComponentsShop.UI.Controllers.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PcComponentsShop.UI.Controllers
{
    [RefuseLockedUsers]
    public class HomeController : Controller
    {
        public PcComponentsUnit pcComponentsUnit;

        delegate void HomeInfoEvents (string message);

        event HomeInfoEvents OrderInfoEvent = MvcApplication.AppInfoLogger.Info;

        public HomeController()
        {
            pcComponentsUnit = MvcApplication.PcComponentsUnit;
        }

        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Administrators, Users")]
        public ActionResult Orders()
        {
            return View(pcComponentsUnit.Orders.GetAll().Where(o => o.UserName == User.Identity.Name));

        }

        [Authorize(Roles = "Administrators, Users")]
        public ActionResult ChangeOrderStatus(int orderId, int goodAmount, bool IsPay = false, bool IsCancel = false, bool IsEnd = false)
        {
            if (goodAmount > 0)
            {
                Order o = pcComponentsUnit.Orders.GetElement(orderId);
                if (o != null)
                {
                    if (IsPay)
                    {
                        o.OrderStatus = OrderStatus.Paid.ToString();
                        o.PaidAt = DateTime.Now;
                    }
                    else if (IsCancel)
                        o.OrderStatus = OrderStatus.Canceled.ToString();
                    else if (o.OrderStatus == OrderStatus.Paid.ToString() && IsEnd)
                        o.OrderStatus = OrderStatus.Finished.ToString();
                    OrderInfoEvent($"Order({o.OrderId}) status has been changed to {o.OrderStatus}\nOwner name:{o.UserName}");
                    o.GoodAmount = goodAmount;
                    pcComponentsUnit.Orders.Update(o);
                    pcComponentsUnit.Save();
                }
            }
            return RedirectToActionPermanent("Orders");
        }
        
        [Authorize(Roles = "Administrators, Users")]
        public ActionResult CreateRegisteredOrder(int[] goodId, string[] category, string ids = null, string ctgrs = null)
        {
            if (!string.IsNullOrEmpty(ids) && !string.IsNullOrEmpty(ctgrs))
            {
                goodId = Array.ConvertAll(ids.Split(','), int.Parse);
                category = ctgrs.Split(',');
            }

            int i = 0;
            OrderValidators.UserName = User.Identity.Name;
            while (i < goodId.Length && i < category.Length)
            {
                OrderValidators.AllGoods = pcComponentsUnit.GetGoodsDependsOnCategory(category[i]);

                HttpCookie cookieReq = Request.Cookies["ShoppingBasket"];
                string findItem = string.Format($"{goodId[i]},{category[i]}+");

                if (cookieReq != null && cookieReq["ShoppingBasket"].Contains(findItem))
                {
                    Order order = OrdersManipulator.CreateAndReturnNewOrder(
                        User.Identity.Name,
                        pcComponentsUnit.GetGoodsDependsOnCategory(category[i]).FirstOrDefault(g => g.ID == goodId[i]),
                        OrderValidators.IsValidOrder);
                    if (order != null)
                    {
                        pcComponentsUnit.Orders.Create(order);
                        pcComponentsUnit.Save();
                        cookieReq["ShoppingBasket"] = cookieReq["ShoppingBasket"].Replace(findItem, "");
                        Response.Cookies.Add(cookieReq);
                        OrderInfoEvent($"Order({order.OrderId}) has been created and registered\nOwner name:{order.UserName}\n" +
                            $"GoodId: {order.GoodId} Price: {order.GoodPrice}");
                    }
                }
                i++;
            }
            return RedirectToActionPermanent("Orders");
        }

        public ActionResult ShopBasket()
        {
            HttpCookie cookieReq = Request.Cookies["ShoppingBasket"];
            ShoppingBasket shoppingBasket = new ShoppingBasket();

            List<Good> goods = new List<Good>();
            if (cookieReq == null)
            {
                HttpCookie cookie = new HttpCookie("ShoppingBasket");
                cookie.Expires = DateTime.Now.AddMonths(6);
                Response.Cookies.Add(cookie);
            }
            else
            {
                shoppingBasket = ShoppingBasket.ReadFromCookie(cookieReq["ShoppingBasket"]);
                foreach (Good g in shoppingBasket.Goods)
                {
                    Good el = pcComponentsUnit.GetGoodsDependsOnCategory(g.Category).FirstOrDefault(e => e.ID == g.ID);
                    if (el != null)
                        goods.Add(el);
                }
            }
            return View(goods);
        }
        [HttpPost]
        public ActionResult ShopBasket(int id, string category, string actionName, string controllerName, bool removeSelected = false, bool buySelected = false, string[] selectedGoods = null, int page = 1, bool isRemoveFromBasket = false)
        {
            if (!isRemoveFromBasket && !removeSelected && !buySelected)
            {
                HttpCookie cookieReq = Request.Cookies["ShoppingBasket"];
                if (cookieReq == null)
                {
                    cookieReq = new HttpCookie("ShoppingBasket");
                    cookieReq.Expires = DateTime.Now.AddMonths(6);
                }
                ShoppingBasket shoppingBasket = new ShoppingBasket() { Goods = { new Good() { ID = id, Category = category } } };
                cookieReq["ShoppingBasket"] += shoppingBasket.ToString();
                Response.Cookies.Add(cookieReq);
            }
            else if (removeSelected && selectedGoods != null)
            {
                HttpCookie cookieReq = Request.Cookies["ShoppingBasket"];
                if (cookieReq != null)
                {
                    if (selectedGoods != null)
                    {
                        string newCookie = cookieReq["ShoppingBasket"];
                        foreach (string s in selectedGoods)
                            newCookie = newCookie.Replace(s, "");
                        cookieReq["ShoppingBasket"] = newCookie;
                        Response.Cookies.Add(cookieReq);
                    }
                }
            }
            else if (isRemoveFromBasket)
            {
                HttpCookie cookieReq = Request.Cookies["ShoppingBasket"];
                if (cookieReq != null)
                {
                    string newCookie = cookieReq["ShoppingBasket"].Replace(string.Format($"{id},{category}+"), "");
                    cookieReq["ShoppingBasket"] = newCookie;
                    Response.Cookies.Add(cookieReq);
                }
            }
            else if (buySelected && selectedGoods != null)
            {
                ShoppingBasket sb = ShoppingBasket.ReadFromCookie(string.Join("", selectedGoods));
                string ids = string.Join(",", sb.Goods.Select(g => g.ID.ToString()));
                string ctgrs = string.Join(",", sb.Goods.Select(g => g.Category));
                return RedirectToActionPermanent("CreateRegisteredOrder", new { ids, ctgrs });
            }
            if (string.IsNullOrEmpty(actionName) || string.IsNullOrEmpty(controllerName))
                return RedirectToActionPermanent("ComponentsCatalog", "Catalog", new { category, page });
            else
                return RedirectToActionPermanent(actionName, controllerName);
        }

    }
}