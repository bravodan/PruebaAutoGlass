using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Services.Commands;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/<SupplierController>
        [HttpPost]
        public async Task<ActionResult<SupplierView>> Post([FromBody] SupplierView supplier)
        {
            if (ModelState.IsValid)
            {
                SupplierView objSupplierAdded = await _mediator.Send(new AddSupplierCommand(supplier));
                if (objSupplierAdded == null)
                {
                    return BadRequest();
                }
                return new ActionResult<SupplierView>(objSupplierAdded);
            }

            return BadRequest();
        }

    }
}
