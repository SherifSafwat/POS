using BayMarch.Data;
using BayMarch.Dto.Filter;
using BayMarch.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BayMarch.Services
{
    public class UomService : IBaseInterface<Uom>
    {
        private readonly DataContext _context;
        public UomService(DataContext context)
        {
            _context = context;
        }
        async Task<Uom> IBaseInterface<Uom>.Get(long id)
        {
            return await _context.Uom.Where(x => x.Enabled == true && x.UomId == id).FirstOrDefaultAsync();
        }
        async Task<IEnumerable<Uom>> IBaseInterface<Uom>.GetList(DefaultFilter df)
        {
            return await _context.Uom.Where(x => x.Enabled == true).ToListAsync();
        }



        Task<bool> IBaseInterface<Uom>.Create(Uom o)
        {
            throw new System.NotImplementedException();
        }
        Task<IEnumerable<Uom>> IBaseInterface<Uom>.GetAll(DefaultFilter df)
        {
            throw new System.NotImplementedException();
        }
        Task<Paging<Uom>> IBaseInterface<Uom>.Page(DefaultFilter df)
        {
            throw new System.NotImplementedException();
        }
        Task<Paging<Uom>> IBaseInterface<Uom>.Search(DefaultFilter df)
        {
            throw new System.NotImplementedException();
        }
        Task<bool> IBaseInterface<Uom>.Update(Uom o)
        {
            throw new System.NotImplementedException();
        }
    }

}
