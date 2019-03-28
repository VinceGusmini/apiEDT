using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using apiEDT.Back;
using apiEDT.Back.Models;


namespace apiEDT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UemoduleController : ControllerBase
    {
        private readonly apiEDTContext _context;

        public UemoduleController(apiEDTContext context)
        {
            _context = context;
        }

        #region GET == Read

        // api/uemodule
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Uemodule>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Uemodule>> Get()
        {
            List<Uemodule> uemodules = _context.Uemodule.ToList(); 

            if(uemodules.Count == 0){ return NotFound(); }

            return Ok(uemodules);
        }

        // api/uemodule/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Uemodule), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Uemodule>> GetById(int id)
        {
            Uemodule uemodule = await _context.Uemodule.FindAsync(id); 

            if(uemodule == null){ return NotFound(); }

            return Ok(uemodule);
        }
        #endregion

        #region POST == Create

        // api/uemodule
        [HttpPost]
        [ProducesResponseType(typeof(Uemodule), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Uemodule>> PostPeriod(Uemodule uemodule)
        {
            //La BDD est en auto-increment : si !=0 --> erreur
            if(uemodule.id_uemod != 0){ return BadRequest(); }

            //if(alreadyExist(period)){ return BadRequest(); }
            
            _context.Uemodule.Add(uemodule);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = uemodule.id_uemod }, uemodule);
        }
        #endregion

        #region PUT == Update

        #endregion

        #region DELETE == Delete

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(String),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteById(int id)
        {
            var uemodule = await _context.Uemodule.FindAsync(id);

            if (uemodule == null) { return NotFound(); }

            _context.Uemodule.Remove(uemodule);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion
    }
}