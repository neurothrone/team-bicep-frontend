using TeamBicep.WebApp.Models;
using TeamBicep.WebApp.Services.Interface;

namespace TeamBicep.WebApp.Services;

public class ToDoService : IToDo
{
    private readonly HttpClient _httpClient;

    public ToDoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

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

    public async Task<List<ToDoDto>> GetAllToDosAsync()
    {
        //TODO: call to API / backend service to get all ToDo items
        var response = await _httpClient.GetFromJsonAsync<List<ToDoModel>>("api/todo");

        var todos = (response ?? new List<ToDoModel>())
            .Select(item => new ToDoDto { Name = item.Name, IsCompleted = item.IsCompleted })
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
