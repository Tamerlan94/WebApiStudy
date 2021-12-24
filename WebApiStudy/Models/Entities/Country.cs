using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Models.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }

        public Country()
        {
            Cities = new List<City>();
        }
    }
}
