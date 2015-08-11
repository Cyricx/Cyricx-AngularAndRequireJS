using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace AngularAndRequireJS.Models
{
    public class TicketCategory
    {
        [Key]
        public int TicketCategoryID { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        //Relationships
        //ICollection is used to represent a category has many tickets.
        //One way to stop circular reference with EF and Web API
        [JsonIgnore]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}