using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PatternsGoF.Facade;
using Microsoft.EntityFrameworkCore;

namespace Patterns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClerkController : ControllerBase
    {
        President president;
        Clerk clerk;
        PresidentNotes notes;
        Models.AppContext db;

        public ClerkController(Models.AppContext context)
        {
            president = new President();
            notes = new PresidentNotes();
            db = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            if(!await db.Notes.AnyAsync() || !await db.Clerks.AnyAsync())
            {
                return Content($"Databases are empty");
            }
            else
            {
                IEnumerable<PresidentNotes> notesCollection = await db.Notes.ToListAsync();
                IEnumerable<Clerk> clerksCollection = await db.Clerks.ToListAsync();
                string messageNotes = "";
                string messageClerks = "";

                foreach (var item in notesCollection)
                {
                    messageNotes += $"Id->{item.Id} || {item.PostedAt} : {item.DailyAgenda}\n";
                }

                foreach (var thief in clerksCollection)
                {
                    messageClerks += $"Id->{thief.Id} || {thief.Name} : {thief.Position}\n";
                }

                return Content(messageNotes+"\n\n\n"+messageClerks);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNewsByID(int id)
        {
            notes = await db.Notes.FirstOrDefaultAsync(n => n.Id == id);

            if (notes != null)
            {
                return Content(notes.Id + " || " + notes.DailyAgenda + " || " + notes.PostedAt);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> HireAnOfficial(string name, string position)
        {
            clerk = president.HireAnOfficial(name, position);

            await db.Clerks.AddAsync(clerk);
            await db.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("{content}")]
        public async Task<IActionResult> CreatePresidentMessage(string content)
        {
            notes = president.MakeAnAnnouncment(content);
            
            await db.Notes.AddAsync(notes);
            await db.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeAnOfficial(int id, string newPosition)
        {
            clerk = await db.Clerks.FirstOrDefaultAsync(c => c.Id == id);

            if (clerk != null)
            {
                clerk = president.ChangeAnOfficial(clerk, newPosition);
                await db.SaveChangesAsync();

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAnOfficial(int id)
        {
            clerk = await db.Clerks.FirstOrDefaultAsync(c=>c.Id==id);

            if (clerk != null)
            {
                clerk = president.ImprisonAnOfficial(clerk);

                if (clerk.Name == null && clerk.Position == null)
                {
                    db.Clerks.Remove(clerk);
                    await db.SaveChangesAsync();

                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}
