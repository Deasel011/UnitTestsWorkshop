using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Castle.Components.DictionaryAdapter;
using FakeItEasy;
using Interfaces;
using Logic;
using Models;
using Xunit;

namespace xUnitFakeItEasyTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Remaining_Fruits_Out_Variable_After_Condition_Method_Is_Exact()
        {
            //Arrange
            var fruitGateway = A.Fake<IFruitGateway>();
            A.CallTo(() => fruitGateway.ObtainAvailableFruits()).Returns(new List<Fruit>
            {
                new Fruit {color = "red", name = "apple", quantity = 4, texture = "crunchy"},
                new Fruit {color = "yellow", name = "pineapple", quantity = 1, texture = "soft"},
                new Fruit {color = "yellow", name = "pear", quantity = 4, texture = "crunchy"}
            });
            var recipe = new Recipe
            {
                name = "Super Apple juice", recipeType = typeof(Juice),
                requiredIngredients = new List<Ingredient>(new List<Ingredient>
                {
                    new Fruit {name = "apple", quantity = 1},
                    new Fruit {name = "pineapple", quantity = 0.25}
                })
            };
            var juiceService = new JuiceService(fruitGateway);

            //Act
            var enoughAvailableFruits = juiceService.EnoughAvailableFruitsForRequiredFruits(fruitGateway.ObtainAvailableFruits(),
                recipe.requiredIngredients, out var remainingFruits);

            //Assert
            Assert.True(enoughAvailableFruits);
            Assert.Equal(0.75,
                remainingFruits
                    .FirstOrDefault(x => x.name.Equals("pineapple", StringComparison.InvariantCultureIgnoreCase))
                    .quantity);
            Assert.Equal(3,
                remainingFruits
                    .FirstOrDefault(x => x.name.Equals("apple", StringComparison.InvariantCultureIgnoreCase))
                    .quantity);
            Assert.Equal(4,
                remainingFruits
                    .FirstOrDefault(x => x.name.Equals("pear", StringComparison.InvariantCultureIgnoreCase))
                    .quantity);
        }
    }
}