using System.Linq;
using System.Web.Mvc;
using ToDo.Domain.Abstract;
using ToDo.Domain.Entities;

namespace ToDo.Controllers
{
    public class CrudController : Controller
    {
        private IToDoTaskRepository repository;

        public CrudController(IToDoTaskRepository repo)
        {
            repository = repo;
        }
        
        public ViewResult Index()
        {
            return View(repository.ToDoTasks);
        }

        // Crud/Edit
        public ViewResult Edit(int taskId)
        {
            ToDoTask task = repository.ToDoTasks.FirstOrDefault(t => t.TaskID == taskId);
            return View(task);
        }

        // POST: Crud/Edit
        [HttpPost]
        public ActionResult Edit(ToDoTask task)
        {
            if(ModelState.IsValid)
            {
                repository.SaveTask(task);
                TempData["message"] = string.Format("Zapisano zadanie");
                return RedirectToAction("Index");
            }
            else
            {
                return View(task);
            }
        }

        // Crud/Create
        public ViewResult Create()
        {
            return View("Edit", new ToDoTask());
        }

        // POST: Crud/Delete
        [HttpPost]
        public ActionResult Delete(int taskId)
        {
            ToDoTask deletedTask = repository.DeleteTask(taskId);
            if(deletedTask != null)
            {
                TempData["message"] = string.Format("Usunięto zadanie");
            }

            return RedirectToAction("Index");
        }
    }
}
