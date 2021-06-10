using BayMarch.Data;
using BayMarch.Models;
using System.Collections.Generic;

namespace BayMarch.Services
{
    public interface IPaymentService : IDataControl
    {
        public List<Payment> GetDefault();
        //public Paging<Category> GetAll();
        //public Paging<Category> GetPage(DefaultFilter defaultFilter);
        //public Category Get(long id);
        //public bool Update(Category category);
        //public bool Create(Category category);
        //public bool Delete(long id);
    }
}
