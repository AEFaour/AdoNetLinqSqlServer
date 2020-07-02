namespace WpfAppAutresApprochesEF.Model3
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EFModel3 : DbContext
    {
        public EFModel3()
            : base("name=EFModel3")
        {
        }

        public virtual DbSet<Cours> Cours { get; set; }
        public virtual DbSet<Etudiants> Etudiants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cours>()
                .HasMany(e => e.Etudiants)
                .WithMany(e => e.Cours)
                .Map(m => m.ToTable("EtudiantCours").MapRightKey("Etudiant_Id"));
        }
    }
}
