using BayMarch.Models;
using System.Collections.Generic;
namespace BayMarch.Dto
{
    public class OrderDto
    {
        public OrderHead OrderHead { get; set; }
        public List<OrderTail> OrderTails { get; set; }
    }
}
