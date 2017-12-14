namespace ATOEBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectNum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ProjectNum", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "ProjectNum");
        }
    }
}
