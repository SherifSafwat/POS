using BayMarch.Data;
using BayMarch.Dto.Filter;
using BayMarch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using DynamicExpressions.Linq;
using System.Threading.Tasks;

namespace BayMarch.Services
{
    public class ProductService : IBaseInterface<Product>
    {
        private readonly long _sellerId;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _htttpAccessor;

        public ProductService(DataContext context, IHttpContextAccessor htttpAccessor)
        {
            _context = context;
            _htttpAccessor = htttpAccessor;

            var userId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).Id;
            _sellerId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).SellerId;
        }

        async Task<Product> IBaseInterface<Product>.Get(long id)
        {
            return await _context.Product.FindAsync(id);
        }

        async Task<IEnumerable<Product>> IBaseInterface<Product>.GetList(DefaultFilter df)
        {
            return await _context.Product.Where(x => x.Enabled == true && x.SellerId == _sellerId).ToListAsync();
        }

        async Task<bool> IBaseInterface<Product>.Create(Product parentProduct)
        {
            await _context.Product.AddAsync(parentProduct);
            return await _context.SaveChangesAsync() > 0;
        }

        async Task<bool> IBaseInterface<Product>.Update(Product obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        async Task<IEnumerable<Product>> IBaseInterface<Product>.GetAll(DefaultFilter df)
        {
            if (!String.IsNullOrEmpty(df.Orderby) && df.IsDesc)
                return await _context.Product.OrderBy(df.Orderby + " desc").ToListAsync();

            if (!String.IsNullOrEmpty(df.Orderby))
                return await _context.Product.OrderBy(df.Orderby).ToListAsync();

            return await _context.Product.ToListAsync();
        }

        async Task<Paging<Product>> IBaseInterface<Product>.Page(DefaultFilter df)
        {
            Paging<Product> resault = new Paging<Product>();
            resault.TotalPages = (int)Math.Ceiling((double)_context.Product.Count() / df.MaxPageSize);
            resault.CurrentPage = df.PageNumber;

            if (!String.IsNullOrEmpty(df.Orderby) && df.IsDesc)
            {
                resault.Data = await _context.Product.Where(x => x.Enabled == true && x.SellerId == _sellerId)
                    .OrderBy(df.Orderby + " desc").Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();
                return resault;
            }

            if (!String.IsNullOrEmpty(df.Orderby))
            {
                resault.Data = await _context.Product.Where(x => x.Enabled == true && x.SellerId == _sellerId)
                    .OrderBy(df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();
                return resault;
            }


            resault.Data = await _context.Product.Where(x => x.Enabled == true && x.SellerId == _sellerId)
                .Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();
            return resault;

        }

        async Task<Paging<Product>> IBaseInterface<Product>.Search(DefaultFilter df)
        {
            Paging<Product> resault = new Paging<Product>();
            resault.TotalPages = (int)Math.Ceiling((double)_context.Product.Count() / df.MaxPageSize);
            resault.CurrentPage = df.PageNumber;

            if (!String.IsNullOrEmpty(df.Orderby) && df.IsDesc)
            {
                resault.Data = await _context.Product.Where(x => (x.Enabled == true && x.SellerId == _sellerId) && x.ProductId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
                    .OrderBy(df.Orderby + " desc").Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();

                return resault;
            }

            if (!String.IsNullOrEmpty(df.Orderby))
            {
                resault.Data = await _context.Product.Where(x => (x.Enabled == true && x.SellerId == _sellerId) && x.ProductId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
                    .OrderBy(df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToListAsync();

                return resault;
            }

            resault.Data = await _context.Product.Where(x => (x.Enabled == true && x.SellerId == _sellerId) && x.ProductId.ToString().Contains(df.Filter) || x.EName.Contains(df.Filter) || x.AName.Contains(df.Filter) || x.DataComment.Contains(df.Filter))
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

public ProductService(DataContext context, IMapper mapper, IHttpContextAccessor htttpAccessor)
{
    _htttpAccessor = htttpAccessor;
    _context = context;
    _mapper = mapper;

    _userId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).Id;
    _sellerId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).SellerId;
}

public bool Create(Product product)
{
    product.SellerId = _sellerId;
    _context.Product.Add(product);
    return _context.SaveChanges() > 0;
}

public bool Delete(long id)
{
    var product = _context.Product.Find(id);
    _context.Product.Remove(product);
    return _context.SaveChanges() > 0;
}

public Product Get(long id)
{
    return _context.Product.Find(id);
}

//public Paging<Product> GetAll()
//{
//    return _context.Product.ToList();
//}

public Paging<Product> GetDefault()
{
    return GetPage(new DefaultFilter { PageNumber = 1, Orderby = "CreationDate" });

}

public IEnumerable<Product> GetList()
{
    throw new NotImplementedException();
}

public Paging<Product> GetPage(DefaultFilter df)
{

    Paging<Product> resault = new Paging<Product>();
    resault.TotalPages = (int)Math.Ceiling((double)_context.Product.Where(x => x.SellerId == _sellerId).Count() / df.MaxPageSize);
    resault.CurrentPage = df.PageNumber;

    if (df.IsDesc)  //review error
    {
        resault.Data = _context.Product.Where(x => x.SellerId == _sellerId).OrderBy(p => df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToList();
        return resault;
    }

    //resault.Data = _context.Product.Where(x => (x.ProductId == df.Id || x.EName.Contains(df.EName)) && x.SellerId == _sellerId).ToList();
    //resault.Data = _context.Product.Where(x => (x.ProductId == df.Id || x.EName.Contains(df.EName)) && x.SellerId == _sellerId).OrderBy(p => df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToList();

    return resault;

}

public bool Update(Product product)
{
    _context.Entry(product).State = EntityState.Modified;
    return _context.SaveChanges() > 0;
}
}
}


/*
private readonly string _userId;
private readonly long _sellerId;

private readonly IHttpContextAccessor _htttpAccessor;
private readonly DataContext _context;
private readonly IMapper _mapper;
//private readonly ILogger _lo;

//private readonly string userId;
//private readonly UserManager<ApplicationUser> _userManager;
//private readonly IUserStore<ApplicationUser> _us;
//private readonly JwtBearerHandler _jt;

public ProductService(DataContext context, IMapper mapper, IHttpContextAccessor htttpAccessor
    , UserManager<ApplicationUser> userManager, IUserStore<ApplicationUser> us, JwtBearerHandler jt) : base()
{
    _htttpAccessor = htttpAccessor;
    _context = context;
    _mapper = mapper;

    _userId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).Id;
    _sellerId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).SellerId;

    //_userManager = userManager;
    //_us = us;
    //_jt = jt;
    //ApplicationUser currentUser = _context.Users.FirstOrDefault(x => x.UserName == ht.HttpContext.User.Identity.Name);
    //var t  = _context.Users.FirstOrDefault(x => x.UserName == ht.HttpContext.User.Identity.Name).Id;
}

public List<ProductDto> GetAll()
{
    return _mapper.Map<List<ProductDto>>(_context.Product.ToList());
}

public ProductDto Get(long id)
{
    return _mapper.Map<ProductDto>( _context.Product.Where(x => x.ProductId == id && x.SellerId == _sellerId).FirstOrDefault());
}


public List<ProductDto> Find(ProductFilter productFilter)
{
    return _mapper.Map<List<ProductDto>>(_context.Product.Where(x => (x.ProductId == productFilter.Id || x.EName.Contains(productFilter.EName) ) && x.SellerId == _sellerId).ToList());
}


public bool Update(ProductDto productDto)
{
    var product = _mapper.Map<Product>(productDto);
    _context.Entry(product).State = EntityState.Modified;
    return _context.SaveChanges() > 0;
}

public bool Create(ProductDto productDto)
{
    var product = _mapper.Map<Product>(productDto);

    product.SellerId = _sellerId;
    product.CreatedID = _userId;
    _context.Product.Add(product);
    return _context.SaveChanges() > 0;  
}

public bool Delete(long id)
{
    var product =  _context.Product.Find(id);
    _context.Product.Remove(product);
    return _context.SaveChanges() > 0 ;
}

public List<ProductDto> Page(long id, string orderby)
{
    PageReq p = new PageReq();
    var t = _context.Product.OrderBy(p => orderby ).Skip((int) (id * p.MaxPageSize) ).Take(p.MaxPageSize).ToList();
    return _mapper.Map<List<Product>, List<ProductDto>>(t);
}

public PageReq PagesCount()
{
    PageReq p = new PageReq();
    p.TotalPages = (int)Math.Ceiling((double) (_context.Product.Count() / p.MaxPageSize));
    return p;
}


}
}
*/