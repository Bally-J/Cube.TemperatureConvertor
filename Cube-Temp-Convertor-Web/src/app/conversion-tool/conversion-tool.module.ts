import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConvertTemperatureFormComponent } from './convert-temperature-form/convert-temperature-form.component';
import { HomeModule } from '../home/home.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ConvertTemperatureFormComponent
  ],
  imports: [
    CommonModule,
    HomeModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class ConversionToolModule { }
