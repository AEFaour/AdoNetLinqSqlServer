namespace ConsoleAppCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AjoutDuree : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Films", "Distribution");
        }

        public override void Down()
        {
            AddColumn("dbo.Films", "Distribution", c => c.String());
        }
    }
}
