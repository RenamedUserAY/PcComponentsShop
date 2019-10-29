using PcComponentsShop.Infrastructure.Business.Basic_Models;
using PcComponentsShop.Infrastructure.Data.Units;
using System;
using System.Linq;
using System.Web.Mvc;
namespace PcComponentsShop.UI.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class OrderAdminController : Controller
    {
        PcComponentsUnit pcComponentsUnit;

        delegate void OrderAdminEvents(string message);

        event OrderAdminEvents OrderInfoEvent = MvcApplication.AppInfoLogger.Info;

        public OrderAdminController()
        {
            pcComponentsUnit = MvcApplication.PcComponentsUnit;
        }
        public ActionResult Orders()
        {
            return View(pcComponentsUnit.Orders.GetAll());
        }
        [HttpPost]
        public ActionResult ChangeOrderStatus(int orderId, string newStatus)
        {
            Order order = pcComponentsUnit.Orders.GetElement(orderId);
            if (order != null) {
                string orderStatus = pcComponentsUnit.Orders.GetElement(orderId).OrderStatus;
                if (newStatus != orderStatus && Enum.GetNames(typeof(OrderStatus)).Contains(newStatus)
                    && !"Registered, Finished".Contains(newStatus))
                {
                    order.OrderStatus = newStatus;
                    pcComponentsUnit.Orders.Update(order);
                    pcComponentsUnit.Save();
                    OrderInfoEvent($"Order({order.OrderId}) status has been changed to {order.OrderStatus}\nOwner name:{order.UserName}");
                }
            }
            return View("Orders", pcComponentsUnit.Orders.GetAll());
        }
    }
}