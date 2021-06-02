using AutoMapper;
using BayMarch.Data;
using BayMarch.Dto;
using BayMarch.Dto.Filter;
using BayMarch.Dto.Request;
using BayMarch.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BayMarch.Services
{
    public class ProductService : ServiceBase, IProductService
    {

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
            return _mapper.Map<List<ProductDto>>(_context.Product.Where(x => (x.ProductId == productFilter.ProductId || x.EName.Contains(productFilter.EName) ) && x.SellerId == _sellerId).ToList());
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
