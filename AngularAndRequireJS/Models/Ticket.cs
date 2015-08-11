using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularAndRequireJS.Models
{
    public class Ticket
    {
        //[Key] explicit defines this as the primary key. In this case it is not necessary
        //as EF will make that assumption based on the naming convention of the ID.
        [Key]
        public int TicketID { get; set; }

        //Listing this as required will make it non-nullable
        //The stringlength will be used to define the sql field. Strings default to NVARCHAR
        //therefore this will become an NVARCHAR(250)
        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [Required]
        public bool IsClosed { get; set; }

        [Required]
        public DateTime SprintDate { get; set; }

        [Required]
        public string Details { get; set; }

        //If we did not want tickets to be required to have a category we would
        //leave off the [Required] tag and make the data type either
        //int? or Nullable<int>
        [Required]
        public int TicketCategoryID { get; set; }

        //public string TheImportantPropertyIForgotAbout { get; set; }

        //Relationships (virtual allows for lazy loading)
        public virtual TicketCategory TicketCategory { get; set; }
    }
}