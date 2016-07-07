using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

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
        public string ServerName { get; set; }

        [NotMapped]
        public bool EditMode { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}