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
    public class InvoiceService : IInvoiceService
    {
        private readonly string _userId;
        private readonly long _sellerId;

        private readonly IHttpContextAccessor _htttpAccessor;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        //private readonly ILogger _lo;

        public InvoiceService(DataContext context, IMapper mapper, IHttpContextAccessor htttpAccessor)
        {
            _htttpAccessor = htttpAccessor;
            _context = context;
            _mapper = mapper;

            _userId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).Id;
            _sellerId = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name).SellerId;
            //ApplicationUser currentUser = _context.Users.FirstOrDefault(x => x.UserName == htttpAccessor.HttpContext.User.Identity.Name);

        }

        public bool Create(InvoiceDto invoiceDto)
        {
            invoiceDto.InvoiceHead.SellerId = _sellerId;
            invoiceDto.InvoiceHead.CreatedID = _userId;
            foreach(InvoiceTail tail in invoiceDto.InvoiceTails)
            {
                tail.SellerId = _sellerId;
                tail.CreatedID = _userId;
            }

            _context.InvoiceHead.Add(invoiceDto.InvoiceHead);
            _context.InvoiceTail.AddRange(invoiceDto.InvoiceTails);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public InvoiceDto Get(long id)
        {
            InvoiceDto invoiceDto = new()
            {
                //InvoiceHead = _context.InvoiceHead.Find(id),
                //InvoiceTails = _context.InvoiceTail.Where(x => x.InvoiceHeadId == id).ToList()
                InvoiceHead = _context.InvoiceHead.Where(x => x.InvoiceHeadId == id && x.SellerId == _sellerId).FirstOrDefault(),
                InvoiceTails = _context.InvoiceTail.Where(x => x.InvoiceHeadId == id && x.SellerId == _sellerId).ToList()
            };
            return invoiceDto;
        }

        public List<InvoiceDto> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public List<InvoiceDto> Page(long id, string condition, string orderby)
        {
            throw new System.NotImplementedException();
        }

        public PageReq PagesCount()
        {
            throw new System.NotImplementedException();
        }

        public bool Update(InvoiceDto InvoiceDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
