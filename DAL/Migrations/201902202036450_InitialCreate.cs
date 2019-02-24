namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookReadingEvent",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookTitle = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Location = c.String(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        Duration = c.Int(),
                        Description = c.String(),
                        OtherDetails = c.String(),
                        InvitedEmails = c.String(),
                        UserID = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookReadingEvent", "UserID", "dbo.User");
            DropIndex("dbo.BookReadingEvent", new[] { "UserID" });
            DropTable("dbo.User");
            DropTable("dbo.BookReadingEvent");
        }
    }
}
