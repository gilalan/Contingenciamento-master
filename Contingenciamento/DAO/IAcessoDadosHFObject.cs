using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contingenciamento.DAO
{
    public interface IAcessoDadosHFObject<T> where T : new()
    {
        T Get<K>(K id);
        List<T> GetTop();
        void Insert(T obj);
        void BulkInsert(List<T> list);
        void Update<K>(K id, T obj);
        void Delete<K>(K id);
    }
}
