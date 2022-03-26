using Microsoft.AspNetCore.Mvc;
using Poc_GraphQL.Application.Models.Request;
using Poc_GraphQL.Application.Models.Response;
using Poc_GraphQL.Application.UseCase;

namespace Poc_GraphQL.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IUseCaseAsyncR<IEnumerable<CustomerResponse>> getAll;
        private readonly IUseCaseAsync<CustomerRequest> insert;


        public CustomerController(IUseCaseAsyncR<IEnumerable<CustomerResponse>> getAll, IUseCaseAsync<CustomerRequest> insert)
        {
            this.getAll = getAll;
            this.insert = insert;
        }

        [HttpGet("get_all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult GetAllCustomers()
        {
            return Ok(getAll.ExecuteAsync());
        }

        [HttpPost("insert")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult InsertCustomer([FromBody] CustomerRequest request)
        {
            return Ok(insert.ExecuteAsync(request));
        }
    }
}
