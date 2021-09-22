using Northwind.Data;
using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Logic
{
    public class TerritoriesLogic : BaseLogic, IABMLogic<Territories>
    {
        public List<Territories> GetAll()
        {
            return _context.Territories.ToList();
        }

        public Territories GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Territories newTerritory)
        {
            throw new NotImplementedException();
        }

        public void Update(Territories territory)
        {
            throw new NotImplementedException();
        }

        public void Delete(int territoryId)
        {
            throw new NotImplementedException();
        }
    }
}
