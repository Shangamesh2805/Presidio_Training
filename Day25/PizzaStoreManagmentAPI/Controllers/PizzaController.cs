using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStoreManagmentAPI.Interfaces;
using PizzaStoreManagmentAPI.Models.DTO;
using PizzaStoreManagmentAPI.Models;
using PizzaStoreManagmentAPI.Exceptions;

namespace PizzaStoreManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
            IPizzaService _pizzaService;

            public PizzaController(IPizzaService pizzaService)
            {
                _pizzaService = pizzaService;
            }
            [Route("/GetAvailablePizza")]
            [HttpPost]
            [ProducesResponseType(typeof(Pizza), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<IList<Pizza>>> GetPizza(PizzaDTO pizzaDTO)
            {
                try
                {
                    var pizzasInStock = await _pizzaService.GetPizzas(pizzaDTO);
                    return Ok(pizzasInStock.ToList());

                }
                catch (EmptyListException ele)
                {

                    return BadRequest(new Error(501, ele.Message));

                }
            }

            [Route("/GetPizzaByName")]
            [HttpGet]
            [ProducesResponseType(typeof(Pizza), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<IList<Pizza>>> GetPizzaByName(string name)
            {
                try
                {
                    var pizzasInStock = await _pizzaService.GetPizzasByName(name);
                    return Ok(pizzasInStock.ToList());

                }
                catch (EmptyListException ele)
                {

                    return BadRequest(new Error(501, ele.Message));

                }


            }
        }

    }

