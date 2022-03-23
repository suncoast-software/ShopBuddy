using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBuddy.Services.Models
{
    public class WebItem
    {
        public string? Id { get; set; }
        public string? ModelNumber { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public ProductStyle Style { get; set; }
    }
}
