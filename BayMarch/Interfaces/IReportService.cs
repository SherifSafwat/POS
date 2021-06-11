using BayMarch.Data;
using BayMarch.Dto.Filter;
using System.Collections.Generic;
using System.Text;

namespace BayMarch.Services
{
    public interface IReportService : IDataControl
    {
        public IDictionary<string,int> GetDefault();
        public byte[] GetReport(ReportFilter reportFilter);

        //public Paging<Category> GetAll();
        //public Paging<Category> GetPage(DefaultFilter defaultFilter);
        //public Category Get(long id);
        //public bool Update(Category category);
        //public bool Create(Category category);
        //public bool Delete(long id);
    }
}
