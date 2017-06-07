namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNoPaymentModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payment", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Payment", new[] { "Id" });
            DropTable("dbo.Payment");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PaymentInfo = c.String(),
                        CurrentBill = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Payment", "Id");
            AddForeignKey("dbo.Payment", "Id", "dbo.AspNetUsers", "Id");
        }
    }
}
