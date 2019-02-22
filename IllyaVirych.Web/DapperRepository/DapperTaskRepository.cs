using IllyaVirych.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using IllyaVirych.Web.Interface;
using Dapper.Contrib.Extensions;

namespace IllyaVirych.Web.DapperRepository
{
    public class DapperTaskRepository : ITaskRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Context"].ConnectionString;

        public DapperTaskRepository()
        {
        }

        public IEnumerable<TaskItem> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var res = SqlMapperExtensions.GetAll<TaskItem>(db);
                return res;
            }
        }

        public TaskItem GetById(object id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var res = SqlMapperExtensions.Get<TaskItem>(db,id);
                return res;
            }
        }

        public void Create(TaskItem user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                SqlMapperExtensions.Insert(db, user);
            }
        }

        public void Update(TaskItem user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                SqlMapperExtensions.Update(db, user);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var res = SqlMapperExtensions.Get<TaskItem>(db, id);
                if (res != null)
                {
                    SqlMapperExtensions.Delete(db, res);
                }
            }
        }

        public IEnumerable<TaskItem> GetItem(string id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var res = SqlMapperExtensions.GetAll<TaskItem>(db).Where(x => x.UserId == id);
                return res;
            }
        }
    }
}