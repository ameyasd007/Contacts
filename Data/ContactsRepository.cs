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

        public void Insert(Contact entity)
        {
            Entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Contact entity)
        {
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            // Create a new instance of an entity (BaseEntity) and add the id.
            var entity = new Contact
            {
                Id = id
            };

            // Attach the entity to the context and call the delete method.
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