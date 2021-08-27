using BayMarch.Data;
using BayMarch.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BayMarch.Dto.Filter;
using System;
using DynamicExpressions.Linq;

namespace BayMarch.Services
{
    public class TypeService : IBaseInterface<Models.Type>
    {
        private readonly DataContext _context;
        public TypeService(DataContext context)
        {
            _context = context;
        }              
        async Task<Models.Type> IBaseInterface<Models.Type>.Get(long id)
        {
            return await _context.Type.Where(x => x.Enabled == true && x.TypeId == id).FirstOrDefaultAsync();
        }
        async Task<IEnumerable<Models.Type>> IBaseInterface<Models.Type>.GetList(DefaultFilter df)
        {
            return await _context.Type.Where(x => x.Enabled == true).ToListAsync();
        }
        async Task<IEnumerable<Models.Type>> IBaseInterface<Models.Type>.GetAll(DefaultFilter df)
        {
            if (!String.IsNullOrEmpty(df.Orderby) && df.IsDesc)
                return await _context.Type.OrderBy(df.Orderby + " desc").ToListAsync();

            if (!String.IsNullOrEmpty(df.Orderby))
                return await _context.Type.OrderBy(df.Orderby).ToListAsync();

            return await _context.Type.ToListAsync();
        }


        Task<bool> IBaseInterface<Models.Type>.Create(Models.Type o)
        {
            throw new System.NotImplementedException();
        }    
        Task<Paging<Models.Type>> IBaseInterface<Models.Type>.Page(DefaultFilter df)
        {
            throw new System.NotImplementedException();
        }
        Task<Paging<Models.Type>> IBaseInterface<Models.Type>.Search(DefaultFilter df)
        {
            throw new System.NotImplementedException();
        }
        Task<bool> IBaseInterface<Models.Type>.Update(Models.Type o)
        {
            throw new System.NotImplementedException();
        }
    }

}
