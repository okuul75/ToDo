using System.Collections.Generic;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Abstract
{
    public interface IToDoTaskRepository
    {
        IEnumerable<ToDoTask> ToDoTasks { get; }

        void SaveTask(ToDoTask task);

        ToDoTask DeleteTask(int taskId);
    }
}
