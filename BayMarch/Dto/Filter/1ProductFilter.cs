namespace BayMarch.Dto.Filter
{
    public class ProductFilter : DefaultFilter
    {
        public long GlobalBarCode { get; set; }
        public long LocalBarCode { get; set; }
        public long Price { get; set; }

        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        
    }
}
