namespace HeroAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hero",
                c => new
                    {
                        HeroId = c.Int(nullable: false, identity: true),
                        HeroName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HeroId);
            
            CreateTable(
                "dbo.PowerDetails",
                c => new
                    {
                        HeroId = c.Int(nullable: false),
                        PowerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HeroId, t.PowerId })
                .ForeignKey("dbo.Hero", t => t.HeroId, cascadeDelete: true)
                .ForeignKey("dbo.Power", t => t.PowerId, cascadeDelete: true)
                .Index(t => t.HeroId)
                .Index(t => t.PowerId);
            
            CreateTable(
                "dbo.Power",
                c => new
                    {
                        PowerId = c.Int(nullable: false, identity: true),
                        PowerName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PowerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PowerDetails", "PowerId", "dbo.Power");
            DropForeignKey("dbo.PowerDetails", "HeroId", "dbo.Hero");
            DropIndex("dbo.PowerDetails", new[] { "PowerId" });
            DropIndex("dbo.PowerDetails", new[] { "HeroId" });
            DropTable("dbo.Power");
            DropTable("dbo.PowerDetails");
            DropTable("dbo.Hero");
        }
    }
}
