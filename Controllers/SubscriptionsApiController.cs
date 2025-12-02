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
        public async Task<IActionResult> Post([FromBody] SubscriptionRequest request)
        {
            Console.WriteLine("=== Nueva suscripción recibida ===");
            Console.WriteLine($"Nombre: {request.Nombre}");
            Console.WriteLine($"Email: {request.Email}");
            Console.WriteLine($"Phone: {request.Phone}");
            Console.WriteLine($"Plan: {request.Plan}");
            Console.WriteLine("=================================");

            var sus = new SubscriptionRequest
            {
                Nombre = request.Nombre ,
                Email = request.Email,
                Phone= request.Phone,
                Plan= request.Plan  
            };

            _context.SubscriptionRequests.Add(sus);
            await  _context.SaveChangesAsync();
            return Ok(new { message = "Suscripción guardada correctamente" });
        
        }
    }
}
