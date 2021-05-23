using System.Collections.Generic;
namespace BayMarch.Models
{
    public class Product : MastrerBaseModel
    {

        public long ProductId { get; set; }

        //Data
        public long ProductNum { get; set; }
        public long GlobalBarCode { get; set; }
        public long LocalBarCode { get; set; }
        public long Price { get; set; }


        //Tax
        public long TaxId { get; set; }
        public bool Taxed { get; set; }
        public float TaxValue { get; set; }

        //Lists
        public List<Price> ItemPrices { get; set; }

    }
}
