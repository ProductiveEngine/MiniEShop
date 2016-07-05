using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainClasses.Models
{
    public class ProductType: Base.Base
    {
        [Key]
        public int ProductTypeID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [NotMapped]
        public bool EditMode { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}