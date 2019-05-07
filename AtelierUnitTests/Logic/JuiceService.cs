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
        private readonly IFruitGateway _fruitGateway;

        public JuiceService(IFruitGateway fruitGateway)
        {
            _fruitGateway = fruitGateway;
        }

        public Juice Create(Recipe recipe)
        {
            var availableFruits = _fruitGateway.ObtainAvailableFruits();
            var intersectOfFruits = recipe.requiredIngredients.Intersect(availableFruits);

            return null;
        }

        internal bool EnoughAvailableFruitsForRequiredFruits(List<Fruit> availableFruits,
            List<Ingredient> requiredFruits, out List<Fruit> remainingFruits)
        {
            remainingFruits = new List<Fruit>();
            requiredFruits.ForEach(requiredFruit =>
            {
                var fruitToUpdate = findViableFruit(availableFruits, requiredFruit, out var remainingFruit);
                if (fruitToUpdate == null)
                {
                    remainingFruits = availableFruits;
                    return false;
                }
                availableFruits.FirstOrDefault(x =>
                    x.name.Equals(fruitToUpdate.name) && x.color.Equals(fruitToUpdate.color) &&
                    x.texture.Equals(fruitToUpdate.texture)).quantity = fruitToUpdate.quantity;
                if (remainingFruit.quantity > 0)
                {

                }
            });


            return false;
        }

        private Fruit findViableFruit(List<Fruit> availableIngredients, Ingredient requiredIngredient,
            out Ingredient remainingIngredient)
        {
            var fruitToUpdate = availableIngredients.FirstOrDefault(y =>
                y.name.Equals(requiredIngredient.name, StringComparison.InvariantCultureIgnoreCase));
            if (fruitToUpdate != null)
            {
                fruitToUpdate.quantity -= requiredIngredient.quantity;
                if (fruitToUpdate.quantity < 0)
                {
                    remainingIngredient = requiredIngredient;
                    remainingIngredient.quantity += fruitToUpdate.quantity;
                    fruitToUpdate.quantity = 0;
                }

                requiredIngredient.quantity = 0;
                remainingIngredient = requiredIngredient;
                return fruitToUpdate;
            }

            remainingIngredient = requiredIngredient;

            return null;
        }
    }
}