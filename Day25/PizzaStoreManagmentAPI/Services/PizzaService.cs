using PizzaStoreManagmentAPI.Exceptions;
using PizzaStoreManagmentAPI.Interfaces;
using PizzaStoreManagmentAPI.Models.DTO;
using PizzaStoreManagmentAPI.Models;

namespace PizzaStoreManagmentAPI.Services
{

        public class PizzaService : IPizzaService
        {
            private readonly IRepository<int, Pizza> _pizza;
            public PizzaService(IRepository<int, Pizza> pizzaRepo)
            {
                _pizza = pizzaRepo;
            }

            public async Task<IList<Pizza>> GetPizzas(PizzaDTO pizzaDTO)
            {
                var pizzas = await _pizza.Get();
                var inStockPizzas = pizzas.Where(p => p.Availability == pizzaDTO.Availability).ToList();

                if (inStockPizzas.Any())
                {
                    return inStockPizzas;
                }

                throw new EmptyListException("Pizza");
            }

            public async Task<IList<Pizza>> GetPizzasByName(string pizzaName)
            {
                var pizzas = await _pizza.Get();
                var pizzaAvailable = pizzas.Where(p => p.Name == pizzaName).ToList();

                if (pizzaAvailable.Any())
                {
                    return pizzaAvailable;
                }

                throw new EmptyListException("Pizza");
            }

        }
    }

