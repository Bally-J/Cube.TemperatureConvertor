using Cube.Core.Exceptions;
using Cube.Core.Interfaces;
using Cube.Core.Models;
using Moq;

namespace Cube.Services.TemperatureConversionService.Tests
{
    public class TemperatureConversionManagementTests
    {
        private readonly TemperatureConversionManagement _Sut;
        private readonly Mock<IAuditLogManagement> _AuditLogManagement;

        public TemperatureConversionManagementTests()
        {
            _AuditLogManagement = new Mock<IAuditLogManagement>();
            _Sut = new TemperatureConversionManagement(_AuditLogManagement.Object);
        }

        #region Test Converting Kelvin to Celsius
        [Theory]
        [InlineData(100, -173.14999999999998)]
        [InlineData(1000, 726.85)]
        public async Task ConvertToCelsiusAsync_FromKelvin_ShouldReturnValues(double valueForConversion, double expectedResult)
        {
            var result = await _Sut.ConvertToCelsiusAsync(Kelvin.From(valueForConversion));

            Assert.Equal(expectedResult, result.Value);
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(1e+33)]
        public async Task ConvertToCelsiusAsync_FromKelvin_OutOfRangeExceptionThrown(double valueForConversion)
        {
            var ex = await Assert.ThrowsAsync<OutOfTemperatureRangeException>(async () =>  await _Sut.ConvertToCelsiusAsync(Kelvin.From(valueForConversion)));

            Assert.Equal(valueForConversion, ex.TemperatureValue);
            Assert.Equal($"Temperature Value '{valueForConversion}' Is Out Of Range. Temperature Value Must Between 0K And {1e+32}K", ex.Message);
        }

        [Fact]
        public async Task ConvertToCelsiusAsync_FromKelvin_ShouldCallAuditLog()
        {
            var user = new ApiUser() { Username = "TestPerson" };
            _Sut.User = user;
            var result = await _Sut.ConvertToCelsiusAsync(Kelvin.From(10));
            
            _AuditLogManagement.Verify(x => x.AuditUserAsync(user, $"Converted 10K to {result}"), Times.Once);           
        }
        #endregion

        #region Test Converting Kelvin to Fahrenheit
        [Theory]
        [InlineData(100, -279.66999999999996)]
        [InlineData(1000, 1340.3300000000002)]
        public async Task ConvertToFahrenheitAsync_FromKelvin_ShouldReturnValues(double valueForConversion, double expectedResult)
        {
            var result = await _Sut.ConvertToFahrenheitAsync(Kelvin.From(valueForConversion));

            Assert.Equal(expectedResult, result.Value);
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(1e+33)]
        public async Task ConvertToFahrenheitAsync_FromKelvin_OutOfRangeExceptionThrown(double valueForConversion)
        {
            var ex = await Assert.ThrowsAsync<OutOfTemperatureRangeException>(async () =>  await _Sut.ConvertToFahrenheitAsync(Kelvin.From(valueForConversion)));

            Assert.Equal(valueForConversion, ex.TemperatureValue);
            Assert.Equal($"Temperature Value '{valueForConversion}' Is Out Of Range. Temperature Value Must Between 0K And {1e+32}K", ex.Message);
        }

        [Fact]
        public async Task ConvertToFahrenheitAsync_FromKelvin_ShouldCallAuditLog()
        {
            var user = new ApiUser() { Username = "TestPerson" };
            _Sut.User = user;
            var result = await _Sut.ConvertToFahrenheitAsync(Kelvin.From(10));
            
            _AuditLogManagement.Verify(x => x.AuditUserAsync(user, $"Converted 10K to {result}"), Times.Once);           
        }
        #endregion

        #region Test Converting Fahrenheit to Celsius
        [Theory]
        [InlineData(100, 37.77777777777778)]
        [InlineData(1000, 537.7777777777778)]
        public async Task ConvertToCelsiusAsync_FromFahrenheit_ShouldReturnValues(double valueForConversion, double expectedResult)
        {
            var result = await _Sut.ConvertToCelsiusAsync(Fahrenheit.From(valueForConversion));

            Assert.Equal(expectedResult, result.Value);
        }

        [Theory]
        [InlineData(-460)]
        [InlineData(1.8e+33)]
        public async Task ConvertToCelsiusAsync_FromFahrenheit_OutOfRangeExceptionThrown(double valueForConversion)
        {
            var ex = await Assert.ThrowsAsync<OutOfTemperatureRangeException>(async () =>  await _Sut.ConvertToCelsiusAsync(Fahrenheit.From(valueForConversion)));

            Assert.Equal(valueForConversion, ex.TemperatureValue);
            Assert.Equal($"Temperature Value '{valueForConversion}' Is Out Of Range. Temperature Value Must Between -459.67°F And {1.8e+32}°F", ex.Message);
        }

