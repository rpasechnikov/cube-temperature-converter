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
}
