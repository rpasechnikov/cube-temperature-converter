using Cube.Temperature.Converter.API.Services.Interfaces;
using Cube.Temperature.Converter.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cube.Temperature.Converter.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureConverterController : Controller
    {
        private ITemperatureConverterService _temperatureConverterService;

        public TemperatureConverterController(ITemperatureConverterService temperatureConverterService)
        {
            _temperatureConverterService = temperatureConverterService;
        }


        [HttpPost("convert")]
        [ProducesResponseType(typeof(double), StatusCodes.Status200OK)]
        public IActionResult ConvertTemperature(TemperatureConversionViewModel viewModel)
        {
            return Ok(_temperatureConverterService.Convert(viewModel));
        }
    }
}
