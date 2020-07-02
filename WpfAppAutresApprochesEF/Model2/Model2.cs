namespace WpfAppAutresApprochesEF.Model2
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model2 : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « Model2 » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « WpfAppAutresApprochesEF.Model1.Model2 » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « Model2 » dans le fichier de configuration de l'application.
        public Model2()
            : base("name=EFModel2")
        {
        }

        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Adherent> Adherents { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
    }
}

