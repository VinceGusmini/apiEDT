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
    public class MatiereController : ControllerBase
    {
        private readonly apiEDTContext _context;

        public MatiereController(apiEDTContext context)
        {
            _context = context;
        }


        // GET api/matiere
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Matiere>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Matiere>> Get()
        {
            List<Matiere> matieres = _context.Matiere.ToList(); 
            
            if(matieres.Count == 0){ return NotFound(); }

            return Ok(matieres);
        }

        // GET api/matiere/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Matiere), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Matiere>> GetById(int id)
        {
            Matiere matiere = await _context.Matiere.FindAsync(id); 

            if(matiere == null){ return NotFound(); }

            return Ok(matiere);
        }



    }
}