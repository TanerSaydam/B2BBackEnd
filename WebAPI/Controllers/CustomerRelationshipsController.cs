using Business.Repositories.CustomerRelationshipRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRelationshipsController : ControllerBase
    {
        private readonly ICustomerRelationshipService _customerRelationshipService;

        public CustomerRelationshipsController(ICustomerRelationshipService customerRelationshipService)
        {
            _customerRelationshipService = customerRelationshipService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(CustomerRelationship customerRelationship)
        {
            var result = await _customerRelationshipService.Add(customerRelationship);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(CustomerRelationship customerRelationship)
        {
            var result = await _customerRelationshipService.Update(customerRelationship);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(CustomerRelationship customerRelationship)
        {
            var result = await _customerRelationshipService.Delete(customerRelationship);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _customerRelationshipService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _customerRelationshipService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
