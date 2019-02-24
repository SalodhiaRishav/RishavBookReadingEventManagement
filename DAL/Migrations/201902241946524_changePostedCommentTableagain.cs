namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changePostedCommentTableagain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostedComment", "User_ID", "dbo.User");
            DropIndex("dbo.PostedComment", new[] { "User_ID" });
            DropColumn("dbo.PostedComment", "User_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostedComment", "User_ID", c => c.Int());
            CreateIndex("dbo.PostedComment", "User_ID");
            AddForeignKey("dbo.PostedComment", "User_ID", "dbo.User", "ID");
        }
    }
}
