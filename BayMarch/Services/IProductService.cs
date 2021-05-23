using BayMarch.Data;
using BayMarch.Dto;
using BayMarch.Dto.Request;
using System.Collections.Generic;

namespace BayMarch.Services
{
    public interface IProductService : IDataControl
    {
        public List<ProductDto> GetAll();
        public ProductDto Get(long id);
        public bool Update(ProductDto product);
        public bool Create(ProductDto productDto);
        public bool Delete(long id);
        public List<ProductDto> Page(long id, string orderby);
        public PageReq PagesCount();

    }
}
