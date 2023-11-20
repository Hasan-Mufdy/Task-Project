using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskProject.Data;
using TaskProject.Models.Interfaces;

namespace TaskProject.Models.Services
{
    public class TaskModelService : ITaskModel
    {
        private readonly AppDbContext _context;
        public TaskModelService(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteTask(int id)
        {
            var task = await _context.Tasks.SingleOrDefaultAsync(t=> t.TaskModelId == id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
            var task = await _context.Tasks.Where(t => t.TaskModelId == id).SingleOrDefaultAsync();
            return task;
        }

        public async Task<TaskModel> PostTask(TaskModel taskModel)
        {
            var task = new TaskModel()
            {
                TaskModelName = taskModel.TaskModelName,
                TaskModelDescription = taskModel.TaskModelDescription
            };

            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<TaskModel> UpdateTask(int id, TaskModel updatedTaskModel)
        {
            var existingTask = await _context.Tasks.FindAsync(id);

            if (existingTask == null)
            {
                return null;
            }

            existingTask.TaskModelName = updatedTaskModel.TaskModelName;
            existingTask.TaskModelDescription = updatedTaskModel.TaskModelDescription;

            _context.Update(existingTask);
            await _context.SaveChangesAsync();

            return existingTask;
        }
    }
}
