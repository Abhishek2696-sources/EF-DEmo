using Microsoft.EntityFrameworkCore;
using MVCWebApplication.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCWebApplication.DAL.Interface
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;

        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
        }

        public T Get<T>(int id) where T : class
        {

            return _context.Find<T>(id);
        }

        public T Get<T>(T model) where T : class
        {


            return _context.Find<T>(model);

        }
        private DbSet<T> DbSet<T>() where T : class
        {
            return _context.Set<T>();

        }
        public IEnumerable<T> GetWithRawSqls<T>(string query, params object[] parameters) where T :class
        {
            return DbSet<T>().FromSql(query, parameters).ToList();
        }
        public void Save<T>(T model) where T : class
        {
            var transaction = _context.Database;
            try
            {
                transaction.BeginTransaction();
                DbSet<T>().Add(model);
                _context.Add(model);
                _context.SaveChanges();
                transaction.CommitTransaction();
            }
            catch (Exception)
            {
                transaction.RollbackTransaction();
            }
        }

        public void Update<T>(T entityToUpdate) where T : class
        {
            _context.Update<T>(entityToUpdate);
            _context.SaveChanges();
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void Delete<T>(T id) where T : class
        {
            if (_context.Entry(id).State == EntityState.Detached)
            {
                _context.Remove<T>(id);
            }
        }
        //public void Delete<T>(T id) where T : class
        //{
        //    if (_context.Entry(id).State == EntityState.Detached)
        //    {
        //        _context.Remove<T>(id);
        //    }
        //}

    }
}