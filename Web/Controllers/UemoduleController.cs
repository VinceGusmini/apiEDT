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


        // GET api/Uemodule
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Uemodule>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Uemodule>> Get()
        {
            //[ProducesResponseType(typeof(Uemodule), 200)]
            //public ActionResult<IEnumerable<string>> Get()
            
            //List<Uemodule> uemodules = _context.Uemodules.ToList(); 

            //Uemodule == null
            //if(true){ return NotFound(); }
            Uemodule uemodule1 = new Uemodule();
            Uemodule uemodule2 = new Uemodule();
            List<Uemodule> uemodules = new List<Uemodule>();
            uemodules.Add(uemodule1);
            uemodules.Add(uemodule2);
            return Ok(uemodules);
        }

        // GET api/uemodule/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Uemodule), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Uemodule>> GetById(int id)
        {
            //[ProducesResponseType(typeof(Uemodule), 200)]
            //public ActionResult<IEnumerable<string>> Get()
            
            //Uemodule uemodule = await _context.Uemodules.FindAsync(id); 

            //Uemodule == null
            //if(true){ return NotFound(); }
            Uemodule uemodule = new Uemodule();
            return Ok(uemodule);
        }



    }
}