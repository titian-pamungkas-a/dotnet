using System.Text.Json;

namespace EmptyProject.DTO
{
    public class CreateShoeDTO
    {
        public string Type { get; set; }
        public JsonElement Data { get; set; }
    }
}
