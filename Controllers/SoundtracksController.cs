using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music_Api.Data;
using Music_Api.Models;

namespace Music_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoundtracksController : ControllerBase
    {
        private readonly MusicContext _context;

        public SoundtracksController(MusicContext context)
        {
            _context = context;
        }

        // GET: api/Soundtracks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Soundtrack>>> GetSoundtrack()
        {
            var soundtracks = await _context.Soundtrack.ToListAsync();
            //Hämtar kategori för alla låtar
            foreach(var soundtrack in soundtracks)
            {
                Category category = _context.Category.Find(soundtrack.CategoryId);
                soundtrack.Category = category;
            }
            return soundtracks;
            
        }

        // GET: api/Soundtracks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Soundtrack>> GetSoundtrack(int id)
        {
            var soundtrack = await _context.Soundtrack.FindAsync(id);

            //Hämtar kategori för specifik låt
            Category category = _context.Category.Find(soundtrack.CategoryId);
            soundtrack.Category = category;

            if (soundtrack == null)
            {
                return NotFound();
            }

            return soundtrack;
        }

        // PUT: api/Soundtracks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoundtrack(int id, Soundtrack soundtrack)
        {
            if (id != soundtrack.SoundtrackId)
            {
                return BadRequest();
            }

            _context.Entry(soundtrack).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoundtrackExists(id))
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

        // POST: api/Soundtracks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Soundtrack>> PostSoundtrack(Soundtrack soundtrack)
        {
            _context.Soundtrack.Add(soundtrack);
            await _context.SaveChangesAsync();

            //Hämtar kategori för låt
            Category category = _context.Category.Find(soundtrack.CategoryId);
            soundtrack.Category = category;
            return CreatedAtAction("GetSoundtrack", new { id = soundtrack.SoundtrackId }, soundtrack);
        }

        // DELETE: api/Soundtracks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoundtrack(int id)
        {
            var soundtrack = await _context.Soundtrack.FindAsync(id);
            if (soundtrack == null)
            {
                return NotFound();
            }

            _context.Soundtrack.Remove(soundtrack);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoundtrackExists(int id)
        {
            return _context.Soundtrack.Any(e => e.SoundtrackId == id);
        }
    }
}
