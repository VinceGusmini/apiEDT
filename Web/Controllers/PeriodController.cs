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
    public class PeriodController : ControllerBase
    {
        private readonly apiEDTContext _context;

        public PeriodController(apiEDTContext context)
        {
            _context = context;
            /*
            if (_context.TodoItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.TodoItems.Add(new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            }
             */
        }


        // GET api/period
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Period>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Period>> Get()
        {
            //[ProducesResponseType(typeof(Period), 200)]
            //public ActionResult<IEnumerable<string>> Get()
            
            //List<Period> periods = _context.Periods.ToList(); 

            //Period == null
            //if(true){ return NotFound(); }
            Period period1 = new Period();
            Period period2 = new Period();
            List<Period> periods = new List<Period>();
            periods.Add(period1);
            periods.Add(period2);
            return Ok(periods);
        }

        // GET api/period/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Period), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Period>> GetById(int id)
        {
            //[ProducesResponseType(typeof(Period), 200)]
            //public ActionResult<IEnumerable<string>> Get()
            
            //Period period = await _context.Periods.FindAsync(id); 

            //Period == null
            //if(true){ return NotFound(); }
            Period period = new Period();
            return Ok(period);
        }



    }
}