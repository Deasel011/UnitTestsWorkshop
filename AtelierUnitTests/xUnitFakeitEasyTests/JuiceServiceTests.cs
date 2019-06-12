using System;
using System.Collections.Generic;
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
            A.CallTo(()=> ingredientRepository.RemoveIngredientQuantity(A<string>.Ignored, A<Type>.Ignored, A<double>.Ignored)).MustHaveHappenedOnceExactly();
            Assert.InRange(juice.ingredients.Count,1,1);
        }

        [Fact]
        public void Given_A_Recipe_And_Unavailable_Fruits_When_I_Create_A_Juice_Then_Not_Enough_Ingredients_Exception_Is_Raised()
        {
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public void Given_A_Recipe_And_Unavailable_Fruits_When_I_Create_A_Juice_Then_No_Fruits_Are_Being_Removed()
        {
            //Arrange
            
            //Act

            //Assert
            
        }

        [Fact]
        public void
            Given_A_Number_Of_Ingredients_In_A_Recipe_When_I_Create_Juice_Then_The_Same_Amount_Of_Ingredients_Is_Being_Removed()
        {
            //Arrange

            //Act

            //Assert
            
        }
    }
}