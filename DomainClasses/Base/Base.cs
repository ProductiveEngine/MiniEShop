using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainClasses.Base
{
    public class Base : IObjectWithState
    {
        public Base()
        {
            CreatedDate = DateTime.Now;
        }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [NotMapped]
        public State State { get; set; }
    }
}
