using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Services.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductItemController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<ProductItemCreateResponse>> Post([FromBody] ProductItemCreateView productItem)
        {
            if (ModelState.IsValid)
            {
                ProductItemCreateResponse objSupplierAdded = await _mediator.Send(new AddProductItemCommand(productItem));
                if (objSupplierAdded == null)
                {
                    return BadRequest();
                }

                return new ActionResult<ProductItemCreateResponse>(objSupplierAdded);
            }
            return BadRequest();
        
        }

        

        // PUT api/<OrderController>/5
        [HttpPut("{productId}")]
        public async Task<ActionResult> PutAsync([FromBody] ProductItemUpdateView productItem)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new UpdateProductItemCommand(productItem));
                return Ok();
            }
            return BadRequest();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
