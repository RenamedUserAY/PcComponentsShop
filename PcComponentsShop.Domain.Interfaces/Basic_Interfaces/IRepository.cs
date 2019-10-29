using System.Collections.Generic;

namespace PcComponentsShop.Domain.Interfaces.Basic_Interfaces
{
    public interface IRepository<TElementsType> where TElementsType:class
    {
        IEnumerable<TElementsType> GetAll();
        TElementsType GetElement(int id);
        void Create(TElementsType item);
        void Update(TElementsType item);
        void Delete(int id);
    }
}
