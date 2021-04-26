using Cube.Temperature.Converter.API.Enums;
using Cube.Temperature.Converter.API.ViewModels;
using System.Collections.Generic;

namespace Cube.Temperature.Converter.API.Services.Interfaces
{
    /// <summary>
    /// Provides various temperature conversion functions
    /// </summary>
    public interface ITemperatureConverterService
    {
        /// <summary>
        /// Gets available temperature types to convert to/from
        /// </summary>
        ICollection<SelectOptionViewModel<TemperatureType>> GetTemperatureTypes();

        /// <summary>
        /// Converts provided temperature from source to destination type
        /// </summary>
        double Convert(TemperatureConversionViewModel viewModel);
    }
}
