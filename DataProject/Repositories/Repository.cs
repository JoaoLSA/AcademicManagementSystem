using CoreProject.Models;
using CoreProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProject.Repositories
{
    public class Repository<T> : IRepository<T>
         where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetAllAsync()
            => Task.FromResult(new List<T>().AsEnumerable());
    }
}
