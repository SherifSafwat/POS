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
    public class PaymentService : IBaseInterface<Payment>
    {

        private readonly long _sellerId;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _htttpAccessor;

        public PaymentService(DataContext context, IHttpContextAccessor htttpAccessor)
        {
            _context = context;
            _htttpAccessor = htttpAccessor;

            var userId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).Id;
            _sellerId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).SellerId;
        }

        async Task<Payment> IBaseInterface<Payment>.Get(long id)
        {
            return await _context.Payment.FindAsync(id);
        }

        async Task<IEnumerable<Payment>> IBaseInterface<Payment>.GetList(DefaultFilter df)
        {
            return await _context.Payment.Where(x => x.Enabled == true && x.SellerId == _sellerId).ToListAsync();
        }

        async Task<bool> IBaseInterface<Payment>.Create(Payment parentCategory)
        {
            await _context.Payment.AddAsync(parentCategory);
            return await _context.SaveChangesAsync() > 0;
        }

        async Task<bool> IBaseInterface<Payment>.Update(Payment obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        async Task<IEnumerable<Payment>> IBaseInterface<Payment>.GetAll(DefaultFilter df)
        {
            if (!String.IsNullOrEmpty(df.Orderby) && df.IsDesc)
                return await _context.Payment.OrderBy(df.Orderby + " desc").ToListAsync();

            if (!String.IsNullOrEmpty(df.Orderby))
                return await _context.Payment.OrderBy(df.Orderby).ToListAsync();

            return await _context.Payment.ToListAsync();
        }

        async Task<Paging<Payment>> IBaseInterface<Payment>.Page(DefaultFilter df)
        {
            Paging<Payment> resault = new Paging<Payment>();
            resault.TotalPages = (int)Math.Ceiling((double)_context.Payment.Count() / df.MaxPageSize);
            resault.CurrentPage = df.PageNumber;

            if (!String.IsNullOrEmpty(df.Orderby) && df.IsDesc)
            {
                resault.Data = await _context.Payment.OrderBy(df.Orderby + " desc").Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();
                return resault;
            }

            if (!String.IsNullOrEmpty(df.Orderby))
            {
                resault.Data = await _context.Payment.OrderBy(df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();
                return resault;
            }


            resault.Data = await _context.Payment.Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();
            return resault;

        }

        async Task<Paging<Payment>> IBaseInterface<Payment>.Search(DefaultFilter df)
        {
            Paging<Payment> resault = new Paging<Payment>();
            resault.TotalPages = (int)Math.Ceiling((double)_context.Payment.Count() / df.MaxPageSize);
            resault.CurrentPage = df.PageNumber;

            if (!String.IsNullOrEmpty(df.Orderby) && df.IsDesc)
            {
                resault.Data = await _context.Payment.Where(x => x.PaymentId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
                    .OrderBy(df.Orderby + " desc").Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();

                return resault;
            }

            if (!String.IsNullOrEmpty(df.Orderby))
            {
                resault.Data = await _context.Payment.Where(x => x.PaymentId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
                    .OrderBy(df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();

                return resault;
            }

            resault.Data = await _context.Payment.Where(x => x.PaymentId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
                .Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();

            return resault;
        }



    }
}

/*private readonly DataContext _context;
public PaymentService(DataContext context)
{
    _context = context;
}

public Payment Get(long id)
{
    throw new System.NotImplementedException();
}

public List<Payment> GetDefault()
{
    return _context.Payment.ToList();
}

public IEnumerable<Payment> GetList()
{
    throw new System.NotImplementedException();
}
}
}
*/