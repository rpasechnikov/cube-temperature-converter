import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { SelectOption, TemperatureConversionModel } from '../models';

@Injectable({
  providedIn: 'root'
})
export class TemperatureConverterService {
  constructor(private httpClient: HttpClient) {}

  getTemperatureTypes(): Observable<SelectOption<number>> {
    return this.httpClient.get<SelectOption<number>>(this.getApiUrl('temperatureTypes'));
  }

  convertTemperature(model: TemperatureConversionModel): Observable<number> {
    // TODO: add error handling
    return this.httpClient.post(this.getApiUrl('convert'), model).pipe(map(result => +result));
  }

  getApiUrl(url: string): string {
    return environment.apiUrl + '/' + url;
  }
}
