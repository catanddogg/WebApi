using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.Entity;

namespace IllyaVirych.Web.Models
{
    public class TaskItemContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
    }
}