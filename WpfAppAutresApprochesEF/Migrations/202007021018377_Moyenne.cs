namespace WpfAppAutresApprochesEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Moyenne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MoyennePasse = c.Int(nullable: false),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Etudiants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EtudiantCours",
                c => new
                    {
                        Cours_Id = c.Int(nullable: false),
                        Etudiant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cours_Id, t.Etudiant_Id })
                .ForeignKey("dbo.Cours", t => t.Cours_Id, cascadeDelete: true)
                .ForeignKey("dbo.Etudiants", t => t.Etudiant_Id, cascadeDelete: true)
                .Index(t => t.Cours_Id)
                .Index(t => t.Etudiant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EtudiantCours", "Etudiant_Id", "dbo.Etudiants");
            DropForeignKey("dbo.EtudiantCours", "Cours_Id", "dbo.Cours");
            DropIndex("dbo.EtudiantCours", new[] { "Etudiant_Id" });
            DropIndex("dbo.EtudiantCours", new[] { "Cours_Id" });
            DropTable("dbo.EtudiantCours");
            DropTable("dbo.Etudiants");
            DropTable("dbo.Cours");
        }
    }
}
