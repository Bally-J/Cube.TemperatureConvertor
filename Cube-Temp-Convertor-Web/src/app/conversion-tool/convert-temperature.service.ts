import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TemperatureConversionRequest, TemperatureConversionResponseResult } from '../models/TemperatureConversionModels';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConvertTemperatureService {

  private apiUrl: string = "https://localhost:7186";

  constructor(private httpClient:HttpClient) { }

  convertTemperature(request: TemperatureConversionRequest): Observable<TemperatureConversionResponseResult>{
    return this.httpClient.post<TemperatureConversionResponseResult>(this.apiUrl + "/convert-temperature", request);
  }
}
