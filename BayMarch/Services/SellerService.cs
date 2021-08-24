using BayMarch.Data;
using BayMarch.Dto.Filter;
using BayMarch.Dto.Request;
using BayMarch.Models;
using DynamicExpressions.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BayMarch.Services
{
    public class SellerService : IBaseInterface<Seller>
    {
        private readonly DataContext _context;

        public SellerService(DataContext context) 
        {
            _context = context;
        }

        async Task<Seller> IBaseInterface<Seller>.Get(long id)
        {
            return await _context.Seller.FindAsync(id);
        }

        async Task<IEnumerable<Seller>> IBaseInterface<Seller>.GetList(DefaultFilter df)
        {
            return await _context.Seller.Where(x => x.Enabled == true).ToListAsync();
        }

        async Task<bool> IBaseInterface<Seller>.Create(Seller seller)
        {
            await _context.Seller.AddAsync(seller);
            return await _context.SaveChangesAsync() > 0;
        }

        async Task<bool> IBaseInterface<Seller>.Update(Seller obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        async Task<IEnumerable<Seller>> IBaseInterface<Seller>.GetAll(DefaultFilter df)
        {            
            if(!String.IsNullOrEmpty(df.Orderby) && df.IsDesc )
                return await _context.Seller.OrderBy(df.Orderby + " desc").ToListAsync();

            if (!String.IsNullOrEmpty(df.Orderby))
                return await _context.Seller.OrderBy(df.Orderby).ToListAsync();

            return await _context.Seller.ToListAsync();
        }

        async Task<Paging<Seller>> IBaseInterface<Seller>.Page(DefaultFilter df)
        {
            Paging<Seller> resault = new Paging<Seller>();
            resault.TotalPages = (int)Math.Ceiling((double)_context.Seller.Count() / df.MaxPageSize);
            resault.CurrentPage = df.PageNumber;

            if (!String.IsNullOrEmpty(df.Orderby) && df.IsDesc)
            {
                resault.Data = await _context.Seller.OrderBy(df.Orderby + " desc").Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();
                return resault;
            }
                
            if (!String.IsNullOrEmpty(df.Orderby))
            {
                resault.Data = await _context.Seller.OrderBy(df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();
                return resault;
            }
                

            resault.Data = await _context.Seller.Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();
            return resault;

        }

        async Task<Paging<Seller>> IBaseInterface<Seller>.Search(DefaultFilter df)
        {
            Paging<Seller> resault = new Paging<Seller>();
            resault.TotalPages = (int)Math.Ceiling((double)_context.Seller.Count() / df.MaxPageSize);
            resault.CurrentPage = df.PageNumber;

            if (!String.IsNullOrEmpty(df.Orderby) && df.IsDesc)
            {
                resault.Data = await _context.Seller.Where(x => x.SellerId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
                    .OrderBy(df.Orderby + " desc").Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();

                return resault;
            }

            if (!String.IsNullOrEmpty(df.Orderby))
            {
                resault.Data = await _context.Seller.Where(x => x.SellerId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
                    .OrderBy(df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();

                return resault;
            }

            resault.Data = await _context.Seller.Where(x => x.SellerId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
                .Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();

            return resault;
        }


    }
}
