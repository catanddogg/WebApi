using IllyaVirych.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IllyaVirych.Web.Interface
{
    public interface ITaskRepository : IBaseRepository<TaskItem>
    {
        IEnumerable<TaskItem> GetItem(string id);
    }
}
