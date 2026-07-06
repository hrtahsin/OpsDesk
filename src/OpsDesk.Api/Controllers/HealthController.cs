using Microsoft.AspNetCore.Mvc;
using OpsDesk.Application;
using OpsDesk.Infrastructure;
using OpsDesk.Shared;

namespace OpsDesk.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class HealthController : ControllerBase
{
    [HttpGet]
    public ActionResult<HealthResponse> Get()
    {
        return Ok(new HealthResponse(
            Status: "Healthy",
            Service: "OpsDesk.Api",
            ApplicationAssembly: ApplicationAssemblyReference.Assembly.GetName().Name ?? string.Empty,
            InfrastructureAssembly: InfrastructureAssemblyReference.Assembly.GetName().Name ?? string.Empty,
            SharedAssembly: SharedAssemblyReference.Assembly.GetName().Name ?? string.Empty));
    }

    public sealed record HealthResponse(
        string Status,
        string Service,
        string ApplicationAssembly,
        string InfrastructureAssembly,
        string SharedAssembly);
}
