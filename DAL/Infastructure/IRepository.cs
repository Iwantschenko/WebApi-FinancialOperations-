using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infastructure
{
    public interface IRepository<T> where T : class
    {
        public Task<T> GetByID(Guid ID);
        public Task<List<T>> GetAll();
        public Task Add(T entity);
        public Task AddRange(IEnumerable<T> entities);
        public void Update(T entity);
        public void RemoveEntity(T entity);
        public Task Delete(Guid ID );
    }
}
