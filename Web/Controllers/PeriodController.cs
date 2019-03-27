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


        // GET api/period
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Period>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Period>> Get()
        {   
            List<Period> periods = _context.Period.ToList(); 

            if(periods.Count == 0){ return NotFound(); }

            return Ok(periods);
        }

        // GET api/period/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Period), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Period>> GetById(int id)
        {
            Period period = await _context.Period.FindAsync(id); 

            if(period == null){ return NotFound(); }

            return Ok(period);
        }

    }
}