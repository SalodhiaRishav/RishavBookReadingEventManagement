namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changePostedCommentTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostedComment", "UserID", "dbo.User");
            DropIndex("dbo.PostedComment", new[] { "UserID" });
            RenameColumn(table: "dbo.PostedComment", name: "UserID", newName: "User_ID");
            AddColumn("dbo.PostedComment", "EmailID", c => c.String(nullable: false));
            AlterColumn("dbo.PostedComment", "User_ID", c => c.Int());
            CreateIndex("dbo.PostedComment", "User_ID");
            AddForeignKey("dbo.PostedComment", "User_ID", "dbo.User", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostedComment", "User_ID", "dbo.User");
            DropIndex("dbo.PostedComment", new[] { "User_ID" });
            AlterColumn("dbo.PostedComment", "User_ID", c => c.Int(nullable: false));
            DropColumn("dbo.PostedComment", "EmailID");
            RenameColumn(table: "dbo.PostedComment", name: "User_ID", newName: "UserID");
            CreateIndex("dbo.PostedComment", "UserID");
            AddForeignKey("dbo.PostedComment", "UserID", "dbo.User", "ID", cascadeDelete: true);
        }
    }
}
