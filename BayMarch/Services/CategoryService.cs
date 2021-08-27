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
    public class CategoryService : IBaseInterface<Category>
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _htttpAccessor;

        public CategoryService(DataContext context, IHttpContextAccessor htttpAccessor)
        {
            _context = context;
            _htttpAccessor = htttpAccessor;
        }

        async Task<Category> IBaseInterface<Category>.Get(long id)
        {
            return await _context.Category.FindAsync(id);
        }

        async Task<IEnumerable<Category>> IBaseInterface<Category>.GetList(DefaultFilter df)
        {
            return await _context.Category.Where(x => x.Enabled == true && x.ParentCategoryId == df.Id).ToListAsync();
        }

        async Task<bool> IBaseInterface<Category>.Create(Category parentCategory)
        {
            await _context.Category.AddAsync(parentCategory);
            return await _context.SaveChangesAsync() > 0;
        }

        async Task<bool> IBaseInterface<Category>.Update(Category obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        async Task<IEnumerable<Category>> IBaseInterface<Category>.GetAll(DefaultFilter df)
        {
            if (!String.IsNullOrEmpty(df.Orderby) && df.IsDesc)
                return await _context.Category.OrderBy(df.Orderby + " desc").ToListAsync();

            if (!String.IsNullOrEmpty(df.Orderby))
                return await _context.Category.OrderBy(df.Orderby).ToListAsync();

            return await _context.Category.ToListAsync();
        }

        async Task<Paging<Category>> IBaseInterface<Category>.Page(DefaultFilter df)
        {
            Paging<Category> resault = new Paging<Category>();
            resault.TotalPages = (int)Math.Ceiling((double)_context.Category.Count() / df.MaxPageSize);
            resault.CurrentPage = df.PageNumber;

            if (!String.IsNullOrEmpty(df.Orderby) && df.IsDesc)
            {
                resault.Data = await _context.Category.OrderBy(df.Orderby + " desc").Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();
                return resault;
            }

            if (!String.IsNullOrEmpty(df.Orderby))
            {
                resault.Data = await _context.Category.OrderBy(df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();
                return resault;
            }


            resault.Data = await _context.Category.Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();
            return resault;

        }

        async Task<Paging<Category>> IBaseInterface<Category>.Search(DefaultFilter df)
        {
            Paging<Category> resault = new Paging<Category>();
            resault.TotalPages = (int)Math.Ceiling((double)_context.Category.Count() / df.MaxPageSize);
            resault.CurrentPage = df.PageNumber;

            if (!String.IsNullOrEmpty(df.Orderby) && df.IsDesc)
            {
                resault.Data = await _context.Category.Where(x => x.CategoryId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
                    .OrderBy(df.Orderby + " desc").Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();

                return resault;
            }

            if (!String.IsNullOrEmpty(df.Orderby))
            {
                resault.Data = await _context.Category.Where(x => x.CategoryId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
                    .OrderBy(df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();

                return resault;
            }

            resault.Data = await _context.Category.Where(x => x.CategoryId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
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

public CategoryService(DataContext context, IMapper mapper, IHttpContextAccessor htttpAccessor) 
{
    _htttpAccessor = htttpAccessor;
    _context = context;
    _mapper = mapper;

    _userId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).Id;
    _sellerId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).SellerId;            
}

public bool Create(Category category)
{
    category.SellerId = _sellerId;
    _context.Category.Add(category);
    return _context.SaveChanges() > 0;
}

public bool Delete(long id)
{
    var category = _context.Category.Find(id);
    _context.Category.Remove(category);
    return _context.SaveChanges() > 0;
}

public Category Get(long id)
{
    return _context.Category.Find(id);
}

public Task<IEnumerable<Category>> GetAll(DefaultFilter df)
{
    throw new NotImplementedException();
}

//public Paging<Category> GetAll()
//{
//    return _context.Category.ToList();
//}

public Paging<Category> GetDefault()
{
    return GetPage(new DefaultFilter { PageNumber = 1, Orderby = "CreationDate" });
}

public IEnumerable<Category> GetList()
{
    throw new NotImplementedException();
}

public Paging<Category> GetPage(DefaultFilter df)
{

    Paging<Category> resault = new Paging<Category>();
    resault.TotalPages = (int)Math.Ceiling((double)_context.Category.Where(x => x.SellerId == _sellerId).Count() / df.MaxPageSize);
    resault.CurrentPage = df.PageNumber;

    if (df.IsDesc) //errr
    {
        resault.Data = _context.Category.Where(x => x.SellerId == _sellerId).OrderBy(p => df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToList();
        return resault;
    }

    //resault.Data = _context.Category.Where(x => (x.CategoryId == df.Id || x.EName.Contains(df.EName)) && x.SellerId == _sellerId).ToList();
    //resault.Data = _context.Category.Where(x => (x.CategoryId == df.Id || x.EName.Contains(df.EName)) && x.SellerId == _sellerId).OrderBy(p => df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToList();

    return resault;

}

public Task<Paging<Category>> Page(DefaultFilter df)
{
    throw new NotImplementedException();
}

public Task<Paging<Category>> Search(DefaultFilter df)
{
    throw new NotImplementedException();
}

public bool Update(Category category)
{
    _context.Entry(category).State = EntityState.Modified;
    return _context.SaveChanges() > 0;
}

Task<bool> IBaseInterface<Category>.Create(Category obj)
{
    throw new NotImplementedException();
}

Task<Category> IBaseInterface<Category>.Get(long id)
{
    throw new NotImplementedException();
}

Task<IEnumerable<Category>> IBaseInterface<Category>.GetList(DefaultFilter df)
{
    throw new NotImplementedException();
}

Task<bool> IBaseInterface<Category>.Update(Category obj)
{
    throw new NotImplementedException();
}
}
}*/
