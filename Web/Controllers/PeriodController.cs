using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using apiEDT.Back;
using apiEDT.Back.Models;


namespace apiEDT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodController : ControllerBase
    {
        private readonly apiEDTContext _context;

        public PeriodController(apiEDTContext context)
        {
            _context = context;
        }


        #region GET == Read

        // api/period
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Period>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Period>> Get()
        {   
            List<Period> periods = _context.Period.ToList(); 

            if(periods.Count == 0){ return NotFound(); }

            return Ok(periods);
        }

        // api/period/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Period), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Period> GetById(int id)
        {
            Period period = _context.Period.Where(x => x.id_period == id).FirstOrDefault(); 

            if(period == null){ return NotFound(); }

            return Ok(period);
        }

        // api/period/promo/{id}
        [HttpGet("promo/{id}")]
        [ProducesResponseType(typeof(IEnumerable<Period>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Period> GetByIdPromo(int id)
        {
            Promotion promo = _context.Promotion.Where(x => x.id_promo == id).FirstOrDefault();
            
            if(promo == null){ return BadRequest(); }

            List<Period> periods = _context.Period.Where(x => x.id_promo == id).ToList(); 

            if(periods.Count == 0){ return NoContent(); }

            return Ok(periods);
        }
        #endregion


        #region POST == Create

        // api/period
        [HttpPost]
        [ProducesResponseType(typeof(Period), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Period>> PostPeriod(Period period)
        {
            //La BDD est en auto-increment : si !=0 --> erreur
            if(period.id_period != 0){ return BadRequest(); }

            if(alreadyExist(period)){ return BadRequest(); }
            
            _context.Period.Add(period);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = period.id_period }, period);
        }
        #endregion


        #region PUT == Update


        #endregion


        #region DELETE == Delete

        // api/period
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(String),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteById(int id)
        {
            var period = await _context.Period.FindAsync(id);

            if (period == null) { return NotFound(); }

            _context.Period.Remove(period);
            await _context.SaveChangesAsync();

            return Ok(id);
        }
        #endregion


        public Boolean alreadyExist(Period periodRecu)
        {
            List<Period> periods = _context.Period.ToList();

            Period res = periods.Where( x => 
                                        x.id_promo == periodRecu.id_promo && x.label == periodRecu.label && 
                                        x.tDeb == periodRecu.tDeb && x.tFin == periodRecu.tFin
                                      ).FirstOrDefault();

            if(res == null ){ return false; }
            return true;
        }
    }
}