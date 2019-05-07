using System;
using System.Collections.Generic;

namespace Models
{
    public class Recipe
    {
        public string name { get; set; }
        public Type recipeType { get; set; }
        public List<Ingredient> requiredIngredients { get; set; }
    }
}
