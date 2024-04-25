using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository.IRepository
{
	public interface IRepository<T> where T : class // making it a generic interface
	{
		// T - Category
		IEnumerable<T> GetAll(string? includedProperties = null);
		T Get(Expression<Func<T, bool>> filter, string? includedProperties = null);
		void Add(T entity);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entities);
		
	}
}

