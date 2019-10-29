using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Infrastructure.Data.Contexts;
using System.Data.Entity;

namespace PcComponentsShop.Infrastructure.Data.Repositories
{
    public class VideoCardRepository : PcComponentsRepository<VideoCard>
    {
        public VideoCardRepository(PcComponentsShopContext context, DbSet<VideoCard> table)
            : base(context, table)
        { }
    }
}