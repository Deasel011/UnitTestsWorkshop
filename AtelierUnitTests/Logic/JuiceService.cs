using System;
using System.Runtime.CompilerServices;
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
            throw new NotImplementedException();
        }
    }
}