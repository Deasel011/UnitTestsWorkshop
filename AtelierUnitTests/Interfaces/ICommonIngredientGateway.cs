using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Interfaces
{
    public interface ICommonIngredientGateway
    {
        List<Ingredient> ObtainAvailable();
        double ObtainAvailableQuantity(string ingredientName);
        double Remove(string ingredientName, double ingredientQuantity);
        double Add(Ingredient ingredient, double quantity);
    }
}
