using BayMarch.Dto.Filter;
using BayMarch.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BayMarch.Data
{
    public interface IBaseInterface1<T>
    {
        public Task<T> Get(long id);
        public Task<IEnumerable<T>> GetList();
        public Task<IEnumerable<T>> GetAll(DefaultFilter df);
        public Task<bool> Update(T o);
        public Task<bool> Create(T o);
        public Task<Paging<T>> Page(DefaultFilter df);
        public Task<IEnumerable<T>> Search(T o);
    }
}
