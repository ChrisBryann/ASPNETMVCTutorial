using System;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;

namespace Bulky.DataAccess.Repository
{
    // centralizes all db into one resource and combine any global methods into just one
    // implements all the repos in this class when instantiated, meaning that if we only need one repo, the other repos are still created and wont be used.
	public class UnitOfWork : IUnitOfWork
	{
        private readonly ApplicationDbContext _db;
        public ICategoryRepository CategoryRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CategoryRepository = new CategoryRepository(_db);
            ProductRepository = new ProductRepository(_db);
        }

        

        public void Save()
        {
            // save method is not dependent on the Table type in the database. it is a global method that will save changes of any type
            _db.SaveChanges();
        }
    }
}

