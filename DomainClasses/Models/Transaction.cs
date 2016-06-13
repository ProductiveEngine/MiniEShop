namespace DomainClasses.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Transaction : Base.Base
    {        
        [Key]
        public int TransactionID { get; set; }

        public int? MemberID { get; set; }

        public int? ProductID { get; set; }

        public int? Quantity { get; set; }

        public int? ApprovalStatus { get; set; }

        public virtual Member Member { get; set; }

        public virtual Product Product { get; set; }
    }
}
