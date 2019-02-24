namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropUserID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookReadingEvent", "UserID", "dbo.User");
            DropIndex("dbo.BookReadingEvent", new[] { "UserID" });
            DropColumn("dbo.BookReadingEvent", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookReadingEvent", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.BookReadingEvent", "UserID");
            AddForeignKey("dbo.BookReadingEvent", "UserID", "dbo.User", "ID", cascadeDelete: true);
        }
    }
}
