using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Infrastructure.Data.Contexts;
using System.Data.Entity;

namespace PcComponentsShop.Infrastructure.Data.Repositories
{
    public class MotherboardRepository : PcComponentsRepository<Motherboard>
    {
        public MotherboardRepository(PcComponentsShopContext context, DbSet<Motherboard> table)
            : base(context, table)
        { }
    }
}
