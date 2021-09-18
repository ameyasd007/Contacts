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
            try
            {
                return _contactsService.GetAllContacts();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return default;
        }
    }
}
