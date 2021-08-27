using DynamicExpressions.Linq;
using BayMarch.Data;
using BayMarch.Dto.Filter;
using BayMarch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BayMarch.Services
{
    public class CustomerService : IBaseInterface<Customer>
    {
        private readonly long _sellerId;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _htttpAccessor;

        public CustomerService(DataContext context, IHttpContextAccessor htttpAccessor)
        {
            _context = context;
            _htttpAccessor = htttpAccessor;

            var userId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).Id;
            _sellerId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).SellerId;
        }

        async Task<Customer> IBaseInterface<Customer>.Get(long id)
        {
            return await _context.Customer.FindAsync(id);
        }

        async Task<IEnumerable<Customer>> IBaseInterface<Customer>.GetList(DefaultFilter df)
        {
            return await _context.Customer.Where(x => x.Enabled == true && x.SellerId == _sellerId).ToListAsync();
        }

        async Task<bool> IBaseInterface<Customer>.Create(Customer customer)
        {
            customer.SellerId = _sellerId;
            await _context.Customer.AddAsync(customer);
            return await _context.SaveChangesAsync() > 0;
        }

        async Task<bool> IBaseInterface<Customer>.Update(Customer obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        async Task<IEnumerable<Customer>> IBaseInterface<Customer>.GetAll(DefaultFilter df)
        {
            if (!String.IsNullOrEmpty(df.Orderby) && df.IsDesc)
                return await _context.Customer.OrderBy(df.Orderby + " desc").ToListAsync();

            if (!String.IsNullOrEmpty(df.Orderby))
                return await _context.Customer.OrderBy(df.Orderby).ToListAsync();

            return await _context.Customer.OrderBy(x => x.CustomerId).ToListAsync();
        }

        async Task<Paging<Customer>> IBaseInterface<Customer>.Page(DefaultFilter df)
        {
            double i = await _context.Customer.CountAsync();

            Paging<Customer> resault = new Paging<Customer>();
            resault.TotalPages = (int)Math.Ceiling(i / df.MaxPageSize);
            resault.CurrentPage = df.PageNumber;


            if (!String.IsNullOrEmpty(df.Orderby) && df.IsDesc)
            {
                resault.Data = await _context.Customer.Where(x => x.SellerId == _sellerId)
                    .OrderBy(df.Orderby + " desc").Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();
                return resault;
            }

            if (!String.IsNullOrEmpty(df.Orderby))
            {
                resault.Data = await _context.Customer.Where(x => x.SellerId == _sellerId)
                    .OrderBy(df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();
                return resault;
            }


            resault.Data = await _context.Customer.Where(x => x.SellerId == _sellerId)
                .Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();

            return resault;

        }

        async Task<Paging<Customer>> IBaseInterface<Customer>.Search(DefaultFilter df)
        {  
            double i = await _context.Customer.Where(x => (x.SellerId == _sellerId) && x.CustomerId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter)).CountAsync();

            Paging<Customer> resault = new Paging<Customer>();
            resault.TotalPages = (int)Math.Ceiling( i / df.MaxPageSize);
            resault.CurrentPage = df.PageNumber;

            if (!String.IsNullOrEmpty(df.Orderby) && df.IsDesc)
            {
                resault.Data = await _context.Customer.Where(x => (x.SellerId == _sellerId) && x.CustomerId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
                    .OrderBy(df.Orderby + " desc").Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();

                return resault;
            }

            if (!String.IsNullOrEmpty(df.Orderby))
            {
                resault.Data = await _context.Customer.Where(x => (x.SellerId == _sellerId) && x.CustomerId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
                    .OrderBy(df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();

                return resault;
            }

            resault.Data = await _context.Customer.Where(x => (x.SellerId == _sellerId) && x.CustomerId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
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

public CustomerService(DataContext context, IMapper mapper, IHttpContextAccessor htttpAccessor)
{
    _htttpAccessor = htttpAccessor;
    _context = context;
    _mapper = mapper;

    //_userId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).Id;
    _sellerId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).SellerId;
}

public bool Create(Customer customer)
{
    customer.SellerId = _sellerId;
    _context.Customer.Add(customer);
    return _context.SaveChanges() > 0;
}

public Customer Get(long id)
{
    throw new System.NotImplementedException();
}

public IEnumerable<Customer> GetList()
{
    throw new System.NotImplementedException();
}
}
}
*/