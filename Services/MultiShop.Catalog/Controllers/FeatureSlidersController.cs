using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderServices _FeatureSliderServices;
        public FeatureSlidersController(IFeatureSliderServices featureSliderServices)
        {
            _FeatureSliderServices = featureSliderServices;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureSliderList()
        {
            var values = await _FeatureSliderServices.GetAllFeatureSliderAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureSliderById(string id)
        {
            var value = await _FeatureSliderServices.GetByIdFeatureSliderAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _FeatureSliderServices.CreateFeatureSliderAsync(createFeatureSliderDto);
            return Ok("Öne çıkan görsel başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _FeatureSliderServices.DeleteFeatureSliderAsync(id);
            return Ok("Öne çıkan görsel başarılı bir şekilde silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _FeatureSliderServices.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return Ok("Öne çıkan görsel başarılı bir şekilde güncellendi.");
        }
    }
}
