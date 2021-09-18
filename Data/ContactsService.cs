
using System.Collections.Generic;

namespace Contacts
{
    public class ContactsService : IContactsService
    {
        private readonly IContactsRepository _contactRepository;

        public ContactsService(IContactsRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public bool AddContact(Contact contact)
        {
            // Validate etc.
            _contactRepository.Insert(contact);

            // return validation result.
            return true;
        }

        public IList<Contact> GetAllContacts() => _contactRepository.GetAll();
        public Contact GetById(int id) => _contactRepository.GetById(id);
        public void Update(Contact contact) => _contactRepository.Update(contact);
        public void Delete(int id) => _contactRepository.Delete(id);

    }
}