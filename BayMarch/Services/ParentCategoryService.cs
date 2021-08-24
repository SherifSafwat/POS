using BayMarch.Data;
using BayMarch.Dto.Filter;
using BayMarch.Models;
using DynamicExpressions.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BayMarch.Services
{
    public class ParentCategoryService : IBaseInterface<ParentCategory>
    {
        private readonly long _sellerId;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _htttpAccessor;

        public ParentCategoryService(DataContext context, IHttpContextAccessor htttpAccessor) 
        {
            _context = context;
            _htttpAccessor = htttpAccessor;

            var userId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).Id;
            _sellerId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).SellerId;
        }

        async Task<ParentCategory> IBaseInterface<ParentCategory>.Get(long id)
        {
            return await _context.ParentCategory.FindAsync(id);
        }

        async Task<IEnumerable<ParentCategory>> IBaseInterface<ParentCategory>.GetList(DefaultFilter df)
        {
            var obj = await _context.Seller.Where(x => x.SellerId == _sellerId).FirstOrDefaultAsync();
            var typeid = obj.TypeId;
            return await _context.ParentCategory.Where(x => x.Enabled == true && x.TypeId == typeid).ToListAsync();
        }

        async Task<bool> IBaseInterface<ParentCategory>.Create(ParentCategory parentCategory)
        {
            await _context.ParentCategory.AddAsync(parentCategory);
            return await _context.SaveChangesAsync() > 0;
        }

        async Task<bool> IBaseInterface<ParentCategory>.Update(ParentCategory obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        async Task<IEnumerable<ParentCategory>> IBaseInterface<ParentCategory>.GetAll(DefaultFilter df)
        {            
            if(!String.IsNullOrEmpty(df.Orderby) && df.IsDesc )
                return await _context.ParentCategory.OrderBy(df.Orderby + " desc").ToListAsync();

            if (!String.IsNullOrEmpty(df.Orderby))
                return await _context.ParentCategory.OrderBy(df.Orderby).ToListAsync();

            return await _context.ParentCategory.ToListAsync();
        }

        async Task<Paging<ParentCategory>> IBaseInterface<ParentCategory>.Page(DefaultFilter df)
        {
            Paging<ParentCategory> resault = new Paging<ParentCategory>();
            resault.TotalPages = (int)Math.Ceiling((double)_context.ParentCategory.Count() / df.MaxPageSize);
            resault.CurrentPage = df.PageNumber;

            if (!String.IsNullOrEmpty(df.Orderby) && df.IsDesc)
            {
                resault.Data = await _context.ParentCategory.OrderBy(df.Orderby + " desc").Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();
                return resault;
            }
                
            if (!String.IsNullOrEmpty(df.Orderby))
            {
                resault.Data = await _context.ParentCategory.OrderBy(df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();
                return resault;
            }
                

            resault.Data = await _context.ParentCategory.Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();
            return resault;

        }

        async Task<Paging<ParentCategory>> IBaseInterface<ParentCategory>.Search(DefaultFilter df)
        {
            Paging<ParentCategory> resault = new Paging<ParentCategory>();
            resault.TotalPages = (int)Math.Ceiling((double)_context.ParentCategory.Count() / df.MaxPageSize);
            resault.CurrentPage = df.PageNumber;

            if (!String.IsNullOrEmpty(df.Orderby) && df.IsDesc)
            {
                resault.Data = await _context.ParentCategory.Where(x => x.ParentCategoryId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
                    .OrderBy(df.Orderby + " desc").Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();

                return resault;
            }

            if (!String.IsNullOrEmpty(df.Orderby))
            {
                resault.Data = await _context.ParentCategory.Where(x => x.ParentCategoryId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
                    .OrderBy(df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();

                return resault;
            }

            resault.Data = await _context.ParentCategory.Where(x => x.ParentCategoryId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
                .Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();

            return resault;
        }



    }
}
