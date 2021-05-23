namespace BayMarch.Dto
{
    public class ProductDto
    {
        public long ProductId { get; set; }

        //Data
        public long ProductNum { get; set; }
        public long GlobalBarCode { get; set; }
        public long LocalBarCode { get; set; }
        public string EName { get; set; }
        public string AName { get; set; }
        public long Price { get; set; }

        public string DataComment { get; set; }

        //Tax
        public long TaxId { get; set; }
        public bool Taxed { get; set; }
        public float TaxValue { get; set; }

    }
}
