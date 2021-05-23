using BayMarch.Dto;
using BayMarch.Dto.Request;
using System.Collections.Generic;
namespace BayMarch.Services
{
    public interface IInvoiceService
    {
        public List<InvoiceDto> GetAll();
        public InvoiceDto Get(long id);
        public bool Update(InvoiceDto InvoiceDto);
        public bool Create(InvoiceDto InvoiceDto);
        public bool Delete(long id);
        public List<InvoiceDto> Page(long id, string condition, string orderby);
        public PageReq PagesCount();
    }
}
