namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTwoTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvitedToEvent",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(),
                        BookReadingEventID = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BookReadingEvent", t => t.BookReadingEventID)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.BookReadingEventID);
            
            CreateTable(
                "dbo.PostedComment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookReadingEventID = c.Int(),
                        Comments = c.String(nullable: false),
                        UserID = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BookReadingEvent", t => t.BookReadingEventID)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.BookReadingEventID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostedComment", "UserID", "dbo.User");
            DropForeignKey("dbo.PostedComment", "BookReadingEventID", "dbo.BookReadingEvent");
            DropForeignKey("dbo.InvitedToEvent", "UserID", "dbo.User");
            DropForeignKey("dbo.InvitedToEvent", "BookReadingEventID", "dbo.BookReadingEvent");
            DropIndex("dbo.PostedComment", new[] { "UserID" });
            DropIndex("dbo.PostedComment", new[] { "BookReadingEventID" });
            DropIndex("dbo.InvitedToEvent", new[] { "BookReadingEventID" });
            DropIndex("dbo.InvitedToEvent", new[] { "UserID" });
            DropTable("dbo.PostedComment");
            DropTable("dbo.InvitedToEvent");
        }
    }
}
