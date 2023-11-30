import { Component } from '@angular/core';
import { ConvertTemperatureService } from '../convert-temperature.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TemperatureConversionRequest, TemperatureUnit } from '../../models/TemperatureConversionModels';

@Component({
  selector: 'app-convert-temperature-form',
  templateUrl: './convert-temperature-form.component.html',
  styleUrls: ['./convert-temperature-form.component.scss']
})
export class ConvertTemperatureFormComponent {

  conversionForm: FormGroup = new FormGroup({});
  responseText: string = "";
  temperatureUnits = Object.values(TemperatureUnit);
  submitClicked: boolean = false;

  constructor(private formBuilder:FormBuilder, private convertTemperatureService: ConvertTemperatureService){
    this.conversionForm = this.formBuilder.group({
      username: ['', Validators.required],
      value: ['', Validators.required],
      fromUnit: [TemperatureUnit.Celsius, Validators.required],
      toUnit: [TemperatureUnit.Celsius, Validators.required],
    });
  }

  onSubmit(){
    this.submitClicked = true;
    if (this.conversionForm.valid) {
      const { username, value, fromUnit, toUnit } = this.conversionForm.value;

      var request = {
        username: username,
        temperatureToConvert: value,
        convertFromTemperatureUnit: fromUnit,
        convertToTemperatureUnit: toUnit
      } as TemperatureConversionRequest;

      this.convertTemperatureService.convertTemperature(request).subscribe(
        (response) => {
          if(!response.isSuccess)
          {
            this.responseText = response.error.message;
            return;
          }

          this.responseText = response.value.convertedTemperatureAsText;
        },
        (e) => {
          this.responseText = e.error.error.message ? e.error.error.message : 'An error occurred during the conversion.';
        }
      );
    }
  }
}
