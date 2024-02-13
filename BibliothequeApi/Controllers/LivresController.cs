using BibliothequeApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliothequeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivresController : ControllerBase
    {
        private readonly IService<Livre> _service;

        public LivresController(IService<Livre> service)
        {
            _service = service;
        }

        // GET: api/Livres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livre>>> GetLivres()
        {
            IEnumerable<Livre> livres = await _service.GetAll();
            if (livres != null)
            {
                return Ok(livres);
            }
            return NotFound();
        }

        // GET: api/Livres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Livre>> GetLivre(int id)
        {
            var livre = await _service.GetById(id);

            if (livre == null)
            {
                return NotFound();
            }

            return Ok(livre);
        }

        // PUT: api/Livres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivre(int id, Livre livre)
        {
            if (id != livre.Id)
            {
                return BadRequest();
            }



            try
            {
                Livre modified = await _service.Update(livre);
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

        // POST: api/Livres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Livre>> PostLivre(Livre livre)
        {
            livre = await _service.Add(livre);

            return CreatedAtAction("GetLivre", new { id = livre.Id }, livre);
        }

        // DELETE: api/Livres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivre(int id)
        {

            return await _service.Delete(id) ? NoContent() : NotFound();
        }
    }
}
