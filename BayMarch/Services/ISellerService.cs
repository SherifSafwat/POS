using BayMarch.Data;
using BayMarch.Dto.Request;
using BayMarch.Models;
using System.Collections.Generic;
namespace BayMarch.Services
{
    public interface ISellerService : IDataControl
    {
        public List<Seller> GetAll();
        public Seller Get(long id);
        public bool Update(Seller seller);
        public bool Create(Seller seller);
        public bool Delete(long id);
        public List<Seller> Page(long id, string condition, string orderby);
        public PageReq PagesCount();
    }
}
