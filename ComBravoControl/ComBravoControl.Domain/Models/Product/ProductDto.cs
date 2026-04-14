using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravoControl.Domains.Models.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime Duration { get; set; }
        public string Url { get; set; }
    }
}
