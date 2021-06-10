namespace BayMarch.Models
{
    public class Product : MasterBaseModel
    {
        public long ProductId { get; set; }

        //Data
        public long GlobalBarCode { get; set; }
        public long LocalBarCode { get; set; }
        public long Price { get; set; }

        public long CategoryId { get; set; }
        //public Category CategoryObj { get; set; }
        public long SupplierId { get; set; }
        //public Supplier SupplierObj { get; set; }        
        public long UomId { get; set; }
        //public Uom UomObj { get; set; }

        //Tax
        public long TaxId { get; set; }
        public bool Taxed { get; set; }
        public float TaxValue { get; set; }

        //Lists
        //public List<Price> ItemPrices { get; set; }
    }
}
