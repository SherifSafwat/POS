using BayMarch.Data;
using BayMarch.Dto.Filter;
using BayMarch.Models;
namespace BayMarch.Services
{
    public interface ICategoryService : IDataControl<Category>
    {
        //public Paging<Category> GetAll();
        public Paging<Category> GetDefault();
        public Paging<Category> GetPage(DefaultFilter defaultFilter);
        public bool Update(Category category);
        public bool Create(Category category);
        public bool Delete(long id);
        //public List<Seller> Page(long id, string condition, string orderby);
        //public PageReq PagesCount();
    }
}

