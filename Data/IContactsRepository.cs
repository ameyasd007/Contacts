
using System.Collections.Generic;

namespace Contacts
{
    public interface IContactsRepository
    {
        Contact GetById(int id);
        IList<Contact> GetAll();
        void Insert(Contact contact);
        void Update(Contact contact);
        void Delete(int id);
    }
}
