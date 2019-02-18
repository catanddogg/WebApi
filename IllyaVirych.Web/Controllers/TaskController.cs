using IllyaVirych.Web.Models;
using IllyaVirych.Web.Service;
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
        UnitOfWork unitOfWork;

        public TaskController()
        {
            unitOfWork = new UnitOfWork();
        }

        //[HttpGet]
        // GET api/task/5
        public IEnumerable<TaskItem> GetTaskItem(string id)
        {
            var taskItem = unitOfWork.Tasks.GetItem(id);
            return taskItem;
        }

        [HttpPost]
        // POST api/task
        public void CreateTask([FromBody]TaskItem taskItem)
        {
            unitOfWork.Tasks.CreateItem(taskItem);
        }

        [HttpPut]
        // PUT api/task/5
        public void UpdateTask(int id, [FromBody]TaskItem taskItem)
        {
            unitOfWork.Tasks.UpdateItem(id, taskItem);
        }

        [HttpDelete]
        // DELETE api/task/5
        public void DeleteTask(int id)
        {
            unitOfWork.Tasks.DeleteItem(id);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    unitOfWork.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}
