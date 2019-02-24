namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDUserID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookReadingEvent", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.BookReadingEvent", "UserID");
            AddForeignKey("dbo.BookReadingEvent", "UserID", "dbo.User", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookReadingEvent", "UserID", "dbo.User");
            DropIndex("dbo.BookReadingEvent", new[] { "UserID" });
            DropColumn("dbo.BookReadingEvent", "UserID");
        }
    }
}
