using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Infrastructure.Data.Filters;
using PcComponentsShop.Infrastructure.Data.Units;
using PcComponentsShop.UI.Models;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace PcComponentsShop.UI.Controllers
{
    public class CatalogController : Controller
    {
        PcComponentsUnit componentsUnit;
        public CatalogController()
        {
            componentsUnit = MvcApplication.PcComponentsUnit;
        }

        [HttpGet]
        public ActionResult ComponentsCatalog(string[] Brands, string returnUrl, CommonSort SortByIncreaseName = CommonSort.Нет, CommonSort SortByIncreasePrice = CommonSort.Нет, CommonSort SortByIncreaseProducedAt = CommonSort.Нет, string category = "Процессоры", int? minPrice = null, int? maxPrice = null, int page = 1, int pageSize = 20)
        {
            ViewBag.returnUrl = returnUrl;

            if (Session["CurrentFilter"] == null || ((PcComponentsFilter)Session["CurrentFilter"]).Category != category)
                Session["CurrentFilter"] = new PcComponentsFilter();

            PcComponentsFilter curFilter = new PcComponentsFilter { SortByIncreaseName = SortByIncreaseName, SortByIncreasePrice = SortByIncreasePrice, SortByIncreaseProducedAt = SortByIncreaseProducedAt, MinPrice = minPrice, MaxPrice = maxPrice, Brands = Brands, Category=category};

            if (curFilter.ValidateInputParameters())
                Session["CurrentFilter"] = curFilter;
            else
                ModelState.AddModelError("CatalogViewModel", curFilter.ErrorMessage);

            IEnumerable<Good> allGoods = componentsUnit.GetGoodsDependsOnCategory(category);

            IEnumerable<Good> filteredGoods = componentsUnit.GetGoodsDependsOnFilter(category,(PcComponentsFilter)Session["CurrentFilter"]);

            if(allGoods != null && filteredGoods != null)
                return View(CatalogViewModel<Good>.GetCatalogViewModel(page, pageSize, filteredGoods, allGoods, category));
            throw new HttpException(404, "Page Not Found");
        }
    }
}