using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliothequeApi;
using BibliothequeApi.Interfaces;

namespace BibliothequeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainesController : ControllerBase
    {
        private readonly IService<Domaine> _service;

        public DomainesController(IService<Domaine> service)
        {
           _service = service;
        }

        // GET: api/Domaines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domaine>>> GetDomaines()
        {
            IEnumerable<Domaine> domaines = await _service.GetAll();
            if (domaines != null)
            {
                return Ok(domaines);
            }
            return NotFound();
        }

        // GET: api/Domaines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Domaine>> GetDomaine(int id)
        {
            var domaine = await _service.GetById(id);

            if (domaine == null)
            {
                return NotFound();
            }

            return Ok(domaine);
        }

        // PUT: api/Domaines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDomaine(int id, Domaine domaine)
        {
            if (id != domaine.Id)
            {
                return BadRequest();
            }



            try
            {
                Domaine modified = await _service.Update(domaine);
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

        // POST: api/Domaines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Domaine>> PostDomaine(Domaine domaine)
        {
            domaine = await _service.Add(domaine);

            return CreatedAtAction("GetDomaine", new { id = domaine.Id }, domaine);
        }

        // DELETE: api/Domaines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDomaine(int id)
        {

            return await _service.Delete(id)? NoContent() : NotFound();
        }
    }
}
