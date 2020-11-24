using System;
using System.Collections.Generic;

namespace MVCWebApplication.Query.Generic
{
    public interface IDapperWrapper
    {
        IEnumerable<T> Query<T>(string sql, object param = null, bool buffered = true, int? commandTimeout = null);
        IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null);

        T QueryFirst<T>(string sql, object param = null, int? commandTimeout = null);
        T QueryFirstOrDefault<T>(string sql, object param = null, int? commandTimeout = null);

    }
}
