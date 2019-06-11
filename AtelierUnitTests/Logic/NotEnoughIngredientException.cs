using System;

namespace Logic
{
    public class NotEnoughIngredientException : Exception
    {
        public NotEnoughIngredientException(string name, double expectedQuantity, double availableQuantity):base($"{expectedQuantity} {name}s are required for the recipe. Available quantity : {availableQuantity}")
        {
            
        }
    }
}