using System;
using Interfaces;
using Models;

namespace Logic
{
    public class IngredientRepository: IIngredientRepository
    {
        private IFruitGateway _fruitGateway;
        private ICommonIngredientGateway _ingredientGateway;

        public IngredientRepository(IFruitGateway fruitGateway, ICommonIngredientGateway ingredientGateway)
        {
            _fruitGateway = fruitGateway;
            _ingredientGateway = ingredientGateway;
        }

        public double ObtainAvailableQuantity(string ingredientName, Type ingredientType)
        {
            throw new NotImplementedException();
        }

        public double RemoveIngredientQuantity(string ingredientName, Type ingredientType, double ingredientQuantity)
        {
            throw new NotImplementedException();
        }

        public double AddIngredient(Ingredient ingredient, double quantity)
        {
            throw new NotImplementedException();
        }
    }
}
