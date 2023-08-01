using imageuploadapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace imageuploadapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly KaninidbContext db;
        public FileController(KaninidbContext _db)
        {
            db = _db;
        }
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Imagetbl>> PostImagetbl([FromForm]FileModel file)
        {
             try
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", file.FileName);
                    using (Stream stream = new FileStream(path, FileMode.Create))
                    {
                        file.FormFile.CopyTo(stream);
                    Imagetbl imgtbl = new Imagetbl();
                    imgtbl.Imgname = "~/Images/"+file.FileName;
                        db.Imagetbls.Add(imgtbl);
                        await db.SaveChangesAsync();
                    }
                    return StatusCode(StatusCodes.Status201Created);
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

            }
        }

    }

