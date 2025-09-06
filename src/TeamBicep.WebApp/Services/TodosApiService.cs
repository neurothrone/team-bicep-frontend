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

    public async Task<TodoItem?> AddTodoItemAsync(InputTodoItem item)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync(TodosEndpoint, item);
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<TodoItem>();
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
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<TodoItem>();
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