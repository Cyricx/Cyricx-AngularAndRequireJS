namespace AngularAndRequireJS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketCategories",
                c => new
                    {
                        TicketCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TicketCategoryID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        IsClosed = c.Boolean(nullable: false),
                        SprintDate = c.DateTime(nullable: false),
                        Details = c.String(nullable: false),
                        TicketCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.TicketCategories", t => t.TicketCategoryID, cascadeDelete: true)
                .Index(t => t.TicketCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TicketCategoryID", "dbo.TicketCategories");
            DropIndex("dbo.Tickets", new[] { "TicketCategoryID" });
            DropTable("dbo.Tickets");
            DropTable("dbo.TicketCategories");
        }
    }
}
