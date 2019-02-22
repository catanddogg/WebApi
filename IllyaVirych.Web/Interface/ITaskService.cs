using IllyaVirych.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IllyaVirych.Web.Interface
{
    public interface ITaskService<T> where T : class
    {
        IEnumerable<TaskItem> GetItem(string id);
        void Create(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}
