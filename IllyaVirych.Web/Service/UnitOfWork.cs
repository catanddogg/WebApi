using IllyaVirych.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IllyaVirych.Web.Service
{
    public class UnitOfWork : IDisposable
    {
        private TaskItemContext _db = new TaskItemContext();
        private TaskRepository _taskRepository;

        public TaskRepository Tasks
        {
            get
            {
                if(_taskRepository == null)
                {
                    _taskRepository = new TaskRepository(_db);
                }
                return _taskRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;
        
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if(disposing)
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