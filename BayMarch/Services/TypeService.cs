using BayMarch.Data;
using BayMarch.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BayMarch.Dto.Filter;

namespace BayMarch.Services
{
    public class TypeService : IBaseInterface<Type>
    {
        private readonly DataContext _context;
        public TypeService(DataContext context)
        {
            _context = context;
        }              
        async Task<Type> IBaseInterface<Type>.Get(long id)
        {
            return await _context.Type.Where(x => x.Enabled == true && x.TypeId == id).FirstOrDefaultAsync();
        }
        async Task<IEnumerable<Type>> IBaseInterface<Type>.GetList(DefaultFilter df)
        {
            return await _context.Type.Where(x => x.Enabled == true).ToListAsync();
        }



        Task<bool> IBaseInterface<Type>.Create(Type o)
        {
            throw new System.NotImplementedException();
        }
        Task<IEnumerable<Type>> IBaseInterface<Type>.GetAll(DefaultFilter df)
        {
            throw new System.NotImplementedException();
        }        
        Task<Paging<Type>> IBaseInterface<Type>.Page(DefaultFilter df)
        {
            throw new System.NotImplementedException();
        }
        Task<Paging<Type>> IBaseInterface<Type>.Search(DefaultFilter df)
        {
            throw new System.NotImplementedException();
        }
        Task<bool> IBaseInterface<Type>.Update(Type o)
        {
            throw new System.NotImplementedException();
        }
    }

}
