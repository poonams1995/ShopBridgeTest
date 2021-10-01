using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Model
{
    public class UnitMaster
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Makes Identity column
        public int Id { get; set; }

        [Required(ErrorMessage ="Unit Name is required.")]
        public string UnitName { get; set; }
        public bool IsDeleted { get; set; } 
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? ModifiedOn { get; set; }
    }
}
