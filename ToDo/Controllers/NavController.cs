using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.Domain.Abstract;

namespace ToDo.Controllers
{
    public class NavController : Controller
    {
        private IToDoTaskRepository repository;

        public NavController(IToDoTaskRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string state = null)
        {
            ViewBag.SelectedState = state;
            IEnumerable<string> states = repository.ToDoTasks
                .Select(x => x.RealizationState.ToString())
                .Distinct()
                .OrderBy(x => x);
            
            return PartialView(states);
        }
	}
}