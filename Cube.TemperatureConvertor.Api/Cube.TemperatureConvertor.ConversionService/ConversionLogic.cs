namespace Cube.TemperatureConvertor.ConversionService
{
    public static class ConversionLogic
    {

        public static double ConvertCelsiusToFahrenheit(double Celsius)
            => (Celsius * 9 / 5) + 32;

        public static double ConvertFahrenheitToCelsius(double fahrenheit)
            => (fahrenheit - 32) * 5 / 9;

        public static double ConvertCelsiusToKelvin(double Celsius)
            => Celsius + 273.15;

        public static double ConvertKelvinToCelsius(double kelvin)
            => kelvin - 273.15;
        
        public static double ConvertFahrenheitToKelvin(double fahrenheit)
            => ((fahrenheit - 32) * 5 / 9) + 273.15;

        public static double ConvertKelvinToFahrenheit(double kelvin)
            => ((kelvin - 273.15) * 9 / 5) + 32;

    }
}