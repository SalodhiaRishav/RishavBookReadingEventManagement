namespace DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DAL.Domains;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Dbcontext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Dbcontext context)
        {

            var users = new List<User>
            {
            new User{Email="def.abc@gmail.com",FirstName="abc",LastName="def",Password="mypass",ModifiedOn=DateTime.Now,CreatedOn=DateTime.Now}
            };
            users.ForEach(s => context.Users.AddOrUpdate(s));
            context.SaveChanges();

            var events = new List<BookReadingEvent>
            {
                new BookReadingEvent{ModifiedOn = DateTime.Now, CreatedOn = DateTime.Now,BookTitle = "RishavBook",Date=DateTime.Now,Location="Best PG",StartTime="1",Type=Shared.CustomDataTypes.EventType.Public,UserID=1}               
            };
            events.ForEach(s => context.BookReadingEvents.AddOrUpdate(s));
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
