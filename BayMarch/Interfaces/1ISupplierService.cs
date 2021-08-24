using BayMarch.Data;
using BayMarch.Dto.Filter;
using BayMarch.Models;
namespace BayMarch.Services
{
    public interface ISupplierService : IDataControl<Supplier>
    {
        //public Paging<Supplier> GetAll();
        public Paging<Supplier> GetDefault();
        public Paging<Supplier> GetPage(DefaultFilter defaultFilter);
        public bool Update(Supplier supplier);
        public bool Create(Supplier supplier);
        public bool Delete(long id);
        //public List<Seller> Page(long id, string condition, string orderby);
        //public PageReq PagesCount();
    }
}

