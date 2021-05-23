using System;
namespace BayMarch.Models
{
    public class Price : MastrerBaseModel
    {
        public long PriceId { get; set; }

        //ID
        public long ProductId { get; set; }
        public Product ProductObj { get; set; }

        //Data
        public long PriceNum { get; set; }
        public long ItemPrice { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
       
    }
}
