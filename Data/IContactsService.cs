
using System.Collections.Generic;

namespace Contacts
{
    public interface IContactsService
    {
        bool AddContact(Contact contact);
        Contact GetById(int id);
        IList<Contact> GetAllContacts();
        void Update(Contact contact);
        void Delete(int id);
    }
}