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
    public class JuiceServiceTests
    {
        [Fact]
        public void Given_A_Recipe_And_Available_Fruits_When_I_Create_A_Juice_Then_It_Is_Correctly_done()
        {
            //Arrange
            var ingredientRepository = A.Fake<IIngredientRepository>();

            A.CallTo(() => ingredientRepository.ObtainAvailableQuantity("apple", typeof(Fruit)))
                .Returns(5);

            var recipe = new Recipe
            {
                name = "Apple Juice",
                recipeType = typeof(Juice),
                requiredIngredients = new List<Ingredient>
                {
                    new Fruit {name = "apple", quantity = 1}
                }
            };
            var juiceService = new JuiceService(ingredientRepository);

            //Act
            var juice = juiceService.Create(recipe);

            //Assert
            A.CallTo(()=> ingredientRepository.RemoveIngredientQuantity(A<string>.Ignored, A<double>.Ignored)).MustHaveHappenedOnceExactly();
            Assert.Equal(1,juice.ingredients.Count);
        }

        [Fact]
        public void Given_A_Recipe_And_UnAvailable_Fruits_When_I_Create_A_Juice_Then_Not_Enough_Ingredients_Exception_Is_Raised()
        {
            //Arrange
            var ingredientRepository = A.Fake<IIngredientRepository>();

            A.CallTo(() => ingredientRepository.ObtainAvailableQuantity("apple", typeof(Fruit)))
                .Returns(4);

            var recipe = new Recipe
            {
                name = "Apple Juice Super Extra Large",
                recipeType = typeof(Juice),
                requiredIngredients = new List<Ingredient>
                {
                    new Fruit {name = "apple", quantity = 5}
                }
            };
            var juiceService = new JuiceService(ingredientRepository);

            //Act
            //Assert
            Assert.Throws<NotEnoughIngredientException>(()=>juiceService.Create(recipe));
            A.CallTo(() => ingredientRepository.RemoveIngredientQuantity(A<string>.Ignored, A<double>.Ignored)).MustNotHaveHappened();
        }
    }
}