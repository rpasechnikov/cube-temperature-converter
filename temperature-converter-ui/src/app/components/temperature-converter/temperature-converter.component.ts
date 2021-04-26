import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
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

  inTemperatureType: number;
  outTemperatureType: number;

  temperatureTypes$: Observable<SelectOption<number>>;

  constructor(private tempConverterService: TemperatureConverterService) {
    this.initialize();
  }

  ngOnInit(): void {}

  private initialize(): void {
    this.temperatureTypes$ = this.tempConverterService.getTemperatureTypes();
  }
}
