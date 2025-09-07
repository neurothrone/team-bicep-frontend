using System.Text.Json.Serialization;

namespace TeamBicep.WebApp.Models;

public class InputTodoItem
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("completed")]
    public bool Completed = false;
}