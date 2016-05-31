namespace DomainClasses.Models    
{
    using System.ComponentModel.DataAnnotations;

    public partial class Rating
    {        
        [Key]
        public int RatingID { get; set; }

        public int? MemberID { get; set; }

        public int? ProductID { get; set; }

        public int? Value { get; set; }

        public virtual Member Member { get; set; }

        public virtual Product Product { get; set; }
    }
}
