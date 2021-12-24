
namespace WebApplication1.Models.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Country Country { get; set; }
    }
}
