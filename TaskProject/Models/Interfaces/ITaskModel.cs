using Microsoft.AspNetCore.Mvc;

namespace TaskProject.Models.Interfaces
{
    public interface ITaskModel
    {
        Task<List<TaskModel>> GetAllTasks();
        Task<TaskModel> GetTaskById(int id);
        Task<TaskModel> PostTask(TaskModel taskModel);
        Task<TaskModel> UpdateTask(int id, TaskModel taskModel);
        Task DeleteTask(int id);
    }
}
