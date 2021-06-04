using AutoMapper;
using BayMarch.Data;
using BayMarch.Dto.Request;
using BayMarch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BayMarch.Services
{
    public class SellerService : ISellerService
    {
        //private readonly string _userId;
        //private readonly long   _sellerId;

        private readonly IHttpContextAccessor _htttpAccessor;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        //private readonly ILogger _lo;

        public SellerService(DataContext context, IMapper mapper, IHttpContextAccessor htttpAccessor) 
        {
            _htttpAccessor = htttpAccessor;
            _context = context;
            _mapper = mapper;

            //_userId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).Id;
            //_sellerId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).SellerId;
            //ApplicationUser currentUser = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name);

        }
        public bool Create(Seller seller)
        {
            //var seller = _mapper.Map<seller>(sellerDto);
            _context.Seller.Add(seller);
            return _context.SaveChanges() > 0;

        }

        public bool Delete(long id)
        {
            var seller = _context.Seller.Find(id);
            _context.Seller.Remove(seller);
            return _context.SaveChanges() > 0;
        }

        public Seller Get(long id)
        {
            return _context.Seller.Find(id);
        }

        public List<Seller> GetAll()
        {
            return _context.Seller.ToList();
        }

        public List<Seller> Page(long id, string condition, string orderby)
        {
            PageReq p = new PageReq();
            return _context.Seller.OrderBy(x => orderby).Skip((int)(id * p.MaxPageSize)).Take(p.MaxPageSize).ToList();
        }

        public PageReq PagesCount()
        {
            PageReq p = new PageReq();
            p.TotalPages = (int)Math.Ceiling((double)(_context.Seller.Count() / p.MaxPageSize));
            return p;
        }

        public bool Update(Seller seller)
        {
            //var seller = _mapper.Map<seller>(sellerDto);
            _context.Entry(seller).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
    }
}
