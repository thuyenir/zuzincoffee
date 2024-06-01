using Microsoft.AspNetCore.Mvc;

namespace ZuZin.Models.Interfaces
{
    public interface IContactRepository
    {
        void AddContact(Contact contact);
        IEnumerable<Contact> ListContacts();
        void SaveChanges();
    }
}
