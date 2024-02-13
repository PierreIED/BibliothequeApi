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
    public class AdressesController : ControllerBase
    {
         private readonly IService<Adresse> _service;

        public AdressesController(IService<Adresse> service)
        {
            _service = service;
        }

        // GET: api/Adresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adresse>>> GetAdresses()
        {
            IEnumerable<Adresse> adresses = await _service.GetAll();
            if (adresses != null)
            {
                return Ok(adresses);
            }
            return NotFound();
        }

        // GET: api/Adresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adresse>> GetAdresse(int id)
        {
            var adresse = await _service.GetById(id);

            if (adresse == null)
            {
                return NotFound();
            }

            return Ok(adresse);
        }

        // PUT: api/Adresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdresse(int id, Adresse adresse)
        {
            if (id != adresse.Id)
            {
                return BadRequest();
            }



            try
            {
                Adresse modified = await _service.Update(adresse);
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

        // POST: api/Adresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adresse>> PostAdresse(Adresse adresse)
        {
            adresse = await _service.Add(adresse);

            return CreatedAtAction("GetAdresse", new { id = adresse.Id }, adresse);
        }

        // DELETE: api/Adresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdresse(int id)
        {

            return await _service.Delete(id) ? NoContent() : NotFound();
        }
    }
}
