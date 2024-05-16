using PizzaStoreManagmentAPI.Models;
using PizzaStoreManagmentAPI.Models.DTO;

namespace PizzaStoreManagmentAPI.Interfaces
{
    public interface IPizzaService
    {
        Task<IList<Pizza>> GetPizzas(PizzaDTO pizzaDTO);
        Task<IList<Pizza>> GetPizzasByName(string name);

    }
}
