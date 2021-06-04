using System.Collections.Generic;
namespace BayMarch.Models
{
    public class Paging<T>
    {
        public long CurrentPage { get; set; }
        public long TotalPages { get; set; }
        public List<T> Data { get; set; }
    }
}
