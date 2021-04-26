import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { NgSelectModule } from '@ng-select/ng-select';

import { AppComponent } from './app.component';
import { TemperatureConverterComponent } from './components/temperature-converter/temperature-converter.component';

@NgModule({
  declarations: [AppComponent, TemperatureConverterComponent],
  imports: [BrowserModule, HttpClientModule, NgSelectModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
