using System.Collections.Generic;
using ToDo.Domain.Abstract;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Concrete
{
    public class EFToDoTaskRepository : IToDoTaskRepository
    {
        private IDbContext context;

        public EFToDoTaskRepository(IDbContext contextParam)
        {
            context = contextParam;
        }

        //private EFDbContext context = new EFDbContext();

        public IEnumerable<ToDoTask> ToDoTasks
        {
            get { return context.ToDoTasks; }
        }

        public void SaveTask(ToDoTask task)
        {
            if(task.TaskID == 0)
            {
                context.ToDoTasks.Add(task);
            }
            else
            {
                ToDoTask dbEntry = context.ToDoTasks.Find(task.TaskID);
                if(dbEntry != null)
                {
                    dbEntry.CreatingDate = task.CreatingDate;
                    dbEntry.RealizationDate = task.RealizationDate;
                    dbEntry.Description = task.Description;
                    dbEntry.RealizationState = task.RealizationState;
                }
            }
            context.SaveChanges();
        }

        public ToDoTask DeleteTask(int taskId)
        {
            ToDoTask dbEntry = context.ToDoTasks.Find(taskId);

            if(dbEntry != null)
            {
                context.ToDoTasks.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
