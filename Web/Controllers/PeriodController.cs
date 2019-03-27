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
        public async Task<ActionResult<Period>> GetById(int id)
        {
            Period period = await _context.Period.FindAsync(id); 

            if(period == null){ return NotFound(); }

            return Ok(period);
        }
        #endregion


        #region POST == Create

        // api/period
        [HttpPost]
        [ProducesResponseType(typeof(Period), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Period>> PostPeriod(Period period)
        {
            //if(await alreadyExist(period.id_period)){ return BadRequest(); } si id pas 0 (autoIncre)
            
            _context.Period.Add(period);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = period.id_period }, period);
        }
        #endregion

        #region PUT == Update


        #endregion

        #region DELETE == Delete

        
        #endregion


        public async Task<Boolean> alreadyExist(int idItem)
        {
            //faire un test sur création et comparaison
            Period period = await _context.Period.FindAsync(idItem);

            if(period == null ){ return false; }
            return true;
        }
    }
}