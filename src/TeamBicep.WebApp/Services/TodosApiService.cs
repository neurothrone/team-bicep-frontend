using TeamBicep.WebApp.Models;
using TeamBicep.WebApp.Services.Interface;

namespace TeamBicep.WebApp.Services;

public class TodosApiService(HttpClient httpClient) : ITodosService
{
    //public async Task<ToDoModel> CreateToDoAsync(ToDoModel toDo)
    //{
    //    //TODO: call to API / backend service to create a new ToDo item


    //    //throw new NotImplementedException(); // <-- Remove this line when implemented
    //}

    //public async Task<bool> IToDo.DeleteToDoAsync(int id)
    //{
    //    //TODO: call to API / backend service to delete a ToDo item by id
    //    throw new NotImplementedException();// <-- Remove this line when implemented

    //}

    public async Task<List<TodoItemDto>> GetAllTodosAsync()
    {
        var response = await httpClient.GetFromJsonAsync<List<TodoItem>>("api/todos");
        var todos = (response ?? [])
            .Select(item => new TodoItemDto { Name = item.Name, Completed = item.Completed })
            .ToList();
        return todos;
    }

    //public async Task<ToDoModel?> IToDo.GetToDoByIdAsync(int id)
    //{
    //    // TODO: call to API / backend service to get a ToDo item by id

    //    throw new NotImplementedException(); // <-- Remove this line when implemented
    //}

    //public async Task<ToDoModel?> IToDo.UpdateToDoAsync(int id, ToDoModel toDo)
    //{
    //    //TODO: call to API / backend service to update a ToDo item by id
    //    throw new NotImplementedException();
    //}
}