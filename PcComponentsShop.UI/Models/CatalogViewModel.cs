using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.UI.Models.Pagination;
using System.Collections.Generic;
using System.Linq;

namespace PcComponentsShop.UI.Models
{
    public class CatalogViewModel<TGoodType> where TGoodType : Good
    {
        public IEnumerable<TGoodType> Goods { get; set; }
        public IEnumerable<TGoodType> AllGoods { get; set; }
        public PageInfo PageInfo { get; set; }
        public string Category { get; set; }
        public static CatalogViewModel<TGoodType> GetCatalogViewModel(int page, int pageSize, IEnumerable<TGoodType> goods,IEnumerable<TGoodType> allGoods, string category)
        {
            IEnumerable<TGoodType> goodsPerPages = goods.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = goods.Count() };
            return new CatalogViewModel<TGoodType> { PageInfo = pageInfo, Goods = goodsPerPages, Category = category, AllGoods = allGoods};
        }
    }
}