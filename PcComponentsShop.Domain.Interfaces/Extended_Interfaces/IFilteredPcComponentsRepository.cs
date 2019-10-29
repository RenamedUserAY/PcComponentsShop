using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Domain.Interfaces.Basic_Interfaces;
using System.Collections.Generic;

namespace PcComponentsShop.Domain.Interfaces.Extended_Interfaces
{
    public interface IFilteredPcComponentsRepository<T> : IRepository<T> where T : Good
    {
        IEnumerable<Good> GetAll(IPcComponentsRepositoryFilter repositoryFIlter);
    }
}
