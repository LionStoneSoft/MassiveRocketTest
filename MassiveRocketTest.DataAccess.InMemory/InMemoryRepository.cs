using MassiveRocketTest.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MassiveRocketTest.DataAccess.InMemory
{
    public class InMemoryRepository<P> where P : BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<P> items;
        string className;

        public InMemoryRepository()
        {
            className = typeof(P).Name;
            items = cache[className] as List<P>;
            if (items == null) {
                items = new List<P>();
            }
        }

        public void Commit()
        {
            cache[className] = items;
        }

        public void Insert(P p)
        {
            items.Add(p);
        }

        public void Update(P p)
        {
            P pToUpdate = items.Find(i => i.Id == p.Id);

            if (pToUpdate != null)
            {
                pToUpdate = p;
            } else
            {
                throw new Exception(className + " Not found");
            }
        }

        public P Find(String Id)
        {
            P p = items.Find(i => i.Id == Id);
            if (p != null)
            {
                return p;
            } else
            {
                throw new Exception(className + " Not found");
            }

        }

        public IQueryable<P> Collection()
        {
            return items.AsQueryable();
        }

        public void Delete(string Id)
        {
            P pToDelete = items.Find(i => i.Id == Id);

            if (pToDelete != null)
            {
                items.Remove(pToDelete);
            } else
            {
                throw new Exception(className + " Not found");
            }
        }
    }
}
