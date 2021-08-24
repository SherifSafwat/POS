using AutoMapper;
using BayMarch.Data;
using BayMarch.Dto.Filter;
using BayMarch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicExpressions.Linq;

namespace BayMarch.Services
{
    public class SupplierService : IBaseInterface<Supplier>
    {
        private readonly long _sellerId;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _htttpAccessor;

        public SupplierService(DataContext context, IHttpContextAccessor htttpAccessor)
        {
            _context = context;
            _htttpAccessor = htttpAccessor;

            var userId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).Id;
            _sellerId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).SellerId;
        }

        async Task<Supplier> IBaseInterface<Supplier>.Get(long id)
        {
            return await _context.Supplier.FindAsync(id);
        }

        async Task<IEnumerable<Supplier>> IBaseInterface<Supplier>.GetList(DefaultFilter df)
        {
            return await _context.Supplier.Where(x => x.Enabled == true && x.SellerId == _sellerId).ToListAsync();
        }

        async Task<bool> IBaseInterface<Supplier>.Create(Supplier parentSupplier)
        {
            await _context.Supplier.AddAsync(parentSupplier);
            return await _context.SaveChangesAsync() > 0;
        }

        async Task<bool> IBaseInterface<Supplier>.Update(Supplier obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        async Task<IEnumerable<Supplier>> IBaseInterface<Supplier>.GetAll(DefaultFilter df)
        {
            if (!String.IsNullOrEmpty(df.Orderby) && df.IsDesc)
                return await _context.Supplier.OrderBy(df.Orderby + " desc").ToListAsync();

            if (!String.IsNullOrEmpty(df.Orderby))
                return await _context.Supplier.OrderBy(df.Orderby).ToListAsync();

            return await _context.Supplier.ToListAsync();
        }

        async Task<Paging<Supplier>> IBaseInterface<Supplier>.Page(DefaultFilter df)
        {
            Paging<Supplier> resault = new Paging<Supplier>();
            resault.TotalPages = (int)Math.Ceiling((double)_context.Supplier.Count() / df.MaxPageSize);
            resault.CurrentPage = df.PageNumber;

            if (!String.IsNullOrEmpty(df.Orderby) && df.IsDesc)
            {
                resault.Data = await _context.Supplier.Where(x => x.Enabled == true && x.SellerId == _sellerId)
                    .OrderBy(df.Orderby + " desc").Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();
                return resault;
            }

            if (!String.IsNullOrEmpty(df.Orderby))
            {
                resault.Data = await _context.Supplier.Where(x => x.Enabled == true && x.SellerId == _sellerId)
                    .OrderBy(df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();
                return resault;
            }


            resault.Data = await _context.Supplier.Where(x => x.Enabled == true && x.SellerId == _sellerId)
                .Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();
            return resault;

        }

        async Task<Paging<Supplier>> IBaseInterface<Supplier>.Search(DefaultFilter df)
        {
            Paging<Supplier> resault = new Paging<Supplier>();
            resault.TotalPages = (int)Math.Ceiling((double)_context.Supplier.Count() / df.MaxPageSize);
            resault.CurrentPage = df.PageNumber;

            if (!String.IsNullOrEmpty(df.Orderby) && df.IsDesc)
            {
                resault.Data = await _context.Supplier.Where(x => (x.Enabled == true && x.SellerId == _sellerId) && x.SupplierId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
                    .OrderBy(df.Orderby + " desc").Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();

                return resault;
            }

            if (!String.IsNullOrEmpty(df.Orderby))
            {
                resault.Data = await _context.Supplier.Where(x => (x.Enabled == true && x.SellerId == _sellerId) && x.SupplierId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
                    .OrderBy(df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();

                return resault;
            }

            resault.Data = await _context.Supplier.Where(x => (x.Enabled == true && x.SellerId == _sellerId) && x.SupplierId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
                .Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();

            return resault;
        }



    }
}





/*private readonly string _userId;
private readonly long _sellerId;

private readonly IHttpContextAccessor _htttpAccessor;
private readonly DataContext _context;
private readonly IMapper _mapper;

public SupplierService(DataContext context, IMapper mapper, IHttpContextAccessor htttpAccessor)
{
    _htttpAccessor = htttpAccessor;
    _context = context;
    _mapper = mapper;

    //_userId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).Id;
    _sellerId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).SellerId;
}

public bool Create(Supplier Supplier)
{
    Supplier.SellerId = _sellerId;
    _context.Supplier.Add(Supplier);
    return _context.SaveChanges() > 0;
}

public bool Delete(long id)
{
    var Supplier = _context.Supplier.Find(id);
    _context.Supplier.Remove(Supplier);
    return _context.SaveChanges() > 0;
}

public Supplier Get(long id)
{
    return _context.Supplier.Find(id);
}

//public Paging<Supplier> GetAll()
//{
//    return _context.Supplier.ToList();
//}

public Paging<Supplier> GetDefault()
{
    return GetPage(new DefaultFilter { PageNumber = 1, Orderby = "CreationDate" });
}

public IEnumerable<Supplier> GetList()
{
    throw new NotImplementedException();
}

public Paging<Supplier> GetPage(DefaultFilter df)
{

    Paging<Supplier> resault = new Paging<Supplier>();
    resault.TotalPages = (int)Math.Ceiling((double)_context.Supplier.Where(x => x.SellerId == _sellerId).Count() / df.MaxPageSize);
    resault.CurrentPage = df.PageNumber;

    if (df.IsDesc) //err
    {
        resault.Data = _context.Supplier.Where(x => x.SellerId == _sellerId).OrderBy(p => df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToList();
        return resault;
    }

    //resault.Data = _context.Supplier.Where(x => (x.SupplierId == df.Id || x.EName.Contains(df.EName)) && x.SellerId == _sellerId).ToList();
    //resault.Data = _context.Supplier.Where(x => (x.SupplierId == df.Id || x.EName.Contains(df.EName)) && x.SellerId == _sellerId).OrderBy(p => df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToList();

    return resault;

}

public bool Update(Supplier supplier)
{
    _context.Entry(supplier).State = EntityState.Modified;
    return _context.SaveChanges() > 0;
}
}
}

/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BayMarch.Services
{
public class SupplierService
{
}
}
*/