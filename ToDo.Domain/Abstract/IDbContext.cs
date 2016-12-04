using System.Data.Entity;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Abstract
{
    public interface IDbContext
    {
        DbSet<ToDoTask> ToDoTasks { get; set; }

        int SaveChanges();
    }
}
