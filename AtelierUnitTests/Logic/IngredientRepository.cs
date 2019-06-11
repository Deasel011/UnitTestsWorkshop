using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

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

        public double RemoveIngredientQuantity(string ingredientName, double ingredientQuantity)
        {
            throw new NotImplementedException();
        }
    }
}
