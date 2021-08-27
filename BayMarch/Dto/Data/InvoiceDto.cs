using BayMarch.Models;
using System.Collections.Generic;
namespace BayMarch.Dto
{
    public class InvoiceDto
    {
        public InvoiceHead InvoiceHead { get; set; }
        public List<InvoiceTail> InvoiceTails { get; set; }
    }
}
