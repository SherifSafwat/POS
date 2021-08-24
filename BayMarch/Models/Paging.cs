using System.Collections;
using System.Collections.Generic;
namespace BayMarch.Models
{
    public class Paging<T> //: IEnumerable
    {
        public long CurrentPage { get; set; }
        public long TotalPages { get; set; }
        public List<T> Data { get; set; }

        //public IEnumerator GetEnumerator()
        //{
        //    yield return Data;
        //}
    }
}
