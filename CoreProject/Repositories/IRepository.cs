using CoreProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProject.Repositories
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        IQueryable<T> GetAll();

        public Task<IEnumerable<TViewModel>> GetAllProjectedAsync<TViewModel>();
    }
}
