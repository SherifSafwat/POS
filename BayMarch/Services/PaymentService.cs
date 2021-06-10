using BayMarch.Data;
using BayMarch.Models;
using System.Collections.Generic;
using System.Linq;

namespace BayMarch.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly DataContext _context;
        public PaymentService(DataContext context)
        {
            _context = context;
        }

        public List<Payment> GetDefault()
        {
            return _context.Payment.ToList();
        }       
    }
}
