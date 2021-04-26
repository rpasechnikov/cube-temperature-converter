using Cube.Temperature.Converter.API.ViewModels;

namespace Cube.Temperature.Converter.API.Services.Interfaces
{
    /// <summary>
    /// Provides various temperature conversion functions
    /// </summary>
    public interface ITemperatureConverterService
    {
        /// <summary>
        /// Converts provided temperature from source to destination type
        /// </summary>
        double Convert(TemperatureConversionViewModel viewModel);
    }
}
