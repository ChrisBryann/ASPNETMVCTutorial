﻿using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
	public class ProductRepository : Repository<Product>, IProductRepository // Repository should come first before IProductRepository to define pre-existing methods
	{                                                                           // this prevents defining the base repository methods again
        private readonly ApplicationDbContext _db;
		public ProductRepository(ApplicationDbContext db) : base(db)
		{
            _db = db;
		}

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
