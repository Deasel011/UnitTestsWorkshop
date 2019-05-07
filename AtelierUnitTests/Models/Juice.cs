using System.Collections.Generic;

namespace Models
{
    public class Juice
    {
        public string color { get; set; }
        public string name { get; set; }
        public List<Ingredient> ingredients { get; set; }
    }
}