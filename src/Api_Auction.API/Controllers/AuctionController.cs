using Microsoft.AspNetCore.Mvc;

namespace Api_Auction.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    [HttpGet]
    public IActionResult GetCurrentAuction()
    {
        return Ok("Mizael");
    }
}