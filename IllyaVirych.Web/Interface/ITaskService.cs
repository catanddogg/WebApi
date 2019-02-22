using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IllyaVirych.Web.Interface
{
    public interface ITaskService
    {
         ITaskRepository Tasks { get;  }
    }
}
