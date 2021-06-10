using BayMarch.Data;
using BayMarch.Models;
namespace BayMarch.Services
{
    public interface ICustomerService : IDataControl
    {
        public bool Create(Customer customer);

        //public Paging<Customer> GetAll();
        //public Paging<Customer> GetDefault();
        //public Paging<Customer> GetPage(DefaultFilter defaultFilter);
        //public Customer Get(long id);
        //public bool Update(Customer customer);
        //public bool Delete(long id);
        //public List<Seller> Page(long id, string condition, string orderby);
        //public PageReq PagesCount();
    }
}

