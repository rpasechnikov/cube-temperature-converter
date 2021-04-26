export interface TemperatureConversionModel {
  value: number;

  // TODO: can we do this better? Any is no better...
  sourceTemperatureType: number;
  destinationTemperatureType: number;
}
