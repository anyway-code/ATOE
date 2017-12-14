namespace ATOEBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        ResourceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ResourceId);
            
            CreateTable(
                "dbo.ResourceUsages",
                c => new
                    {
                        ResourceUsageId = c.Int(nullable: false, identity: true),
                        Start = c.DateTimeOffset(precision: 7),
                        End = c.DateTimeOffset(precision: 7),
                        ResourceId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResourceUsageId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Resources", t => t.ResourceId, cascadeDelete: true)
                .Index(t => t.ResourceId)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResourceUsages", "ResourceId", "dbo.Resources");
            DropForeignKey("dbo.ResourceUsages", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ResourceUsages", new[] { "ProjectId" });
            DropIndex("dbo.ResourceUsages", new[] { "ResourceId" });
            DropTable("dbo.ResourceUsages");
            DropTable("dbo.Resources");
            DropTable("dbo.Projects");
        }
    }
}
