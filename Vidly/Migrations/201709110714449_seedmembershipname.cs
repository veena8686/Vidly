namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedmembershipname : DbMigration
    {
        public override void Up()
        {
            Sql("update membershiptypes set name = 'Pay as you go' where id = 1");
            Sql("update membershiptypes set name = 'Monthly' where id = 2");
            Sql("update membershiptypes set name = 'Quaterly' where id = 3");
            Sql("update membershiptypes set name = 'Yearly' where id = 4");
        }

        public override void Down()
        {
        }
    }
}
