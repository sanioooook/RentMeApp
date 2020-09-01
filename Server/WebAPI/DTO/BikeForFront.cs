using Entities.Models.Enums;
using System.Text.Json.Serialization;

namespace WebAPI.DTO
{
    public class BikeForFront
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Type Type { get; set; }
        public decimal Price { get; set; }
    }
}