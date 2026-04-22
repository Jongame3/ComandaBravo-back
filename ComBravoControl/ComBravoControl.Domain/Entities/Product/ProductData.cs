using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ComBravo.Domains.Entities.Product
{
    public class ProductData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required, StringLength(200)]
        public string? Description { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime Duration { get; set; }
        [Required,StringLength(100)]
        public string? Url { get; set; }
    }
}
