using System.Collections.Generic;
using Models;

namespace Interfaces
{
    public interface IFruitGateway
    {
        List<Fruit> ObtainAvailableFruits();
    }
}
