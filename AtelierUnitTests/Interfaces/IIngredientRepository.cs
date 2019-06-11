using System;

namespace Interfaces
{
    public interface IIngredientRepository
    {
        double ObtainAvailableQuantity(string ingredientName, Type ingredientType);
        double RemoveIngredientQuantity(string ingredientName, double ingredientQuantity);
    }
}
