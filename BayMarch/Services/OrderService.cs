using AutoMapper;
using BayMarch.Data;
using BayMarch.Dto;
using BayMarch.Dto.Request;
using BayMarch.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace BayMarch.Services
{
    public class OrderService : IOrderService
    {
        private readonly string _userId;
        private readonly long _sellerId;

        private readonly IHttpContextAccessor _htttpAccessor;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        //private readonly ILogger _lo;

        public OrderService(DataContext context, IMapper mapper, IHttpContextAccessor htttpAccessor)
        {
            _htttpAccessor = htttpAccessor;
            _context = context;
            _mapper = mapper;

            _userId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).Id;
            _sellerId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).SellerId;
            //ApplicationUser currentUser = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name);

        }

        public bool Create(OrderDto orderDto)
        {
            orderDto.OrderHead.SellerId = _sellerId;
            orderDto.OrderHead.CreatedID = _userId;
            foreach (OrderTail tail in orderDto.OrderTails)
            {
                tail.SellerId = _sellerId;
                tail.CreatedID = _userId;
            }

            _context.OrderHead.Add(orderDto.OrderHead);
            _context.OrderTail.AddRange(orderDto.OrderTails);
            _context.Customer.Add(orderDto.Customer);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public OrderDto Get(long id)
        {
            OrderHead orderHead = _context.OrderHead.Where(x => x.OrderHeadId == id && x.SellerId == _sellerId).FirstOrDefault();

            OrderDto OrderDto = new()
            {
                //OrderHead = _context.OrderHead.Find(id),
                //OrderHead = _context.OrderHead.Where(x => x.OrderHeadId == id && x.SellerId == _sellerId).FirstOrDefault(),
                OrderTails = _context.OrderTail.Where(x => x.OrderHeadId == id && x.SellerId == _sellerId).ToList(),
                Customer = _context.Customer.Where(x => x.CustomerId == orderHead.CustomerId).FirstOrDefault(),
            };
            return OrderDto;
        }

        public List<OrderDto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public List<OrderDto> Page(long id, string condition, string orderby)
        {
            throw new System.NotImplementedException();
        }

        public PageReq PagesCount()
        {
            throw new System.NotImplementedException();
        }

        public bool Update(OrderDto OrderDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
