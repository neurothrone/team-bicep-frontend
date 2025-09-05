using System.Text.Json.Serialization;

namespace TeamBicep.WebApp.Models;

public class ToDoModel
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("is-completed")]
    public bool IsCompleted { get; set; }
}
