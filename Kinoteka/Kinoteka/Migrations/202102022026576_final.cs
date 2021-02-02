namespace Kinoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Show_id", "dbo.Shows");
            DropForeignKey("dbo.People", "Show_id1", "dbo.Shows");
            DropForeignKey("dbo.Genres", "Show_id", "dbo.Shows");
            DropIndex("dbo.Genres", new[] { "Show_id" });
            DropIndex("dbo.People", new[] { "Show_id" });
            DropIndex("dbo.People", new[] { "Show_id1" });
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        image = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        image = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ShowActors",
                c => new
                    {
                        Show_id = c.Int(nullable: false),
                        Actor_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Show_id, t.Actor_id })
                .ForeignKey("dbo.Shows", t => t.Show_id, cascadeDelete: true)
                .ForeignKey("dbo.Actors", t => t.Actor_id, cascadeDelete: true)
                .Index(t => t.Show_id)
                .Index(t => t.Actor_id);
            
            CreateTable(
                "dbo.DirectorShows",
                c => new
                    {
                        Director_id = c.Int(nullable: false),
                        Show_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Director_id, t.Show_id })
                .ForeignKey("dbo.Directors", t => t.Director_id, cascadeDelete: true)
                .ForeignKey("dbo.Shows", t => t.Show_id, cascadeDelete: true)
                .Index(t => t.Director_id)
                .Index(t => t.Show_id);
            
            CreateTable(
                "dbo.GenreShows",
                c => new
                    {
                        Genre_id = c.Int(nullable: false),
                        Show_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_id, t.Show_id })
                .ForeignKey("dbo.Genres", t => t.Genre_id, cascadeDelete: true)
                .ForeignKey("dbo.Shows", t => t.Show_id, cascadeDelete: true)
                .Index(t => t.Genre_id)
                .Index(t => t.Show_id);
            
            DropColumn("dbo.Genres", "Show_id");
            DropColumn("dbo.People", "Show_id");
            DropColumn("dbo.People", "Show_id1");
            DropColumn("dbo.Shows", "type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shows", "type", c => c.String(nullable: false));
            AddColumn("dbo.People", "Show_id1", c => c.Int());
            AddColumn("dbo.People", "Show_id", c => c.Int());
            AddColumn("dbo.Genres", "Show_id", c => c.Int());
            DropForeignKey("dbo.GenreShows", "Show_id", "dbo.Shows");
            DropForeignKey("dbo.GenreShows", "Genre_id", "dbo.Genres");
            DropForeignKey("dbo.DirectorShows", "Show_id", "dbo.Shows");
            DropForeignKey("dbo.DirectorShows", "Director_id", "dbo.Directors");
            DropForeignKey("dbo.ShowActors", "Actor_id", "dbo.Actors");
            DropForeignKey("dbo.ShowActors", "Show_id", "dbo.Shows");
            DropIndex("dbo.GenreShows", new[] { "Show_id" });
            DropIndex("dbo.GenreShows", new[] { "Genre_id" });
            DropIndex("dbo.DirectorShows", new[] { "Show_id" });
            DropIndex("dbo.DirectorShows", new[] { "Director_id" });
            DropIndex("dbo.ShowActors", new[] { "Actor_id" });
            DropIndex("dbo.ShowActors", new[] { "Show_id" });
            DropTable("dbo.GenreShows");
            DropTable("dbo.DirectorShows");
            DropTable("dbo.ShowActors");
            DropTable("dbo.Directors");
            DropTable("dbo.Actors");
            CreateIndex("dbo.People", "Show_id1");
            CreateIndex("dbo.People", "Show_id");
            CreateIndex("dbo.Genres", "Show_id");
            AddForeignKey("dbo.Genres", "Show_id", "dbo.Shows", "id");
            AddForeignKey("dbo.People", "Show_id1", "dbo.Shows", "id");
            AddForeignKey("dbo.People", "Show_id", "dbo.Shows", "id");
        }
    }
}
