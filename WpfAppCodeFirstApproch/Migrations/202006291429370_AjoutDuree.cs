namespace WpfAppCodeFirstApproch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutDuree : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Film_Id", "dbo.Films");
            DropIndex("dbo.Categories", new[] { "Film_Id" });
            CreateTable(
                "dbo.FilmCategories",
                c => new
                    {
                        Film_Id = c.Int(nullable: false),
                        Categorie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Film_Id, t.Categorie_Id })
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Categorie_Id, cascadeDelete: true)
                .Index(t => t.Film_Id)
                .Index(t => t.Categorie_Id);
            
            AddColumn("dbo.Films", "Duree", c => c.Int(nullable: false));
            DropColumn("dbo.Categories", "Film_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Film_Id", c => c.Int());
            DropForeignKey("dbo.FilmCategories", "Categorie_Id", "dbo.Categories");
            DropForeignKey("dbo.FilmCategories", "Film_Id", "dbo.Films");
            DropIndex("dbo.FilmCategories", new[] { "Categorie_Id" });
            DropIndex("dbo.FilmCategories", new[] { "Film_Id" });
            DropColumn("dbo.Films", "Duree");
            DropTable("dbo.FilmCategories");
            CreateIndex("dbo.Categories", "Film_Id");
            AddForeignKey("dbo.Categories", "Film_Id", "dbo.Films", "Id");
        }
    }
}
