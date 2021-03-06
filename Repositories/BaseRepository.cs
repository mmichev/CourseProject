﻿using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {

        protected GamesDBEntities Context;

        public BaseRepository()
            : this(new GamesDBEntities())
        {
        }

        public BaseRepository(GamesDBEntities context)
        {
            Context = context;
        }

        protected DbSet<T> DBSet
        {
            get
            {
                return Context.Set<T>();
            }
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
        public T GetByID(int id)
        {
            return Context.Set<T>().Find(id);
        }
        public void Create(T item)
        {
            Context.Set<T>().Add(item);
            Context.SaveChanges();
        }
        public void Update(T item, Func<T, bool> findByIDPredecate)
        {
            var local = Context.Set<T>()
                         .Local
                         .FirstOrDefault(findByIDPredecate);
            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }
            Context.Entry(item).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete(T obj)
        {
            if (obj != null)
            {
                Context.Set<T>().Remove(obj);
            }
            Context.SaveChanges();
        }

        public void DeleteByID(int id)
        {
            T dbItem = Context.Set<T>().Find(id);
            if (dbItem != null)
            {
                Context.Set<T>().Remove(dbItem);
            }
            Context.SaveChanges();
        }

        public abstract void Save(T item);
    }
}
