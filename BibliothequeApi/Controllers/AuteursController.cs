using BibliothequeApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliothequeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuteursController : ControllerBase
    {
        private readonly IService<Auteur> _service;

        public AuteursController(IService<Auteur> service)
        {
            _service = service;
        }

        // GET: api/Auteurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auteur>>> GetAuteurs()
        {
            IEnumerable<Auteur> auteurs = await _service.GetAll();
            if (auteurs != null)
            {
                return Ok(auteurs);
            }
            return NotFound();
        }

        // GET: api/Auteurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Auteur>> GetAuteur(int id)
        {
            var auteur = await _service.GetById(id);

            if (auteur == null)
            {
                return NotFound();
            }

            return Ok(auteur);
        }

        // PUT: api/Auteurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuteur(int id, Auteur auteur)
        {
            if (id != auteur.Id)
            {
                return BadRequest();
            }



            try
            {
                Auteur modified = await _service.Update(auteur);
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

        // POST: api/Auteurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Auteur>> PostAuteur(Auteur auteur)
        {
            auteur = await _service.Add(auteur);

            return CreatedAtAction("GetAuteur", new { id = auteur.Id }, auteur);
        }

        // DELETE: api/Auteurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuteur(int id)
        {

            return await _service.Delete(id) ? NoContent() : NotFound();
        }
    }
}
