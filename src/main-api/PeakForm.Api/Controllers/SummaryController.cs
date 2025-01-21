using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace PeakForm.Api.Controllers;

[Authorize]
[ApiController]
[EnableRateLimiting("fixed")]
[Route("[Controller]")]
public class SummaryController : ControllerBase
{
}
