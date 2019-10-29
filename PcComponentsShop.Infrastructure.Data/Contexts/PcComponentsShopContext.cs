using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Infrastructure.Business.Basic_Models;
using System.Data.Entity;

namespace PcComponentsShop.Infrastructure.Data.Contexts
{
    public class PcComponentsShopContext : DbContext
    {
        public DbSet<ComputerCase> ComputerCases { get; set; }
        public DbSet<MemoryModule> MemoryModules { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<PowerSupply> PowerSuppliess { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<SSDDrive> SSDDrives { get; set; }
        public DbSet<VideoCard> VideoCards { get; set; }
        //Business
        public DbSet<Order> Orders { get; set; }
    }
}
