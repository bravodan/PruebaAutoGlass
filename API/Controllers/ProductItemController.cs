using Domain.QueryParams;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Newtonsoft.Json;
using Services.Commands;
using Services.Queries;
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
        public async Task<IActionResult> GetAsync([FromQuery] ProductItemParameters parameters)
        {
            if (!parameters.MaxManufacturingYear.Equals(0) && !parameters.MinManufacturingYear.Equals(0))
            {
                if (!parameters.getValidDateRange())
                {
                    return BadRequest("La fecha máxima de fabricación es mayor a la fecha mínima");
                }
            }

            var products = await _mediator.Send(new GetAllProductItemsQuery(parameters));
            var metadata = new
            {
                products.TotalCount,
                products.PageSize,
                products.CurrentPage,
                products.TotalPages,
                products.HasNext,
                products.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(products);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductItemGetResponse>> Get(int id)
        {
            if (ModelState.IsValid)
            {
                ProductItemGetResponse objSupplierAdded = await _mediator.Send(new GetProductItemQuery(id));
                if (objSupplierAdded == null)
                {
                    return BadRequest();
                }

                return new ActionResult<ProductItemGetResponse>(objSupplierAdded);
            }
            return BadRequest();
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

        // PUT api/<OrderController>
        [HttpPut]
        public async Task<ActionResult> PutAsync([FromBody] ProductItemUpdateView productItem)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new UpdateProductItemCommand(productItem));
                return Ok();
            }
            return BadRequest();
        }

        // DELETE api/<OrderController>
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new DeleteProductItemCommand(id));
                return Ok();
            }
            return BadRequest();
        }
    }
}
