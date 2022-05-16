namespace IMDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "DirectorID", "dbo.Directors");
            DropIndex("dbo.Movies", new[] { "DirectorID" });
            AlterColumn("dbo.Movies", "DirectorID", c => c.Int());
            CreateIndex("dbo.Movies", "DirectorID");
            AddForeignKey("dbo.Movies", "DirectorID", "dbo.Directors", "DirectorID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "DirectorID", "dbo.Directors");
            DropIndex("dbo.Movies", new[] { "DirectorID" });
            AlterColumn("dbo.Movies", "DirectorID", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "DirectorID");
            AddForeignKey("dbo.Movies", "DirectorID", "dbo.Directors", "DirectorID", cascadeDelete: true);
        }
    }
}
