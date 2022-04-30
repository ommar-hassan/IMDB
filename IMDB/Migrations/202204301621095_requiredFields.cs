namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Directors", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Directors", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Directors", "LastName", c => c.String());
            AlterColumn("dbo.Directors", "FirstName", c => c.String());
        }
    }
}
