using Cube.Temperature.Converter.API.Enums;
using Cube.Temperature.Converter.API.Services.Interfaces;
using Cube.Temperature.Converter.API.ViewModels;
using System;
using System.Collections.Generic;

namespace Cube.Temperature.Converter.API.Services
{
    /// <summary>
    /// Provides various temperature conversion functions
    /// </summary>
    public class TemperatureConverterService : ITemperatureConverterService
    {
        /// <summary>
        /// Gets available temperature types to convert to/from
        /// </summary>
        public ICollection<SelectOptionViewModel<TemperatureType>> GetTemperatureTypes()
        {
            // TODO: create a helper functon
            return new List<SelectOptionViewModel<TemperatureType>>
            {
                new SelectOptionViewModel<TemperatureType>
                {
                    Id = TemperatureType.Celcius,
                    Name = TemperatureType.Celcius.ToString()
                },
                new SelectOptionViewModel<TemperatureType>
                {
                    Id = TemperatureType.Fahrenheit,
                    Name = TemperatureType.Fahrenheit.ToString()
                },
                new SelectOptionViewModel<TemperatureType>
                {
                    Id = TemperatureType.Kelvin,
                    Name = TemperatureType.Kelvin.ToString()
                }
            };
        }

        /// <summary>
        /// Converts provided temperature from source to destination type
        /// 
        /// TODO: add unit tests
        /// </summary>
        public double Convert(TemperatureConversionViewModel viewModel)
        {
            const string ERROR_FORMAT = 
                "{0} temperature type is not supported. " +
                "Only Celcius, Fahrenheit and Kelvin {1} temperature types are supported.";

            double inCelcius;

            switch (viewModel.SourceTemperatureType)
            {
                case TemperatureType.Celcius:
                    inCelcius = viewModel.Value;
                    break;
                case TemperatureType.Fahrenheit:
                    inCelcius = ConvertFahrenheitToCelcius(viewModel.Value);
                    break;
                case TemperatureType.Kelvin:
                    inCelcius = ConvertKelvinToCelcius(viewModel.Value);
                    break;
                default:
                    throw new NotSupportedException(
                        string.Format(
                            ERROR_FORMAT,
                            viewModel.SourceTemperatureType.ToString(),
                            "input"));
            }

            switch (viewModel.DestinationTemperatureType)
            {
                case TemperatureType.Celcius:
                    return inCelcius;
                case TemperatureType.Fahrenheit:
                    return ConvertCelciusToFahrenheit(inCelcius);
                case TemperatureType.Kelvin:
                    return ConvertCelciusToKelvin(inCelcius);
                default:
                    throw new NotSupportedException(
                        string.Format(
                            ERROR_FORMAT,
                            viewModel.DestinationTemperatureType.ToString(),
                            "output"));
            }
        }

        private double ConvertCelciusToFahrenheit(double value)
        {
            return (value * 9) / 5 + 32;
        }

        private double ConvertFahrenheitToCelcius(double value)
        {
            return 5.0 / 9.0 * (value - 32);
        }

        private double ConvertCelciusToKelvin(double value)
        {
            return value + 273.15;
        }

        private double ConvertKelvinToCelcius(double value)
        {
            return value - 273.15;
        }
    }
}
