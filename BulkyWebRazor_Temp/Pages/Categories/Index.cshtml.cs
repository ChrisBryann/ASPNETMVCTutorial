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
	public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Category> CategoryList { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet() //must have On prepended for this GET method to work, same goes for other methods
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
