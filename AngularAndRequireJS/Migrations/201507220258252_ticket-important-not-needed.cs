namespace AngularAndRequireJS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ticketimportantnotneeded : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tickets", "TheImportantPropertyIForgotAbout");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "TheImportantPropertyIForgotAbout", c => c.String());
        }
    }
}
