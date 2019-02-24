namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropInvitedEventsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvitedToEvent", "BookReadingEventID", "dbo.BookReadingEvent");
            DropForeignKey("dbo.InvitedToEvent", "UserID", "dbo.User");
            DropForeignKey("dbo.PostedComment", "UserID", "dbo.User");
            DropIndex("dbo.InvitedToEvent", new[] { "UserID" });
            DropIndex("dbo.InvitedToEvent", new[] { "BookReadingEventID" });
            DropIndex("dbo.PostedComment", new[] { "UserID" });
            AlterColumn("dbo.PostedComment", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.PostedComment", "UserID");
            AddForeignKey("dbo.PostedComment", "UserID", "dbo.User", "ID", cascadeDelete: true);
            DropTable("dbo.InvitedToEvent");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.PostedComment", "UserID", "dbo.User");
            DropIndex("dbo.PostedComment", new[] { "UserID" });
            AlterColumn("dbo.PostedComment", "UserID", c => c.Int());
            CreateIndex("dbo.PostedComment", "UserID");
            CreateIndex("dbo.InvitedToEvent", "BookReadingEventID");
            CreateIndex("dbo.InvitedToEvent", "UserID");
            AddForeignKey("dbo.PostedComment", "UserID", "dbo.User", "ID");
            AddForeignKey("dbo.InvitedToEvent", "UserID", "dbo.User", "ID");
            AddForeignKey("dbo.InvitedToEvent", "BookReadingEventID", "dbo.BookReadingEvent", "ID");
        }
    }
}
