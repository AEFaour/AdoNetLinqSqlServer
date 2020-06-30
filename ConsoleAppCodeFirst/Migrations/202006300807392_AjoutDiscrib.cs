namespace ConsoleAppCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AjoutDiscrib : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Films", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Films", new[] { "Genre_Id" });
            CreateTable(
                "dbo.GenreFilms",
                c => new
                {
                    Genre_Id = c.Int(nullable: false),
                    Film_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Genre_Id, t.Film_Id })
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Film_Id);

            AddColumn("dbo.Films", "Distribution", c => c.String());
            DropColumn("dbo.Films", "Genre_Id");
        }

        public override void Down()
        {
            AddColumn("dbo.Films", "Genre_Id", c => c.Int());
            DropForeignKey("dbo.GenreFilms", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.GenreFilms", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.GenreFilms", new[] { "Film_Id" });
            DropIndex("dbo.GenreFilms", new[] { "Genre_Id" });
            DropColumn("dbo.Films", "Distribution");
            DropTable("dbo.GenreFilms");
            CreateIndex("dbo.Films", "Genre_Id");
            AddForeignKey("dbo.Films", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
