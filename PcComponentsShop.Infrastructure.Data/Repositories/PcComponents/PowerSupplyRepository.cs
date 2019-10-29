using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Infrastructure.Data.Contexts;
using System.Data.Entity;

namespace PcComponentsShop.Infrastructure.Data.Repositories
{
    public class PowerSupplyRepository : PcComponentsRepository<PowerSupply>
    {
        public PowerSupplyRepository(PcComponentsShopContext context, DbSet<PowerSupply> table)
            : base(context, table)
        { }
    }
}
