using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Domain.Interfaces.Extended_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PcComponentsShop.Infrastructure.Data.Filters
{
    public enum CommonSort
    {
        Нет,
        Возрастание,
        Убывание,
    }
  
    public class PcComponentsFilter : IPcComponentsRepositoryFilter
    {
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public CommonSort? SortByIncreaseName { get; set; }
        public CommonSort? SortByIncreasePrice { get; set; }
        public CommonSort? SortByIncreaseProducedAt { get; set; } = CommonSort.Нет;
        public IEnumerable<string> Brands { get; set; }
        public string ErrorMessage { get; set; } = "";
        public string Category { get; set; }

        public IEnumerable<Good> ExecuteAndReturn(IQueryable<Good> goods)
        {
            if (ValidateInputParameters())
            {
                goods = goods.Where(g => g.Price >= MinPrice && g.Price <= MaxPrice);
                List<Good> r = new List<Good>();
                foreach (string s in Brands)
                {
                    r.AddRange(goods.Where(g => g.Brand == s));
                }
                goods = r.AsQueryable();
                switch (SortByIncreaseName)
                {
                    case (CommonSort.Возрастание):
                        goods = goods.OrderBy(g => g.FullName);
                        break;
                    case (CommonSort.Убывание):
                        goods = goods.OrderByDescending(g => g.FullName);
                        break;
                }

                switch (SortByIncreasePrice)
                {
                    case (CommonSort.Возрастание):
                        goods = goods.OrderBy(g => g.Price);
                        break;
                    case (CommonSort.Убывание):
                        goods = goods.OrderByDescending(g => g.Price);
                        break;
                }

                switch (SortByIncreaseProducedAt)
                {
                    case (CommonSort.Возрастание):
                        goods = goods.OrderBy(g => g.ProducedAt);
                        break;
                    case (CommonSort.Убывание):
                        goods = goods.OrderByDescending(g => g.ProducedAt);
                        break;
                }
            }
            return goods;
        }
        public bool ValidateInputParameters()
        {
            if (MinPrice == null || MaxPrice == null || SortByIncreasePrice == null || SortByIncreaseName == null || SortByIncreaseProducedAt == null)
                return false;
            int c = 0;
            foreach (var v in Enum.GetNames(typeof(CommonSort)))
            {
                if (v != "Нет")
                {
                    if (Enum.GetName(typeof(CommonSort), SortByIncreasePrice) == v)
                        c++;
                    if (Enum.GetName(typeof(CommonSort), SortByIncreaseName) == v)
                        c++;
                    if (Enum.GetName(typeof(CommonSort), SortByIncreaseProducedAt) == v)
                        c++;
                }
            }
            if (c > 1)
            {
                ErrorMessage += "Пожалуйста выберите только один параметр(Имя, Цена или Новизна);";
                return false;
            }
            else if (MinPrice < 0 || MaxPrice < 0)
            {
                ErrorMessage += "Цены не могут быть отрицательными;";
                return false;
            }
            else if (MinPrice > MaxPrice)
            {
                ErrorMessage += "Минимальная цена не может быть больше максимальной;";
                return false;
            }
            return true;
        }
    }
}
