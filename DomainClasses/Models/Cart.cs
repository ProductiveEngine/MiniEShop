using System.ComponentModel.DataAnnotations;

namespace DomainClasses.Models
{
    public partial class Cart: Base.Base
    {        
        [Key]
        public int CartID { get; set; }

        public int? MemberID { get; set; }

        public int? ProductID { get; set; }

        public int? Quantity { get; set; }

        public virtual Member Member { get; set; }

        public virtual Product Product { get; set; }
    }
}
