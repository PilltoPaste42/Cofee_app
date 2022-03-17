namespace CoffeeMachine.Web.Controllers
{
    using CoffeeMachine.Core.Dto;
    using CoffeeMachine.Core.Interfaces.Services;

    using Microsoft.AspNetCore.Mvc;

    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        /// <summary>
        ///     Получение всех выполненных заказов
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetAll()
        {
            return Ok(await _service.GetOrdersAsync());
        }

        /// <summary>
        ///     Создание и выполнение заказа
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<MachineBanknoteDto>>> Post([FromBody] OrderCreateDto orderDto)
        {
            return Ok(await _service.CreateOrderAsync(orderDto));
        }
    }
}