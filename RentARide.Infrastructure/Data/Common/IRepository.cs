using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Infrastructure.Data.Common
{
	public interface IRepository
	{
		IQueryable<T> All<T>() where T : class;

		IQueryable<T> AllReadOnly<T>() where T : class;

		Task Add<T>(T entity) where T : class;

		Task <T?> GetById<T> (object id) where T : class;

        Task<int> SaveChanges();
	}
}
