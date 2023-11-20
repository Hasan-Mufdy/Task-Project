using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskProject.Models;
using TaskProject.Models.Interfaces;

namespace TaskProject.Controllers
{
    public class TaskModelController : Controller
    {
        private readonly ITaskModel _taskModels;

        public TaskModelController(ITaskModel taskModel)
        {
            _taskModels = taskModel;
        }

        public async Task<IActionResult> Index()
        {
            var task = await _taskModels.GetAllTasks();
            return View(task);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TaskModel taskModel)
        {
            if (!ModelState.IsValid)
            {
                return View(taskModel);
            }

            await _taskModels.PostTask(taskModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var taskDetails = await _taskModels.GetTaskById(id);
            return View(taskDetails);
        }

        public async Task<IActionResult> Details(int id)
        {
            var TaskDetails = await _taskModels.GetTaskById(id);
            return View(TaskDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,TaskModel taskModel)
        {
            if (!ModelState.IsValid)
            {
                return View(taskModel);
            }
            await _taskModels.UpdateTask(id, taskModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var taskDetails = await _taskModels.GetTaskById(id);
            return View(taskDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var CategoryDetails = await _taskModels.GetTaskById(id);
            await _taskModels.DeleteTask(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
