using AutoMapper;
using BayMarch.Data;
using BayMarch.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace BayMarch.Services
{
    public class CustomerService : ICustomerService
    {
        //private readonly string _userId;
        private readonly long _sellerId;

        private readonly IHttpContextAccessor _htttpAccessor;
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CustomerService(DataContext context, IMapper mapper, IHttpContextAccessor htttpAccessor)
        {
            _htttpAccessor = htttpAccessor;
            _context = context;
            _mapper = mapper;

            //_userId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).Id;
            _sellerId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).SellerId;
        }

        public bool Create(Customer customer)
        {
            customer.SellerId = _sellerId;
            _context.Customer.Add(customer);
            return _context.SaveChanges() > 0;
        }
    }
}
