using Cube.Core.Exceptions;
using Cube.Core.Validation;
using Cube.TemperatureConvertor.Api.Handlers;
using Cube.TemperatureConvertor.Api.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cube.TemperatureConvertor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        private readonly IMediator _Mediator;
        public ConversionController(IMediator mediator)
        {
            this._Mediator = mediator;
        }

        [HttpPost("~/convert-temperature")]
        public async Task<ActionResult<Result<TemperatureConversionResponse>>> ConvertTemperature(TemperatureConversionRequest request)
        {
            if (String.IsNullOrEmpty(request.Username))
                return BadRequest(Result.Failure<TemperatureConversionResponse>(new Error("TemperatureConversion.MissingUsername", "Username is required")));

            try
            {
                var query = new GetTemperatureConversionQuery(request);
                var result = await _Mediator.Send(query);

                if (result is null)
                    return NotFound();

                return Ok(Result.Success(result));
            }
            catch (UserException ex)
            {
                return BadRequest(Result.Failure<TemperatureConversionResponse>(new Error("TemperatureConversion.ConversionIssue", ex.Message)));
            }
            catch (Exception)
            {
                return BadRequest(Result.Failure<TemperatureConversionResponse>(new Error("TemperatureConversion.UnknownIssue", "Unknown Issue Occured. Please Contact Administrator")));
            }

        }
    }
}
