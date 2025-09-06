using TeamBicep.WebApp.Models;

namespace TeamBicep.WebApp.Services.Interface;

public interface ITodosService
{
    Task<List<TodoItemDto>> GetAllTodosAsync();
    //Task<Models.ToDoModel?> GetToDoByIdAsync(int id);
    //Task<Models.ToDoModel> CreateToDoAsync(Models.ToDoModel toDo);
    //Task<Models.ToDoModel?> UpdateToDoAsync(int id, Models.ToDoModel toDo);
    //Task<bool> DeleteToDoAsync(int id);
}