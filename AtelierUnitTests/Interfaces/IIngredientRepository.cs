using System;
using Models;

namespace Interfaces
{
    public interface IIngredientRepository
    {
        double ObtainAvailableQuantity(string ingredientName, Type ingredientType);
        double RemoveIngredientQuantity(string ingredientName, Type ingredientType, double ingredientQuantity);
        double AddIngredient(Ingredient ingredient, double quantity);
    }
}
