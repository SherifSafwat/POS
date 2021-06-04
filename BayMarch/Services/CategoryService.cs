using AutoMapper;
using BayMarch.Data;
using BayMarch.Dto.Filter;
using BayMarch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BayMarch.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly string _userId;
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

        //public Paging<Category> GetAll()
        //{
        //    return _context.Category.ToList();
        //}

        public Paging<Category> GetDefault()
        {
            return GetPage(new DefaultFilter { PageNumber = 1, Filter = false, Orderby = "CreationDate" });
        }

        public Paging<Category> GetPage(DefaultFilter df)
        {

            Paging<Category> resault = new Paging<Category>();
            resault.TotalPages = (int)Math.Ceiling((double)_context.Category.Where(x => x.SellerId == _sellerId).Count() / df.MaxPageSize);
            resault.CurrentPage = df.PageNumber;

            if (df.Filter == false)
            {
                resault.Data = _context.Category.Where(x => x.SellerId == _sellerId).OrderBy(p => df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToList();
                return resault;
            }

            //resault.Data = _context.Category.Where(x => (x.CategoryId == df.Id || x.EName.Contains(df.EName)) && x.SellerId == _sellerId).ToList();
            resault.Data = _context.Category.Where(x => (x.CategoryId == df.Id || x.EName.Contains(df.EName)) && x.SellerId == _sellerId).OrderBy(p => df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToList();

            return resault;
            
        }

        public bool Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
    }
}
