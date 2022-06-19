using Business.Repositories.PriceListRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceListsController : ControllerBase
    {
        private readonly IPriceListService _priceListService;

        public PriceListsController(IPriceListService priceListService)
        {
            _priceListService = priceListService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(PriceList priceList)
        {
            var result = await _priceListService.Add(priceList);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(PriceList priceList)
        {
            var result = await _priceListService.Update(priceList);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(PriceList priceList)
        {
            var result = await _priceListService.Delete(priceList);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _priceListService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _priceListService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
