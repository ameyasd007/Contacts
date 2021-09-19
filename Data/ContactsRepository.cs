using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Contacts
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly ContactsContext _context;
        private DbSet<Contact> _entities;

        public ContactsRepository(ContactsContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        private DbSet<Contact> Entities
        {
            get { return _entities ?? (_entities = _context.Contacts); }
        }

        public IList<Contact> GetAll()
        {
            return Entities.ToList();
        }

        public Contact GetById(int id)
        {
            return Entities.Find(id);
        }

        public void Insert(Contact contact)
        {
            Entities.Add(contact);
            _context.SaveChanges();
        }

        public void Update(Contact contact)
        {
            _context.Attach(contact);
            _context.Entry(contact).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = new Contact
            {
                Id = id
            };

            Entities.Attach(entity);
            Delete(entity);
        }

        public void Delete(Contact entity)
        {
            Entities.Remove(entity);
            _context.SaveChanges();
        }

    }
}