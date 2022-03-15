namespace CoffeeMachine.Web.Controllers
{
    using CoffeeMachine.Core.Dto;
    using CoffeeMachine.Core.Interfaces.Services;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Контроллер для работы с оплатой
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMachineBanknoteService _service;

        public PaymentController(IMachineBanknoteService service)
        {
            _service = service;
        }

        /// <summary>
        ///     Получение всех банкнот в автомате
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MachineBanknoteDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        /// <summary>
        ///     Добавление множества банкнот
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> PostRange([FromBody] IEnumerable<MachineBanknoteDto> banknotesDto)
        {
            await _service.CreateRangeAsync(banknotesDto);
            return Ok();
        }

        /// <summary>
        ///     Удаление всех банкнот
        /// </summary>
        [HttpDelete]
        public async Task<ActionResult> DeleteAll()
        {
            await _service.CleanAsync();
            return Ok();
        }

        /// <summary>
        ///     Обновление множества банкнот
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> UpdateRange([FromBody] IEnumerable<MachineBanknoteDto> banknotesDto)
        {
            await _service.UpdateRangeAsync(banknotesDto);
            return Ok();
        }
    }
}