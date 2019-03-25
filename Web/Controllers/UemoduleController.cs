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


        // GET api/Uemodule
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Uemodule>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Uemodule>> Get()
        {
            List<Uemodule> uemodules = _context.Uemodule.ToList(); 

            if(uemodules.Count == 0){ return NotFound(); }

            return Ok(uemodules);
        }

        // GET api/uemodule/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Uemodule), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Uemodule>> GetById(int id)
        {
            Uemodule uemodule = await _context.Uemodule.FindAsync(id); 

            if(uemodule == null){ return NotFound(); }

            return Ok(uemodule);
        }



    }
}