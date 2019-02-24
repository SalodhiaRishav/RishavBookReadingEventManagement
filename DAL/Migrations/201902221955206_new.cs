namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookReadingEvent", "StartTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookReadingEvent", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
