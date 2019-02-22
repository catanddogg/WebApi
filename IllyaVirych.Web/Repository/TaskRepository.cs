using IllyaVirych.Web.Interface;
using IllyaVirych.Web.Models;
using IllyaVirych.Web.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IllyaVirych.Web.Repository
{
    public class TaskRepository : BaseRepository<TaskItemContext, TaskItem>, ITaskRepository
    {
        private TaskItemContext _dbSet;


         public TaskRepository()
        {
            _dbSet = new TaskItemContext();
        }

        public IEnumerable<TaskItem> GetItem(string id)
        {
            var taskItem = _dbSet.TaskItems.Where(x => x.UserId == id).ToList();
            return taskItem;
        }
    }
}