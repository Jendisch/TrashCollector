namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAdminName : DbMigration
    {
        public override void Up()
        {

            Sql("UPDATE ASPNETUsers SET FirstName='Administrator' WHERE LastName = 'Worker'");

        }
        
        public override void Down()
        {
        }
    }
}
