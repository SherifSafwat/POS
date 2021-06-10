using BayMarch.Data;
using BayMarch.Dto;
using BayMarch.Dto.Filter;
using BayMarch.Dto.Request;
using BayMarch.Models;
using System.Collections.Generic;

namespace BayMarch.Services
{
    public interface IProductService : IDataControl
    {
        public Paging<Product> GetDefault();
        public Paging<Product> GetPage(DefaultFilter defaultFilter);
        public Product Get(long id);
        public bool Update(Product category);
        public bool Create(Product category);
        public bool Delete(long id);

        /*public List<ProductDto> GetAll();
        public ProductDto Get(long id);
        public List<ProductDto> Find(ProductFilter productFilter);
        public bool Update(ProductDto product);
        public bool Create(ProductDto productDto);
        public bool Delete(long id);
        public List<ProductDto> Page(long id, string orderby);
        public PageReq PagesCount();*/

    }
}
