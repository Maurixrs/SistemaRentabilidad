using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SistemaRentabilidad.Context;

namespace SistemaRentabilidad.Repositories
{
    public abstract class Repository<T>
        where T: class
    {
        public ContextSR db = new ContextSR();

        public IList<T> FindAllE()
        {
            return db.Set<T>().ToList();

        }

        

        public T FindE(int? id)
        {
            return db.Set<T>().Find(id);
        }

        public void AddE(T entidad)
        {
            db.Set<T>().Add(entidad);
            db.SaveChanges();
        }

        public void EditE(T entidad)
        {
            db.Entry(entidad).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteE(int id)
        {
            T entidad = db.Set<T>().Find(id);
            db.Set<T>().Remove(entidad);
            db.SaveChanges();
        }
    }
}