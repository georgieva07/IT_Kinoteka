namespace Kinoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        image = c.String(),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Shows",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        description = c.String(),
                        image = c.String(),
                        released_date = c.String(),
                        rating = c.Single(nullable: false),
                        type = c.String(),
                        play_link = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shows");
            DropTable("dbo.People");
            DropTable("dbo.Genres");
        }
    }
}
