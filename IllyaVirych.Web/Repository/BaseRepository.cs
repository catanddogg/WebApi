using IllyaVirych.Web.Interface;
using IllyaVirych.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IllyaVirych.Web.Repository
{
    public class BaseRepository <C,T> : IBaseRepository <T> where T : class where C 
        : TaskItemContext, new()
    {

        private C _entities = new C();
        public C Context
        {
            get
            {
                return _entities;
            }
            set
            {
                _entities = value;
            }
        }
        private DbSet<T> _dbSet;

        public BaseRepository()
        {
            _dbSet = _entities.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _entities.Set<T>();
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Create(T entity)
        {
            _dbSet.Add(entity);
            _entities.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            T taskItem = _dbSet.Find(id);
            if (taskItem != null)
            {
                _dbSet.Remove(taskItem);
                _entities.SaveChanges();
            }
        }

        public virtual void Update(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
            _entities.SaveChanges();
        }
    }
}