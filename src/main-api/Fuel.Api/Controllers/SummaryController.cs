using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Fuel.Api.Controllers;

[Authorize]
[ApiController]
[Route("Summary")]
public class SummaryController : ControllerBase
{
}
