using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Domain.Interfaces.Extended_Interfaces;
using PcComponentsShop.Infrastructure.Data.Contexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PcComponentsShop.Infrastructure.Data.Repositories
{
    public abstract class PcComponentsRepository<T> : IFilteredPcComponentsRepository<T> where T:Good
    {
        protected PcComponentsShopContext db;
        protected DbSet<T> table;

        public PcComponentsRepository(PcComponentsShopContext context, DbSet<T> table)
        {
            this.db = context;
            this.table = table;
        }
        public virtual void Create(T item)
        {
            table.Add(item);
        }

        public virtual void Delete(int id)
        {
            T item = table.Find(id);
            if (item != null)
                table.Remove(item);
        }

        public virtual T GetElement(int id)
        {
            return table.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return table;
        }
        public virtual IEnumerable<Good> GetAll(IPcComponentsRepositoryFilter repositoryFIlter)
        {
            return repositoryFIlter.ExecuteAndReturn(table);
        }
        //https://patrickdesjardins.com/blog/entity-framework-ef-modifying-an-instance-that-is-already-in-the-context
        public virtual void Update(T item)
        {
            var local = db.Set<T>()
                         .Local
                         .FirstOrDefault(f => f.ID == item.ID);
            if (local != null)
            {
                db.Entry(local).State = EntityState.Detached;
            }
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
