﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfAppRequetesLinq.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BBVideotheque2Entities : DbContext
    {
        public BBVideotheque2Entities()
            : base("name=BBVideotheque2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Films> Films { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<pays> pays { get; set; }
        public virtual DbSet<PaysFilm> PaysFilm { get; set; }
        public virtual DbSet<vFilmLabelle> vFilmLabelle { get; set; }
    }
}
