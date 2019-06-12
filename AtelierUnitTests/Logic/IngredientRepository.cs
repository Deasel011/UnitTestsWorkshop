using System;
using System.Collections.Generic;
using System.Text;
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
            if (ingredientType.IsEquivalentTo(typeof(Fruit)))
            {
               return _fruitGateway.ObtainAvailableQuantity(ingredientName);
            }

            if (ingredientType.IsEquivalentTo(typeof(Ingredient)))
            {
                return _ingredientGateway.ObtainAvailableQuantity(ingredientName);
            }

            throw new IngredientTypeUnknownException();
        }

        public double RemoveIngredientQuantity(string ingredientName, Type ingredientType, double ingredientQuantity)
        {
            if (ingredientType.IsEquivalentTo(typeof(Fruit)))
            {
                return _fruitGateway.Remove(ingredientName,ingredientQuantity);
            }

            if (ingredientType.IsEquivalentTo(typeof(Ingredient)))
            {
                return _ingredientGateway.Remove(ingredientName, ingredientQuantity);
            }

            throw new IngredientTypeUnknownException();
        }

        public double AddIngredient(Ingredient ingredient, double quantity)
        {
            if (ingredient.GetType().IsEquivalentTo(typeof(Fruit)))
            {
                return _fruitGateway.Add((Fruit)ingredient, quantity);
            }

            if (ingredient.GetType().IsEquivalentTo(typeof(Ingredient)))
            {
                return _ingredientGateway.Add(ingredient, quantity);
            }

            throw new IngredientTypeUnknownException();
        }
    }
}
