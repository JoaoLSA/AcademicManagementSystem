using AutoMapper;
using CoreProject.Models;
using CoreProject.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProject.Repositories
{
    public class Repository<T, TDbContext> : IRepository<T>
         where T : BaseEntity
         where TDbContext : DbContext
    {
        private TDbContext _context;
        private DbSet<T> _currentSet;

        public Repository(TDbContext ctx)
        {
            _context = ctx;
            _currentSet = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
            => _currentSet;

        public Task<IEnumerable<TViewModel>> GetAllProjectedAsync<TViewModel>()
            => Task.FromResult(new List<TViewModel>().AsEnumerable());
    }
}
