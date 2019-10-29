using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Infrastructure.Data.Contexts;
using System.Data.Entity;

namespace PcComponentsShop.Infrastructure.Data.Repositories
{
    public class ProcessorRepository : PcComponentsRepository<Processor>
    {
        public ProcessorRepository(PcComponentsShopContext context, DbSet<Processor> table)
            : base(context, table)
        { }
    }
}
