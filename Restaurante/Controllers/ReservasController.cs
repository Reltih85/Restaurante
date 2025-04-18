using Restaurante.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Restaurante.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly RestauranteContext _context;

        public ReservaController(RestauranteContext context)
        {
            _context = context;
        }

        // GET: api/Reserva
        [HttpGet]
        public ActionResult<IEnumerable<Reserva>> GetReservas()
        {
            var reservas = new List<Reserva>();
            foreach (var r in _context.Reservas.Include(r => r.Cliente).Include(r => r.Mesa))
            {
                reservas.Add(r);
            }
            return Ok(reservas);
        }

        // GET: api/Reserva/5
        [HttpGet("{id}")]
        public ActionResult<Reserva> GetReserva(int id)
        {
            var reserva = _context.Reservas
                                  .Include(r => r.Cliente)
                                  .Include(r => r.Mesa)
                                  .FirstOrDefault(r => r.Id == id);

            if (reserva == null)
                return NotFound();

            return Ok(reserva);
        }

        // POST: api/Reserva
        [HttpPost]
        public ActionResult<Reserva> CrearReserva([FromBody] Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetReserva), new { id = reserva.Id }, reserva);
        }

        // PUT: api/Reserva/5
        [HttpPut("{id}")]
        public IActionResult ActualizarReserva(int id, [FromBody] Reserva reserva)
        {
            if (id != reserva.Id)
                return BadRequest();

            var reservaExistente = _context.Reservas.Find(id);
            if (reservaExistente == null)
                return NotFound();

            reservaExistente.ClienteId = reserva.ClienteId;
            reservaExistente.MesaId = reserva.MesaId;
            reservaExistente.Fecha = reserva.Fecha;
            reservaExistente.Hora = reserva.Hora;
            reservaExistente.Recurrente = reserva.Recurrente;
            reservaExistente.Estado = reserva.Estado;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Reserva/5
        [HttpDelete("{id}")]
        public IActionResult EliminarReserva(int id)
        {
            var reserva = _context.Reservas.Find(id);
            if (reserva == null)
                return NotFound();

            _context.Reservas.Remove(reserva);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
