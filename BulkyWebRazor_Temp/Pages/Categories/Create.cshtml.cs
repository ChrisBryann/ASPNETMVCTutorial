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
    [BindProperties] // or can just define at class level to bind all properties in this model
	public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty] // to be binded and be available in the post handler
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Category obj)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
