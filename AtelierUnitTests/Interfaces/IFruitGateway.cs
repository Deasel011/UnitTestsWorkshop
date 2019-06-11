using System.Collections.Generic;
using Models;

namespace Interfaces
{
    public interface IFruitGateway
    {
        List<Fruit> ObtainAvailableFruits();
        double ObtainAvailableQuantityOfFruit(string fruitName);
        double RemoveFruit(string fruitName, double fruitQuantity);
    }
}
