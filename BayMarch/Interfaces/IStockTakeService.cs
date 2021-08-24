using BayMarch.Dto;
using System.Collections.Generic;
namespace BayMarch.Services
{
    public interface IStockTakeService
    {
        public long Get(long id);
        public List<long> GetAll(long id);
        //public long Add(ProductBalance productBalance);
        //public long Deduct(ProductBalance productBalance);
        //public long Adjust(ProductBalance productBalance);

    }
}
