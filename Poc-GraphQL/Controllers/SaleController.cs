using Microsoft.AspNetCore.Mvc;
using Poc_GraphQL.Application.Models.Request;
using Poc_GraphQL.Application.UseCase;

namespace Poc_GraphQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly IUseCaseAsync<SaleRequest> insert;

        public SaleController(IUseCaseAsync<SaleRequest> insert)
        {
            this.insert = insert;
        }


        [HttpPost("insert")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult InsertSale([FromBody] SaleRequest request)
        {
            return Ok(insert.ExecuteAsync(request));
        }

    }
}
