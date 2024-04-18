using System;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository // Repository should come first before ICategoryRepository to define pre-existing methods
	{                                                                           // this prevents defining the base repository methods again
        private readonly ApplicationDbContext _db;
		public CategoryRepository(ApplicationDbContext db) : base(db)
		{
            _db = db;
		}

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}

