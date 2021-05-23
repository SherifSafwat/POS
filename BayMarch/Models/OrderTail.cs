namespace BayMarch.Models
{
    public class OrderTail : MastrerBaseModel
    {
        public long OrderTailId { get; set; }

        //Data
        public long OrderHeadId { get; set; }
        public long? InvoiceTailId { get; set; }
        public long ProductId { get; set; }
        public long PriceListId { get; set; }

        public long LineNum { get; set; }
        public long ProductNum { get; set; }
        public float Price { get; set; }
        public float Qty { get; set; }
        public float LineTax { get; set; }
        public float LineDisc { get; set; }
        public float TotalLine { get; set; }

    }
}
