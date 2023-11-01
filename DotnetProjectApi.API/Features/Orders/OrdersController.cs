using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotnetProjectApi.API.Features.Orders;

[ApiController]
[Route("[controller]")]
public class OrdersController : ApiController
{
    public OrdersController(ISender sender) : base(sender)
    {
    }

    // [HttpGet]
    // public async Task<ActionResult<Get.Response>> Get()
    // {
    //     var orders = await Sender.Send(new Get.Query { });
    //     return Ok(orders);
    // }

    [HttpPost]
    public async Task<ActionResult> AddOrder([FromBody] AddOrder.Command command)
    {
        await Sender.Send(command);
        return Ok();
    }
}
