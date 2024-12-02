using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazor.Data;
using WebRazor.Models;

namespace WebRazor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Category> CategoryList { get; set; }

        [BindProperty]
        public int Id { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            CategoryList=_db.Categories.ToList();
        }

        public IActionResult OnPost()
        {
            var category = _db.Categories.Find(Id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
                //TempData["SuccessMessage"] = "Category deleted successfully.";
            }
           
            return RedirectToPage(); // ?????????? ?? ?????? ????????.
        }
    }
}
