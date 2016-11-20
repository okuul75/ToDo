using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDo.Domain.Entities;

namespace ToDo.Models
{
    public class ToDoTasksListViewModel
    {
        public IEnumerable<ToDoTask> ToDoTasks { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentState { get; set; }
    }
}