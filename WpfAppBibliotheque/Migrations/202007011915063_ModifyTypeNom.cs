namespace WpfAppBibliotheque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTypeNom : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Auteurs", "Nom", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Auteurs", "Nom", c => c.Int(nullable: false));
        }
    }
}
