using IllyaVirych.Web.Interface;
using IllyaVirych.Web.Models;
using IllyaVirych.Web.Repository;
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
        private ITaskService<TaskItem> _taskService;        

        public TaskController(ITaskService<TaskItem> taskService)
        {
            _taskService = taskService; 
        }

        [HttpGet]
        // GET api/task/5
        public IEnumerable<TaskItem> GetTaskItem(string id)
        {
            var taskItem = _taskService.GetItem(id);
            return taskItem;
        }

        [HttpPost]
        // POST api/task
        public void CreateTask([FromBody]TaskItem taskItem)
        {
            _taskService.Create(taskItem);
        }

        [HttpPut]
        // PUT api/task/5
        public void UpdateTask(int id,[FromBody]TaskItem taskItem)
        {
            _taskService.Update(taskItem);
        }

        [HttpDelete]
        // DELETE api/task/5
        public void DeleteTask(int id)
        {
            _taskService.Delete(id);
        }
    }
}
