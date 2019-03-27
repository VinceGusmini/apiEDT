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
    public class EdtItemController : ControllerBase
    {
        private readonly apiEDTContext _context;

        public EdtItemController(apiEDTContext context)
        {
            _context = context;
        }


        // GET api/edtitem
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EdtItem>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<EdtItem>> Get()
        {
            List<EdtItem> edtItems = _context.EdtItem.ToList(); 

            if(edtItems.Count == 0){ return NotFound(); }

            return Ok(edtItems);
        }

        // GET api/edtitem/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EdtItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EdtItem>> GetById(int id)
        {
            EdtItem edtItem = await _context.EdtItem.FindAsync(id); 

            if(edtItem == null){ return NotFound(); }

            return Ok(edtItem);
        }



    }
}