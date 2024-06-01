using Microsoft.EntityFrameworkCore;
using ZuZin.Data;
using ZuZin.Models.Interfaces;

namespace ZuZin.Models.Services
{
    public class ContactRepository:IContactRepository
    {
        private ZuZinDbContext dbContext;
        public ContactRepository(ZuZinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddContact(Contact contact)
        {
            dbContext.Contacts.Add(contact);
        }
        public IEnumerable<Contact> ListContacts()
        {
            return dbContext.Contacts;
        }
        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
