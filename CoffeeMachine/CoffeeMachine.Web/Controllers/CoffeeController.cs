namespace CoffeeMachine.Web.Controllers
{
    using CoffeeMachine.Core.Dto;
    using CoffeeMachine.Core.Interfaces.Services;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Контроллер для работы с кофе
    /// </summary>
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeService _service;

        public CoffeeController(ICoffeeService service)
        {
            _service = service;
        }

        /// <summary>
        ///     Удаление позиции кофе
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

        /// <summary>
        ///     Получение позиции кофе
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<CoffeeDto>> Get(int id)
        {
            return Ok(await _service.GetAsync(id));
        }

        /// <summary>
        ///     Получение всех позиций кофе
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoffeeDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        /// <summary>
        ///     Добавление новой позиции кофе
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CoffeeDto coffeeDto)
        {
            await _service.CreateAsync(coffeeDto);
            return Ok();
        }

        /// <summary>
        ///     Обновление существующей позиции кофе
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CoffeeDto coffeeDto)
        {
            await _service.UpdateAsync(coffeeDto);
            return Ok();
        }
    }
}