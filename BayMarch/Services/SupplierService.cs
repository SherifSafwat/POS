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
    public class SupplierService : ISupplierService
    {
        private readonly string _userId;
        private readonly long _sellerId;

        private readonly IHttpContextAccessor _htttpAccessor;
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SupplierService(DataContext context, IMapper mapper, IHttpContextAccessor htttpAccessor)
        {
            _htttpAccessor = htttpAccessor;
            _context = context;
            _mapper = mapper;

            _userId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).Id;
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
            return GetPage(new DefaultFilter { PageNumber = 1, Filter = false, Orderby = "CreationDate" });
        }

        public Paging<Supplier> GetPage(DefaultFilter df)
        {

            Paging<Supplier> resault = new Paging<Supplier>();
            resault.TotalPages = (int)Math.Ceiling((double)_context.Supplier.Where(x => x.SellerId == _sellerId).Count() / df.MaxPageSize);
            resault.CurrentPage = df.PageNumber;

            if (df.Filter == false)
            {
                resault.Data = _context.Supplier.Where(x => x.SellerId == _sellerId).OrderBy(p => df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToList();
                return resault;
            }

            //resault.Data = _context.Supplier.Where(x => (x.SupplierId == df.Id || x.EName.Contains(df.EName)) && x.SellerId == _sellerId).ToList();
            resault.Data = _context.Supplier.Where(x => (x.SupplierId == df.Id || x.EName.Contains(df.EName)) && x.SellerId == _sellerId).OrderBy(p => df.Orderby).Skip((int)((df.PageNumber - 1) * df.MaxPageSize)).Take(df.MaxPageSize).ToList();

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