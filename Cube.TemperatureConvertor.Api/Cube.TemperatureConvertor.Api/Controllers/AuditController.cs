using Cube.Core.Validation;
using Cube.TemperatureConvertor.Api.Handlers;
using Cube.TemperatureConvertor.Api.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cube.TemperatureConvertor.Api.Controllers
{
    public class AuditController : Controller
    {
        private readonly IMediator _Mediator;
        public AuditController(IMediator mediator)
        {
            this._Mediator = mediator;
        }

        [HttpGet("~/read-audit-logs")]
        public async Task<ActionResult<Result<AuditTrailResponse>>> ReadAuditLogs()
        {
            var query = new GetAuditTrailQuery();
            var result = await _Mediator.Send(query);

            if (result is null)
                return NotFound();

            return Ok(Result.Success(result));
        }
    }
}
