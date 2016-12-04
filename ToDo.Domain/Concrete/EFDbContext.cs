using System.Data.Entity;
using System.Diagnostics;
using ToDo.Domain.Entities;
using ToDo.Domain.Abstract;

namespace ToDo.Domain.Concrete
{
    public class EFDbContext : DbContext , IDbContext
    {
        public DbSet<ToDoTask> ToDoTasks { get; set; }

        public EFDbContext()
        {
            this.Database.Log = s=> Debug.WriteLine(s);
        }
    }
}
