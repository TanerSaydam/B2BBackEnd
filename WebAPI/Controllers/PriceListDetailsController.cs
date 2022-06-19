using Business.Repositories.PriceListDetailRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceListDetailsController : ControllerBase
    {
        private readonly IPriceListDetailService _priceListDetailService;

        public PriceListDetailsController(IPriceListDetailService priceListDetailService)
        {
            _priceListDetailService = priceListDetailService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(PriceListDetail priceListDetail)
        {
            var result = await _priceListDetailService.Add(priceListDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(PriceListDetail priceListDetail)
        {
            var result = await _priceListDetailService.Update(priceListDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(PriceListDetail priceListDetail)
        {
            var result = await _priceListDetailService.Delete(priceListDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _priceListDetailService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _priceListDetailService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
