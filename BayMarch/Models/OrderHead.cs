using System;
namespace BayMarch.Models
{
    public class OrderHead : MasterBaseModel
    {
        public long OrderHeadId { get; set; }

        //Data
        public long OrderNum { get; set; }
        public string OrderRef { get; set; }
        public long? InvoiceHeadId { get; set; }
        public long? CustomerId { get; set; }
        //public Customer CustomerObj { get; set; }
        //public long? ClientId { get; set; }
        //public Client ClientObj { get; set; }
        public DateTime OrderTime { get; set; }

        public float Total { get; set; }
        public float TotalTax { get; set; }
        public float TotalDisc { get; set; }
        public string OrderStatus { get; set; } //Done
        public string UserMsg { get; set; }

    }
}
