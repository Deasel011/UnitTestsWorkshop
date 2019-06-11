using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Interfaces;
using Models;

[assembly: InternalsVisibleTo("xUnitFakeItEasyTests")]

namespace Logic
{
    public class JuiceService : IJuiceService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public JuiceService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public Juice Create(Recipe recipe)
        {
            var ingredients = recipe.requiredIngredients.Where(x=>x.GetType()==typeof(Fruit)).ToList();
            ingredients.ForEach(x =>
            {
                var expectedQuantity = x.quantity;
                var ingredientName = x.name;
                var availableQuantity = _ingredientRepository.ObtainAvailableQuantity(ingredientName, x.GetType());
                if (expectedQuantity > availableQuantity)
                {
                    throw new NotEnoughIngredientException(ingredientName, expectedQuantity, availableQuantity);
                }
            });

            ingredients.ForEach(x=>_ingredientRepository.RemoveIngredientQuantity(x.name,x.quantity));

            return new Juice {name = recipe.name, ingredients = recipe.requiredIngredients};
        }
    }
}