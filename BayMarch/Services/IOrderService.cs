using BayMarch.Dto;
using BayMarch.Dto.Request;
using System.Collections.Generic;
namespace BayMarch.Services
{
    public interface IOrderService
    {
        public List<OrderDto> GetAll();
        public OrderDto Get(long id);
        public bool Update(OrderDto OrderDto);
        public bool Create(OrderDto OrderDto);
        public bool Delete(long id);
        public List<OrderDto> Page(long id, string condition, string orderby);
        public PageReq PagesCount();
    }
}
