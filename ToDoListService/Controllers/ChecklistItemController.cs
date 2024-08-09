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
    [Route("checklist")]
    [ApiController]
    public class ChecklistItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChecklistItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET Cheklist Item API No 1
        [Authorize]
        [HttpGet("{checklistID}/item")]
        public async Task<ActionResult<IEnumerable<ChecklistItem>>> GetAllByChecklistId(int checklistID)
        {
            return await _context.ChecklistItem.Where(l => l.ChecklistId == checklistID).ToListAsync();
        }
        // GET Cheklist Item API No 2
        [HttpPost("{checklistID}/item")]
        public async Task<ActionResult<ChecklistItem>> PostChecklistItem(int checklistID, ChecklistModel model)
        {
            ChecklistItem checklistItem = new ChecklistItem()
            {
                Name = model.Name,
                ChecklistId = checklistID
            };
            _context.ChecklistItem.Add(checklistItem);
            await _context.SaveChangesAsync();

            var newData = await _context.ChecklistItem.FirstOrDefaultAsync(d => d.ChecklistId == checklistID && d.Name == model.Name);

            return newData;
        }
        // GET Cheklist Item API No 3
        [Authorize]
        [HttpGet("{checklistID}/item/{checklistItemId}")]
        public async Task<ActionResult<ChecklistItem>> GetChecklistItem(int checklistID, int checklistItemId)
        {
            var item = await _context.ChecklistItem.SingleOrDefaultAsync(l => l.ChecklistId == checklistID && l.Id == checklistItemId);
            if (item == null)
            {
                return BadRequest("Item not found");
            }
            return item;
        }

        // GET Cheklist Item API No 4
        [Authorize]
        [HttpPut("{checklistID}/item/{checklistItemId}")]
        public async Task<IActionResult> PutChecklistItem(int checklistID, int checklistItemId)
        {
            ChecklistItem item = await _context.ChecklistItem.SingleOrDefaultAsync(l => l.ChecklistId == checklistID && l.Id == checklistItemId);
            if (item == null)
            {
                return BadRequest("Item not found");
            }
            item.Status = !item.Status;
            _context.ChecklistItem.Update(item);
            await _context.SaveChangesAsync();
            return Ok(item);
        }

        // GET Cheklist Item API No 5
        [Authorize]
        [HttpDelete("{checklistID}/item/{checklistItemId}")]
        public async Task<IActionResult> DeleteChecklistItem(int checklistID, int checklistItemId)
        {
            ChecklistItem item = await _context.ChecklistItem.SingleOrDefaultAsync(l => l.ChecklistId == checklistID && l.Id == checklistItemId);
            if (item == null)
            {
                return BadRequest("Item not found");
            }
            _context.ChecklistItem.Remove(item);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // GET Cheklist Item API No 6
        [Authorize]
        [HttpPut("{checklistID}/item/rename/{checklistItemId}")]
        public async Task<ActionResult<ChecklistItem>> RenameChecklistItem(int checklistID, int checklistItemId, ChecklistModel model)
        {
            ChecklistItem item = await _context.ChecklistItem.SingleOrDefaultAsync(l => l.ChecklistId == checklistID && l.Id == checklistItemId);
            if (item == null)
            {
                return BadRequest("Item not found");
            }
            item.Name = model.Name;
            _context.ChecklistItem.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
