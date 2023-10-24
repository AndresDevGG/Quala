using MediatR;
using API.Controllers.API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Proccess.CurrencyApplication.GetCurrencies;

namespace API.Controllers.Currency
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ApiController
    {
        private readonly ISender _mediator;

        public CurrencyController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var currencyResult = await _mediator.Send(new CurrencyGetAllQuery());

            return currencyResult.Match(
                loan => Ok(loan),
                errors => Problem(errors)
            );
        }
    }
}
