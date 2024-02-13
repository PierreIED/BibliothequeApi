using BibliothequeApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliothequeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpruntsController : ControllerBase
    {
        private readonly IService<Emprunt> _service;

        public EmpruntsController(IService<Emprunt> service)
        {
            _service = service;
        }

        // GET: api/Emprunts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emprunt>>> GetEmprunts()
        {
            IEnumerable<Emprunt> emprunts = await _service.GetAll();
            if (emprunts != null)
            {
                return Ok(emprunts);
            }
            return NotFound();
        }

        // GET: api/Emprunts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emprunt>> GetEmprunt(int id)
        {
            var emprunt = await _service.GetById(id);

            if (emprunt == null)
            {
                return NotFound();
            }

            return Ok(emprunt);
        }

        // PUT: api/Emprunts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmprunt(int id, Emprunt emprunt)
        {
            if (id != emprunt.Id)
            {
                return BadRequest();
            }



            try
            {
                Emprunt modified = await _service.Update(emprunt);
                return modified == null ? NotFound() : Accepted(modified);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_service.GetById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        // POST: api/Emprunts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Emprunt>> PostEmprunt(Emprunt emprunt)
        {
            emprunt = await _service.Add(emprunt);

            return CreatedAtAction("GetEmprunt", new { id = emprunt.Id }, emprunt);
        }

        // DELETE: api/Emprunts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmprunt(int id)
        {

            return await _service.Delete(id) ? NoContent() : NotFound();
        }
    }
}
