using IllyaVirych.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IllyaVirych.Web.Service
{
    public class TaskRepository: IRepository<TaskItem>
    {
        private TaskItemContext _db;

        public TaskRepository(TaskItemContext db)
        {
            _db = db;
        }

        public void CreateItem(TaskItem item)
        {
            _db.TaskItems.Add(item);
            _db.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            TaskItem taskItem = _db.TaskItems.Find(id);
            if (taskItem != null)
            {
                _db.TaskItems.Remove(taskItem);
                _db.SaveChanges();
            }
        }

        public void UpdateItem(int id, TaskItem item)
        {
            if (id == item.Id)
            {
                _db.Entry(item).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public IEnumerable<TaskItem> GetItem(string id)
        {
            var taskItem = _db.TaskItems.Where(x => x.UserId == id).ToList();
            return taskItem;
        }
    }
}