using FakeItEasy;
using Interfaces;
using Logic;
using Models;
using Xunit;

namespace xUnitFakeItEasyTests
{
    public class IngredientRepositoryTests
    {
        [Fact]
        public void Given_A_Repository_When_I_Obtain_Ingredient_That_Is_Fruit_Then_The_Fruit_Gateway_Is_Called()
        {
            //Arrange
            var fruitGateway = A.Fake<IFruitGateway>();
            var ingredientGateway = A.Fake<ICommonIngredientGateway>();
            var ingredientRepository = new IngredientRepository(fruitGateway, ingredientGateway);
            //Act
            ingredientRepository.ObtainAvailableQuantity("apple", typeof(Fruit));

            //Assert
            A.CallTo(() => ingredientGateway.ObtainAvailableQuantity(A<string>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => fruitGateway.ObtainAvailableQuantity(A<string>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void Given_A_Repository_When_I_Obtain_An_Ingredient_Then_The_Common_Ingredient_Gateway_Is_Called()
        {
            //Arrange
            var fruitGateway = A.Fake<IFruitGateway>();
            var ingredientGateway = A.Fake<ICommonIngredientGateway>();
            var ingredientRepository = new IngredientRepository(fruitGateway, ingredientGateway);
            //Act
            ingredientRepository.ObtainAvailableQuantity("flour", typeof(Ingredient));

            //Assert
            A.CallTo(() => ingredientGateway.ObtainAvailableQuantity(A<string>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => fruitGateway.ObtainAvailableQuantity(A<string>.Ignored)).MustNotHaveHappened();
        }

        [Fact]
        public void Given_A_Repository_When_I_Obtain_An_Unknown_Ingredient_Type_Then_An_Ingredient_Type_Unknown_Exception_Is_Raised()
        {
            //Arrange
            var fruitGateway = A.Fake<IFruitGateway>();
            var ingredientGateway = A.Fake<ICommonIngredientGateway>();
            var ingredientRepository = new IngredientRepository(fruitGateway, ingredientGateway);
            //Act
            //Assert
            Assert.Throws<IngredientTypeUnknownException>(()=>ingredientRepository.ObtainAvailableQuantity("cooking string", typeof(string)));
        }

        [Fact]
        public void Given_A_Repository_When_I_Remove_Ingredient_That_Is_Fruit_Then_The_Fruit_Gateway_Is_Called()
        {
            //Arrange
            var fruitGateway = A.Fake<IFruitGateway>();
            var ingredientGateway = A.Fake<ICommonIngredientGateway>();
            var ingredientRepository = new IngredientRepository(fruitGateway, ingredientGateway);
            //Act
            ingredientRepository.RemoveIngredientQuantity("apple", typeof(Fruit),1);

            //Assert
            A.CallTo(() => ingredientGateway.Remove(A<string>.Ignored, A<double>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => fruitGateway.Remove(A<string>.Ignored, A<double>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void Given_A_Repository_When_I_Remove_An_Ingredient_Then_The_Common_Ingredient_Gateway_Is_Called()
        {
            //Arrange
            var fruitGateway = A.Fake<IFruitGateway>();
            var ingredientGateway = A.Fake<ICommonIngredientGateway>();
            var ingredientRepository = new IngredientRepository(fruitGateway, ingredientGateway);
            //Act
            ingredientRepository.RemoveIngredientQuantity("flour", typeof(Ingredient),1);

            //Assert
            A.CallTo(() => ingredientGateway.Remove(A<string>.Ignored,A<double>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => fruitGateway.Remove(A<string>.Ignored, A<double>.Ignored)).MustNotHaveHappened();
        }

        [Fact]
        public void Given_A_Repository_When_I_Remove_An_Unknown_Ingredient_Type_Then_An_Ingredient_Type_Unknown_Exception_Is_Raised()
        {
            //Arrange
            var fruitGateway = A.Fake<IFruitGateway>();
            var ingredientGateway = A.Fake<ICommonIngredientGateway>();
            var ingredientRepository = new IngredientRepository(fruitGateway, ingredientGateway);
            //Act
            //Assert
            Assert.Throws<IngredientTypeUnknownException>(() => ingredientRepository.RemoveIngredientQuantity("cooking string", typeof(string), 1));
        }

        [Fact]
        public void Given_A_Repository_When_I_Add_An_Ingredient_That_Is_Fruit_Then_The_Fruit_Gateway_Is_Called()
        {
            //Arrange
            var fruitGateway = A.Fake<IFruitGateway>();
            var ingredientGateway = A.Fake<ICommonIngredientGateway>();
            var ingredientRepository = new IngredientRepository(fruitGateway, ingredientGateway);
            //Act
            ingredientRepository.AddIngredient(new Fruit { name = "apple" }, 1);

            //Assert
            A.CallTo(() => ingredientGateway.Add(A<Ingredient>.Ignored, A<double>.Ignored)).MustNotHaveHappened();
            A.CallTo(() => fruitGateway.Add(A<Fruit>.Ignored, A<double>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public void Given_A_Repository_When_I_Add_An_Ingredient_Then_The_Common_Ingredient_Gateway_Is_Called()
        {
            //Arrange
            var fruitGateway = A.Fake<IFruitGateway>();
            var ingredientGateway = A.Fake<ICommonIngredientGateway>();
            var ingredientRepository = new IngredientRepository(fruitGateway, ingredientGateway);
            //Act
            ingredientRepository.AddIngredient(new Ingredient {name="flour"}, 1);

            //Assert
            A.CallTo(() => ingredientGateway.Add(A<Ingredient>.Ignored, A<double>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => fruitGateway.Add(A<Fruit>.Ignored, A<double>.Ignored)).MustNotHaveHappened();
        }

    }
}
