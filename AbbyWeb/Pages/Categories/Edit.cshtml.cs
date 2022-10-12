using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories;

public class Edit : PageModel
{
    [BindProperty]
    public Category Category { get; set; }
    private readonly ApplicationDbContext _db;

    public Edit(ApplicationDbContext db)
    {
        _db = db;
    }
   

    public void OnGet(int id)
    {
        Category = _db.AbbyCategory.FirstOrDefault(c=>c.Id == id);
    }

    public async Task<IActionResult> OnPost()
    {
        if (Category.Name == Category.DisaplayOrder.ToString())
        {
            ModelState.AddModelError("CustomError","Name and DisplayError cannot be the same");
        }
        if (ModelState.IsValid)
        {
            TempData["success"] = "Category Updated Successfully";
            _db.AbbyCategory.Update(Category);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }

        return Page();


    }
}