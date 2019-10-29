using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Infrastructure.Data.Contexts;
using System.Data.Entity;

namespace PcComponentsShop.Infrastructure.Data.Repositories
{
    public class MemoryModuleRepository : PcComponentsRepository<MemoryModule>
    {
        public MemoryModuleRepository(PcComponentsShopContext context, DbSet<MemoryModule> table)
            : base(context, table)
        { }
    }
}
