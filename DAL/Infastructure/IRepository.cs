using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infastructure
{
    public interface IRepository<T> where T : class
    {
        public T GetByID(Guid ID);
        public List<T> GetAll();
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}
