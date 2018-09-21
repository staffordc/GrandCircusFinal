namespace GCFinal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedtrips : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PackingItems", "TripId", c => c.Int(nullable: false));
            CreateIndex("dbo.PackingItems", "TripId");
            AddForeignKey("dbo.PackingItems", "TripId", "dbo.Trips", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PackingItems", "TripId", "dbo.Trips");
            DropIndex("dbo.PackingItems", new[] { "TripId" });
            DropColumn("dbo.PackingItems", "TripId");
            DropTable("dbo.Trips");
        }
    }
}
