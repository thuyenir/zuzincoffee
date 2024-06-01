using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZuZin.Data;
using ZuZin.Models;
using ZuZin.Models.Interfaces;
using ZuZin.Models.Services;
namespace ZuZin.Controllers
{
    public class ContactController : Controller
    {
        private IContactRepository contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    contactRepository.AddContact(contact);
                    contactRepository.SaveChanges();
                    return RedirectToAction("ContactComplex");
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "An error occurred while processing your request. Please try again later.";
                    return View(contact);
                }
            }
            return View(contact);
        }
        // GET: /Contact/ThankYou
        public ActionResult ContactComplex()
        {
            return View();
        }
        public IActionResult ListContact()
        {
            return View(contactRepository.ListContacts());
        }
    }
}
