using IllyaVirych.Web.Interface;
using IllyaVirych.Web.Models;
using System;

namespace IllyaVirych.Web.Service
{
    public class TaskService : IDisposable, ITaskService
    {
        private TaskItemContext _db = new TaskItemContext();
        
        private bool disposed = false;
        
        private readonly ITaskRepository _taskRepository;

        public TaskService( ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public ITaskRepository Tasks
        {
            get
            {
                return _taskRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}