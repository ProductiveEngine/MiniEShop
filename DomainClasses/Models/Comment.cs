namespace DomainClasses.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Comment : Base.Base
    {        
        [Key]
        public int CommentID { get; set; }

        public int? MemberID { get; set; }

        public int? ProductID { get; set; }

        [StringLength(500)] 
        public string Message { get; set; }

        public virtual Member Member { get; set; }

        public virtual Product Product { get; set; }
    }
}
