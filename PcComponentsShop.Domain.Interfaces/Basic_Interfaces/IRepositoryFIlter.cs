using System.Collections.Generic;
using System.Linq;

namespace PcComponentsShop.Domain.Interfaces.Basic_Interfaces
{
    public interface IRepositoryFIlter<TElementsType> where TElementsType:class
    {
        IEnumerable<TElementsType> ExecuteAndReturn(IQueryable<TElementsType> elelments);
    }
}
