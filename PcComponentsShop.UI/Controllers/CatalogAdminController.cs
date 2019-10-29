using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Infrastructure.Data.Units;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PcComponentsShop.UI.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class CatalogAdminController : Controller
    {
        public PcComponentsUnit pcComponentsUnit;

        public CatalogAdminController()
        {
            pcComponentsUnit = MvcApplication.PcComponentsUnit;
        }

        [HttpPost]
        public ActionResult CreateGood(string category)
        {
            int goodId = 0; 
            switch (category)
            {
                case "Процессоры":
                    pcComponentsUnit.Processors.Create(new Processor() { Category = category});
                    pcComponentsUnit.Save();
                    goodId = pcComponentsUnit.Processors.GetAll().Last().ID;
                    break;
                case "Материнские платы":
                    pcComponentsUnit.Motherboards.Create(new Motherboard() { Category = category });
                    pcComponentsUnit.Save();
                    goodId = pcComponentsUnit.Motherboards.GetAll().Last().ID;
                    break;
                case "Видеокарты":
                    pcComponentsUnit.VideoCards.Create(new VideoCard(){ Category = category});
                    pcComponentsUnit.Save();
                    goodId = pcComponentsUnit.VideoCards.GetAll().Last().ID;
                    break;
                case "Корпуса":
                    pcComponentsUnit.ComputerСases.Create(new ComputerCase(){ Category = category});
                    pcComponentsUnit.Save();
                    goodId = pcComponentsUnit.ComputerСases.GetAll().Last().ID;
                    break;
                case "Модули памяти":
                    pcComponentsUnit.MemoryModules.Create(new MemoryModule(){ Category = category});
                    pcComponentsUnit.Save();
                    goodId = pcComponentsUnit.MemoryModules.GetAll().Last().ID;
                    break;
                case "Блоки питания":
                    pcComponentsUnit.PowerSupplies.Create(new PowerSupply(){ Category = category});
                    pcComponentsUnit.Save();
                    goodId = pcComponentsUnit.PowerSupplies.GetAll().Last().ID;
                    break;
                case "SSD диски":
                    pcComponentsUnit.SSDDrives.Create(new SSDDrive(){ Category = category});
                    pcComponentsUnit.Save();
                    goodId = pcComponentsUnit.SSDDrives.GetAll().Last().ID;
                    break;
            }
            return RedirectToActionPermanent("ChangeOrDeleteGood", new { goodId, category, IsChangeGood = true});
        }

        public ActionResult ChangeOrDeleteGood(int goodId, string category, bool IsDeleteGood = false, bool IsChangeGood = false, int page = 1, int pageSize = 20)
        {
            if (IsDeleteGood)
            {
                switch (category)
                {
                    case "Процессоры":
                        pcComponentsUnit.Processors.Delete(goodId);
                        break;
                    case "Материнские платы":
                        pcComponentsUnit.Motherboards.Delete(goodId);
                        break;
                    case "Видеокарты":
                        pcComponentsUnit.VideoCards.Delete(goodId);
                        break;
                    case "Корпуса":
                        pcComponentsUnit.ComputerСases.Delete(goodId);
                        break;
                    case "Модули памяти":
                        pcComponentsUnit.MemoryModules.Delete(goodId);
                        break;
                    case "Блоки питания":
                        pcComponentsUnit.PowerSupplies.Delete(goodId);
                        break;
                    case "SSD диски":
                        pcComponentsUnit.SSDDrives.Delete(goodId);
                        break;
                }
                pcComponentsUnit.Save();
            }
            else if (IsChangeGood)
            {
                ViewBag.page = page;
                ViewBag.pageSize = pageSize;
                switch (category)
                {
                    case "Процессоры":
                        return View("ChangeProcessor", pcComponentsUnit.Processors.GetElement(goodId));
                    case "Материнские платы":
                        return View("ChangeMotherboard", pcComponentsUnit.Motherboards.GetElement(goodId));
                    case "Видеокарты":
                        return View("ChangeVideoCard", pcComponentsUnit.VideoCards.GetElement(goodId));
                    case "Корпуса":
                        return View("ChangeComputerCase", pcComponentsUnit.ComputerСases.GetElement(goodId));
                    case "Модули памяти":
                        return View("ChangeMemoryModule", pcComponentsUnit.MemoryModules.GetElement(goodId));
                    case "Блоки питания":
                        return View("ChangePowerSupply", pcComponentsUnit.PowerSupplies.GetElement(goodId));
                    case "SSD диски":
                        return View("ChangeSSDDrive", pcComponentsUnit.SSDDrives.GetElement(goodId));
                }
            }
            return RedirectToActionPermanent("ComponentsCatalog", "Catalog", new { category, page, pageSize});
        }
        [HttpGet]
        public ActionResult ChangeProcessor(Processor p)
        {
            return View(pcComponentsUnit.Processors.GetElement(p.ID));
        }
        [HttpPost]
        public ActionResult ChangeProcessor(Processor p, HttpPostedFileBase NewImage, bool IsDeletePreviousImageFromServer = false, int page = 1, int pageSize = 20)
        {
            ViewBag.page = page;
            ViewBag.pageSize = pageSize;
            if (ModelState.IsValid)
            {
                if (NewImage != null)
                {
                    if (NewImage.ContentLength <= 200000)
                        AddOrAddRemoveImageForCatalog(NewImage, IsDeletePreviousImageFromServer, p);
                    else
                    {
                        ModelState.AddModelError("NewImage", "Изображение должно быть меньше 200 Кб");
                        return View(pcComponentsUnit.Processors.GetElement(p.ID));
                    }
                }
                p.FullName = string.Format($"{p.Category} {p.Model} {p.Frequency}GHz {p.Socket} ({p.ID})");
                pcComponentsUnit.Processors.Update(p);
                pcComponentsUnit.Save();
                return RedirectToActionPermanent("ComponentsCatalog", "Catalog", new { category = p.Category, page, pageSize });
            }
            return View(pcComponentsUnit.Processors.GetElement(p.ID));
        }
        [HttpGet]
        public ActionResult ChangeComputerCase(ComputerCase p)
        {
            return View(pcComponentsUnit.ComputerСases.GetElement(p.ID));
        }
        
        [HttpPost]
        public ActionResult ChangeComputerCase(ComputerCase p, HttpPostedFileBase NewImage, bool IsDeletePreviousImageFromServer = false, int page = 1, int pageSize = 20)
        {
            ViewBag.page = page;
            ViewBag.pageSize = pageSize;
            if (ModelState.IsValid)
            {
                if (NewImage != null)
                {
                    if (NewImage.ContentLength <= 200000)
                        AddOrAddRemoveImageForCatalog(NewImage, IsDeletePreviousImageFromServer, p);
                    else
                    {
                        ModelState.AddModelError("NewImage", "Изображение должно быть меньше 200 Кб");
                        return View(pcComponentsUnit.ComputerСases.GetElement(p.ID));
                    }
                }
                p.FullName = string.Format($"{p.Category} {p.Model} {p.FormFactor} ({p.ID})");
                pcComponentsUnit.ComputerСases.Update(p);
                pcComponentsUnit.Save();
                return RedirectToActionPermanent("ComponentsCatalog", "Catalog", new { category = p.Category, page, pageSize });
            }
            return View(pcComponentsUnit.ComputerСases.GetElement(p.ID));
        }
        [HttpGet]
        public ActionResult ChangeMemoryModule(MemoryModule p)
        {
            return View(pcComponentsUnit.MemoryModules.GetElement(p.ID));
        }
        
        [HttpPost]
        public ActionResult ChangeMemoryModule(MemoryModule p, HttpPostedFileBase NewImage, bool IsDeletePreviousImageFromServer = false, int page = 1, int pageSize = 20)
        {
            ViewBag.page = page;
            ViewBag.pageSize = pageSize;
            if (ModelState.IsValid)
            {
                if (NewImage != null)
                {
                    if (NewImage.ContentLength <= 200000)
                        AddOrAddRemoveImageForCatalog(NewImage, IsDeletePreviousImageFromServer, p);
                    else
                    {
                        ModelState.AddModelError("NewImage", "Изображение должно быть меньше 200 Кб");
                        return View(pcComponentsUnit.MemoryModules.GetElement(p.ID));
                    }
                }
                p.FullName = string.Format($"{p.Category} {p.Brand} {p.Model} {p.MemoryType} {p.OperatingFrequency}MHz {p.MemoryCapacity}GB ({p.ID})");
                pcComponentsUnit.MemoryModules.Update(p);
                pcComponentsUnit.Save();
                return RedirectToActionPermanent("ComponentsCatalog", "Catalog", new { category = p.Category, page, pageSize });
            }
            return View(pcComponentsUnit.MemoryModules.GetElement(p.ID));
        }
        [HttpGet]
        public ActionResult ChangeMotherboard(Motherboard p)
        {
            return View(pcComponentsUnit.Motherboards.GetElement(p.ID));
        }
        
        [HttpPost]
        public ActionResult ChangeMotherboard(Motherboard p, HttpPostedFileBase NewImage, bool IsDeletePreviousImageFromServer = false, int page = 1, int pageSize = 20)
        {
            ViewBag.page = page;
            ViewBag.pageSize = pageSize;
            if (ModelState.IsValid)
            {
                if (NewImage != null)
                {
                    if (NewImage.ContentLength <= 200000)
                        AddOrAddRemoveImageForCatalog(NewImage, IsDeletePreviousImageFromServer, p);
                    else
                    {
                        ModelState.AddModelError("NewImage", "Изображение должно быть меньше 200 Кб");
                        return View(pcComponentsUnit.Motherboards.GetElement(p.ID));
                    }
                }
                p.FullName = string.Format($"{p.Category} {p.Model} {p.Chipset} {p.Socket} ({p.ID})");
                pcComponentsUnit.Motherboards.Update(p);
                pcComponentsUnit.Save();
                return RedirectToActionPermanent("ComponentsCatalog", "Catalog", new { category = p.Category, page, pageSize });
            }
            return View(pcComponentsUnit.Motherboards.GetElement(p.ID));
        }
        [HttpGet]
        public ActionResult ChangePowerSupply(PowerSupply p)
        {
            return View(pcComponentsUnit.PowerSupplies.GetElement(p.ID));
        }
        
        [HttpPost]
        public ActionResult ChangePowerSupply(PowerSupply p, HttpPostedFileBase NewImage, bool IsDeletePreviousImageFromServer = false, int page = 1, int pageSize = 20)
        {
            ViewBag.page = page;
            ViewBag.pageSize = pageSize;
            if (ModelState.IsValid)
            {
                if (NewImage != null)
                {
                    if (NewImage.ContentLength <= 200000)
                        AddOrAddRemoveImageForCatalog(NewImage, IsDeletePreviousImageFromServer, p);
                    else
                    {
                        ModelState.AddModelError("NewImage", "Изображение должно быть меньше 200 Кб");
                        return View(pcComponentsUnit.PowerSupplies.GetElement(p.ID));
                    }
                }
                p.FullName = string.Format($"{p.Category} {p.Power}W {p.Model} ({p.ID})");
                pcComponentsUnit.PowerSupplies.Update(p);
                pcComponentsUnit.Save();
                return RedirectToActionPermanent("ComponentsCatalog", "Catalog", new { category = p.Category, page, pageSize });
            }
            return View(pcComponentsUnit.PowerSupplies.GetElement(p.ID));
        }
        [HttpGet]
        public ActionResult ChangeSSDDrive(SSDDrive p)
        {
            return View(pcComponentsUnit.SSDDrives.GetElement(p.ID));
        }
        
        [HttpPost]
        public ActionResult ChangeSSDDrive(SSDDrive p, HttpPostedFileBase NewImage, bool IsDeletePreviousImageFromServer = false, int page = 1, int pageSize = 20)
        {
            ViewBag.page = page;
            ViewBag.pageSize = pageSize;
            if (ModelState.IsValid)
            {
                if (NewImage != null)
                {
                    if (NewImage.ContentLength <= 200000)
                        AddOrAddRemoveImageForCatalog(NewImage, IsDeletePreviousImageFromServer, p);
                    else
                    {
                        ModelState.AddModelError("NewImage", "Изображение должно быть меньше 200 Кб");
                        return View(pcComponentsUnit.SSDDrives.GetElement(p.ID));
                    }
                }
                p.FullName = string.Format($"{p.Category} {p.Model} {p.Brand} {p.Capacity} {p.FormFactor} {p.ConnectionInterface} ({p.ID})");
                pcComponentsUnit.SSDDrives.Update(p);
                pcComponentsUnit.Save();
                return RedirectToActionPermanent("ComponentsCatalog", "Catalog", new { category = p.Category, page, pageSize });
            }
            return View(pcComponentsUnit.SSDDrives.GetElement(p.ID));
        }
        [HttpGet]
        public ActionResult ChangeVideoCard(VideoCard p)
        {
            return View(pcComponentsUnit.VideoCards.GetElement(p.ID));
        }
        
        [HttpPost]
        public ActionResult ChangeVideoCard(VideoCard p, HttpPostedFileBase NewImage, bool IsDeletePreviousImageFromServer = false, int page = 1, int pageSize = 20)
        {
            ViewBag.page = page;
            ViewBag.pageSize = pageSize;
            if (ModelState.IsValid)
            {
                if (NewImage != null)
                {
                    if (NewImage.ContentLength <= 200000)
                        AddOrAddRemoveImageForCatalog(NewImage, IsDeletePreviousImageFromServer, p);
                    else
                    {
                        ModelState.AddModelError("NewImage", "Изображение должно быть меньше 200 Кб");
                        return View(pcComponentsUnit.VideoCards.GetElement(p.ID));
                    }
                }
                p.FullName = string.Format($"{p.Category} {p.Brand} {p.Model} {p.Interface} ({p.ID})");
                pcComponentsUnit.VideoCards.Update(p);
                pcComponentsUnit.Save();
                return RedirectToActionPermanent("ComponentsCatalog", "Catalog", new { category = p.Category, page, pageSize });
            }
            return View(pcComponentsUnit.VideoCards.GetElement(p.ID));
        }

        private bool AddOrAddRemoveImageForCatalog(HttpPostedFileBase NewImage, bool IsDeletePreviousImageFromServer, Good p)
        {
            string fileName = string.Format($"{p.ID}{p.Category}{Path.GetExtension(NewImage.FileName)}");
            string path = Server.MapPath("~/Files/CatalogImages/" + NewImage.ContentLength + fileName);
            if (IsDeletePreviousImageFromServer)
            {
                if (!p.ImgSrc.Contains("http"))
                {
                    string oldImagePath = Server.MapPath("~" + p.ImgSrc);
                    if (System.IO.File.Exists(oldImagePath))
                        System.IO.File.Delete(oldImagePath);
                }
            }
            NewImage.SaveAs(path);
            if (System.IO.File.Exists(path))
            {
                p.ImgSrc = "/Files/CatalogImages/" + NewImage.ContentLength + fileName;
            }
            return true;
        }
    }
}