using BraviSimpleCRUD.Data;
using BraviSimpleCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BraviSimpleCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsDbContext _contactsDbContext;

        public ContactsController(ContactsDbContext contactsDbContext)
        {
            this._contactsDbContext = contactsDbContext;    
        }

        //Get All Contacts
        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _contactsDbContext.Contacts.ToListAsync();
            return Ok(contacts);
        }

        //Get Single Contact
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetContact")]
        public async Task<IActionResult> GetContact([FromRoute] Guid id)
        {
            var contact = await _contactsDbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            if(contact != null)
            {
                return Ok(contact);
            }
            return NotFound("Contact not found.");
        }

        //Add Contact
        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] Contact contact)
        {
            contact.Id = Guid.NewGuid();
            await _contactsDbContext.Contacts.AddRangeAsync(contact);
            await _contactsDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
        }

        //Update Contact
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, [FromBody] Contact contact)
        {
            var existingContact = await _contactsDbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            if(contact != null) {
                existingContact.Name = contact.Name;
                existingContact.Email = contact.Email;
                existingContact.Phone = contact.Phone;
                await _contactsDbContext.SaveChangesAsync();
                return Ok(existingContact);
            }

            return NotFound("Contact not found.");
        }

        //Delete Contact
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var existingContact = await _contactsDbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            if (existingContact != null)
            {
                _contactsDbContext.Remove(existingContact);
                await _contactsDbContext.SaveChangesAsync();
                return Ok(existingContact);
            }

            return NotFound("Contact not found.");
        }
    }
}
