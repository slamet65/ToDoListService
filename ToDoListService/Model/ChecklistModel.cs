using System.Text.Json.Serialization;

namespace ToDoListService.Model
{
    public class ChecklistModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
