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


        // GET api/matiere
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Matiere>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Matiere>> Get()
        {
            //[ProducesResponseType(typeof(Matiere), 200)]
            //public ActionResult<IEnumerable<string>> Get()
            
            //List<Matiere> matieres = _context.Matieres.ToList(); 

            //matiere == null
            //if(true){ return NotFound(); }
            Matiere matiere1 = new Matiere();
            Matiere matiere2 = new Matiere();
            List<Matiere> matieres = new List<Matiere>();
            matieres.Add(matiere1);
            matieres.Add(matiere2);
            return Ok(matieres);
        }

        // GET api/matiere/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Matiere), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Matiere>> GetById(int id)
        {
            //[ProducesResponseType(typeof(Matiere), 200)]
            //public ActionResult<IEnumerable<string>> Get()
            
            //Matiere matiere = await _context.Matieres.FindAsync(id); 

            //matiere == null
            //if(true){ return NotFound(); }
            Matiere matiere = new Matiere();
            return Ok(matiere);
        }



    }
}