namespace BayMarch.Dto.Filter
{
    public class ProductFilter
    {
        public long ProductId { get; set; }
        public long ProductNum { get; set; }
        public long GlobalBarCode { get; set; }
        public long LocalBarCode { get; set; }
        public string EName { get; set; }
        public string AName { get; set; }
        public long Price { get; set; }
        public string DataComment { get; set; }
    }
}
