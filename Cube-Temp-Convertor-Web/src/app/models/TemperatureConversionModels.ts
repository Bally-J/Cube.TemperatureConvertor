import { Result } from "./ResultModels"

export interface TemperatureConversionResponse {
    convertedTemperatureAsText: string
}

export interface TemperatureConversionResponseResult extends Result {
    value: TemperatureConversionResponse
}

export interface TemperatureConversionRequest {
    temperatureToConvert: number,
    convertFromTemperatureUnit: TemperatureUnit,
    convertToTemperatureUnit: TemperatureUnit
    username: string
}

export enum TemperatureUnit {
    Kelvin = "Kelvin", 
    Fahrenheit = "Fahrenheit", 
    Celsius = "Celsius" 
}