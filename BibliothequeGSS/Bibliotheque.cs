using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeGSS
{

    #region Generateurs
    public class GenerateurSystemeSolaire
    {
        private SystemeSolaire sy;

        public GenerateurSystemeSolaire(SystemeSolaire sy)
        {
            // TODO: Complete member initialization
            this.sy = sy;
        }


        public void GenererSysteme()
        {
            //sy.DeterminerTableEtoile();
            int nbEtoiles=//sy.tableEtoile.Count;
            for (int i = 0; i < nbEtoiles; i++)
            {
                Etoile et = new Etoile();
                GenerateurEtoile get = new GenerateurEtoile(et);
                get.GenererEtoile();
                sy.tableEtoile.Add(et);
            }
            
            
        }
    }
    #endregion
    
    
    #region Classes composant le Système Solaire
        public class SystemeSolaire
        {
            #region Attributs Système Solaire
            public List<Etoile> tableEtoile=new List<Etoile>();
            public List<Population> tablePopNativeSS = new List<Population>();
            public string id_SS = "SS0";
            public string nomSS = "Système Solaire";
            public int portail = 0;
            public bool systemColonise = false;
            public string raceColonie = "";
            public bool debrisSpatiaux = false;
            public bool etoileInstable = false;
            public int nuageOort = 0;
            public bool repairePirate = false;
            public bool comptoirMarchand = false;
            public string gouvernance = "Personne";
            public int niveauMenace = 0;
            public int niveauSecurite = 0;
            public string commentaireSS = "";
            #endregion

            #region Méthodes Système Solaire
            public void NbPortail() 
            {
                int jetDes = (new JetDes()).JeterD(1, 100);
                if (jetDes < 6)
                {
                    this.portail = 0;
                }
                else if (jetDes < 20 && jetDes > 5)
                {
                    this.portail = 1;
                }
                else
                {
                    this.portail = 2;
                }
            }
            public void colonisationSS()
            {
                int jetDes = (new JetDes()).JeterD(1, 100);
                this.systemColonise = false;
                switch(this.portail)
                {
                    case 0 :
                        if(jetDes < 6)
                        {
                            this.systemColonise = true;
                        }
                        break;
                    case 1:
                        if (jetDes < 16)
                        {
                            this.systemColonise = true;
                        }
                        break;
                    case 2:
                        if (jetDes < 31)
                        {
                            this.systemColonise = true;
                        }
                        break;
                }
                if (this.systemColonise)
                {
                    jetDes = (new JetDes()).JeterD(1, 4);
                    switch (jetDes)
                    {
                        case 1:
                            this.raceColonie = "Humain";
                            break;
                        case 2:
                            this.raceColonie = "Narn";
                            break;
                        case 3:
                            this.raceColonie = "Centauri";
                            break;
                        case 4:
                            this.raceColonie = "Minbari";
                            break;
                    }
                }
            }
            public void NbDebrisSpatiaux()
            {
                int jetDes = (new JetDes()).JeterD(1, 100);
                if (jetDes < 9)
                {
                    this.debrisSpatiaux = true;
                }
                else
                {
                    this.debrisSpatiaux = false;
                }
            }
            public void EtoileInstable()
            {
                int jetDes = (new JetDes()).JeterD(1, 100);
                if (jetDes < 3)
                {
                    this.etoileInstable = true;
                }
                else
                {
                    this.etoileInstable = false;
                }
            }
            public void NuageOort()
            {
                int jetDes = (new JetDes()).JeterD(1, 100);
                if (jetDes < 11)
                {
                    this.nuageOort = 1;
                }
                else if (jetDes == 11)
                {
                    this.nuageOort = 2;
                }
                else
                {
                    this.nuageOort = 0;
                }
            }
            public void RepairePirate()
            {
                int jetDes = (new JetDes()).JeterD(1, 100);
                this.repairePirate = false;
                if(this.tablePopNativeSS.Count() != 0)
                {
                    if(jetDes < 16)
                    {
                        this.repairePirate = true;
                    }
                }
                else
                {
                    if (jetDes < 6)
                    {
                        this.repairePirate = true;
                    }
                }
            }
            public void ComptoirMarchand()
            {
                int jetDes = (new JetDes()).JeterD(1, 100);
                this.comptoirMarchand = false;
                if (this.tablePopNativeSS.Count() != 0)
                {
                    if (jetDes < 9)
                    {
                        this.comptoirMarchand = true;
                    }
                }
                else
                {
                    if (jetDes < 3)
                    {
                        this.comptoirMarchand = true;
                    }
                }
            }
            public void Gouvernance()
            {

            }
            public void NiveauMenace()
            {

            }
            public void NiveauSecurite()
            {

            }
            public void DeterminerTableEtoile()
            {
                int jetDes = (new JetDes()).JeterD(2, 10);
                int nbEtoile;
                if (jetDes < 18)
                {
                    nbEtoile = 1;
                }
                else if (jetDes < 20 && jetDes > 17)
                {
                    nbEtoile = 2;
                }
                else
                {
                    nbEtoile = 3;
                }
                // on créer un nombre d'étoile égal à nbEtoile
                for (int i = 0; i < nbEtoile; i++)
                {
                    this.tableEtoile.Add(new Etoile(this, i));
                }
            }
            public int NbEtoile()
            {
                return this.tableEtoile.Count();
            }
            public int NombreGeanteGazeuse()
            {
                int nbGG = 0;
                foreach (Etoile etoile in this.tableEtoile)
                {
                    foreach (Planete plnt in etoile.tableElementSysteme)
                    {
                        if (plnt.typeCC == "Géante Gazeuse")
                        {
                            nbGG = nbGG + 1;
                        }
                    }
                }
                return nbGG;
            }
            public void ColonisationDuSS()
            {

                foreach(Population pop in tablePopNativeSS)
                {
                    int nbColonie = 0;
                    JetDes jet = new JetDes();
                    int jetDes;
                    Queue<CeintureAsteroide> listeCASS = new Queue<CeintureAsteroide>();
                    Queue<Planete> listePSS = new Queue<Planete>();
                    Queue<Satellite> listeSSS = new Queue<Satellite>();


                    switch(pop.niveauTechnoPo)
                    {
                        case 6:
                            nbColonie = jet.JeterD(1, 2, -1);
                            break;
                        case 7:
                            nbColonie = jet.JeterD(1, 3, -1);
                            break;
                        case 8:
                            nbColonie = jet.JeterD(1, 4, -1);
                            break;
                    }
                    // on rassemble tous les éléments du système solaire dans deux files : une pour les corpscelestes et l'autre pour les astéroïdes
                    foreach (Etoile etoile in this.tableEtoile)
                    {
                        foreach (Planete plnt in etoile.tableElementSysteme)
                        {
                            if (plnt.typeCC != "Géante Gazeuse")
                            {
                                listePSS.Enqueue(plnt);
                            }
                            foreach (Satellite satellite in plnt.tableSatellite)
                            {
                                listeSSS.Enqueue(satellite);
                            }
                        }
                        foreach (CeintureAsteroide ca in etoile.tableElementSysteme)
                        {
                            listeCASS.Enqueue(ca);
                        }
                    }
                    // trier les objet en fonction de la zone d'origine de la population
                    // on parcours ensuite tous les éléments de ces deux queues pour savoir si la population de la ceinture d'astéroïdes possède une autre planètes dans le systéme solaire
                    while (nbColonie != 0)
                    {
                        int choix = jet.JeterD(1, 3);
                        if (choix == 1 && listeCASS.Count != 0)
                        {
                            choix = jet.JeterD(1, listeCASS.Count, -1);

                        }
                        else if (choix == 2 && listePSS.Count != 0)
                        {
                            choix = jet.JeterD(1, listePSS.Count, -1);
                        }
                        else if (choix == 3 && listeSSS.Count != 0)
                        {
                            choix = jet.JeterD(1, listeSSS.Count, -1);
                        }
                    }
                }
            }
            #endregion
        }

        public class Etoile
        {
            #region Attributs Etoile
            public SystemeSolaire systemSE;
            public ArrayList tableElementSysteme;
            public string id_E = "";
            public string nomE = "";
            public string typeE = "";
            public string tailleE = "";
            public int qualificationType = 0;
            public string commentaireE = "";
            #endregion 

            #region Méthodes Etoile
            public void TailleEtoile()
            {
                int jetDes = (new JetDes()).JeterD(1, 100);
                if (jetDes == 2)
                {
                    this.typeE = "B";
                }
                else if (jetDes == 3)
                {
                    this.typeE = "A";
                }
                else if (jetDes > 3 && jetDes < 9)
                {
                    this.typeE = "F";
                }
                else if (jetDes > 8 && jetDes < 14)
                {
                    this.typeE = "G";
                }
                else if (jetDes > 13 && jetDes < 17)
                {
                    this.typeE = "K";
                }
                else if (jetDes > 16)
                {
                    this.typeE = "M";
                }
            }
            public void TypeEtoile()
            {
                int jetDes = (new JetDes()).JeterD(1, 100);
                if (jetDes == 2)
                {
                    this.tailleE = "IV";
                }
                else if (jetDes > 2 && jetDes < 17)
                {
                    this.tailleE = "V";
                }
                else if (jetDes > 16)
                {
                    this.tailleE = "VI";
                }
            }
            public void QualificationType()
            {
                this.qualificationType = (new JetDes()).JeterD(1, 10);
            }
            public void DeterminerTableElementSS()
            {
                int nbEtoile = this.systemSE.NbEtoile();
                // détermine le modificateur au jet de dé en fonction du type de l'étoile
                int modificateurs = 0;
                switch (this.typeE)
                {
                    case "O":
                        modificateurs = modificateurs - 15;
                        break;
                    case "B":
                        modificateurs = modificateurs - 12;
                        break;
                    case "A":
                        modificateurs = modificateurs - 10;
                        break;
                    case "F":
                        modificateurs = modificateurs - 4;
                        break;
                    case "G":
                        modificateurs = modificateurs - 2;
                        break;
                    case "K":
                        modificateurs = modificateurs - 6;
                        break;
                    case "M":
                        modificateurs = modificateurs - 10;
                        break;
                }

                // détermine le modificateur au jet de dé en fonction du taille de l'étoile
                switch (this.tailleE)
                {
                    case "Ia":
                        modificateurs = modificateurs - 8;
                        break;
                    case "Ib":
                        modificateurs = modificateurs - 6;
                        break;
                    case "II":
                        modificateurs = modificateurs - 4;
                        break;
                    case "III":
                        modificateurs = modificateurs - 2;
                        break;
                    case "IV":
                        modificateurs = modificateurs - 1;
                        break;
                    case "VI":
                        modificateurs = modificateurs - 1;
                        break;
                    case "VII":
                        modificateurs = modificateurs - 4;
                        break;
                }
                switch (nbEtoile)
                {
                    case 2:
                        modificateurs = modificateurs - 2;
                        break;
                    case 3:
                        modificateurs = modificateurs - 6;
                        break;
                }
                int jetDes = (new JetDes()).JeterD(3);
                int nbElementSS = jetDes + modificateurs;
                // si jetDes est égale à 18 et qu'il n'y a aucune planète après 
                // l'addition du jetDes et des modificateurs : le système comportera au moins une étoile
                if (jetDes + modificateurs < 0 && jetDes == 18)
                {
                    nbElementSS = 1;
                }
                // dans le cas où le nombre de planète est négatif ou nul et que
                // jetDes est différent de 18 alors il n'y a pas de planete dans ce système solaire 
                else if (jetDes + modificateurs < 0 && jetDes != 18)
                {
                    nbElementSS = 0;
                }
                // dans le cas classique où le nombre de planète est strictement positif 
                // on créé alors un nombre égale d'objet Planète reliés à l'objet Etoile
                for (int j = 0; j < nbElementSS; j++)
                {
                    // determiner la sous-classe : CorpsCeleste.Planete ou CeintureAsteroide
                    ElementSysteme nouvelElementSS = new ElementSysteme();
                    string zoneES;
                    string typeES;
                    zoneES = nouvelElementSS.Zone(this.typeE);
                    typeES = nouvelElementSS.DeterminerTypeES(zoneES);
                    if (typeES == "Géante Gazeuse" || typeES == "Terrestre" || typeES == "Glaciale")
                    {
                        this.tableElementSysteme.Add(new Planete(this, j.ToString() + this.id_E, zoneES, typeES));
                    }
                    else
                    {
                        this.tableElementSysteme.Add(new CeintureAsteroide(this, j.ToString() + this.id_E, zoneES));
                    }
                }
            }
            public int NbElementSS()
            {
                return this.tableElementSysteme.Count;
            }
            #endregion

            #region Constructeurs Etoile
            public Etoile(SystemeSolaire system, int rang)
            {
                this.systemSE = system;
                this.id_E = "E" + rang;
                this.nomE = "Etoile n°" + rang;
                this.TypeEtoile();
                this.TailleEtoile();
            }
            #endregion
        }

        public class ElementSysteme
        {
            #region Attributs ElementSystème
            public Etoile etoileES;
            public string id_ES = "";
            public string nomES = "";
            public string zone = "";
            public string densiteAtmos = "";
            public string commentaireES = "";
            #endregion

            #region Méthodes ElémentSystème
            public string DeterminerTypeES(string zoneES)
            {
                int jetDes = (new JetDes()).JeterD(1, 20);
                string resultat = "";
                if (this is Satellite)
                {
                    switch (zoneES)
                    {
                        case "Chaude":
                            resultat = "Terrestre";
                            break;
                        case "Habitable":
                            if (jetDes < 16)
                            {
                                resultat = "Terrestre";
                            }
                            
                            else
                            {
                                resultat = "Glaciale";
                            }
                            break;
                        case "Froide":
                            if (jetDes < 9)
                            {
                                resultat = "Terrestree";
                            }
                            
                            else
                            {
                                resultat = "Glaciale";
                            }
                            break;
                    }
                }
                else
                {
                    switch (zoneES)
                    {
                        case "Chaude":
                            if (jetDes < 3)
                            {
                                resultat = "Géante Gazeuse";
                            }
                            else if (jetDes < 20 && jetDes > 2)
                            {
                                resultat = "Terrestre";
                            }
                            else if (jetDes > 19)
                            {
                                resultat = "Ceinture d'Astéroide";
                            }
                            break;
                        case "Habitable":
                            if (jetDes < 5)
                            {
                                resultat = "Géante Gazeuse";
                            }
                            else if (jetDes < 19 && jetDes > 4)
                            {
                                resultat = "Terrestre";
                            }
                            else if (jetDes == 19)
                            {
                                resultat = "Ceinture d'Astéroide";
                            }
                            else if (jetDes == 20)
                            {
                                resultat = "Glaciale";
                            }
                            break;
                        case "Froide":
                            if (jetDes < 9)
                            {
                                resultat = "Géante Gazeuse";
                            }
                            else if (jetDes < 11 && jetDes > 8)
                            {
                                resultat = "Terrestre";
                            }
                            else if (jetDes < 13 && jetDes > 10)
                            {
                                resultat = "Ceinture d'Astéroide";
                            }
                            else if (jetDes > 12)
                            {
                                resultat = "Glaciale";
                            }
                            break;
                    }
                }
                return resultat;
            }
            public string Zone(string typeE)
            {
                int jetDes = (new JetDes()).JeterD(1,20);
                string resultat = "";
                switch (typeE)
                {
                    case "O":
                        if (jetDes < 13)
                        {
                            resultat = "Chaude";
                        }
                        else if (jetDes < 15 && jetDes > 12)
                        {
                            resultat = "Habitable";
                        }
                        else if (jetDes > 14)
                        {
                            resultat = "Froide";
                        }
                        break;
                    case "B":
                        if (jetDes < 11)
                        {
                            resultat = "Chaude";
                        }
                        else if (jetDes < 13 && jetDes > 10)
                        {
                            resultat = "Habitable";
                        }
                        else if (jetDes > 12)
                        {
                            resultat = "Froide";
                        }
                        break;
                    case "A":
                        if (jetDes < 9)
                        {
                            resultat = "Chaude";
                        }
                        else if (jetDes < 11 && jetDes > 8)
                        {
                            resultat = "Habitable";
                        }
                        else if (jetDes > 10)
                        {
                            resultat = "Froide";
                        }
                        break;
                    case "F":
                        if (jetDes < 7)
                        {
                            resultat = "Chaude";
                        }
                        else if (jetDes < 10 && jetDes > 6)
                        {
                            resultat = "Habitable";
                        }
                        else if (jetDes > 9)
                        {
                            resultat = "Froide";
                        }
                        break;
                    case "G":
                        if (jetDes < 6)
                        {
                            resultat = "Chaude";
                        }
                        else if (jetDes < 10 && jetDes > 7)
                        {
                            resultat = "Habitable";
                        }
                        else if (jetDes > 9)
                        {
                            resultat = "Froide";
                        }
                        break;
                    case "K":
                        if (jetDes < 5)
                        {
                            resultat = "Chaude";
                        }
                        else if (jetDes < 7 && jetDes > 4)
                        {
                            resultat = "Habitable";
                        }
                        else if (jetDes > 6)
                        {
                            resultat = "Froide";
                        }
                        break;
                    case "M":
                        if (jetDes < 3)
                        {
                            resultat = "Chaude";
                        }
                        else if (jetDes == 3)
                        {
                            resultat = "Habitable";
                        }
                        else if (jetDes > 3)
                        {
                            resultat = "Froide";
                        }
                        break;
                }
                return resultat;
            }
            #endregion

        }

        public class CeintureAsteroide : ElementSysteme
        {
            #region Attributs CeintureAstéroïde
            public List<AsteroideMajeur> tableAsteroid;
            public PopulationAsteroide populationCA;
            public bool estColonise = false;
            public string densiteCA = "";
            #endregion

            #region Méthodes CeintureAstéroïde
            public void DensiteCeinture()
            {
                int jetDes = new JetDes().JeterD(1,20);
                if (this.etoileES.systemSE.NombreGeanteGazeuse() > 2)
                {
                    jetDes = jetDes - 4;
                }
                else if (this.etoileES.systemSE.NombreGeanteGazeuse() < 2)
                {
                    jetDes = jetDes + 2;
                }

                //resultat
                if(jetDes < 6)
                {
                    this.densiteCA = "Légère";
                }
                else if(jetDes < 16 && jetDes > 5)
                {
                    this.densiteCA = "Moyenne";
                }
                else if (jetDes < 19 && jetDes > 15)
                {
                    this.densiteCA = "Dense";
                }
                else if (jetDes > 18)
                {
                    this.densiteCA = "Très Dense";
                }
            }
            public void DeterminerNbAM()
            {
                int nbAsteroid = new JetDes().JeterD();
                switch(this.densiteCA)
                {
                    case "Légère":
                        nbAsteroid = nbAsteroid - 3;
                            break;
                    case "Moyenne":
                        nbAsteroid = nbAsteroid - 1;
                        break;
                    case "Dense":
                        nbAsteroid = nbAsteroid + 2;
                        break;
                    case "Très Dense":
                        nbAsteroid = nbAsteroid + 6;
                        break;
                }
                for (int i = 0; i < nbAsteroid; i++)
                {
                    this.tableAsteroid.Add(new AsteroideMajeur(this, i));
                }
            }
            #endregion

            #region Constructeurs CeintureAstéroïde
            public CeintureAsteroide(Etoile etoile, string numero, string zoneES)
            {
                this.etoileES = etoile;
                this.zone = zoneES;
                this.densiteAtmos = "Vide";
                this.estColonise = false;
                this.id_ES = "CA";// +id;
                this.nomES = "Ceinture d'Astéroïde n°" + numero;
                this.DensiteCeinture();
                this.DeterminerNbAM();
            }
            #endregion
        }

        public class CorpsCeleste : ElementSysteme
        {
            #region Attributs CorpsCéleste
            public List<Population> populationsCC;
            public string typeCC = "";
            public int tailleCC = 0; // cette propriété ne peut prendre que les valeurs : 
            // 0 correspondant à la catégorie Minuscule
            // 1 correspondant à la catégorie Fine
            // 2 correspondant à la catégorie Toute Petite
            // 3 correspondant à la catégorie Petite
            // 4 correspondant à la catégorie Moyenne
            // 5 correspondant à la catégorie Grande
            // 6 correspondant à la catégorie Enorme
            // 7 correspondant à la catégorie Petite Géante Gazeuse
            // 8 correspondant à la catégorie Géante Gazeuse Moyenne
            // 9 correspondant à la catégorie Enorme Géante Gazeuse
            // 10 correspondant à la catégorie Gargantuesque Géante Gazeuse
            public string diametreCC = ""; // représenté par le nom de la catégorie + le diametre en km
            public string gravite = "";
            public string atmosCompo = "";
            public string pollution = "";
            public string geologie= "";
            public string volcanisme = "";
            public string hydrosphere = "";
            public int tauxHydro = 0;
            public string geographie;
            public string climat = "";
            public int tempPole =  0;
            public string densiteBio = "";
            public string complexiteBio = "";
            public bool artefactAncien = false;
            public int mixPopulation = 0; // cette propriété ne peut prendre que quatre valeurs : 0 si il n'y a pas de population du tout
                                          //                                                     1 si la population de ce monde est exclusivement native;
                                          //                                                     2 si la population de ce monde est exclusivement coloniale;
                                          //                                                     3 si la population de ce monde est un mélange natif/colonial.
            #endregion

            #region Méthodes CorpsCéleste
            public void Gravite()
            {
                // correspond à un 1d20
                int jetDes = (new JetDes()).JeterD(1, 20);

                // règle additionnelle : si la planète est glaciale alors il faut soustraire 4 au jet de dé
                if (this.typeCC == "Glaciale")
                {
                    jetDes = jetDes - 4;
                }

                // servira à extraire la chaine de caratère correspondant à la catégorie de taille de la planète
                int categorieTaille = this.tailleCC;

                // compare la chaine de caractère correspondant à la catégorie de taille de la planète pour déterminer la gravité
                switch (categorieTaille)
                {
                    case 0:
                        if (jetDes < 20)
                        {
                            this.gravite = "Microgravité";
                        }
                        else
                        {
                            this.gravite = "Très Basse";
                        }
                        break;
                    case 1:
                        if (jetDes < 16)
                        {
                            this.gravite = "Microgravité";
                        }
                        else
                        {
                            this.gravite = "Très Basse";
                        }
                        break;
                    case 2:
                        if (jetDes < 11)
                        {
                            this.gravite = "Microgravité";
                        }
                        else
                        {
                            this.gravite = "Très Basse";
                        }
                        break;
                    case 3:
                        if (jetDes < 11)
                        {
                            this.gravite = "Très Basse";
                        }
                        else if (jetDes < 20 && jetDes > 10)
                        {
                            this.gravite = "Basse";
                        }
                        else
                        {
                            this.gravite = "Moyenne";
                        }
                        break;
                    case 4:
                        if (jetDes < 3)
                        {
                            this.gravite = "Très Basse";
                        }
                        else if (jetDes < 8 && jetDes > 2)
                        {
                            this.gravite = "Basse";
                        }
                        else if (jetDes < 16 && jetDes > 7)
                        {
                            this.gravite = "Moyenne";
                        }
                        else
                        {
                            this.gravite = "Forte";
                        }
                        break;
                    case 5:
                        if (jetDes < 3)
                        {
                            this.gravite = "Basse";
                        }
                        else if (jetDes < 6 && jetDes > 2)
                        {
                            this.gravite = "Moyenne";
                        }
                        else if (jetDes < 13 && jetDes > 7)
                        {
                            this.gravite = "Forte";
                        }
                        else if (jetDes < 19 && jetDes > 12)
                        {
                            this.gravite = "Très Forte";
                        }
                        else
                        {
                            this.gravite = "Extrème";
                        }
                        break;
                    case 6:
                        if (jetDes < 2)
                        {
                            this.gravite = "Basse";
                        }
                        else if (jetDes < 4 && jetDes > 1)
                        {
                            this.gravite = "Moyenne";
                        }
                        else if (jetDes < 11 && jetDes > 3)
                        {
                            this.gravite = "Forte";
                        }
                        else if (jetDes < 17 && jetDes > 10)
                        {
                            this.gravite = "Très Forte";
                        }
                        else
                        {
                            this.gravite = "Extrème";
                        }
                        break;
                    default:
                        // la gravité pour les géantes gazeuses suit des règles spéciales
                        this.gravite = "Extrème";
                        break;
                }
            }
            public void DensiteAtmos()
            {

                // correspond à un 1d20
                int jetDes = (new JetDes()).JeterD(1, 20);

                // règle additionnelle : si la planète est une lune
                if (this is Satellite)
                {
                    jetDes = jetDes - 2;
                }
                // règle additionnelle : si la planète est glaciale alors il faut soustraire 4 au jet de dé
                if (this.zone == "Chaude" || this.zone == "Froide")
                {
                    jetDes = jetDes - 4;
                }

                if (this.typeCC != "Géante Gazeuse")
                {
                    switch (this.gravite)
                    {
                        case "Microgravité":
                            if (jetDes < 20)
                            {
                                this.densiteAtmos = "Vide";
                            }
                            else
                            {
                                this.densiteAtmos = "Très Faible";
                            }
                            break;
                        case "Très Basse":
                            if (jetDes < 10)
                            {
                                this.densiteAtmos = "Vide";
                            }
                            else if (jetDes < 19 && jetDes > 9)
                            {
                                this.densiteAtmos = "Très Faible";
                            }
                            else
                            {
                                this.densiteAtmos = "Faible";
                            }
                            break;
                        case "Basse":
                            if (jetDes < 6)
                            {
                                this.densiteAtmos = "Vide";
                            }
                            else if (jetDes < 11 && jetDes > 5)
                            {
                                this.densiteAtmos = "Très Faible";
                            }
                            else if (jetDes < 16 && jetDes > 10)
                            {
                                this.densiteAtmos = "Faible";
                            }
                            else
                            {
                                this.densiteAtmos = "Moyenne";
                            }
                            break;
                        case "Moyenne":
                            if (jetDes < 3)
                            {
                                this.densiteAtmos = "Vide";
                            }
                            else if (jetDes < 4 && jetDes > 2)
                            {
                                this.densiteAtmos = "Très Faible";
                            }
                            else if (jetDes < 7 && jetDes > 3)
                            {
                                this.densiteAtmos = "Faible";
                            }
                            else if (jetDes < 11 && jetDes > 6)
                            {
                                this.densiteAtmos = "Moyenne";
                            }
                            else if (jetDes < 16 && jetDes > 10)
                            {
                                this.densiteAtmos = "Dense";
                            }
                            else
                            {
                                this.densiteAtmos = "Très Dense";
                            }
                            break;
                        case "Forte":
                            if (jetDes < 2)
                            {
                                this.densiteAtmos = "Vide";
                            }
                            else if (jetDes < 4 && jetDes > 1)
                            {
                                this.densiteAtmos = "Très Faible";
                            }
                            else if (jetDes < 8 && jetDes > 3)
                            {
                                this.densiteAtmos = "Faible";
                            }
                            else if (jetDes < 12 && jetDes > 7)
                            {
                                this.densiteAtmos = "Moyenne";
                            }
                            else if (jetDes < 17 && jetDes > 11)
                            {
                                this.densiteAtmos = "Dense";
                            }
                            else
                            {
                                this.densiteAtmos = "Très Dense";
                            }
                            break;
                        case "Très Forte":
                            if (jetDes < 2)
                            {
                                this.densiteAtmos = "Vide";
                            }
                            else if (jetDes == 2)
                            {
                                this.densiteAtmos = "Très Faible";
                            }
                            else if (jetDes < 5 && jetDes > 2)
                            {
                                this.densiteAtmos = "Faible";
                            }
                            else if (jetDes < 7 && jetDes > 4)
                            {
                                this.densiteAtmos = "Moyenne";
                            }
                            else if (jetDes < 14 && jetDes > 6)
                            {
                                this.densiteAtmos = "Dense";
                            }
                            else
                            {
                                this.densiteAtmos = "Très Dense";
                            }
                            break;
                        case "Extrème":
                            if (jetDes < 2)
                            {
                                this.densiteAtmos = "Vide";
                            }
                            else if (jetDes == 2)
                            {
                                this.densiteAtmos = "Très Faible";
                            }
                            else if (jetDes == 3)
                            {
                                this.densiteAtmos = "Faible";
                            }
                            else if (jetDes == 4)
                            {
                                this.densiteAtmos = "Moyenne";
                            }
                            else if (jetDes < 9 && jetDes > 4)
                            {
                                this.densiteAtmos = "Dense";
                            }
                            else if (jetDes < 19 && jetDes > 8)
                            {
                                this.densiteAtmos = "Très Dense";
                            }
                            else
                            {
                                this.densiteAtmos = "Extrèmement Dense";
                            }
                            break;
                    }
                }
                else
                {
                    this.densiteAtmos = "Extrèmement Dense"; // cas où la planète est de type Géante gazeuse
                }
            }
            public void AtmosCompo()
            {
                if (this.densiteAtmos != "Vide")
                {
                    if (this.typeCC == "Géante Gazeuse")
                    {
                        // détermine la composition de l'atmospshère pour les géantes gazeuses
                        this.atmosCompo = "Corrosive";
                        this.pollution = "Aucune";
                    }
                    else
                    {
                        // correspond à un 1d20
                        int jetDes = (new JetDes()).JeterD(1, 20);

                        switch (this.zone)
                        {
                            case "Chaude":
                                if (jetDes < 6)
                                {
                                    this.atmosCompo = "Corrosive";
                                    this.pollution = "Aucune";
                                }
                                else if (jetDes < 11 && jetDes > 5)
                                {
                                    this.atmosCompo = "Toxique";
                                    this.pollution = "Aucune";
                                }
                                else
                                {
                                    this.atmosCompo = "Inerte";
                                    this.pollution = "Aucune";
                                }
                                break;
                            case "Habitable":
                                if (jetDes < 4)
                                {
                                    this.atmosCompo = "Toxique";
                                    this.pollution = "Aucune";
                                }
                                else if (jetDes < 6 && jetDes > 3)
                                {
                                    this.atmosCompo = "Inerte";
                                    this.pollution = "Aucune";
                                }
                                else if (jetDes < 13 && jetDes > 5)
                                {
                                    this.atmosCompo = "Respirable";
                                    this.pollution = "Aucune";
                                }
                                else
                                {
                                    this.atmosCompo = "Respirable";
                                    jetDes = (new JetDes()).JeterD();
                                    switch (jetDes)
                                    {
                                        case 1:
                                            this.pollution = "Polluée";
                                            break;
                                        case 2:
                                            this.pollution = "Peu d'Oxygène";
                                            break;
                                        case 3:
                                            this.pollution = "Radioactive";
                                            break;
                                        case 4:
                                            this.pollution = "Nocive";
                                            break;
                                        case 5:
                                            this.pollution = "Allergique";
                                            break;
                                        case 6:
                                            this.pollution = "Contagieuse";
                                            break;
                                    }
                                }
                                break;
                            case "Froide":
                                if (jetDes < 4)
                                {
                                    this.atmosCompo = "Inerte";
                                    this.pollution = "Aucune";
                                }
                                else if (jetDes < 6 && jetDes > 3)
                                {
                                    this.atmosCompo = "Toxique";
                                    this.pollution = "Aucune";
                                }
                                else if (jetDes < 13 && jetDes > 5)
                                {
                                    this.atmosCompo = "Corrosive";
                                    this.pollution = "Aucune";
                                }
                                else
                                {
                                    this.atmosCompo = "Variable";
                                    this.pollution = "Aucune";
                                }
                                break;
                        }
                    }
                   
                }
            }
            public void Geologie()
            {
                if (this.typeCC == "Géante Gazeuse")
                {
                    // détermine la géologie pour les géantes gazeuses
                    this.geologie = "Aucune";
                }
                else
                {
                    // correspond à un 1d20
                    int jetDes = (new JetDes()).JeterD(1, 20);

                    // modificateur apporter au jet pour déterminer la géologie de la planète selon la gravité
                    switch (this.gravite)
                    {
                        case "Microgravité":
                            jetDes = jetDes - 4;
                            break;
                        case "Très Basse":
                            jetDes = jetDes - 2;
                            break;
                        case "Basse":
                            jetDes = jetDes - 1;
                            break;
                        case "Forte":
                            jetDes = jetDes + 1;
                            break;
                        case "Très Forte":
                            jetDes = jetDes + 2;
                            break;
                        case "Extrème":
                            jetDes = jetDes + 4;
                            break;
                    }

                    // modificateur apporter au jet pour déterminer la géologie de la planète selon la densité atmosphérique
                    switch (this.densiteAtmos)
                    {
                        case "Vide":
                            jetDes = jetDes + 3;
                            break;
                        case "Très Faible":
                            jetDes = jetDes + 1;
                            break;
                        case "Très Dense":
                            jetDes = jetDes - 2;
                            break;
                        case "Extrèmement Dense":
                            jetDes = jetDes - 4;
                            break;
                    }

                    // résultat du jet pour déterminer la géologie de la planète
                    if (jetDes < 4)
                    {
                        this.geologie = "Très Plate";
                    }
                    else if (jetDes < 8 && jetDes > 3)
                    {
                        this.geologie = "Plate";
                    }
                    else if (jetDes < 14 && jetDes > 7)
                    {
                        this.geologie = "Moyenne";
                    }
                    else if (jetDes < 18 && jetDes > 13)
                    {
                        this.geologie = "Rocailleuse";
                    }
                    else
                    {
                        this.geologie = "Très Rocailleuse";
                    }
                }
            }
            public void Volcanisme()
            {
                if (this.typeCC == "Géante Gazeuse")
                {
                    // détermine le volcanisme pour les géantes gazeuses
                    this.volcanisme = "Aucun";
                }
                else
                {
                    // correspond à un 1d20
                    int jetDes = (new JetDes()).JeterD(1, 10);

                    // modificateur apporter au jet pour déterminer le volcanisme de la planète selon la gravité
                    switch (this.gravite)
                    {
                        case "Microgravité":
                            jetDes = jetDes - 4;
                            break;
                        case "Très Basse":
                            jetDes = jetDes - 2;
                            break;
                        case "Basse":
                            jetDes = jetDes - 1;
                            break;
                        case "Forte":
                            jetDes = jetDes + 1;
                            break;
                        case "Très Forte":
                            jetDes = jetDes + 2;
                            break;
                        case "Extrème":
                            jetDes = jetDes + 4;
                            break;
                    }

                    // modificateur apporter au jet pour déterminer le volcanisme de la planète selon la géologie
                    switch (this.geologie)
                    {
                        case "Très Plate":
                            jetDes = jetDes - 5;
                            break;
                        case "Plate":
                            jetDes = jetDes - 3;
                            break;
                        case "Rocailleuse":
                            jetDes = jetDes + 1;
                            break;
                        case "Très Rocailleuse":
                            jetDes = jetDes + 3;
                            break;
                    }

                    // modificateur apporter au jet pour déterminer le volcanisme de la planète
                    if (this is Satellite)
                    {
                        jetDes = jetDes - 2;
                    }

                    // résultat du jet pour déterminer le volcanisme de la planète
                    if (jetDes < 5)
                    {
                        this.volcanisme = "Mort";
                    }
                    else if (jetDes < 7 && jetDes > 4)
                    {
                        this.volcanisme = "Stable";
                    }
                    else if (jetDes < 10 && jetDes > 6)
                    {
                        this.volcanisme = "Actif";
                    }
                    else if (jetDes < 12 && jetDes > 9)
                    {
                        this.volcanisme = "Très Actif";
                    }
                    else
                    {
                        this.volcanisme = "Extrème";
                    }
                }
            }
            public void Hydrosphere()
            {
                if (this.typeCC == "Géante Gazeuse")
                {
                    // détermine l'hydrosphère pour les géantes gazeuses
                    this.geologie = "Aucune";
                }
                else
                {
                    // correspond à un 1d20
                    JetDes jet = new JetDes();
                    int jetDes = jet.JeterD(1, 10);

                    // modificateur apporter au jet pour déterminer l'hydrosphère de la planète selon la densité atmosphérique
                    switch (this.densiteAtmos)
                    {
                        case "Vide":
                            jetDes = jetDes - 8;
                            break;
                        case "Très Faible":
                            jetDes = jetDes - 4;
                            break;
                        case "Faible":
                            jetDes = jetDes - 2;
                            break;
                        case "Dense":
                            jetDes = jetDes + 2;
                            break;
                        case "Très Dense":
                            jetDes = jetDes + 4;
                            break;
                        case "Extrèmement Dense":
                            jetDes = jetDes + 6;
                            break;
                    }

                    // modificateur apporter au jet pour déterminer l'hydrosphère de la planète selon la zone
                    switch (this.zone)
                    {
                        case "Chaude":
                            jetDes = jetDes - 4;
                            break;
                        case "Habitable":
                            jetDes = jetDes +2;
                            break;
                        case "Froide":
                            jetDes = jetDes -2;
                            break;
                    }

                    // modificateur apporter au jet pour déterminer l'hydrosphère de la planète
                    if (this is Satellite)
                    {
                        jetDes = jetDes - 2;
                    }

                    // résultat du jet pour déterminer l'hydrosphère de la planète
                    if (jetDes < 7)
                    {
                        this.hydrosphere = "Aucune";
                    }
                    else if (jetDes < 11 && jetDes > 6)
                    {
                        this.hydrosphere = "Très Sèche";
                        this.tauxHydro = jet.JeterD(1, 20);
                    }
                    else if (jetDes < 14 && jetDes > 10)
                    {
                        this.hydrosphere = "Sèche";
                        this.tauxHydro = 20 + jet.JeterD(1, 10);
                    }
                    else if (jetDes < 16 && jetDes > 13)
                    {
                        this.hydrosphere = "Equilibrée";
                        this.tauxHydro = 30 + jet.JeterD(1, 20);
                    }
                    else if (jetDes < 18 && jetDes > 15)
                    {
                        this.hydrosphere = "Moite";
                        this.tauxHydro = 50 + jet.JeterD(1, 20);
                    }
                    else if (jetDes < 18 && jetDes > 15)
                    {
                        this.hydrosphere = "Humide";
                        this.tauxHydro = 70 + jet.JeterD(1, 20);
                    }
                    else
                    {
                        this.hydrosphere = "Très Humide";
                        this.tauxHydro = 90 + jet.JeterD(1, 10);
                    }
                }
            }
            public void Geographie()
            {
                if (this.typeCC == "Géante Gazeuse")
                {
                    // détermine la géologie pour les géantes gazeuses
                    this.geologie = "Aucune";
                }
                else
                {
                    if (this.tauxHydro < 50)
                    {

                        // définie par les oceans et mers
                        // correspond à un 1d20
                        JetDes jet = new JetDes();
                        int jetDes = jet.JeterD(1, 10);

                        // modificateur apporter au jet pour déterminer les continents de la planète selon la gravité
                        switch (this.volcanisme)
                        {
                            case "Mort":
                                jetDes = jetDes - 4;
                                break;
                            case "Stable":
                                jetDes = jetDes - 2;
                                break;
                            case "Très Actif":
                                jetDes = jetDes + 2;
                                break;
                            case "Extrème":
                                jetDes = jetDes + 4;
                                break;
                        }

                        // modificateur apporter au jet pour déterminer les continents de la planète selon la géologie
                        switch (this.geologie)
                        {
                            case "Très Plate":
                                jetDes = jetDes - 4;
                                break;
                            case "Plate":
                                jetDes = jetDes - 1;
                                break;
                            case "Rocailleuse":
                                jetDes = jetDes + 1;
                                break;
                            case "Très Rocailleuse":
                                jetDes = jetDes + 2;
                                break;
                        }

                        // modificateur apporter au jet pour déterminer les continents de la planète selon la géologie
                        if (this.tauxHydro > 0 && this.tauxHydro < 31)
                        {
                            jetDes = jetDes + 4;
                        }
                        else if (this.tauxHydro > 40 && this.tauxHydro < 50)
                        {
                            jetDes = jetDes - 4;
                        }

                        // resultat
                        if (jetDes < 6)
                        {
                            this.geographie = "Grand océan";
                        }
                        else if (jetDes < 11 && jetDes > 5)
                        {
                            this.geographie = jet.JeterD(1, 4, 1) + " océans";
                        }
                        else if (jetDes < 16 && jetDes > 10)
                        {
                            this.geographie = jet.JeterD(1, 2) + " océans et " + jet.JeterD(1, 4, 1) + " mers";
                        }
                        else if (jetDes > 15)
                        {
                            this.geographie = "Grands lacs";
                        }
                    }
                    else
                    {
                        // défine par les continents
                        // correspond à un 1d20
                        JetDes jet = new JetDes();
                        int jetDes = jet.JeterD(1, 10);

                        // modificateur apporter au jet pour déterminer les continents de la planète selon la gravité
                        switch (this.volcanisme)
                        {
                            case "Mort":
                                jetDes = jetDes - 4;
                                break;
                            case "Stable":
                                jetDes = jetDes - 2;
                                break;
                            case "Très Actif":
                                jetDes = jetDes + 2;
                                break;
                            case "Extrème":
                                jetDes = jetDes + 6;
                                break;
                        }

                        // modificateur apporter au jet pour déterminer les continents de la planète selon la géologie
                        switch (this.geologie)
                        {
                            case "Très Plate":
                                jetDes = jetDes - 2;
                                break;
                            case "Plate":
                                jetDes = jetDes - 1;
                                break;
                            case "Rocailleuse":
                                jetDes = jetDes + 2;
                                break;
                            case "Très Rocailleuse":
                                jetDes = jetDes + 4;
                                break;
                        }

                        // modificateur apporter au jet pour déterminer les continents de la planète selon la géologie
                        if (this.tauxHydro > 59 && this.tauxHydro < 76)
                        {
                            jetDes = jetDes + 4;
                        }
                        else if (this.tauxHydro > 75 && this.tauxHydro < 101)
                        {
                            jetDes = jetDes + 8;
                        }

                        // resultat
                        if (jetDes < 6)
                        {
                            this.geographie = "Supercontinent";
                        }
                        else if (jetDes < 11 && jetDes > 5)
                        {
                            this.geographie = jet.JeterD(1, 4, 1) + " grands continents";
                        }
                        else if (jetDes < 16 && jetDes > 10)
                        {
                            this.geographie = jet.JeterD(1, 2) + " grands continents et " + jet.JeterD(1, 4, 1) + " petits continents";
                        }
                        else if (jetDes > 15)
                        {
                            this.geographie = "Grandes îles et archipelles";
                        }
                    }
                }
            }
            public void Climat()
            {
                if (this.typeCC == "Géante Gazeuse" && this.densiteAtmos == "Vide")
                {
                    // détermine la géologie pour les géantes gazeuses
                    this.climat = "Vide";
                }
                else if (this.zone == "Chaude")
                {
                    this.climat = "Chaleur Extrème";
                }
                else if (this.zone == "Froide")
                {
                    this.climat = "Froid Extrème";
                }
                else
                {
                    // correspond à un 2d10
                    JetDes jet = new JetDes();
                    int jetDes = jet.JeterD(2, 10);

                    // modificateur apporter au jet pour déterminer le climat de la planète selon le volcanisme
                    switch (this.volcanisme)
                    {
                        case "Actif":
                            jetDes = jetDes + 1;
                            break;
                        case "Très Actif":
                            jetDes = jetDes + 2;
                            break;
                        case "Extrème":
                            jetDes = jetDes + 4;
                            break;
                    }

                    // modificateur apporter au jet pour déterminer le climat de la planète selon le type d'Etoile
                    switch (this.etoileES.typeE)
                    {
                        case "O":
                            jetDes = jetDes + 7;
                            break;
                        case "B":
                            jetDes = jetDes + 5;
                            break;
                        case "A":
                            jetDes = jetDes + 3;
                            break;
                        case "F":
                            jetDes = jetDes + 1;
                            break;
                        case "K":
                            jetDes = jetDes - 2;
                            break;
                        case "M":
                            jetDes = jetDes - 5;
                            break;
                    }

                    // modificateur apporter au jet pour déterminer le climat de la planète selon la taille de l'Etoile
                    switch (this.etoileES.tailleE)
                    {
                        case "Ia":
                            jetDes = jetDes + 7;
                            break;
                        case "Ib":
                            jetDes = jetDes + 6;
                            break;
                        case "II":
                            jetDes = jetDes + 5;
                            break;
                        case "III":
                            jetDes = jetDes + 3;
                            break;
                        case "IV":
                            jetDes = jetDes + 2;
                            break;
                        case "VI":
                            jetDes = jetDes - 4;
                            break;
                        case "VII":
                            jetDes = jetDes - 8;
                            break;
                    }

                    // modificateur apporter au jet pour déterminer le climat de la planète selon la densité atmosphérique
                    switch (this.densiteAtmos)
                    {
                        case "Très Fine":
                            jetDes = jetDes - 6;
                            break;
                        case "Fine":
                            jetDes = jetDes - 2;
                            break;
                        case "Dense":
                            jetDes = jetDes + 2;
                            break;
                        case "Très Dense":
                            jetDes = jetDes + 4;
                            break;
                        case "Extrèmement Dense":
                            jetDes = jetDes + 8;
                            break;
                    }

                    //résultat

                    if (jetDes < 1)
                    {
                        this.climat = "-10 F°";
                    }
                    else if (jetDes < 3 && jetDes > 0)
                    {
                        this.climat = "0 F°";
                    }
                    else if (jetDes < 5 && jetDes > 2)
                    {
                        this.climat = "20 F°";
                    }
                    else if (jetDes < 7 && jetDes > 4)
                    {
                        this.climat = "30 F°";
                    }
                    else if (jetDes < 9 && jetDes > 6)
                    {
                        this.climat = "40 F°";
                    }
                    else if (jetDes < 13 && jetDes > 8)
                    {
                        this.climat = "50 F°";
                    }
                    else if (jetDes < 15 && jetDes > 12)
                    {
                        this.climat = "60 F°";
                    }
                    else if (jetDes < 17 && jetDes > 14)
                    {
                        this.climat = "70 F°";
                    }
                    else if (jetDes < 19 && jetDes > 16)
                    {
                        this.climat = "80 F°";
                    }
                    else if (jetDes < 21 && jetDes > 18)
                    {
                        this.climat = "90 F°";
                    }
                    else if (jetDes == 21)
                    {
                        this.climat = "100 F°";
                    }
                    else if (jetDes > 21)
                    {
                        this.climat = "110 F°";
                    }
                }
            }
            public void TempPole()
            {
                if (this.typeCC == "Géante Gazeuse" && this.climat == "Chaleur Extrème" && this.climat == "Froid Extrème")
                {
                    // détermine la géologie pour les géantes gazeuses
                    this.tempPole = 0;
                }
                else
                {
                    // correspond à un 2d10
                    JetDes jet = new JetDes();
                    int jetDes = jet.JeterD(2, 10);

                    // modificateur apporter au jet pour déterminer la variance de la température de la planète selon la taille de planète
                    switch (this.tailleCC)
                    {
                        case 0:
                            jetDes = jetDes - 4;
                            break;
                        case 1:
                            jetDes = jetDes - 4;
                            break;
                        case 2:
                            jetDes = jetDes - 4;
                            break;
                        case 3:
                            jetDes = jetDes - 4;
                            break;
                        case 5:
                            jetDes = jetDes + 4;
                            break;
                        case 6:
                            jetDes = jetDes + 8;
                            break;
                    }

                    // modificateur apporter au jet pour déterminer la variance de la température de la planète selon l'hydrosphère
                    if (this.tauxHydro < 21)
                    {
                        jetDes = jetDes - 2;
                    }
                    if (this.tauxHydro < 81 && this.tauxHydro > 20)
                    {
                        jetDes = jetDes + 2;
                    }
                    if (this.tauxHydro > 80)
                    {
                        jetDes = jetDes + 4;
                    }

                    // résultat
                    this.tempPole = jetDes * 3;
                }
            }
            public void Biosphere()
            {
                this.complexiteBio = "Aucune";

                if (this.typeCC == "Géante Gazeuse")
                {
                    this.densiteBio = "Aucune";
                }
                else
                {
                    // correspond à un 2d10
                    JetDes jet = new JetDes();
                    int jetDes = jet.JeterD(2, 10);

                    // modificateur apporter au jet pour déterminer la biopshère de la planète selon la densité atmosphérique
                    switch (this.densiteAtmos)
                    {
                        case "Vide":
                            jetDes = jetDes - 8;
                            break;
                        case "Très Fine":
                            jetDes = jetDes - 4;
                            break;
                        case "Fine":
                            jetDes = jetDes - 2;
                            break;
                        case "Dense":
                            jetDes = jetDes - 2;
                            break;
                        case "Très Dense":
                            jetDes = jetDes - 4;
                            break;
                        case "Extrèmement Dense":
                            jetDes = jetDes - 8;
                            break;
                    }

                    // modificateur apporter au jet pour déterminer la biopshère de la planète selon l'hydropshère
                    switch (this.hydrosphere)
                    {
                        case "Aucune":
                            jetDes = jetDes - 8;
                            break;
                        case "Très Sèche":
                            jetDes = jetDes - 4;
                            break;
                        case "Humide":
                            jetDes = jetDes + 4;
                            break;
                        case "Très Humide":
                            jetDes = jetDes + 8;
                            break;
                    }

                    // modificateur apporter au jet pour déterminer la biopshère de la planète selon la zone
                    switch (this.zone)
                    {
                        case "Habitable":
                            jetDes = jetDes + 2;
                            break;
                        case "Froide":
                            jetDes = jetDes - 6;
                            break;
                        case "Chaude":
                            jetDes = jetDes - 8;
                            break;
                    }
                    // modificateur apporter au jet pour déterminer la biopshère de la planète selon la composition de l'atmosphère
                    switch (this.atmosCompo)
                    {
                        case "Corrosive":
                            jetDes = jetDes - 6;
                            break;
                        case "Toxique":
                            jetDes = jetDes - 4;
                            break;
                        case "Respirable":
                            jetDes = jetDes + 2;
                            break;
                        case "Inerte":
                            jetDes = jetDes - 6;
                            break;
                    }
                    // modificateur apporter au jet pour déterminer la biopshère de la planète selon le volcanisme
                    if (this.volcanisme == "Extrème")
                    {
                        jetDes = jetDes - 6;
                    }

                    //resultat densité biopshère
                    if (jetDes < 6)
                    {
                        this.densiteBio = "Aucune";
                    }
                    else if (jetDes < 11 && jetDes > 5)
                    {
                        this.densiteBio = "Très Rare";
                        jetDes = jetDes - 10;
                    }
                    else if (jetDes < 16 && jetDes > 10)
                    {
                        this.densiteBio = "Rare";
                        jetDes = jetDes - 5;
                    }
                    else if (jetDes < 19 && jetDes > 15)
                    {
                        this.densiteBio = "Peu Fréquente";
                    }
                    else if (jetDes < 22 && jetDes > 18)
                    {
                        this.densiteBio = "Moyenne";
                    }
                    else if (jetDes < 26 && jetDes > 21)
                    {
                        this.densiteBio = "Abondante";
                        jetDes = jetDes + 3;
                    }
                    else if (jetDes > 25)
                    {
                        this.densiteBio = "Très Abondante";
                        jetDes = jetDes + 5;
                    }

                    // resultat complexité biosphère
                    if (this.densiteBio != "Aucune")
                    {
                        if (jetDes < 6)
                        {
                            this.complexiteBio = "Très Simple";
                        }
                        else if (jetDes < 11 && jetDes > 5)
                        {
                            this.complexiteBio = "Simple";
                        }
                        else if (jetDes < 16 && jetDes > 10)
                        {
                            this.complexiteBio = "Basique";

                        }
                        else if (jetDes < 19 && jetDes > 15)
                        {
                            this.complexiteBio = "Modérée";
                        }
                        else if (jetDes < 22 && jetDes > 18)
                        {
                            this.complexiteBio = "Avancée";
                        }
                        else if (jetDes < 26 && jetDes > 21)
                        {
                            this.complexiteBio = "Très Avancée";
                        }
                        else if (jetDes > 25)
                        {
                            this.complexiteBio = "Intelligence Native";
                        }
                    }
                }
            }
            public void Artefact()
            {
                int jetDes = (new JetDes()).JeterD(1,100);
                if (jetDes == 1)
                {
                    artefactAncien = true;
                }
            }
            public void MixPopulation()
            {
                if (this.typeCC == "Géante Gazeuse") // pas de population si le  corps celeste est une géante gazeuse
                {
                    this.mixPopulation = 0;
                }
                else
                {
                    if (this.etoileES.systemSE.systemColonise == false) // si le systeme solaire n'est pas colonisé
                    {
                        if (this.complexiteBio == "Très Avancée" || this.complexiteBio == "Intelligence Native") // et si il y a une forme de vie assez avancée
                        {
                            this.mixPopulation = 1;
                        }
                        else // sinon pas de population
                        {
                            this.mixPopulation = 0;
                        }
                    }
                    else // si le systeme solaire est colonisé
                    {
                        int jetDes = (new JetDes()).JeterD(1,10);
                        // table faite maison de manière arbitraire pour déterminer si ce corps céleste est colonisé
                        switch (this.etoileES.systemSE.raceColonie)// quelle est la race coloniale
                        {
                            case "Humain":
                                jetDes = jetDes - 2 ;
                                break;
                            case "Centauri":
                                jetDes = jetDes + 1 ;
                                break;
                            case "Minbari":
                                jetDes = jetDes + 2 ;
                                break;
                        }
                        switch (this.complexiteBio) // quelle est la complexité de la biosphère
                        {
                            case "Très Simple":
                                jetDes = jetDes - 2 ;
                                break;
                            case "Simple":
                                jetDes = jetDes - 1 ;
                                break;
                            case "Modérée":
                                jetDes = jetDes + 1 ;
                                break;
                            case "Avancée":
                                jetDes = jetDes + 2 ;
                                break;
                            case "Très Avancée":
                                jetDes = jetDes + 1 ;
                                break;
                            case "Intelligence Native":
                                jetDes = jetDes - 1 ;
                                break;
                        }
                        if (this.volcanisme == "Extrème") // le volcanisme est il supportable
                        {
                            jetDes = jetDes - 2;
                        }
                        switch (this.atmosCompo) // quelles sont les conditions atmosphériques
                        {
                            case "Respirable":
                                jetDes = jetDes + 1 ;
                                break;
                            default:
                                jetDes = jetDes - 1 ;
                                break;
                        }
                        if (this.artefactAncien) // y a t'il un artefact des anciens
                        {
                            jetDes = jetDes + 10;
                        }

                        // resultat
                        if (jetDes < 8) // pas suffisament intéressant pour être colonisé
                        {
                            if (this.complexiteBio == "Très Avancée" || this.complexiteBio == "Intelligence Native")  // il y a quand même une forme de vie suffisamment avancée
                            {
                                this.mixPopulation = 1; 
                            }
                            else // pas de population
                            {
                                this.mixPopulation = 0;
                            }
                        }
                        else // suffisamment interessant pour être colonisé
                        {
                            if (this.complexiteBio == "Très Avancée" || this.complexiteBio == "Intelligence Native")
                            {
                                this.mixPopulation = 3; // il y a une forme de vie originaire du corps celeste et une population coloniale
                            }
                            else
                            {
                                this.mixPopulation = 2; // il n'y a qu'une population coloniale
                            }
                        }
                        
                    }
                }
            }
            #endregion

        }

        public class Planete : CorpsCeleste
        {
            #region Attributs Planète
            public List<Satellite> tableSatellite;
            public int nbMoonlet;
            private Planete plnt;
            #endregion

            #region Méthodes Planète
            public void TailleDiametrePl()
            {
                int jetDes = (new JetDes()).JeterD(1, 20);
                string zoneCC = this.zone;
                string type = this.typeCC;
                double diametrePl = 0;
                JetDes jet = new JetDes();
                switch(zoneCC)
                {
                    case "Chaude" :
                        jetDes = jetDes - 1;
                        break;
                    case "Froide" :
                        jetDes = jetDes + 1;
                        break;
                }
                switch (type)
                {
                    case "Géante Gazeuse":
                        jetDes = jetDes + 20;
                        break;
                    case "Glaciale":
                        jetDes = jetDes - 3;
                        break;
                }
                
                if (jetDes < -4)
                {
                    this.tailleCC = 0;
                }
                if (jetDes < 1 && jetDes > -4)
                {
                    this.tailleCC = 1;
                }
                if (jetDes < 6 && jetDes > 0)
                {
                    this.tailleCC = 2;
                }
                if (jetDes < 11 && jetDes > 5)
                {
                    this.tailleCC = 3;
                }
                if (jetDes < 16 && jetDes > 10)
                {
                    this.tailleCC = 4;
                }
                if (jetDes < 19 && jetDes > 15)
                {
                    this.tailleCC = 5;
                }
                if (jetDes < 21 && jetDes > 18) 
                {
                    if(this.typeCC == "Géante Gazeuse")
                    {
                        this.tailleCC = 7;
                    }
                    else
                    {
                        this.tailleCC = 6;
                    }
                }
                if (jetDes < 26 && jetDes > 20) 
                {
                    if(this.typeCC != "Géante Gazeuse")
                    {
                        this.tailleCC = 6;
                    }
                    else
                    {
                        this.tailleCC = 7;
                    }
                }
                if (jetDes < 36 && jetDes > 25)
                {
                    this.tailleCC = 8;
                }
                if (jetDes < 39 && jetDes > 35)
                {
                    this.tailleCC = 9;
                }
                if (jetDes > 38)
                {
                    this.tailleCC = 10;
                }


                switch(this.tailleCC)
                {
                    case 0 :
                        diametrePl = (jet.JeterD(5, 10,50) * 1.61);
                        this.diametreCC = "Minuscule(" + diametrePl.ToString() + "km)";
                        break;
                    case 1 :
                        diametrePl = (jet.JeterD(1, 4) * 100 + (jet.JeterD(1, 100)-1)) * 1.609344;
                        this.diametreCC = "Fine(" + diametrePl.ToString() + "km)";
                        break;
                    case 2 :
                        diametrePl = (jet.JeterD(2) * 100 + (jet.JeterD(1, 100)-1)) * 1.609344;
                        this.diametreCC = "Toute Petite(" + diametrePl.ToString() + "km)";
                        break;
                    case 3 :
                        diametrePl = (jet.JeterD(1, 2, 1) * 1000 + (jet.JeterD(1, 10)-1) * 100 + (jet.JeterD(1, 100)-1)) * 1.609344;
                        this.diametreCC = "Petite(" + diametrePl.ToString() + "km)";
                            break;
                    case 4 :
                        diametrePl = (jet.JeterD(2, 4, 4) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1)) * 1.609344;
                        this.diametreCC = "Moyenne(" + diametrePl.ToString() + "km)";
                        break;
                    case 5 :
                        diametrePl = (jet.JeterD(5, 10, 50) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1)) * 1.609344;
                        this.diametreCC = "Grande(" + diametrePl.ToString() + "km)";
                        break;
                    case 6 :
                        diametrePl = (jet.JeterD(1, 2, 1) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1)) * 1.609344;
                        this.diametreCC = "Enorme(" + diametrePl.ToString() + "km)";
                        break;
                    case 7 :
                        diametrePl = (jet.JeterD(1, 2, 1) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1)) * 1.609344;
                        this.diametreCC = "Géante Gazeuse Petite(" + diametrePl.ToString() + "km)";
                        break;
                    case 8 :
                        diametrePl = (jet.JeterD(1, 2, 1) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1)) * 1.609344;
                        this.diametreCC = "Géante Gazeuse Moyenne(" + diametrePl.ToString() + "km)";
                        break;
                    case 9 :
                        diametrePl = (jet.JeterD(1, 2, 1) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1)) * 1.609344;
                        this.diametreCC = "Géante Gazeuse Enorme(" + diametrePl.ToString() + "km)";
                        break;
                    case 10 :
                        diametrePl = (jet.JeterD(1, 2, 1) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1)) * 1.609344;
                        jetDes = jet.JeterD(1,20); // regle optionnel sur les Naine brunes en cas de Géante Gazeuse Gargantuesque
                        if (jetDes == 1)
                        {
                            this.diametreCC = "Naine Brune(" + diametrePl.ToString() + "km)";
                        }
                        else
                        {
                            this.diametreCC = "Géante Gazeuse Gargantuesque(" + diametrePl.ToString() + "km)";
                        }
                        break;
                }
            }
            public void NombreLunes()
            {
                
                JetDes jet = new JetDes();
                int jetDes;

                if (this.tailleCC == 7 || this.tailleCC == 8) // petite ou moyenne géante gazeuse
                {
                    jetDes = jet.JeterD(2, 6);
                    this.nbMoonlet = jet.JeterD(3, 6);
                    for (int i = 0; i < jetDes ; i++)
                    {
                        this.tableSatellite[i] = new Satellite(this, i); 
                    }
                }
                else if (this.tailleCC == 9 || this.tailleCC == 10) // énorme ou gargantuesque géante gazeuse
                {
                    jetDes = jet.JeterD(3, 6);
                    this.nbMoonlet = jet.JeterD(4, 6);
                    for (int i = 0; i < jetDes; i++)
                    {
                        this.tableSatellite[i] = new Satellite(this, i);
                    }
                }
                else if (this.tailleCC == 5) // grande terrestre ou glaciale
                {
                    jetDes = jet.JeterD(1, 6,-2);
                    this.nbMoonlet = jet.JeterD(1, 6, -3);
                    for (int i = 0; i < jetDes; i++)
                    {
                        this.tableSatellite[i] = new Satellite(this, i);
                    }
                }
                else if (this.tailleCC == 3 || this.tailleCC == 4) // petite ou moyenne  terrestre ou glaciale
                {
                    jetDes = jet.JeterD(1, 6, -4);
                    this.nbMoonlet = jet.JeterD(1, 6, -3);
                    for (int i = 0; i < jetDes; i++)
                    {
                        this.tableSatellite[i] = new Satellite(this, i);
                    }
                }
            }
            #endregion

            #region Constructeurs Planète
            public Planete(Etoile etoile, string id, string zoneES, string typeES)
            {
                // instanciation de toutes les valeurs de la planète
                this.etoileES = etoile;
                this.id_ES = "P" + id;
                this.nomES = "Planète " + id;
                this.zone = zoneES;
                this.typeCC = typeES;
                this.TailleDiametrePl();
                this.Gravite();
                this.DensiteAtmos();
                this.AtmosCompo();
                this.Geologie();
                this.Volcanisme();
                this.Hydrosphere();
                this.Geographie();
                this.Climat();
                this.TempPole();
                this.Biosphere();
                this.Artefact();
                this.MixPopulation();
                this.NombreLunes();
                // on détermine si il y a zéro, une ou deux populations sur cette planète
                if (mixPopulation == 1) // population native seulement
                {
                    this.populationsCC.Add(new Population(this,false));
                }
                else if (mixPopulation == 2)// population coloniale seulement
                {
                    this.populationsCC.Add(new Population(this,true));

                }
                else if (mixPopulation == 3) // population mix
                {
                    this.populationsCC.Add(new Population(this, false));

                    this.populationsCC.Add(new Population(this,true));

                }

            }

            public Planete(Planete plnt)
            {
                // TODO: Complete member initialization
                this.plnt = plnt;
            }
            #endregion
        }

        public class Satellite : CorpsCeleste
        {
            #region Attributs Satellite
            public Planete plnt;
            public int distance;
            #endregion

            #region Méthodes Satellite
            public void TypeS()
            {
                int jetDes = (new JetDes()).JeterD(1, 20);
                switch (this.zone)
                {
                    case "Chaude":
                        this.typeCC = "Terrestre";
                        break;
                    case "Habitable":
                        if (jetDes < 16)
                        {
                            this.typeCC = "Terrestre";
                        }
                        else
                        {
                            this.typeCC = "Glaciale";
                        }
                        break;
                    case "Froide":
                        if (jetDes < 11)
                        {
                            this.typeCC = "Terrestre";
                        }
                        else
                        {
                            this.typeCC = "Glaciale";
                        }
                        break;
                }
            }
            public void TailleDiametreS()
            {
                int jetDes = (new JetDes()).JeterD(1, 20, -5);
                string zoneCC = this.zone;
                string type = this.typeCC;
                double diametreS = 0;
                JetDes jet = new JetDes();
                switch (zoneCC)
                {
                    case "Chaude":
                        jetDes = jetDes - 1;
                        break;
                    case "Froide":
                        jetDes = jetDes + 1;
                        break;
                }
                switch (type)
                {
                    case "Glaciale":
                        jetDes = jetDes - 3;
                        break;
                }


                if (jetDes < -4)
                {
                    this.tailleCC = 0;
                }
                if (jetDes < 1 && jetDes > -4)
                {
                    this.tailleCC = 1;
                }
                if (jetDes < 6 && jetDes > 0)
                {
                    this.tailleCC = 2;
                }
                if (jetDes < 11 && jetDes > 5)
                {
                    this.tailleCC = 3;
                }
                if (jetDes < 16 && jetDes > 10)
                {
                    this.tailleCC = 4;
                }
                if (jetDes < 19 && jetDes > 15)
                {
                    this.tailleCC = 5;
                }
                if (jetDes > 18)
                {
                    this.tailleCC = 6;
                }


                if (this.plnt.tailleCC <= this.tailleCC)
                {
                    this.tailleCC = this.plnt.tailleCC - 1;
                }


                switch (this.tailleCC)
                {
                    case 0:
                        diametreS = (jet.JeterD(5, 10, 50) * 1.61);
                        this.diametreCC = "Minuscule(" + diametreS.ToString() + "km)";
                        break;
                    case 1:
                        diametreS = (jet.JeterD(1, 4) * 100 + (jet.JeterD(1, 100) - 1)) * 1.609344;
                        this.diametreCC = "Fine(" + diametreS.ToString() + "km)";
                        break;
                    case 2:
                        diametreS = (jet.JeterD(2) * 100 + (jet.JeterD(1, 100) - 1)) * 1.609344;
                        this.diametreCC = "Toute Petite(" + diametreS.ToString() + "km)";
                        break;
                    case 3:
                        diametreS = (jet.JeterD(1, 2, 1) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1)) * 1.609344;
                        this.diametreCC = "Petite(" + diametreS.ToString() + "km)";
                        break;
                    case 4:
                        diametreS = (jet.JeterD(2, 4, 4) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1)) * 1.609344;
                        this.diametreCC = "Moyenne(" + diametreS.ToString() + "km)";
                        break;
                    case 5:
                        diametreS = (jet.JeterD(5, 10, 50) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1)) * 1.609344;
                        this.diametreCC = "Grande(" + diametreS.ToString() + "km)";
                        break;
                    case 6:
                        diametreS = (jet.JeterD(1, 2, 1) * 1000 + (jet.JeterD(1, 10) - 1) * 100 + (jet.JeterD(1, 100) - 1)) * 1.609344;
                        this.diametreCC = "Enorme(" + diametreS.ToString() + "km)";
                        break;
                }
            }
            #endregion

            #region Constructeurs Satellite
            public Satellite(Planete planete, int id)
            {
                // instanciation de toutes les valeurs du satellite

                this.plnt = planete;
                this.id_ES = "S" + id;
                this.nomES = "Satellite " + id;
                this.zone = this.plnt.zone;
                this.TypeS();
                this.TailleDiametreS();
                this.Gravite();
                this.DensiteAtmos();
                this.AtmosCompo();
                this.Geologie();
                this.Volcanisme();
                this.Hydrosphere();
                this.Geographie();
                this.Climat();
                this.TempPole();
                this.Biosphere();
                this.Artefact();
                this.MixPopulation();
                // on détermine si il y a zéro, une ou deux populations sur cette planète
                if (mixPopulation == 1) // population native seulement
                {
                    this.populationsCC.Add(new Population(this, false));
                }
                else if (mixPopulation == 2)// population coloniale seulement
                {
                    this.populationsCC.Add(new Population(this, true));

                }
                else if (mixPopulation == 3) // population mix
                {
                    this.populationsCC.Add(new Population(this, false));

                    this.populationsCC.Add(new Population(this, true));

                }
            }
            #endregion
        }

        public class AsteroideMajeur
        {
            #region Attributs AstéroïdeMajeur
            public CeintureAsteroide ceintureAM;
            public string id_AM;
            public string nomAM;
            public int tailleAM;
            public string commentaireAM;
            #endregion

            #region Méthodes AstéroïdeMajeur
            public void TailleAM()
            {
                JetDes jet = new JetDes();
                int jetDes = jet.JeterD(1, 20);
                // modificateurs au jet de la taille de l'asteroid Majeur
                switch(this.ceintureAM.densiteCA)
                {
                    case "Légère":
                        jetDes = jetDes - 2;
                        break;
                    case "Dense":
                        jetDes = jetDes + 1;
                        break;
                    case "Très Dense":
                        jetDes = jetDes + 2;
                        break;
                }

                //résultat
                if(jetDes < 11)
                {
                    this.tailleAM = 20 + jet.JeterD(2,10);
                }
                else if (jetDes < 19 && jetDes > 10)
                {
                    this.tailleAM = 100 + (jet.JeterD(1, 10) * 10);
                }
                else if (jetDes > 18)
                {
                    this.tailleAM = jet.JeterD(2, 4)*100;
                }
            }
            #endregion

            #region Constructeurs AstéroïdeMajeur
            public AsteroideMajeur(CeintureAsteroide ceintureAsteroide, int numero)
            {
                
                this.ceintureAM = ceintureAsteroide;
                this.id_AM = "AM" + numero + this.ceintureAM.id_ES;
                this.nomAM = "Asteroid n°" + numero;
                this.TailleAM();
            }
            #endregion
        }

        public class PopulationAsteroide
        {
            #region Attributs PopulationAstéroïde
            public CeintureAsteroide ceinturePA;
            public Population populationPA;
            public string id_PA;
            public int niveauTechnoPA;
            public string catTechnoPA;
            public int nbHabitantPA;
            public string commentairePA;
            #endregion

            #region Méthodes populationAstéroïde
            public void PerteTechnologique()
            {
                int jetDes = new JetDes().JeterD(1,100);
                if(jetDes < 6)
                {
                    this.niveauTechnoPA = this.populationPA.niveauTechnoPo - 1;
                    switch(this.populationPA.niveauTechnoPo)
                    {
                        case 5:
                            this.catTechnoPA = "Age du Pétrole";
                            break;
                        case 6:
                            this.catTechnoPA = "Age de la Fusion";
                            break;
                        case 7:
                            this.catTechnoPA = "Avancé";
                            break;
                        case 8:
                            this.catTechnoPA = "Très Avancé";
                            break;
                    }
                }
            }
            public void NbHabitantPA()
            {
                JetDes jet = new JetDes();
                int jetDes = jet.JeterD(1, 20);
                bool multiplicateur = false;
                bool autreColonie = false;
                Queue<CeintureAsteroide> listeCASS = new Queue<CeintureAsteroide>();
                Queue<CorpsCeleste> listeCCSS = new Queue<CorpsCeleste>();
                switch(this.ceinturePA.densiteCA)
                {
                    case "Légère":
                        jetDes = jetDes - 3;
                        break;
                    case "Dense":
                        jetDes = jetDes + 1;
                        break;
                    case "Très Dense":
                        jetDes = jetDes + 2;
                        break;
                }

                switch(this.niveauTechnoPA)
                {
                    case 5:
                        jetDes = jetDes - 5;
                        break;
                    case 6:
                        jetDes = jetDes - 1;
                        break;
                    case 7:
                        jetDes = jetDes + 1;
                        break;
                    case 8:
                        jetDes = jetDes + 3;
                        break;
                }

                // on rassemble tous les éléments du système solaire dans deux files : une pour les corpscelestes et l'autre pour les astéroïdes
                foreach(Etoile etoile in this.ceinturePA.etoileES.systemSE.tableEtoile)
                {
                    foreach (Planete plnt in etoile.tableElementSysteme)
                    {
                        if (plnt.typeCC != "Géante Gazeuse")
                        {
                            listeCCSS.Enqueue(plnt);
                        }
                        foreach (Satellite satellite in plnt.tableSatellite)
                        {
                            listeCCSS.Enqueue(satellite);
                        }
                    }
                    foreach (CeintureAsteroide ca in etoile.tableElementSysteme)
                    {
                        listeCASS.Enqueue(ca);
                    }
                }
                // on parcours ensuite tous les éléments de ces deux queues pour savoir si la population de la ceinture d'astéroïdes possède une autre planètes dans le systéme solaire
                foreach(CeintureAsteroide ca in listeCASS)
                {
                    if (ca.populationCA.populationPA == this.populationPA)
                    {
                        autreColonie = true;
                    }
                }
                foreach (CorpsCeleste cc in listeCCSS)
                {
                    foreach(Population pop in cc.populationsCC)
                    {
                        if (pop == this.populationPA)
                        {
                            autreColonie = true;
                        }
                    }
                }
                if (autreColonie)
                {
                    jetDes = jetDes + 1;
                }
                // si le système solaire est le système d'origine de la population
                if(this.ceinturePA.etoileES.systemSE.tablePopNativeSS.Contains(this.populationPA))
                {
                    jetDes = jetDes + 2;
                    int indice = new JetDes().JeterD(1,100);
                    if(indice < 31)
                    {
                        multiplicateur = true;
                    }
                }

                //résultat
                if(jetDes < 1)
                {
                    this.nbHabitantPA = 0;
                }
                else if(jetDes < 6 && jetDes > 0)
                {
                    this.nbHabitantPA = jet.JeterD(1, 4)*100;
                }
                else if(jetDes < 11 && jetDes > 5)
                {
                    this.nbHabitantPA = jet.JeterD(1, 4)*1000;
                }
                else if(jetDes < 16 && jetDes > 10)
                {
                    this.nbHabitantPA = (jet.JeterD(1, 10)+10)*1000;
                }
                else if(jetDes < 20 && jetDes > 15)
                {
                    this.nbHabitantPA = (jet.JeterD(1, 20)+50)*1000;
                }
                else if(jetDes > 19)
                {
                    this.nbHabitantPA = jet.JeterD(1, 10)*10000;
                }

                if(multiplicateur)
                {
                    this.nbHabitantPA = this.nbHabitantPA * 10;
                }
            }
            #endregion

            #region Constructeurs PopulationAstéroïde
            public PopulationAsteroide(CeintureAsteroide ceintureAsteroide, Population popColoniale)
            {
                this.ceinturePA = ceintureAsteroide;
                this.populationPA = popColoniale;
                this.id_PA = "PA" + this.populationPA.id_Po + this.ceinturePA.id_ES ;
                this.PerteTechnologique();
                this.NbHabitantPA();
            }
        }

        public class Population
        {
            #region Attributs Population
            public CorpsCeleste corpsCeleste;
            public List<Cite> tableCite;
            public string id_Po = "";
            public string nomPo = "";
            public bool nativeOuColoniale = false;  // population native = false
                                                    // population coloniale = true
            public string catPo = "";
            public int nbHabitant = 0;
            public int niveauTechnoPo = 0;
            public string catTechnoPo = "";
            public int participation;
            public int diversite;
            public int control;
            public int soutien;
            public int nbColonieMajeure;
            public int nbColonieMineure;
            public int nbBaseMilitaire;
            public int nbBaseScientifique;
            public int nbBaseDefensive;
            public int nbBaseCommerciale;
            public string commentairePo;
            #endregion

            #region Méthodes Population
            public void NombreHabitant()
            {
                JetDes jet= new JetDes();
                int jetDes = jet.JeterD(2, 10);
                // modificateurs aux jets du nombre d'habitant de la population
                switch(this.corpsCeleste.densiteBio)
                {
                    case "Aucune":
                        jetDes = jetDes - 8;
                        break;
                    case "Très Rare":
                        jetDes = jetDes - 6;
                        break;
                    case "Rare":
                        jetDes = jetDes - 2;
                        break;
                    case "Abondante":
                        jetDes = jetDes + 4;
                        break;
                }

                switch (this.corpsCeleste.complexiteBio)
                {
                    case "Simple":
                        jetDes = jetDes - 6;
                        break;
                    case "Basique":
                        jetDes = jetDes - 3;
                        break;
                    case "Avancée":
                        jetDes = jetDes + 2;
                        break;
                    case "Très Avancée":
                        jetDes = jetDes + 4;
                        break;
                    case "Intelligence Native":
                        jetDes = jetDes + 6;
                        break;
                }

                switch (this.corpsCeleste.atmosCompo)
                {
                    case "Corrosive":
                        jetDes = jetDes - 4;
                        break;
                    case "Toxique":
                        jetDes = jetDes - 3;
                        break;
                    case "Inerte":
                        jetDes = jetDes - 2;
                        break;
                    case "Respirable":
                        if (this.corpsCeleste.pollution == "Aucune")
                        {
                            jetDes = jetDes + 2;
                        }
                        else
                        {
                            jetDes = jetDes - 1;
                        }
                        break;
                }

                switch (this.corpsCeleste.zone)
                {
                    case "Chaude":
                        jetDes = jetDes - 4;
                        break;
                    case "Habitable":
                        jetDes = jetDes + 2;
                        break;
                    case "Froide":
                        jetDes = jetDes - 2;
                        break;
                }

                if (this.corpsCeleste.hydrosphere == "Très Humide" || this.corpsCeleste.hydrosphere == "Humide")
                {
                    jetDes = jetDes + 2;
                }
                else if (this.corpsCeleste.hydrosphere == "Aucune" || this.corpsCeleste.hydrosphere == "Très Sèche")
                {
                    jetDes = jetDes - 2;
                }

                if(this.corpsCeleste.volcanisme == "Extrème")
                {
                    jetDes = jetDes - 4;
                }
                if (this.nativeOuColoniale == true)
                {
                    switch (this.corpsCeleste.etoileES.systemSE.raceColonie)
                    {
                        case "Humain":
                            jetDes = jetDes - 3;
                            break;
                        case "Narn":
                            jetDes = jetDes - 2;
                            break;
                        case "Centauri":
                            jetDes = jetDes + 2;
                            break;
                        case "Minbari":
                            jetDes = jetDes + 4;
                            break;
                    }
                }

                if(this.corpsCeleste.mixPopulation == 3)
                {
                    jetDes = jetDes - 4;
                }

                // résultat
                if (jetDes < 6)
                {
                    this.catPo = "Très Basse";
                    if(this.nativeOuColoniale)
                    {
                        this.nbHabitant = jet.JeterD(1,4)* 100;
                    }
                    else
                    {
                        this.nbHabitant = jet.JeterD(1, 100) * 1000;
                    }
                }
                else if (jetDes < 10 && jetDes > 5)
                {
                    this.catPo = "Basse";
                    if (this.nativeOuColoniale)
                    {
                        this.nbHabitant = jet.JeterD(1, 10) * 1000;
                    }
                    else
                    {
                        this.nbHabitant = jet.JeterD(1, 10) * 1000000;
                    }
                }
                else if (jetDes < 16 && jetDes > 9)
                {
                    this.catPo = "Moyenne";
                    if (this.nativeOuColoniale)
                    {
                        this.nbHabitant = jet.JeterD(1, 10) * 10000;
                    }
                    else
                    {
                        this.nbHabitant = jet.JeterD(1, 100) * 1000000;
                    }
                }
                else if (jetDes < 20 && jetDes > 15)
                {
                    this.catPo = "Forte";
                    if (this.nativeOuColoniale)
                    {
                        this.nbHabitant = jet.JeterD(1, 10) * 100000;
                    }
                    else
                    {
                        this.nbHabitant = jet.JeterD(1, 10) * 100000000;
                    }
                }
                else if (jetDes < 25 && jetDes > 19)
                {
                    this.catPo = "Très Forte";
                    if (this.nativeOuColoniale)
                    {
                        this.nbHabitant = jet.JeterD(1, 10) * 1000000;
                    }
                    else
                    {
                        this.nbHabitant = jet.JeterD(1, 10) * 1000000000;
                    }
                }
                else if (jetDes > 24)
                {
                    this.catPo = "Extrèmement Forte";
                    if (this.nativeOuColoniale)
                    {
                        this.nbHabitant = jet.JeterD(1, 10) * 100000000;
                    }
                    else
                    {
                        this.nbHabitant = jet.JeterD(1, 10, 4) * 1000000000;
                    }
                }
            }
            public void NiveauTechnologique()
            {
                JetDes jet = new JetDes();
                int jetDes = jet.JeterD(1,20);

                switch(this.catPo)
                {
                    case "Très Basse":
                        jetDes = jetDes - 2;
                        break;
                    case "Basse":
                        jetDes = jetDes - 1;
                        break;
                    case "Forte":
                        jetDes = jetDes + 2;
                        break;
                    case "Très Forte":
                        jetDes = jetDes + 4;
                        break;
                    case "Extrèmement Forte":
                        jetDes = jetDes + 5;
                        break;
                }

                if(this.nativeOuColoniale == true)
                {
                    jetDes = jetDes + 3;
                }

                if(this.corpsCeleste.gravite == "Extrème" ||
                    this.corpsCeleste.volcanisme == "Extrème" ||
                    this.corpsCeleste.atmosCompo == "Corrosive" ||
                    this.corpsCeleste.densiteAtmos == "Vide" ||
                    this.corpsCeleste.densiteAtmos == "Extrèmement Dense" ||
                    this.corpsCeleste.densiteBio == "Aucune" ||
                    this.corpsCeleste.climat == "Chaleur Extrème"||
                    this.corpsCeleste.climat == "Froid Extrème") 
                {
                    jetDes = jetDes + 4;
                }

                // résultat
                if(jetDes == 1)
                {
                    this.niveauTechnoPo = 0;
                    this.catTechnoPo = "Age de Pierre";
                }
                else if (jetDes < 4 && jetDes > 1)
                {
                    this.niveauTechnoPo = 1;
                    this.catTechnoPo = "Age de Bronze";
                }
                else if (jetDes < 6 && jetDes > 3)
                {
                    this.niveauTechnoPo = 2;
                    this.catTechnoPo = "Age du Fer";
                }
                else if (jetDes < 8 && jetDes > 5)
                {
                    this.niveauTechnoPo = 3;
                    this.catTechnoPo = "Renaissance";
                }
                else if (jetDes < 10 && jetDes > 7)
                {
                    this.niveauTechnoPo = 4;
                    this.catTechnoPo = "Age de la Vapeur";
                }
                else if (jetDes < 13 && jetDes > 9)
                {
                    this.niveauTechnoPo = 5;
                    this.catTechnoPo = "Age du Pétrole";
                }
                else if (jetDes < 16 && jetDes > 12)
                {
                    this.niveauTechnoPo = 6;
                    this.catTechnoPo = "Age de la Fusion";
                }
                else if (jetDes < 20 && jetDes > 15)
                {
                    this.niveauTechnoPo = 7;
                    this.catTechnoPo = "Avancé";
                }
                else if (jetDes > 19)
                {
                    this.niveauTechnoPo = 8;
                    this.catTechnoPo = "Très Avancé";
                }


                if(this.nativeOuColoniale) // à améliorer en prenant en compte les autres races existant dans BAB5 et les races générées aléatoirement
                {
                    switch(this.corpsCeleste.etoileES.systemSE.raceColonie)
                    {
                        case "Humain":
                            if(this.niveauTechnoPo > 7)
                            {
                                this.niveauTechnoPo = 7;
                            }
                            break;
                        case "Narn":
                            if (this.niveauTechnoPo > 7)
                            {
                                this.niveauTechnoPo = 7;
                            }
                            break;
                    }
                }
            }
            public void DeterminerGouvernement()
            {
                if(this.nativeOuColoniale)
                {
                    switch (this.corpsCeleste.etoileES.systemSE.raceColonie)
                    {
                        case "Humain":
                            this.participation = 7;
                            this.diversite = 4;
                            this.control = 5;
                            this.soutien = 8;
                            break;
                        case "Narn":
                            this.participation = 3;
                            this.diversite = 6;
                            this.control = 6;
                            this.soutien = 5;
                            break;
                        case "Centauri":
                            this.participation = 2;
                            this.diversite = 7;
                            this.control = 7;
                            this.soutien = 7;
                            break;
                        case "Minbari":
                            this.participation = 3;
                            this.diversite = 1;
                            this.control = 5;
                            this.soutien = 8;
                            break;
                    }
                }
                else
                {
                    JetDes jet = new JetDes();

                    this.participation = jet.JeterD(1,10);
                    this.diversite = jet.JeterD(1, 10);
                    this.control = jet.JeterD(1, 10);
                    this.soutien = jet.JeterD(1, 10);
                }
            }
            public void PopulationOrbital()
            {
                if(this.niveauTechnoPo > 5) // modification !!!!!!!!!!!!!!!!!!!!!!!!!!
                {
                    JetDes jet = new JetDes();
                    int jetDes = jet.JeterD(2,10);

                    // modificateurs au jet de la population orbitale
                    switch(this.niveauTechnoPo)
                    {
                        case 6:
                            jetDes = jetDes - 2;
                            break;
                        case 8:
                            jetDes = jetDes + 2;
                            break;
                    }

                    // résultat pour le colonies majeure et mineure
                    if(jetDes < 5)
                    {
                        this.nbColonieMajeure = 0;
                        this.nbColonieMineure = 0;
                    }
                    else if(jetDes < 11 && jetDes > 4)
                    {
                        this.nbColonieMajeure = 1;
                        this.nbColonieMineure = 0;
                        jetDes = jetDes - 1; // on retire le nombre minimum de colonie au score pour déterminer plus tard la quantité de base présentes
                    }
                    else if (jetDes < 18 && jetDes > 10)
                    {
                        this.nbColonieMajeure = jet.JeterD(1, 3);
                        this.nbColonieMineure = jet.JeterD(2, 3);
                        jetDes = jetDes - 3;// on retire le nombre minimum de colonie au score pour déterminer plus tard la quantité de base présentes
                    }
                    else if (jetDes > 17)
                    {
                        this.nbColonieMajeure = jet.JeterD(1, 4);
                        this.nbColonieMineure = jet.JeterD(3, 4);
                        jetDes = jetDes - 4;// on retire le nombre minimum de colonie au score pour déterminer plus tard la quantité de bases présentes
                    }

                    // résultat pour les bases à partir du score restant
                    int typeBase;
                    // on initialise les nombres de bases présentes
                    this.nbBaseMilitaire = 0;
                    this.nbBaseScientifique = 0;
                    this.nbBaseDefensive = 0;
                    this.nbBaseCommerciale = 0;
                    for(int i = jetDes; i == 0; i--)//chaque point du score restant représente une base (règle arbitraire car non explicité dans le supplément)
                    {
                        typeBase = jet.JeterD(1, 4); // on détermine le type de la base au hazard
                        switch(typeBase)
                        {
                            case 1:
                                this.nbBaseMilitaire = this.nbBaseMilitaire + 1;
                                break;
                            case 2:
                                this.nbBaseScientifique = this.nbBaseScientifique + 1;
                                break;
                            case 3:
                                this.nbBaseDefensive = this.nbBaseDefensive + 1;
                                break;
                            case 4:
                                this.nbBaseCommerciale = this.nbBaseCommerciale + 1;
                                break;
                        }
                    }

                }
                else // résultat où le niveau technologique de la population est insuffisant pour pouvoir avoir un population orbitale
                {
                    this.nbColonieMajeure = 0;
                    this.nbColonieMineure = 0;
                    this.nbBaseMilitaire = 0;
                    this.nbBaseScientifique = 0;
                    this.nbBaseDefensive = 0;
                    this.nbBaseCommerciale = 0;
                }
            }
            public int CalculerPopOrbital()
            {
                int jetDes = new JetDes().JeterD(1, 100);

                return Convert.ToInt32(jetDes * 0.00001 * this.nbHabitant);
            }
            #endregion

            #region Constructeurs Population
            public Population(CorpsCeleste corpsC, bool typePop)
            {
                this.corpsCeleste = corpsC;
                this.nativeOuColoniale = typePop;
                if (nativeOuColoniale)
                {
                    this.id_Po = "PopCol" + this.corpsCeleste.id_ES ;
                    this.nomPo = "Colonie " + this.corpsCeleste.etoileES.systemSE.raceColonie + " : " + this.corpsCeleste.nomES;
                }
                else
                {
                    this.id_Po = "PopNat" + this.corpsCeleste.id_ES;
                    this.nomPo = "Population Native : " + this.corpsCeleste.nomES;
                }
                this.NombreHabitant();
                this.NiveauTechnologique();
                this.DeterminerGouvernement();
                this.PopulationOrbital();
                this.tableCite.Add(new Cite(this, true));
                this.tableCite.Add(new Cite(this, false));
                if(this.niveauTechnoPo == 6 || // l'espèce extraterrestre est une capable de colonisé le reste du système.
                    this.niveauTechnoPo == 7||
                    this.niveauTechnoPo == 8)
                {
                    this.corpsCeleste.etoileES.systemSE.tablePopNativeSS.Add(this);
                }
            }
            #endregion
        }

        public class Cite
        {
            #region Attributs Cité
            public Population popC;
            public string id_C;
            public string nomC;
            public bool capitale;
            public string commentaireC;
            #endregion

            #region Méthodes Cité
            public int CalculerPopCite()
            {
                double pourcentage;
                if(this.capitale)
                {
                    pourcentage = 0.6;
                }
                else
                {
                    pourcentage = 0.4;
                }
                return Convert.ToInt32(pourcentage * this.popC.nbHabitant);
            }
            #endregion

            #region Constructeurs Cité
            public Cite(Population pop, bool estCapitale)
            {
                this.popC = pop;
                this.capitale = estCapitale;
                if(estCapitale)
                {
                    this.id_C  = "C0" + this.popC.id_Po;
                    this.nomC = "Capitale " + this.popC.nomPo; 
                }
                else
                {
                    this.id_C  = "C1" + this.popC.id_Po;
                    this.nomC = "Métropole " + this.popC.nomPo;
                }
            }
            #endregion
        }

    #endregion

    #region Tables de jet aléatoire

        //public class Table : List<LigneTable>
        //{
        //    // Méthodes
        //    public bool LigneSuperieure(LigneTable ligneSousTable1, LigneTable ligneSousTable2)
        //    {
        //        if (ligneSousTable1.paireEntiers.entierSup < ligneSousTable2.paireEntiers.entierInf)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }

        //    }
        //    public void TrierSousTable()
        //    {
        //        LigneTable ligneTemp;
        //        for (int i = 1; i < this.Count(); i++)
        //        {
        //            ligneTemp = this[i];
        //            int j = i;
        //            while (j > 0 && this.LigneSuperieure(this[j - 1], ligneTemp))
        //            {
        //                this[j] = this[j - 1];
        //                j--;
        //            }
        //            this[j] = ligneTemp;
        //        }
        //    }
        //    public void AjouterLigne(LigneTable newLigne)
        //    {
        //        int nbelement = this.Count;
        //        int capacite = this.Capacity;
        //        Console.WriteLine("\nTentative d'ajout");
        //        Console.WriteLine("nombre d'element dans la soustable : {0}", nbelement);
        //        Console.WriteLine("capacité de la soustable : {0}", capacite);
        //        if (this.Count() == 0)
        //        {
        //            this.Insert(0, newLigne);
        //            Console.WriteLine("Ajout bien effectué de {0}", newLigne.resultat, 0);
        //        }
        //        else
        //        {
        //            bool chevauche = false;
        //            foreach (LigneTable ligne in this)
        //            {
        //                if (chevauche == false)
        //                {
        //                    Console.WriteLine("chevauche vaut {0}", chevauche);
        //                    chevauche = newLigne.paireEntiers.Chevauche(ligne.paireEntiers);
        //                }
        //            }
        //            if (chevauche == false)
        //            {
        //                this.Insert(this.Count(), newLigne);
        //                Console.WriteLine("Ajout bien effectué de {0}", newLigne.resultat);
        //            }
        //            else
        //            {
        //                Console.WriteLine("N'a pas pu ajouter {0}", newLigne.resultat);
        //            }
        //        }

        //        this.TrierSousTable();
        //    }
        //    // Constructeur
        //    public Table()
        //    {
        //        this.Capacity = 1;
        //    }
        //}

        //public class LigneTable
        //{
        //    // Propriétés
        //    public PaireEntier paireEntiers;
        //    public string resultat;
        //    // Constructeurs
        //    public LigneTable(PaireEntier p, string r)
        //    {
        //        this.paireEntiers = p;
        //        this.resultat = r;
        //    }
        //    public LigneTable() { }
        //}

        //public class PaireEntier
        //{
        //    // Propriétés
        //    public int entierSup { get; set; }
        //    public int entierInf { get; set; }
        //    // Méthodes
        //    public List<int> CreerTranche()
        //    {
        //        List<int> tranche = new List<int>();
        //        int borneInf = this.entierInf,
        //            borneSup = this.entierSup;
        //        if (borneSup == borneInf)
        //        {
        //            tranche.Add(borneSup);
        //        }
        //        else
        //        {
        //            for (int i = borneInf; i < (borneSup + 1); i++)
        //            {
        //                tranche.Add(i);
        //            }
        //        }
        //        return tranche;
        //    }
        //    public bool Chevauche(PaireEntier p)
        //    {
        //        List<int> t1 = this.CreerTranche();
        //        List<int> t2 = p.CreerTranche();
        //        foreach (int entierT1 in t1)
        //        {

        //            foreach (int entierT2 in t2)
        //            {
        //                if (entierT1 == entierT2)
        //                {
        //                    return true;
        //                }
        //            }
        //        }
        //        return false;
        //    }
        //    public int Compter()
        //    {
        //        List<int> tranche = this.CreerTranche();
        //        return tranche.Count;
        //    }
        //    // Constructeurs
        //    public PaireEntier(int a, int b)
        //    {
        //        this.entierSup = Math.Max(a, b);
        //        this.entierInf = Math.Min(a, b);
        //    }
        //    public PaireEntier()
        //    {
        //        this.entierInf = 0;
        //        this.entierSup = 0;
        //    }
        //}

        //// Variables Globales
        //public static class MyGlobals
        //{
        //    //public static TrancheDeScore caca = new TrancheDeScore(9, -9);

        //    // Nombre d'étoile
        //    // Type d'étoile
        //    // Nombre de planète
        //    // Table des modificateurs : Nombre de planète
        //    // Position de la planète
        //    // Type de planète
        //    // Taille de la planète
        //    // Table des modificateurs : Taille de la planète
        //    // Nombre de Portail
        //    // Gravité
        //    // Densité atmosphérique
        //    // Composition atmosphérique
        //    // Pollution
        //    // Géologie
        //    // Table de modificateurs : Géologie
        //    // Volcanisme
        //    // Table de modificateurs : Volcanisme
        //    // Hydrosphère
        //    // Table de modificateurs : Hydrosphère
        //    // Continent
        //    // Table de modificateurs : Continent
        //    // Océan
        //    // Table de modificateurs : Océan
        //    // Température moyenne à l'Equateur
        //    // Table de modificateurs : Température moyenne à l'équateur
        //    // Table de modificateurs : Variabilité du climant
        //    // Biosphère
        //    // Table de modificateurs : Biosphère
        //    // Population
        //    // Table de modificateurs : Population
        //    // Technologie
        //    // Table de modificateurs : Technologie
        //    // Colonies orbitales
        //    // Population de la ceinture d'astéroïde
        //    // Table de modificateurs : Population de la ceinture d'astéroïde 
        //    // Nombre de lune
        //    // Type de lune
        //}
            

    #endregion

   
    #region Définir un jet de dés

        public class JetDes
        {
            // méthode pour jeter n'importe quel jet de dés
            // par défaut elle lance 1d6+0
            public int JeterD(int nbD = 1,int typeD = 6,int modifD = 0)
            {
                Random hazard = new Random();
                return hazard.Next(nbD + modifD, modifD + nbD * typeD + 1);
            }    
        }

    #endregion


}
    #endregion
