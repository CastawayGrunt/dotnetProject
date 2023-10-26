using DotnetProjectApi.API.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotnetProjectApi.API.Features.Products;

[ApiController]
[Route("[controller]")]
public class ProductsController : ApiController
{
    public ProductsController(ISender sender) : base(sender)
    {
    }

    [HttpGet]
    public async Task<ActionResult<Get.Response>> Get()
    {
        var products = await Sender.Send(new Get.Query { });
        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult> AddProduct([FromBody] AddProduct.Command command)
    {
        await Sender.Send(command);
        return Ok();
    }

    [HttpPut("{productId:guid}")]
    public async Task<ActionResult> UpdateProduct([FromRoute] Guid productId, [FromBody] UpdateProduct.Command command)
    {
        await Sender.Send(command with { Id = productId });
        return Ok();
    }

    [HttpDelete("{productId:guid}")]
    public async Task<ActionResult> DeleteProduct(Guid productId)
    {
        await Sender.Send(new DeleteProduct.Command { Id = productId });
        return Ok();
    }
}