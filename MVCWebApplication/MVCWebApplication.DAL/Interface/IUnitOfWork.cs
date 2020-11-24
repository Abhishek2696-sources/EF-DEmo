using System;
using System.Collections.Generic;
using System.Text;

namespace MVCWebApplication.DAL.Interface
{
    public interface IUnitOfWork
    {
        void Update<T>(T entityToUpdate) where T : class;
        void Save<T>(T model) where T : class;
        void Delete<T>(T id) where T : class;
        T Get<T>(int id) where T : class;
        T Get<T>(T model) where T : class; //added
        IEnumerable<T> GetWithRawSqls<T>(string query, params object[] parameters) where T : class;
        //T Delete<T>(T entity);
        //void Save<T>(T entity);
    }
}

