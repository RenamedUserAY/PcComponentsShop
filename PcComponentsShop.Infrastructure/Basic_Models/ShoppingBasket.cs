using PcComponentsShop.Domain.Core.Basic_Models;
using System.Collections.Generic;
using System.Text;

namespace PcComponentsShop.Infrastructure.Business.Basic_Models
{
    public class ShoppingBasket
    {
        public List<Good> Goods { get; set; } = new List<Good>();
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (Good g in Goods)
                result.AppendFormat(string.Format($"{g.ID},{g.Category}+"));
            return result.ToString();
        }
        public static ShoppingBasket ReadFromCookie(string cookie)
        {
            List<Good> goods = new List<Good>();
            if (!string.IsNullOrEmpty(cookie))
            {
                StringBuilder id = new StringBuilder();
                StringBuilder category = new StringBuilder();
                bool isWriteId = true;
                foreach (char c in cookie)
                {
                    if (c != ',' && isWriteId)
                        id.AppendFormat(c.ToString());
                    else if (c == ',')
                        isWriteId = false;
                    else if (c != '+' && !isWriteId)
                        category.AppendFormat(c.ToString());
                    else
                    {
                        if (int.TryParse(id.ToString(), out int identifer) && !string.IsNullOrEmpty(category.ToString()))
                        {
                            goods.Add(new Good() { ID = identifer, Category = category.ToString() });
                        }
                        id = new StringBuilder();
                        category = new StringBuilder();
                        isWriteId = true;
                    }
                }
            }
            return new ShoppingBasket() { Goods = goods };
        }
    }
}
