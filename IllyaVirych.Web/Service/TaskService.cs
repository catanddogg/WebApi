using IllyaVirych.Web.Interface;
using IllyaVirych.Web.Models;
using System;
using System.Collections.Generic;

namespace IllyaVirych.Web.Service
{
    public class TaskService : ITaskService<TaskItem>
    {
        private TaskItemContext _db = new TaskItemContext();
        
        private readonly ITaskRepository _taskRepository;

        public TaskService( ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IEnumerable<TaskItem> GetItem(string id)
        {
            var res = _taskRepository.GetItem(id);
            return res;
        }

        public void Create(TaskItem taskItem)
        {
            _taskRepository.Create(taskItem);
        }

        public void Delete(int id)
        {
            _taskRepository.Delete(id);
        }

        public void Update(TaskItem taskItem)
        {
            _taskRepository.Update(taskItem);
        }
    }
}