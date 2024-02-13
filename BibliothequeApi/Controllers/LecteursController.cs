using BibliothequeApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliothequeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecteursController : ControllerBase
    {
        private readonly IService<Lecteur> _service;

        public LecteursController(IService<Lecteur> service)
        {
            _service = service;
        }

        // GET: api/Lecteurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lecteur>>> GetLecteurs()
        {
            IEnumerable<Lecteur> lecteurs = await _service.GetAll();
            if (lecteurs != null)
            {
                return Ok(lecteurs);
            }
            return NotFound();
        }

        // GET: api/Lecteurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lecteur>> GetLecteur(int id)
        {
            var lecteur = await _service.GetById(id);

            if (lecteur == null)
            {
                return NotFound();
            }

            return Ok(lecteur);
        }

        // PUT: api/Lecteurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLecteur(int id, Lecteur lecteur)
        {
            if (id != lecteur.Id)
            {
                return BadRequest();
            }



            try
            {
                Lecteur modified = await _service.Update(lecteur);
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

        // POST: api/Lecteurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lecteur>> PostLecteur(Lecteur lecteur)
        {
            lecteur = await _service.Add(lecteur);

            return CreatedAtAction("GetLecteur", new { id = lecteur.Id }, lecteur);
        }

        // DELETE: api/Lecteurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLecteur(int id)
        {

            return await _service.Delete(id) ? NoContent() : NotFound();
        }
    }
}
