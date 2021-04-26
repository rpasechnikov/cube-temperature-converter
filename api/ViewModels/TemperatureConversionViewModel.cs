using Cube.Temperature.Converter.API.Enums;

namespace Cube.Temperature.Converter.API.ViewModels
{
    /// <summary>
    /// Represents a request for temperature conversion
    /// </summary>
    public class TemperatureConversionViewModel
    {
        public double Value { get; set; }
        public TemperatureType SourceTemperatureType { get; set; }
        public TemperatureType DestinationTemperatureType { get; set; }
    }
}
