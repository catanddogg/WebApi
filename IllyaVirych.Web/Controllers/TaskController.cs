using IllyaVirych.Web.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IllyaVirych.Web.Controllers
{
    public class TaskController : ApiController
    {
        TaskItemContext db = new TaskItemContext(); 
        // GET api/values
        public IEnumerable<TaskItem> GetTaskItems()
        {
            return db.TaskItems;
        }

        ObservableCollection<TaskItem> Items = new ObservableCollection<TaskItem>
            {
                new TaskItem { Id = 1, NameTask = "Illya", DescriptionTask = "Go", StatusTask = true, LalitudeMarker = 40, LongitudeMarker = 40, UserId = "101010"}
            };


        // GET api/task/5
        public TaskItem GetTaskItem(string userId)
        {
            ObservableCollection<TaskItem> Items = new ObservableCollection<TaskItem>
            {
                new TaskItem { Id = 1, NameTask = "Illya", DescriptionTask = "Go", StatusTask = true, LalitudeMarker = 40, LongitudeMarker = 40, UserId = "101010"}
            };
            db.TaskItems.AddRange(Items);
            db.SaveChanges();
            var product = Items.FirstOrDefault((p) => p.UserId == userId);
            if (product == null)
            {
                return null;
            }
            //TaskItem taskItem = db.TaskItems.Find(userId);
            return product;
          
        }

        [HttpPost]
        // POST api/task
        public void CreateTask([FromBody]TaskItem taskItem)
        {

            db.TaskItems.Add(taskItem);
            db.SaveChanges();
        }

        [HttpPut]
        // PUT api/values/5
        public void EditTask(int id, [FromBody]TaskItem taskItem)
        {
            if(id == taskItem.Id)
            {
                db.Entry(taskItem).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        [HttpDelete]
        // DELETE api/values/5
        public void DeleteTask(int id)
        {
            TaskItem taskItem = db.TaskItems.Find(id);
            if(taskItem != null)
            {
                db.TaskItems.Remove(taskItem);
                db.SaveChanges();
            }
        }
    }
}
