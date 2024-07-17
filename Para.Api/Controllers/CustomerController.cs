using Microsoft.AspNetCore.Mvc;
using Para.Data.Domain;
using Para.Data.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Para.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            var customers = await _unitOfWork.Repository<Customer>().GetAll();
            return Ok(customers);
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<Customer>> Get(long customerId)
        {
            var customer = await _unitOfWork.Repository<Customer>().GetById(customerId);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Post([FromBody] Customer value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (value.CustomerAddresses == null)
            {
                value.CustomerAddresses = new List<CustomerAddress>();
            }

            if (value.CustomerPhones == null)
            {
                value.CustomerPhones = new List<CustomerPhone>();
            }

            if (value.CustomerDetail == null)
            {
                value.CustomerDetail = new CustomerDetail();
            }

            value.CustomerDetail.Customer = value;

            await _unitOfWork.Repository<Customer>().Insert(value);
            await _unitOfWork.Complete();
            return CreatedAtAction(nameof(Get), new { customerId = value.Id }, value);
        }

        [HttpPut("{customerId}")]
        public async Task<ActionResult> Put(long customerId, [FromBody] Customer value)
        {
            if (customerId != value.Id)
                return BadRequest("Customer ID mismatch");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            value.CustomerDetail.Customer = value;

            _unitOfWork.Repository<Customer>().Update(value);
            await _unitOfWork.Complete();
            return NoContent();
        }

        [HttpDelete("{customerId}")]
        public async Task<ActionResult> Delete(long customerId)
        {
            var customer = await _unitOfWork.Repository<Customer>().GetById(customerId);
            if (customer == null)
                return NotFound();

            await _unitOfWork.Repository<Customer>().Delete(customerId);
            await _unitOfWork.Complete();
            return NoContent();
        }
    }
}
