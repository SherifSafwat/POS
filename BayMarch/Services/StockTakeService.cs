using AutoMapper;
using BayMarch.Data;
using BayMarch.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace BayMarch.Services
{
    public class StockTakeService : IStockTakeService
    {
        //private readonly string _userId;
        private readonly long _sellerId;

        private readonly IHttpContextAccessor _htttpAccessor;
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public StockTakeService(DataContext context, IMapper mapper, IHttpContextAccessor htttpAccessor)
        {
            _htttpAccessor = htttpAccessor;
            _context = context;
            _mapper = mapper;

            //_userId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).Id;
            _sellerId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).SellerId;
        }

        public long Add(ProductBalance productBalance)
        {
            throw new NotImplementedException();
        }

        public long Adjust(ProductBalance productBalance)
        {
            throw new NotImplementedException();
        }

        public long Deduct(ProductBalance productBalance)
        {
            throw new NotImplementedException();
        }

        public long Get(long id)
        {
            throw new NotImplementedException();
        }

        public List<long> GetAll(long id)
        {
            throw new NotImplementedException();
        }
    }
}
