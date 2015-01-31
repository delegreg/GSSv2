namespace BibliothequeGSS
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BibliothequeEF : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « BibliothequeEF » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « BibliothequeGSS.BibliothequeEF » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « BibliothequeEF » dans le fichier de configuration de l'application.
        public BibliothequeEF()
            : base("name=BibliothequeEF")
        {
        }

        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
         public virtual DbSet<SystemeSolaire> Systemes { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}