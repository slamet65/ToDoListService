using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListService;
using ToDoListService.Entity;
using ToDoListService.Model;

namespace ToDoListService.Controllers
{
    [Route("")]
    [ApiController]
    public class ChecklistController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChecklistController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("checklist")]
        public async Task<ActionResult<IEnumerable<Checklist>>> GetChecklists()
        {
            return await _context.Checklists.ToListAsync();
        }

        
        [Authorize]
        [HttpPost("checklist")]
        public async Task<ActionResult<Checklist>> PostChecklist(ChecklistModel model)
        {
            var newData = await _context.Checklists.FirstOrDefaultAsync(d => d.Name == model.Name);
            if (newData != null) {
                return BadRequest("checklist data already exists");
            }
            Checklist checklist  = new Checklist() { Name = model.Name };
            _context.Checklists.Add(checklist);
            await _context.SaveChangesAsync();
            newData = await _context.Checklists.FirstOrDefaultAsync(d => d.Name == model.Name);

            return newData;
        }

        [Authorize]
        [HttpDelete("checklist/{id}")]
        public async Task<IActionResult> DeleteChecklist(int id)
        {
            var checklist = await _context.Checklists.FindAsync(id);
            if (checklist == null)
            {
                return NotFound();
            }

            _context.Checklists.Remove(checklist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChecklistExists(int id)
        {
            return _context.Checklists.Any(e => e.Id == id);
        }
    }
}
