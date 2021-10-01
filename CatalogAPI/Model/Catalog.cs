using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Model
{
    public class Catalog
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="CatalogName is required.")]
        public string CatalogName { get; set; }

        [Required(ErrorMessage ="Catalog must comes under category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Catalog should have Unit")]
        public int UnitId { get; set; }
        public string Description { get; set; }

        public decimal SellingPrice { get; set; } 

        public bool IsAvailable { get; set; }
        public bool IsInStock { get; set; }
        public int CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public int? ModifiedBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? ModifiedOn { get; set; }

    }
    /// <summary>
    /// Class for getting all details of catalog
    /// </summary>
    public class CatalogModel : Catalog {
        public string UnitName { get; set; }
        public string CategoryName { get; set; } 
    }
}
