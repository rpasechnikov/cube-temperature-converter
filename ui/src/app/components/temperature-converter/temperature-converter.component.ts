import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { SelectOption } from 'src/app/models';
import { TemperatureConverterService } from 'src/app/services/temperature-converter.service';

@Component({
  selector: 'app-temperature-converter',
  templateUrl: './temperature-converter.component.html',
  styleUrls: ['./temperature-converter.component.scss']
})
export class TemperatureConverterComponent implements OnInit {
  inValue: number;
  outValue: number;

  sourceTemperatureType: number;
  destinationTemperatureType: number;

  temperatureTypes$: Observable<SelectOption<number>>;

  // TODO: replace with reactive forms? Could be overkill here
  get isFormValid(): boolean {
    return (
      !this.isNullOrEmpty(this.inValue) &&
      !this.isNullOrEmpty(this.sourceTemperatureType) &&
      !this.isNullOrEmpty(this.destinationTemperatureType)
    );
  }

  constructor(private tempConverterService: TemperatureConverterService) {
    this.initialize();
  }

  ngOnInit(): void {}

  onConvert(): void {
    this.tempConverterService
      .convertTemperature({
        value: this.inValue,
        sourceTemperatureType: this.sourceTemperatureType,
        destinationTemperatureType: this.destinationTemperatureType
      })
      .pipe(take(1))
      .subscribe(result => (this.outValue = result));
  }

  private initialize(): void {
    this.temperatureTypes$ = this.tempConverterService.getTemperatureTypes();
  }

  // TODO: extract into utils
  private isNullOrEmpty<T>(value: T): boolean {
    return value === undefined || value === null;
  }
}
