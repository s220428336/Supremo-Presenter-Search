using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supremo_Presenter_Search.Areas.Identity.Data;
using Supremo_Presenter_Search.Models;

namespace Supremo_Presenter_Search.Controllers
{
    public class VotesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public VotesController (ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            IEnumerable<VotesModel> objList = dbContext.tblVotes;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VotesModel votes)
        {
            if (ModelState.IsValid)
            {
                dbContext.tblVotes.Add(votes);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(votes);
        }

        public IActionResult Edit(int? Id)
        {
            if(Id==null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblVotes.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VotesModel votes)
        {
            dbContext.tblVotes.Update(votes);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int? Id)
        {
            if(Id==null || Id == 0)
            {
                return NotFound();
            }
            var obj = dbContext.tblVotes.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(VotesModel votes)
        {
            dbContext.tblVotes.Remove(votes);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
