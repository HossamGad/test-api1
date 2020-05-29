using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SFF_Api_App.DB;
using SFF_Api_App.Models;

namespace SFF_Api_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriviasApiController : Controller
    {
        private readonly SFF_DbContext _context;

        public TriviasApiController(SFF_DbContext context)
        {
            _context = context;
        }

        // GET: Trivias
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Trivias.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trivias>> GetTodoItem(int id)
        {
            var trivias = await _context.Trivias.FindAsync(id);

            if (trivias == null)
            {
                return NotFound("Kunde inte hitta film");
            }

            return Ok(trivias);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrivias(int Id, Trivias trivias)
        {
            if (Id != trivias.Id)
            {
                return BadRequest("Trivias finns inte");
            }

            var getTrivias = await _context.Trivias.FindAsync(Id);
            if (getTrivias == null)
            {
                return NotFound();
            }

            getTrivias.Id = trivias.Id;
            getTrivias.Title = trivias.Title;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return NotFound("Kunde inte lagra trivia");
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Trivias>> CreateTrivia(Trivias trivias)
        {
            try
            {
                var newTrivias = new Trivias
                {
                    Id = trivias.Id,
                    Title = trivias.Title,

            };

                _context.Trivias.Add(newTrivias);
                await _context.SaveChangesAsync();

                return Ok(newTrivias);
            }
            catch
            {
                return BadRequest("Databas fel");
            }

            /*
            return CreatedAtAction(
                nameof(GetTodoItem),
                new { id = todoItem.Id },
                ItemToDTO(todoItem));
            */
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrivias(int id)
        {
            var trivias = await _context.Trivias.FindAsync(id);

            if (trivias == null)
            {
                return NotFound("Kunde inte hitta filmen");
            }

            _context.Trivias.Remove(trivias);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
