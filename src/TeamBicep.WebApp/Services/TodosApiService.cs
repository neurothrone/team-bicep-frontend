using TeamBicep.WebApp.Models;
using TeamBicep.WebApp.Services.Interface;

namespace TeamBicep.WebApp.Services;

public class TodosApiService(HttpClient httpClient) : ITodosService
{
    private const string TodosEndpoint = "api/todos";

    public async Task<List<TodoItem>> GetAllTodosAsync()
    {
        try
        {
            var response = await httpClient.GetFromJsonAsync<List<TodoItem>>(TodosEndpoint);
            var todos = (response ?? [])
                .ToList();
            return todos;
        }
        catch
        {
            return [];
        }
    }

    public async Task<TodoItem?> AddTodoItemAsync(TodoItem item)
    {
        try
        {
            var dto = new TodoItemDto { Name = item.Name };
            var response = await httpClient.PostAsJsonAsync(TodosEndpoint, dto);
            return response.IsSuccessStatusCode ? item : null;
        }
        catch
        {
            return null;
        }
    }

    public async Task<TodoItem?> UpdateTodoItemAsync(TodoItem todo)
    {
        try
        {
            var response = await httpClient.PutAsJsonAsync($"{TodosEndpoint}/{todo.Id}", todo);
            if (response.IsSuccessStatusCode)
            {
                var updatedTodo = await response.Content.ReadFromJsonAsync<TodoItem>();
                return updatedTodo;
            }

            return null;
        }
        catch
        {
            return null;
        }
    }

    public async Task<bool> DeleteTodoItemAsync(string id)
    {
        try
        {
            var response = await httpClient.DeleteAsync($"{TodosEndpoint}/{id}");
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}