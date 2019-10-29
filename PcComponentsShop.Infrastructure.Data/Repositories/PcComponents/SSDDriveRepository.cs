using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Infrastructure.Data.Contexts;
using System.Data.Entity;

namespace PcComponentsShop.Infrastructure.Data.Repositories
{
    public class SSDDriveRepository : PcComponentsRepository<SSDDrive>
    {
        public SSDDriveRepository(PcComponentsShopContext context, DbSet<SSDDrive> table)
            : base(context, table)
        { }
    }
}