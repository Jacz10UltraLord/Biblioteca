using Biblioteca.DTO.Models;
using Biblioteca.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Create()
        {
            var authors = await new AuthorServices().GetAuthors();
            ViewData["authors"] = new SelectList(authors, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                var request = await new BookServices().Create(book);
                if (request.Success)
                { return RedirectToAction("Create", "book"); }

            }
            var authors = await new AuthorServices().GetAuthors();
            ViewData["authors"] = new SelectList(authors, "Id", "Name");
            return View(book);
        }
    }
}