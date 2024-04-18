using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
	public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty] // to be binded and be available in the post handler
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if(id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category); // based on the ID of obj, it will auto update the corresponding data in db
                _db.SaveChanges();
                TempData["success"] = "Category updated succesfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
