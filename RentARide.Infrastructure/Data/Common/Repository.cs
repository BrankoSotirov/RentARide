using Microsoft.EntityFrameworkCore;
using RentARide.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Infrastructure.Data.Common
{
	public class Repository : IRepository
	{
		private readonly DbContext context;

		public Repository(ApplicationDbContext _context)
		{
			context = _context;
		}

		private DbSet<T> DbSet<T>() where T : class 
		{
			return context.Set<T>();
		}
		public IQueryable< T> All<T>() where T : class
		{
			return DbSet<T>()
				.AsQueryable();

		}

		public IQueryable<T> AllReadOnly<T>() where T : class
		{
			return DbSet<T>()
				.AsNoTracking();
		}

        public async Task Add<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        public async Task<int> SaveChanges()
        {
           return await context.SaveChangesAsync();
        }

        public async Task<T?> GetById<T>(object id) where T : class
        {
           return await DbSet<T>().FindAsync(id);
        }
    }
}
