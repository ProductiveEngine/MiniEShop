namespace DomainClasses.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Product : Base.Base
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required]
        public int ProductTypeID { get; set; }        

        [StringLength(500)]
        public string Description { get; set; }

        public int? Stock { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }        
        public virtual ICollection<Comment> Comments { get; set; }        
        public virtual ICollection<Rating> Ratings { get; set; }        
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
