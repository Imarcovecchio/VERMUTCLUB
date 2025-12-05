using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VermutClub.Data;
using VermutClub.Models;

namespace VermutClub.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 👉 Necesario para que el CORS funcione
        [HttpOptions]
        public IActionResult Options()
        {
            return Ok();
        }

        [HttpPost]
public async Task<IActionResult> Post([FromBody] SubscriptionRequest req)
{
    Console.WriteLine("[API] POST recibido en /api/SubscriptionsApi");

    if (req == null)
    {
        Console.WriteLine("[API] ERROR: Request body vino vacío");
        return BadRequest(new { error = "Request vacío" });
    }

    Console.WriteLine("[API] Datos recibidos:");
    Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(req));

    _context.SubscriptionRequests.Add(req);
    await _context.SaveChangesAsync();

    Console.WriteLine("[API] Suscripción guardada correctamente");

    return Ok(new { message = "Suscripción guardada correctamente" });
}

    }
}
