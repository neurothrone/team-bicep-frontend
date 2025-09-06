using TeamBicep.WebApp.Models;

namespace TeamBicep.WebApp.Services.Interface;

public interface ITodosService
{
    Task<List<TodoItem>> GetAllTodosAsync();
    Task<TodoItem?> AddTodoItemAsync(TodoItem item);
    Task<TodoItem?> UpdateTodoItemAsync(TodoItem item);
    Task<bool> DeleteTodoItemAsync(string id);
}