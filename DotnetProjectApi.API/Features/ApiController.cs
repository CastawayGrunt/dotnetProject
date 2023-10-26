using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotnetProjectApi.API.Features;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    protected ISender Sender { get; private set; }

    // protected string Sub => User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

    public ApiController(ISender sender)
    {
        Sender = sender;
    }
}