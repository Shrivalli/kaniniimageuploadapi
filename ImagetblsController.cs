using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using imageuploadapi.Models;

namespace imageuploadapi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagetblsController : ControllerBase
    {
        private readonly KaninidbContext _context;

        public ImagetblsController(KaninidbContext context)
        {
            _context = context;
        }

        // GET: api/Imagetbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Imagetbl>>> GetImagetbls()
        {
          if (_context.Imagetbls == null)
          {
              return NotFound();
          }
            return await _context.Imagetbls.ToListAsync();
        }

        // GET: api/Imagetbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Imagetbl>> GetImagetbl(int id)
        {
          if (_context.Imagetbls == null)
          {
              return NotFound();
          }
            var imagetbl = await _context.Imagetbls.FindAsync(id);

            if (imagetbl == null)
            {
                return NotFound();
            }

            return imagetbl;
        }

        // PUT: api/Imagetbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImagetbl(int id, Imagetbl imagetbl)
        {
            if (id != imagetbl.Imgid)
            {
                return BadRequest();
            }

            _context.Entry(imagetbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagetblExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Imagetbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Imagetbl>> PostImagetbl(Imagetbl imagetbl)
        {
            if (_context.Imagetbls == null)
            {
                return Problem("Entity set 'KaninidbContext.Imagetbls'  is null.");
            }
            else {
                
                try
                {
                    //string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagetbl.Imgname);
                    //using (Stream stream = new FileStream(path, FileMode.Create))
                    {
                        //imagetb.FormFile.CopyTo(stream);
                        _context.Imagetbls.Add(imagetbl);
                        await _context.SaveChangesAsync();
                    }
                    return StatusCode(StatusCodes.Status201Created);
                } catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

            }
        }


            

        // DELETE: api/Imagetbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImagetbl(int id)
        {
            if (_context.Imagetbls == null)
            {
                return NotFound();
            }
            var imagetbl = await _context.Imagetbls.FindAsync(id);
            if (imagetbl == null)
            {
                return NotFound();
            }

            _context.Imagetbls.Remove(imagetbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImagetblExists(int id)
        {
            return (_context.Imagetbls?.Any(e => e.Imgid == id)).GetValueOrDefault();
        }
    }
}
