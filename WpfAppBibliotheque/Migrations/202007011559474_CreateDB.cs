namespace WpfAppBibliotheque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auteurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prenom = c.String(),
                        Nom = c.Int(nullable: false),
                        Livre_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Livres", t => t.Livre_Id)
                .Index(t => t.Livre_Id);
            
            CreateTable(
                "dbo.Livres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Description = c.String(),
                        Annee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auteurs", "Livre_Id", "dbo.Livres");
            DropIndex("dbo.Auteurs", new[] { "Livre_Id" });
            DropTable("dbo.Livres");
            DropTable("dbo.Auteurs");
        }
    }
}
