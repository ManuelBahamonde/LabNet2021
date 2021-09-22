using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Logic
{
    public interface IABMLogic<T>
    {
        List<T> GetAll();
        T GetOne(int id);
        void Add(T newEntity);
        void Update(T entity);
        void Delete(int entityId);
    }
}
