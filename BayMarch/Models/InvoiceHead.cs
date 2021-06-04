using System;
namespace BayMarch.Models
{
    public class InvoiceHead : MastrerWithContact
    {
        public long InvoiceHeadId { get; set; }

        //Data
        public long InvoiceNum { get; set; }
        public long UserId { get; set; }
        public long? DeviceId { get; set; }
        public long? OrderHeadId { get; set; }
        public long? CustomerId { get; set; }
        //public Customer CustomerObj { get; set; }
        public long? ClientId { get; set; }
        //public Client ClientObj { get; set; }

        public DateTime InvoiceTime { get; set; }

        public float Total { get; set; }
        public float TotalTax { get; set; }
        public float TotalDisc { get; set; }

    }
}
