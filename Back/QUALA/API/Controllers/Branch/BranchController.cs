using API.Controllers.API;
using Application.Proccess.BranchApplication.Delete;
using Application.Proccess.BranchApplication.GetAll;
using Application.Proccess.BranchApplication.Save;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Branch
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ApiController
    {
        private readonly ISender _mediator;

        public BranchController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SaveBranchCommand command)
        {

            var branchResult = await _mediator.Send(command);

            return branchResult.Match(
                loan => Ok(loan),
                errors => Problem(errors)
            );
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var branchResult = await _mediator.Send(new BranchGetAllquery());

            return branchResult.Match(
                loan => Ok(loan),
                errors => Problem(errors)
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteResult = await _mediator.Send(new DeleteBranchCommand(id));

            return deleteResult.Match(
                customerId => NoContent(),
                errors => Problem(errors)
            );
        }
    }
}
