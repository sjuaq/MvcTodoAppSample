using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCTodoAppSample.Models
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Task> Tasks { get; set; }
    }
}