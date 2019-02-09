using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contingenciamento.DAO
{
    public interface IAcessoDadosObject <T> where T:new()
    {
        T Get<K>(K id);
        List<T> GetTop();
        void Insert(T obj);
        void BulkInsert(HashSet<T> list);
        void Update<K>(K id, T obj);
        void Delete<K>(K id);
    }
}
