﻿using System.Linq;
using System.Web.Mvc;
using ToDo.Domain.Abstract;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class ToDoTaskController : Controller
    {
        private IToDoTaskRepository repository;
        public int PageSize = 4;

        public ToDoTaskController(IToDoTaskRepository toDoTaskRepository)
        {
           repository = toDoTaskRepository;
        }

        public ViewResult List(string state, int page = 1)
        {
            ToDoTasksListViewModel model = new ToDoTasksListViewModel
            {
                ToDoTasks = repository.ToDoTasks
                    .Where(p => state == null || p.RealizationState.ToString() == state)
                    .OrderBy(p => p.RealizationDate)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = state == null ?
                            repository.ToDoTasks.Count() :
                            repository.ToDoTasks.Where(s => s.RealizationState.ToString() == state).Count()
                    },
                    CurrentState = state
            };
            
            return View(model);
        }
	}
}