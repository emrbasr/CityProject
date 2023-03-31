using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public void Delete(T entity)
        {
            using (var context = new SqlDbContext())
            {

                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public T GetSehirById(int id)
        {
            using (var context = new SqlDbContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public List<T> GetList()
        {
            using (var context = new SqlDbContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public void Insert(T entity)
        {
            using (var context = new SqlDbContext())
            {
                context.Add(entity);
                context.SaveChanges();
                
            }
            
        }

        public void Update(T entity)
        {
            using (var context = new SqlDbContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

       
    }
}
