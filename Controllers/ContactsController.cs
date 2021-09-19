using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Contacts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IContactsService _contactsService;

        public ContactsController(ILogger<ContactsController> logger, IContactsService contactsService)
        {
            _logger = logger;
            _contactsService = contactsService;
        }

        [HttpGet]
        public IList<Contact> Get()
        {
            return _contactsService.GetAllContacts();
        }

        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return _contactsService.GetById(id);
        }

        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest("invalid parameters");

            _contactsService.AddContact(contact);

            return CreatedAtAction(nameof(Get), new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Contact contact)
        {
            if (id != contact.Id)
                return BadRequest("Id mismatch");
            if (!ModelState.IsValid)
                return BadRequest("invalid parameters");

            _contactsService.Update(contact);

            return Ok(contact);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _contactsService.Delete(id);

            return NoContent();
        }
    }
}
