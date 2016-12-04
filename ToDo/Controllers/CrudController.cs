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
            return View(repository.ToDoTasks
                .OrderBy(p => p.RealizationDate));
        }

        // Crud/Edit
        public ViewResult Edit(int taskId)
        {
            ToDoTask task = repository.ToDoTasks.FirstOrDefault(t => t.TaskID == taskId);
            return View(task);
        }

        // POST: Crud/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ToDoTask task)
        {
            if (string.IsNullOrEmpty(task.Description))
            {
                ModelState.AddModelError("Description", "Uzupełnij opis");
            }
            if (ModelState.IsValidField("RealizationDate") && task.RealizationDate < task.CreatingDate)
            {
                ModelState.AddModelError("RealizationDate", "Data realizacji musi być późniejsza niż utworzenia");
            }

            if (ModelState.IsValid)
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
            return View("Create", new ToDoTask());
        }

        // POST: Crud/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDoTask task)
        {
            if (string.IsNullOrEmpty(task.Description))
            {
                ModelState.AddModelError("Description", "Uzupełnij opis");
            }
            if (ModelState.IsValidField("RealizationDate") && task.RealizationDate < task.CreatingDate)
            {
                ModelState.AddModelError("RealizationDate", "Data realizacji musi być późniejsza niż utworzenia");
            }

            if (ModelState.IsValid)
            {
                repository.SaveTask(task);
                TempData["message"] = string.Format("Zapisano nowe zadanie");
                return RedirectToAction("Index");
            }
            else
            {
                return View(task);
            }
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
