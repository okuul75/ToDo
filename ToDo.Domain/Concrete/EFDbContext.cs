using System.Data.Entity;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<ToDoTask> ToDoTasks { get; set; }
    }
}
