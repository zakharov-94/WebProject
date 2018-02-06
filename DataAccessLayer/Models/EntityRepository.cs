﻿using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Models
{
    public class EntityRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private ApplicationContext _context;
        private DbSet<TEntity> _dbSet;

        public EntityRepository(string connectionString)
        {
           _context = new ApplicationContext(connectionString);
            _dbSet = _context.Set<TEntity>();
        }

        public EntityRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }
        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }
        public void Remove(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
            _context.SaveChanges();
        }
        public virtual void Update(object item)
        {
            TEntity entity = (TEntity) item;
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
