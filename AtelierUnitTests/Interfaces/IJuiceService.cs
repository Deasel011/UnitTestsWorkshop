using System.Dynamic;
using Models;

namespace Interfaces
{
    public interface IJuiceService
    {
        Juice Create(Recipe recipe);
    }
}
