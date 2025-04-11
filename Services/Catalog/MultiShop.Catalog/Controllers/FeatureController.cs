
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Services.FeatureServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureServices _featureServices;
        public FeatureController(IFeatureServices FeatureServices)
        {
            _featureServices = FeatureServices;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _featureServices.GetAllFeatureAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(string id)
        {
            var value = await _featureServices.GetByIdFeatureAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureServices.CreateFeatureAsync(createFeatureDto);
            return Ok("Öne çıkan alan başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureServices.DeleteFeatureAsync(id);
            return Ok("Öne çıkan alan başarılı bir şekilde silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureServices.UpdateFeatureAsync(updateFeatureDto);
            return Ok("Öne çıkan alan başarılı bir şekilde güncellendi.");
        }
    }
}
