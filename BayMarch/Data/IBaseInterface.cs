using BayMarch.Dto.Filter;
using BayMarch.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BayMarch.Data
{
    public interface IBaseInterface<T>
    {
        public Task<T> Get(long id);
        public Task<bool> Create(T obj);
        public Task<bool> Update(T obj);        
        public Task<Paging<T>> Page(DefaultFilter df);
        public Task<Paging<T>> Search(DefaultFilter df);
        public Task<IEnumerable<T>> GetAll(DefaultFilter df);
        public Task<IEnumerable<T>> GetList(DefaultFilter df);
    }
}
