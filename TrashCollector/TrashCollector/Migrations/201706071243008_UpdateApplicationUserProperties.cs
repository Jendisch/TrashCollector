namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateApplicationUserProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PaymentType", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "CardNumber", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CardNumber");
            DropColumn("dbo.AspNetUsers", "PaymentType");
        }
    }
}
