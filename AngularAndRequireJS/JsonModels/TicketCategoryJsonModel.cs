using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularAndRequireJS.JsonModels
{
    public class TicketCategoryJsonModel
    {
        public int TicketCategoryID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int TicketCount { get; set; }
    }
}