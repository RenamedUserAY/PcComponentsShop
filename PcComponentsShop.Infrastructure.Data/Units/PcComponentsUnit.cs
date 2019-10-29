using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Infrastructure.Data.Contexts;
using PcComponentsShop.Infrastructure.Data.Filters;
using PcComponentsShop.Infrastructure.Data.Repositories;
using PcComponentsShop.Infrastructure.Data.Repositories.Business;
using System;
using System.Collections.Generic;

namespace PcComponentsShop.Infrastructure.Data.Units
{
    public class PcComponentsUnit : IDisposable
    {
        private PcComponentsShopContext db = new PcComponentsShopContext();
        private ComputerСaseRepository computerСaseRepository;
        private MemoryModuleRepository memoryModuleRepository;
        private MotherboardRepository motherboardRepository;
        private PowerSupplyRepository powerSupplyRepository;
        private ProcessorRepository processorRepository;
        private SSDDriveRepository sSDDriveRepository;
        private VideoCardRepository videoCardRepository;
        //Business
        private OrderRepository orderRepository;

        public IEnumerable<Good> GetGoodsDependsOnCategory(string category)
        {
            switch (category)
            {
                case "Процессоры":
                    return Processors.GetAll();
                case "Материнские платы":
                    return Motherboards.GetAll();
                case "Видеокарты":
                    return VideoCards.GetAll();
                case "Корпуса":
                    return ComputerСases.GetAll();
                case "Модули памяти":
                    return MemoryModules.GetAll();
                case "Блоки питания":
                    return PowerSupplies.GetAll();
                case "SSD диски":
                    return SSDDrives.GetAll();
                default:
                    return null;
            }
        }
        public IEnumerable<Good> GetGoodsDependsOnFilter(string category, PcComponentsFilter filter)
        {
            switch (category)
            {
                case "Процессоры":
                    return Processors.GetAll(filter);
                case "Материнские платы":
                    return Motherboards.GetAll(filter);
                case "Видеокарты":
                    return VideoCards.GetAll(filter);
                case "Корпуса":
                    return ComputerСases.GetAll(filter);
                case "Модули памяти":
                    return MemoryModules.GetAll(filter);
                case "Блоки питания":
                    return PowerSupplies.GetAll(filter);
                case "SSD диски":
                    return SSDDrives.GetAll(filter);
                default:
                    return null;
            }
        }

        public OrderRepository Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }
        public ComputerСaseRepository ComputerСases
        {
            get
            {
                if (computerСaseRepository == null)
                    computerСaseRepository = new ComputerСaseRepository(db, db.ComputerCases);
                return computerСaseRepository;
            }
        }
        public MemoryModuleRepository MemoryModules
        {
            get
            {
                if (memoryModuleRepository == null)
                    memoryModuleRepository = new MemoryModuleRepository(db, db.MemoryModules);
                return memoryModuleRepository;
            }
        }
        public MotherboardRepository Motherboards
        {
            get
            {
                if (motherboardRepository == null)
                    motherboardRepository = new MotherboardRepository(db, db.Motherboards);
                return motherboardRepository;
            }
        }
        public PowerSupplyRepository PowerSupplies
        {
            get
            {
                if (powerSupplyRepository == null)
                    powerSupplyRepository = new PowerSupplyRepository(db, db.PowerSuppliess);
                return powerSupplyRepository;
            }
        }
        public ProcessorRepository Processors
        {
            get
            {
                if (processorRepository == null)
                    processorRepository = new ProcessorRepository(db, db.Processors);
                return processorRepository;
            }
        }
        public SSDDriveRepository SSDDrives
        {
            get
            {
                if (sSDDriveRepository == null)
                    sSDDriveRepository = new SSDDriveRepository(db, db.SSDDrives);
                return sSDDriveRepository;
            }
        }
        public VideoCardRepository VideoCards
        {
            get
            {
                if (videoCardRepository == null)
                    videoCardRepository = new VideoCardRepository(db, db.VideoCards);
                return videoCardRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
