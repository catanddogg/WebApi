using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IllyaVirych.Web
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetItem(string id);
        void CreateItem(T item);
        void DeleteItem(int id);
        void UpdateItem(int id, T item);
    }
}
