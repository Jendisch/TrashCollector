namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateScheduleAndPaymentModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DefaultPickupDay = c.String(),
                        VacationStartDate = c.DateTime(),
                        VacationEndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "StartDate", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedule", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Schedule", new[] { "Id" });
            DropColumn("dbo.AspNetUsers", "StartDate");
            DropTable("dbo.Schedule");
        }
    }
}
