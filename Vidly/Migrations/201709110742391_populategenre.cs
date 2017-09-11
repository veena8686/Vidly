namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populategenre : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres(name) values('Comedy')");
            Sql("insert into Genres(name) values('Action')");
            Sql("insert into Genres(name) values('Family')");
            Sql("insert into Genres(name) values('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
