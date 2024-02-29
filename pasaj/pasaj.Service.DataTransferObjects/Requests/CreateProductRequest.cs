using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasaj.Service.DataTransferObjects.Requests
{
    public class CreateProductRequest
    {
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public decimal DiscountRate { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; } = "https://ffo3gv1cf3ir.merlincdn.net/SiteAssets/pasaj/crop/cg/00LWMC/00LWMC-1/00LWMC-1_250x188.png?17735349480679";

        public int? CategoryId { get; set; }
    }
}
