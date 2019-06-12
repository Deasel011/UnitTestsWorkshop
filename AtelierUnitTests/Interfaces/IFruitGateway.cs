using System.Collections.Generic;
using Models;

namespace Interfaces
{
    public interface IFruitGateway
    {
        List<Fruit> ObtainAvailable();
        double ObtainAvailableQuantity(string fruitName);
        double Remove(string fruitName, double fruitQuantity);
        double Add(Fruit fruit, double quantity);
    }
}
