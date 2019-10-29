using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Infrastructure.Business.Basic_Models;
using System;

namespace PcComponentsShop.Infrastructure.Business.Basic_Actions
{
    public static class OrdersManipulator
    {
        public static Order CreateAndReturnNewOrder(string userName, Good good, Func<string, Good,int, bool> IsValidOrder, OrderStatus orderStatus = OrderStatus.Registered, int goodAmount = 1)
        {
            if (IsValidOrder(userName, good, goodAmount))
                return new Order() { UserName = userName, FullGoodName = good.FullName, GoodAmount = goodAmount, GoodCategory=good.Category, GoodId = good.ID, GoodPrice=good.Price, GoodImgSrc = good.ImgSrc, OrderStatus = orderStatus.ToString()};
            else
                return null;
        }
        
    }
}
