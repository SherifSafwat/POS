using BayMarch.Data;
using BayMarch.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BayMarch.Services
{
    //public class BaseService : IBaseInterface<Models.Type>
    public class BaseService<T> //: IBaseInterface<T>
    {
        /*
        public T obj;
        public System.Type tt;


        private readonly DataContext _context;
        //public DbSet<Models.Type> _set;
        public object _set;

        public BaseService(DataContext context)
        {
            _context = context;
            if (typeof(T).ToString() == "BayMarch.Models.Type")
                //_set = (DbSet<Models.Type>) _context.Type;
                _set = _context.Type;

            //tt = obj.GetType();
        }

     

        T IBaseInterface<T>.Get(long id)
        {
            throw new System.NotImplementedException();
        }


        IEnumerable<T> IBaseInterface<T>.GetList1()
        {
            return ((IEnumerable<T>)_set).ToList();
        }


        //async Task<IQueryable<T>>  IBaseInterface<T>.GetList()
        async Task<ActionResult<IEnumerable<T>>> IBaseInterface<T>.GetList()
        {
            //return (IQueryable<T>)((IEnumerable<T>)_set).ToList();
            return await ( (IQueryable<T>)_set).ToListAsync();

            //return await ((IQueryable<T>)_set).Select(x => new { x.ServerName, x.ProcessID, x.Username }).ToListAsync();

            //DbSet
            //_context.(DbSet tt).
            //_context.(typeof(this.obj)).

            //var tt = T.GetType();

            //throw new System.NotImplementedException();
        }
        */
    }
}
