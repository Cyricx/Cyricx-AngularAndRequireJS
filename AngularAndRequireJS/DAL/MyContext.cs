using AngularAndRequireJS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularAndRequireJS.DAL
{
    public class MyContext: DbContext
    {
        //Collections that can be access through the context are expressed as DbSet<>'s
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }

        //Use the Constructor to define which connection string will be used by passing
        //the name to the parent constructor. This MUST match the name defined in the web.config
        public MyContext()
            : base ("MyConnectionString")
        {

        }
    }
}