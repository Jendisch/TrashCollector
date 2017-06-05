namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PaymentInfo = c.String(),
                        CurrentBill = c.Double(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payment", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Payment", new[] { "Id" });
            DropTable("dbo.Payment");
        }
    }
}
