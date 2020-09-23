using InstituteApp.DAL;
using InstituteApp.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstituteApp.Services.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly InstituteContext Context;

        public Repository(InstituteContext context)
        {
            Context = context;
        }

        private void Save() => Context.SaveChanges();
        public void Add(T entity)
        {
            Context.Add(entity);
            Save();

        }

        public int Count(Func<T, bool> predicate)
        {
            return Context.Set<T>().Where(predicate).Count();
        }

        public void Delete(T entity)
        {
            Context.Remove(entity);
            Save();

        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public IEnumerable<T> GetByFiler(Func<T, bool> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Save();
        }
    }
}
