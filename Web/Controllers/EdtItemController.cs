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
        public async Task<ActionResult<EdtItem>> GetById(int id)
        {
            EdtItem edtItem = await _context.EdtItem.FindAsync(id); 

            if(edtItem == null){ return NotFound(); }

            return Ok(edtItem);
        }
        #endregion

        #region POST == Create

        // api/edtitem
        [HttpPost]
        [ProducesResponseType(typeof(EdtItem), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EdtItem>> PostEdtItem(EdtItem item)
        {
            if(await alreadyExist(item.idItem)){ return BadRequest(); }
            
            _context.EdtItem.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = item.idItem }, item);
        }
        #endregion

        #region PUT == Update
        //400 Bad Request --> when no other 4xx error code is appropriate	
/* 
        // api/uemodule/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EdtItem), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EdtItem>> Put(long id, EdtItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }*/
        #endregion

        #region DELETE == Delete

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEdtItem(long id)
        {
            var EdtItem = await _context.EdtItem.FindAsync(id);

            if (EdtItem == null)
            {
                return NotFound();
            }

            _context.EdtItem.Remove(EdtItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        public async Task<Boolean> alreadyExist(int idItem)
        {
            EdtItem edtItem = await _context.EdtItem.FindAsync(idItem);

            if(edtItem == null ){ return false; }
            return true;
        }
    }
}