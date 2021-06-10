using BayMarch.Data;
using BayMarch.Models;
using System.Collections.Generic;
using System.Linq;

namespace BayMarch.Services
{
    public class UomService : IUomService
    {
        private readonly DataContext _context;
        public UomService(DataContext context)
        {
            _context = context;
        }

        public List<Uom> GetDefault()
        {
            return _context.Uom.ToList();
        }       
    }
}
