using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories;

public class Delete : PageModel
{
    [BindProperty]
    public Category Category { get; set; }
    private readonly ApplicationDbContext _db;

    public Delete(ApplicationDbContext db)
    {
        _db = db;
    }
   

    public void OnGet(int id)
    {
        Category = _db.AbbyCategory.FirstOrDefault(c=>c.Id == id);
    }

    public async Task<IActionResult> OnPost()
    {
      
            var categoryFromDB = _db.AbbyCategory.Find(Category.Id);
            if (categoryFromDB != null)
            {
                TempData["success"] = "Category Deleted Successfully";
                _db.Remove(categoryFromDB);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
           return Page();


    }
}