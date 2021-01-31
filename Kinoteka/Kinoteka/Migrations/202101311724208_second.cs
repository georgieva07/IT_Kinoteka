namespace Kinoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "Show_id", c => c.Int());
            AddColumn("dbo.People", "Show_id", c => c.Int());
            AddColumn("dbo.People", "Show_id1", c => c.Int());
            AddColumn("dbo.Shows", "Person_id", c => c.Int());
            AlterColumn("dbo.Genres", "name", c => c.String(nullable: false));
            AlterColumn("dbo.People", "name", c => c.String(nullable: false));
            AlterColumn("dbo.People", "role", c => c.String(nullable: false));
            AlterColumn("dbo.Shows", "title", c => c.String(nullable: false));
            AlterColumn("dbo.Shows", "rating", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Shows", "type", c => c.String(nullable: false));
            AlterColumn("dbo.Shows", "play_link", c => c.String(nullable: false));
            CreateIndex("dbo.Genres", "Show_id");
            CreateIndex("dbo.People", "Show_id");
            CreateIndex("dbo.People", "Show_id1");
            CreateIndex("dbo.Shows", "Person_id");
            AddForeignKey("dbo.People", "Show_id", "dbo.Shows", "id");
            AddForeignKey("dbo.People", "Show_id1", "dbo.Shows", "id");
            AddForeignKey("dbo.Genres", "Show_id", "dbo.Shows", "id");
            AddForeignKey("dbo.Shows", "Person_id", "dbo.People", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shows", "Person_id", "dbo.People");
            DropForeignKey("dbo.Genres", "Show_id", "dbo.Shows");
            DropForeignKey("dbo.People", "Show_id1", "dbo.Shows");
            DropForeignKey("dbo.People", "Show_id", "dbo.Shows");
            DropIndex("dbo.Shows", new[] { "Person_id" });
            DropIndex("dbo.People", new[] { "Show_id1" });
            DropIndex("dbo.People", new[] { "Show_id" });
            DropIndex("dbo.Genres", new[] { "Show_id" });
            AlterColumn("dbo.Shows", "play_link", c => c.String());
            AlterColumn("dbo.Shows", "type", c => c.String());
            AlterColumn("dbo.Shows", "rating", c => c.Single(nullable: false));
            AlterColumn("dbo.Shows", "title", c => c.String());
            AlterColumn("dbo.People", "role", c => c.String());
            AlterColumn("dbo.People", "name", c => c.String());
            AlterColumn("dbo.Genres", "name", c => c.String());
            DropColumn("dbo.Shows", "Person_id");
            DropColumn("dbo.People", "Show_id1");
            DropColumn("dbo.People", "Show_id");
            DropColumn("dbo.Genres", "Show_id");
        }
    }
}
