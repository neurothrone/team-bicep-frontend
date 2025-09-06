using System.Text.Json.Serialization;

namespace TeamBicep.WebApp.Models;

public class TodoItemDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("completed")]
    public bool Completed = false;
}