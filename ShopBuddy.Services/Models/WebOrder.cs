using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBuddy.Services.Models
{
    public class WebOrder
    {
        public int Id { get; set; }
        public string? WebOderInvoiceId { get; set; }
        public string? WebOrderName { get; set; }
    }
}
