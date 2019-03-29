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


        #region GET == Read

        // api/edtitem
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EdtItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<EdtItem>> Get()
        {
            List<EdtItem> edtItems = _context.EdtItem.ToList(); 

            if(edtItems.Count == 0){ return NotFound(); }

            return Ok(edtItems);
        }

        // api/edtitem/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EdtItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<EdtItem> GetById(int id)
        {
            EdtItem edtItem = _context.EdtItem.Where(x => x.idItem == id).FirstOrDefault(); 

            if(edtItem == null){ return NotFound(); }

            return Ok(edtItem);
        }

        // api/edtitem/period/{id}
        [HttpGet("period/{id}")]
        [ProducesResponseType(typeof(IEnumerable<EdtItemFront>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<EdtItem>> GetByPeriod(int id)
        {
            Period period = _context.Period.Where(x => x.id_period == id).FirstOrDefault();
            if(period == null){ return BadRequest(); }

            List<EdtItem> edtItems = _context.EdtItem.Where(x => x.idModule == id).ToList();
            if(edtItems.Count == 0){ return NotFound(); }

            List<EdtItemFront> edtItemsFront = new List<EdtItemFront>();
            foreach(EdtItem item in edtItems){
                EdtItemFront front = new EdtItemFront() ;
                front.idItem = item.idItem;
                front.idModule = item.idModule;
                front.idPeriod = item.idPeriod;
                front.nbHeure = item.nbHeure;
                front.nameModule = _context.Uemodule.Where(x => x.id_uemod == item.idModule).FirstOrDefault().nom;
                edtItemsFront.Add(front);
            }

            return Ok(edtItemsFront);
        }
        #endregion


        #region POST == Create

        // api/edtitem
        [HttpPost]
        [ProducesResponseType(typeof(EdtItem), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EdtItem>> Post(EdtItem item)
        {
           if(alreadyExist(item)){ return BadRequest(); }
            
            _context.EdtItem.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = item.idItem }, item);
        }
        #endregion


        #region PUT == Update


        // api/uemodule
        [HttpPut]
        [ProducesResponseType(typeof(EdtItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EdtItem>> Put(EdtItem item)
        {
            //if (id != item.idItem){ return BadRequest(); }

            _context.EdtItem.Update(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        #endregion


        #region DELETE == Delete

        // api/edtitem/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            EdtItem edtItem = _context.EdtItem.Where(x => x.idItem == id).FirstOrDefault();

            if (edtItem == null){ return NotFound(); }

            _context.EdtItem.Remove(edtItem);
            await _context.SaveChangesAsync();

            return Ok(id);
        }
        #endregion

        
        public Boolean alreadyExist(EdtItem item) 
        {
            List<EdtItem> edtItems = _context.EdtItem.Where(x => x.idModule == item.idModule && x.idPeriod == item.idPeriod && x.nbHeure == item.nbHeure).ToList();

            if(edtItems.Count == 0 ){ return false; }
            return true;
        }
    }
}