        [Fact]
        public async Task ConvertToCelsiusAsync_FromFahrenheit_ShouldCallAuditLog()
        {
            var user = new ApiUser() { Username = "TestPerson" };
            _Sut.User = user;
            var result = await _Sut.ConvertToCelsiusAsync(Fahrenheit.From(10));
            
            _AuditLogManagement.Verify(x => x.AuditUserAsync(user, $"Converted 10°F to {result}"), Times.Once);           
        }
        #endregion

        #region Test Converting Fahrenheit to Kelvin
        [Theory]
        [InlineData(100, 310.92777777777775)]
        [InlineData(1000, 810.9277777777778)]
        public async Task ConvertToKelvinAsync_FromFahrenheit_ShouldReturnValues(double valueForConversion, double expectedResult)
        {
            var result = await _Sut.ConvertToKelvinAsync(Fahrenheit.From(valueForConversion));

            Assert.Equal(expectedResult, result.Value);
        }

        [Theory]
        [InlineData(-460)]
        [InlineData(1.8e+33)]
        public async Task ConvertToKelvinAsync_FromFahrenheit_OutOfRangeExceptionThrown(double valueForConversion)
        {
            var ex = await Assert.ThrowsAsync<OutOfTemperatureRangeException>(async () =>  await _Sut.ConvertToKelvinAsync(Fahrenheit.From(valueForConversion)));

            Assert.Equal(valueForConversion, ex.TemperatureValue);
            Assert.Equal($"Temperature Value '{valueForConversion}' Is Out Of Range. Temperature Value Must Between -459.67°F And {1.8e+32}°F", ex.Message);
        }

        [Fact]
        public async Task ConvertToKelvinAsync_FromFahrenheit_ShouldCallAuditLog()
        {
            var user = new ApiUser() { Username = "TestPerson" };
            _Sut.User = user;
            var result = await _Sut.ConvertToKelvinAsync(Fahrenheit.From(10));
            
            _AuditLogManagement.Verify(x => x.AuditUserAsync(user, $"Converted 10°F to {result}"), Times.Once);           
        }
        #endregion

        #region Test Converting Celsius to Kelvin
        [Theory]
        [InlineData(100, 373.15)]
        [InlineData(1000, 1273.15)]
        public async Task ConvertToKelvinAsync_FromCelsius_ShouldReturnValues(double valueForConversion, double expectedResult)
        {
            var result = await _Sut.ConvertToKelvinAsync(Celsius.From(valueForConversion));

            Assert.Equal(expectedResult, result.Value);
        }

        [Theory]
        [InlineData(-274)]
        [InlineData(1e+33)]
        public async Task ConvertToKelvinAsync_FromCelsius_OutOfRangeExceptionThrown(double valueForConversion)
        {
            var ex = await Assert.ThrowsAsync<OutOfTemperatureRangeException>(async () =>  await _Sut.ConvertToKelvinAsync(Celsius.From(valueForConversion)));

            Assert.Equal(valueForConversion, ex.TemperatureValue);
            Assert.Equal($"Temperature Value '{valueForConversion}' Is Out Of Range. Temperature Value Must Between -273.15°C And {1e+32}°C", ex.Message);
        }

        [Fact]
        public async Task ConvertToKelvinAsync_FromCelsius_ShouldCallAuditLog()
        {
            var user = new ApiUser() { Username = "TestPerson" };
            _Sut.User = user;
            var result = await _Sut.ConvertToKelvinAsync(Celsius.From(10));
            
            _AuditLogManagement.Verify(x => x.AuditUserAsync(user, $"Converted 10°C to {result}"), Times.Once);           
        }
        #endregion
        
        #region Test Converting Celsius to Fahrenheit
        [Theory]
        [InlineData(100, 212)]
        [InlineData(1000, 1832)]
        public async Task ConvertToFahrenheitAsync_FromCelsius_ShouldReturnValues(double valueForConversion, double expectedResult)
        {
            var result = await _Sut.ConvertToFahrenheitAsync(Celsius.From(valueForConversion));

            Assert.Equal(expectedResult, result.Value);
        }

        [Theory]
        [InlineData(-274)]
        [InlineData(1e+33)]
        public async Task ConvertToFahrenheitAsync_FromCelsius_OutOfRangeExceptionThrown(double valueForConversion)
        {
            var ex = await Assert.ThrowsAsync<OutOfTemperatureRangeException>(async () =>  await _Sut.ConvertToFahrenheitAsync(Celsius.From(valueForConversion)));

            Assert.Equal(valueForConversion, ex.TemperatureValue);
            Assert.Equal($"Temperature Value '{valueForConversion}' Is Out Of Range. Temperature Value Must Between -273.15°C And {1e+32}°C", ex.Message);
        }

        [Fact]
        public async Task ConvertToFahrenheitAsync_FromCelsius_ShouldCallAuditLog()
        {
            var user = new ApiUser() { Username = "TestPerson" };
            _Sut.User = user;
            var result = await _Sut.ConvertToFahrenheitAsync(Celsius.From(10));
            
            _AuditLogManagement.Verify(x => x.AuditUserAsync(user, $"Converted 10°C to {result}"), Times.Once);           
        }
        #endregion
    }
}