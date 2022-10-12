using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories;

public class Create : PageModel
{
    [BindProperty]
    public Category Category { get; set; }
    private readonly ApplicationDbContext _db;

    public Create(ApplicationDbContext db)
    {
        _db = db;
    }
   

    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPost()
    {
        if (Category.Name == Category.DisaplayOrder.ToString())
        {
            ModelState.AddModelError("CustomError","Name and DisplayError cannot be the same");
        }
        if (ModelState.IsValid)
        {
            TempData["success"] = "Category Created Successfully";
            await _db.AbbyCategory.AddAsync(Category);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }

        return Page();


    }
}