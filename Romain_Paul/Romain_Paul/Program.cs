using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int choix = 42;

        Console.WriteLine("-------------------------------Bienvenue----------------------------------------");

        while (choix != 0)
        {
            Console.WriteLine("\n**************************Application2023-2024**********************************");
            Console.WriteLine("\n1:      PartieA");
            Console.WriteLine("2:      PartieB");
            Console.WriteLine("\n0:      Quitter \n");

            choix = int.Parse(Console.ReadLine());

            switch (choix)
            {
                case 1:
                    PartieA();
                    break;
                case 2:
                    PartieB();
                    break;
                case 0:
                    Quitter();
                    break;
                default:
                    Console.WriteLine("ERREUR!\n\n");
                    break;
            }
        }
    }

    static void PartieA()
    {

        int choixA = 42;
        while (choixA != 0)
        {
            Console.WriteLine("-------- Partie A ------------");
            Console.WriteLine("1 : Impôts sur le revenu");          // l 143
            Console.WriteLine("2 : Code de photocopie");            // l 275
            Console.WriteLine("3 : Code Postal => Code Barre");     // l 313
            Console.WriteLine("4 : Nombre abondant");               // l 372
            Console.WriteLine("5 : Puissance pondérée");            // l 423
            Console.WriteLine("6 : Nombre paires consécutif\n");    // l 450
            Console.WriteLine("0 : Retour\n");

            choixA = int.Parse(Console.ReadLine());

            switch (choixA)
            {
                case 1:
                    ImpotRevenu();
                    break;
                case 2:
                    CodePhotocopie();
                    break;
                case 3:
                    CodePostalCodeBarre();
                    break;
                case 4:
                    NombreAbondant();
                    break;
                case 5:
                    PuissancePonderee();
                    break;
                case 6:
                    NombrePairesConsecutif();
                    break;
                case 0:
                    // Retour
                    break;
                default:
                    Console.WriteLine("Choix non valide. Veuillez essayer de nouveau.");
                    break;
            }
        }


    }

    static void PartieB()
    {

        int choixB = 42;
        while (choixB != 0)
        {
            Console.WriteLine("-------- Partie B ------------");
            Console.WriteLine("1 : Jour d'après");              // l 481
            Console.WriteLine("2 : Jours entre deux dates");    // l 541
            Console.WriteLine("3 : Année bissextile");          // l 576
            Console.WriteLine("4 : Pâque");                     // l 600
            Console.WriteLine("5 : Calendrier");                // l 747 
            Console.WriteLine("0 : Retour\n");

            choixB = int.Parse(Console.ReadLine());

            switch (choixB)
            {
                case 1:
                    jourapres();
                    break;
                case 2:
                    entredate();
                    break;
                case 3:
                    bissextile();
                    break;
                case 4:
                    paque();
                    break;
                case 5:
                    calendrier();
                    break;

                case 0:
                    // Retour
                    break;
                default:
                    Console.WriteLine("Choix non valide. Veuillez essayer de nouveau.");
                    break;
            }
        }


    }



    static void Quitter()
    {
        Console.WriteLine("Au revoir !");
    }



    static void ImpotRevenu()
    {
        Console.WriteLine(" -------------------------------------------------------------------------- ");
        Console.WriteLine(" ----------------------------Impôts sur le revenu-------------------------- ");
        Console.WriteLine(" -------------------------------------------------------------------------- ");

        int statutFamilial = DemanderStatutFamilial();
        int charge = DemanderNombrePersonnesACharge();
        double part;
        double revenu = DemanderRevenu();
        double rpp;
        double impotstot;

        if (statutFamilial == 1)
        {
            part = PartCelib(charge);
        }
        else if (statutFamilial == 2)
        {
            part = PartConcu(charge);
        }
        else
        {
            part = PartMarier(charge);
        }

        rpp = revenu / part;
        double impots = Impo(rpp);
        impotstot = impots * part;

        AfficherResultats(statutFamilial, charge, part, rpp, impotstot);
    }

    static int DemanderStatutFamilial()
    {
        int statut;
        do
        {
            Console.Write("Statut familial (1 pour célibataire, 2 pour concubin, et 3 pour marié) : ");
            statut = Convert.ToInt32(Console.ReadLine());
        }
        while (statut < 1 || statut > 3);
        return statut;
    }

    static int DemanderNombrePersonnesACharge()
    {
        int charge;
        do
        {
            Console.Write("Nombre de personnes à charge : ");
            charge = Convert.ToInt32(Console.ReadLine());
        }
        while (charge < 0);
        return charge;
    }

    static double DemanderRevenu()
    {
        double revenu;
        do
        {
            Console.Write("Revenu : ");
            revenu = Convert.ToDouble(Console.ReadLine());
        }
        while (revenu < 0);
        return revenu;
    }

    static void AfficherResultats(int statut, int charge, double part, double rpp, double impotstot)
    {
        string statutFamilial = "";
        switch (statut)
        {
            case 1: statutFamilial = "Célibataire"; break;
            case 2: statutFamilial = "Célibataire en concubinage"; break;
            case 3: statutFamilial = "Marié(e)"; break;
        }

        Console.WriteLine(" ");

        Console.WriteLine("Vous êtes : " + statutFamilial);
        Console.WriteLine("Nombre de personnes à charge : " + charge);
        Console.WriteLine("Nombre de parts : " + part);
        Console.WriteLine("Revenu imposable : " + rpp + " euros");
        Console.WriteLine("Impôt sur le revenu : " + impotstot + " euros");
    }

    static double PartCelib(int charge)
    {
        double part = 0;
        if (charge == 0) part = 1;
        else if (charge == 1) part = 2;
        else if (charge == 2) part = 2.5;
        else if (charge > 2) part = charge + 0.5;
        return part;
    }

    static double PartConcu(int charge)
    {
        double part = 0;
        if (charge == 0) part = 1;
        else if (charge == 1) part = 1.5;
        else if (charge == 2) part = 2;
        else if (charge > 2) part = charge;
        return part;
    }

    static double PartMarier(int charge)
    {
        double part = 0;
        if (charge == 0) part = 2;
        else if (charge == 1) part = 2.5;
        else if (charge == 2) part = 3;
        else if (charge > 2) part = charge + 1;
        return part;
    }

    static double Impo(double rpp)
    {
        double impots = 0;
        if (rpp <= 9710) impots = 0;
        else if (rpp <= 26818) impots = (rpp - 9710) * 0.14;
        else if (rpp <= 71898) impots = (rpp - 26818) * 0.3 + 2395;
        else if (rpp <= 152260) impots = (rpp - 71898) * 0.41 + 2395.12 + 13524;
        else impots = (rpp - 152260) * 0.45 + 2395.12 + 13524 + 33048;
        return impots;
    }




    static void CodePhotocopie()
    {
        Console.WriteLine(" -------------------------------------------------------------------------- ");
        Console.WriteLine(" -------------------------- Code de photocopie --------------------------- ");
        Console.WriteLine(" -------------------------------------------------------------------------- ");

        int x = DemanderIdentification();

        int q = x / 1000 % 10;  // Premier chiffre
        int s = x / 100 % 10;   // Deuxième chiffre
        int d = x / 10 % 10;    // Troisième chiffre
        int f = x % 10;         // Quatrième chiffre

        Console.WriteLine("Votre code (4 chiffres) : " + q + s + d + f);

        if ((q + s + d) % 7 == f)
        {
            Console.WriteLine("==> Le code " + q + s + d + f + " est correct");
        }
        else
        {
            Console.WriteLine("==> *** Le code " + q + s + d + f + " est incorrect ***");
        }
    }

    static int DemanderIdentification()
    {
        int num;
        do
        {
            Console.Write("Veuillez entrer vos 4 numéros d'identification : ");
            num = Convert.ToInt32(Console.ReadLine());
        }
        while (num > 9999 || num < 1000);

        return num;
    }

    static void CodePostalCodeBarre()
    {
        Console.WriteLine(" -------------------------------------------------------------------------- ");
        Console.WriteLine(" ---------------------- Code Postal => Code Barre ------------------------- ");
        Console.WriteLine(" -------------------------------------------------------------------------- ");

        int x = DemanderCodePostal();

        int a = x / 10000 % 10;
        int z = x / 1000 % 10;
        int e = x / 100 % 10;
        int r = x / 10 % 10;
        int t = x % 10;

        int sommeChiffre = a + z + e + r + t;
        int clef = sommeChiffre % 10 == 0 ? 0 : 10 - sommeChiffre % 10;

        string codeBarre = ConvertirEnCodeBarre(a, z, e, r, t, clef);

        Console.WriteLine("| " + codeBarre + " |");
    }

    static int DemanderCodePostal()
    {
        int codePostal;
        do
        {
            Console.Write("Veuillez entrer un code postal (5 chiffres) : ");
            codePostal = Convert.ToInt32(Console.ReadLine());
        }
        while (codePostal > 99999 || codePostal < 10000);

        return codePostal;
    }

    static string ConvertirEnCodeBarre(int a, int z, int e, int r, int t, int clef)
    {
        return ChiffreEncode(a) + " " + ChiffreEncode(z) + " " + ChiffreEncode(e) + " " + ChiffreEncode(r) + " " + ChiffreEncode(t) + " " + ChiffreEncode(clef);
    }

    static string ChiffreEncode(int numero)
    {
        switch (numero)
        {
            case 0: return "||:::";
            case 1: return ":::||";
            case 2: return "::|:|";
            case 3: return "::||:";
            case 4: return ":|::|";
            case 5: return ":|:|:";
            case 6: return ":||::";
            case 7: return "|:::|";
            case 8: return "|::|:";
            case 9: return "|:|::";
            default: return "";
        }
    }


    static void NombreAbondant()
    {
        Console.WriteLine(" -------------------------------------------------------------------------- ");
        Console.WriteLine(" ---------------------------- Nombre abondant ----------------------------- ");
        Console.WriteLine(" -------------------------------------------------------------------------- ");

        int v1, v2;
        (v1, v2) = DemanderIntervalle();

        if (v2 > 11)
        {
            Console.WriteLine("Voici les nombres abondants :");
            for (int j = v1; j <= v2; j++)
            {
                int somme = 0;
                for (int i = 1; i <= j - 1; i++)
                {
                    if (j % i == 0)
                    {
                        somme += i;
                    }
                }
                if (somme > j)
                {
                    Console.WriteLine(j);
                }
            }
        }
        else
        {
            Console.WriteLine("Il n'y a pas de nombres abondants dans cet intervalle.");
        }
    }

    static (int, int) DemanderIntervalle()
    {
        int v1, v2;
        do
        {
            Console.WriteLine("Veuillez entrer une intervalle (deux nombres, le premier inférieur au deuxième, et le premier supérieur à 1) : ");
            v1 = Convert.ToInt32(Console.ReadLine());
            v2 = Convert.ToInt32(Console.ReadLine());
        }
        while (v1 < 2 || v1 > v2);

        return (v1, v2);
    }




    static void PuissancePonderee()
    {
        Console.WriteLine(" -------------------------------------------------------------------------- ");
        Console.WriteLine(" ------------------------ Puissance pondérée ------------------------------- ");
        Console.WriteLine(" -------------------------------------------------------------------------- ");

        Console.Write("Entrez un entier n : ");
        int n = Convert.ToInt32(Console.ReadLine());

        int k;
        do
        {
            Console.Write("Entrez un entier k (positif) : ");
            k = Convert.ToInt32(Console.ReadLine());
        }
        while (k < 0);

        int somme = 0;
        for (int p = 0; p <= k; p++)
        {
            Console.WriteLine(p + "*" + n + "^" + p);
            somme += p * (int)Math.Pow(n, p);
        }

        Console.WriteLine("Puissance pondérée (" + n + "," + k + ") = " + somme);
    }

    static void NombrePairesConsecutif()
    {
        Console.WriteLine(" -------------------------------------------------------------------------- ");
        Console.WriteLine(" --------------------- Nombre paires consécutif --------------------------- ");
        Console.WriteLine(" -------------------------------------------------------------------------- ");

        Console.Write("Veuillez entrer un nombre : ");
        int n = Convert.ToInt32(Console.ReadLine());
        bool trouve = false;

        for (int i = 0; i <= n; i += 2)
        {
            int somme = i + (i + 2) + (i + 4);
            if (somme == n)
            {
                Console.WriteLine(i + " + " + (i + 2) + " + " + (i + 4) + " = " + n);
                trouve = true;
                break; 
            }
        }

        if (!trouve)
        {
            Console.WriteLine("Il n'existe pas 3 nombres pairs consécutifs qui sont égaux à : " + n);
        }


    }



    static void jourapres()
    {
        Console.WriteLine(" -------------------------------------------------------------------------- ");
        Console.WriteLine(" ------------------------ Calcul du jour d'après -------------------------- ");
        Console.WriteLine(" -------------------------------------------------------------------------- ");

        Console.Write("Veuillez saisir le jour : ");
        int j = Convert.ToInt32(Console.ReadLine());
        Console.Write("Veuillez saisir le mois : ");
        int m = Convert.ToInt32(Console.ReadLine());
        Console.Write("Veuillez saisir l'année : ");
        int a = Convert.ToInt32(Console.ReadLine());

        int bissex = Bissextile(a);
        int valide = AnneExiste(j, m, a, bissex);

        if (valide == 1)
        {
            j++;
            if (j > 31 || (j > 30 && (m == 4 || m == 6 || m == 9 || m == 11)) || (j > 28 && m == 2 && bissex == 0) || (j > 29 && m == 2 && bissex == 1))
            {
                j = 1;
                m++;
                if (m > 12)
                {
                    m = 1;
                    a++;
                }
            }

            Console.WriteLine("Le jour d'après est le " + j + "/" + m + "/" + a);
        }
        else
        {
            Console.WriteLine("La date saisie n'est pas valide.");
        }


    }

    static int Bissextile(int a)
    {
        return a % 4 == 0 && (a % 100 != 0 || a % 400 == 0) ? 1 : 0;
    }

    static int AnneExiste(int j, int m, int a, int bissex)
    {
        if (m > 12 || m < 1 || j > 31 || j < 1 || (j > 30 && (m == 4 || m == 6 || m == 9 || m == 11)) || (j > 28 && bissex == 0 && m == 2) || (j > 29 && bissex == 1 && m == 2) || a < 1)
        {
            return 0;
        }
        return 1;
    }







    static void entredate()
    {
        Console.WriteLine(" -------------------------------------------------------------------------- ");
        Console.WriteLine(" -------------------- Calcul du nombre de jour entre 2 dates --------------- ");
        Console.WriteLine(" -------------------------------------------------------------------------- ");

        Console.WriteLine("Entrer la date initiale");
        DateTime dateInitiale = LireDate();

        Console.WriteLine("Entrer la date finale");
        DateTime dateFinale = LireDate();

        if (dateFinale < dateInitiale)
        {
            Console.WriteLine("L'intervalle est impossible, il doit être croissant");
        }
        else
        {
            int difference = (dateFinale - dateInitiale).Days;
            Console.WriteLine("Il y a " + difference + " jours entre le " + dateInitiale.ToString("dd/MM/yyyy") + " et le " + dateFinale.ToString("dd/MM/yyyy"));
        }
    }

    static DateTime LireDate()
    {
        Console.Write("Veuillez saisir le jour : ");
        int jour = Convert.ToInt32(Console.ReadLine());
        Console.Write("Veuillez saisir le mois : ");
        int mois = Convert.ToInt32(Console.ReadLine());
        Console.Write("Veuillez saisir l'année : ");
        int annee = Convert.ToInt32(Console.ReadLine());

        return new DateTime(annee, mois, jour);
    }

    static void bissextile()
    {

        Console.Write("Veuillez saisir l'année : ");
        int a = Convert.ToInt32(Console.ReadLine());

        int bissex = Bissextile(a);


        if (bissex == 1)
        {

            Console.WriteLine("{0} est une anné bissextile", a);
        }
        else
        {
            Console.WriteLine("{0} n'est pas une anné bissextile", a);

        }

    }



    static void paque()
    {
        int choixP = 42;
        while (choixP != 0)
        {

            Console.WriteLine("               Calcul de Pâque           ");
            Console.WriteLine("1 : Méthode de GAUSS   (Date récentes) ");
            Console.WriteLine("2 : Méthode de MEEUS   (Date très ancienne)");
            Console.WriteLine("3 : Méthode de CONWAY  (Date assez éloignée)\n");


            choixP = int.Parse(Console.ReadLine());
            switch (choixP)
            {
                case 1:
                    GAUSS();
                    break;
                case 2:
                    MEEUS();
                    break;
                case 3:
                    CONWAY();
                    break;

            }

        }


    }
    static void GAUSS()
    {
        Console.WriteLine(" -------------------------------------------------------------------------- ");
        Console.WriteLine(" -------------Calcul de la date de Pâques avec la manière de Gauss---------- ");
        Console.WriteLine(" -------------------------------------------------------------------------- ");

        Console.Write("Veuillez entrer année : ");
        int anne = Convert.ToInt32(Console.ReadLine());

        int a = anne % 19;
        int b = anne % 4;
        int c = anne % 7;

        int k = anne / 100;
        int p = (8 * k + 13) / 25;
        int q = k / 4;

        int m = (15 - p + k - q) % 30;
        int n = (4 + k - q) % 7;

        int d = (19 * a + m) % 30;
        int e = (2 * b + 4 * c + 6 * d + n) % 7;

        int h = 22 + d + e;
        int i = d + e - 9;

        if (i < 1)
        {
            Console.WriteLine("Selon Gauss, Pâques tombe le " + h + " mars en " + anne);
        }
        else
        {
            Console.WriteLine("Selon Gauss, Pâques tombe le " + i + " avril en " + anne);
        }





    }
    static void MEEUS()
    {
        Console.WriteLine(" -------------------------------------------------------------------------- ");
        Console.WriteLine(" ------------Calcul de la date de Pâques avec la manière de Meeus----------- ");
        Console.WriteLine(" -------------------------------------------------------------------------- ");

        Console.Write("Veuillez entrer année : ");
        int anne = Convert.ToInt32(Console.ReadLine());

        if (anne >= 326)
        {
            int A = anne % 19;
            int B = anne % 7;
            int C = anne % 4;
            int D = (19 * A + 15) % 30;
            int E = (2 * C + 4 * B - D + 34) % 7;
            int G = (D + E + 114) % 31;
            int F = (D + E + 114 - G) / 31;

            if (F == 3)
            {
                Console.WriteLine("Selon Meeus, Pâques tombe le " + (G + 1) + " mars en " + anne);
            }
            else if (F == 4)
            {
                Console.WriteLine("Selon Meeus, Pâques tombe le " + (G + 1) + " avril en " + anne);
            }
        }
        else
        {
            Console.WriteLine("Pas de date trouvée");
        }


    }

    static void CONWAY()
    {
        Console.WriteLine(" -------------------------------------------------------------------------- ");
        Console.WriteLine(" ---------- Calcul de la date de Pâques avec la manière de Conway ---------- ");
        Console.WriteLine(" -------------------------------------------------------------------------- ");

        Console.Write("Veuillez entrer année : ");
        int anne = Convert.ToInt32(Console.ReadLine());


        int t = anne % 100;
        int s = anne / 100;
        int a = t / 4;
        int p = s % 4;
        int jps = (9 - 2 * p) % 7;
        int jp = (jps + a + t) % 7;
        int g = anne % 19;
        int gg = g + 1;
        int b = s / 4;
        int r = 8 * (s + 11) / 25;
        int cc = -s + b + r;
        int d = (11 * gg + cc) % 30;
        d = (d + 30) % 30;
        int h = (551 - 19 * d + gg) / 544;
        int e = (50 - d - h) % 7;
        int f = (e + jp) % 7;
        int R = (57 - d - f - h);

        if (R < 32)
        {
            Console.WriteLine("Selon Conway, Pâques tombe le " + R + " mars en " + anne);
        }
        else
        {
            Console.WriteLine("Selon Conway, Pâques tombe le " + (R - 31) + " avril en " + anne);
        }
    }


    static void calendrier()
    {
      
            Console.WriteLine(" -------------------------------------------------------------------------- ");
            Console.WriteLine(" -----------------------------CALENDRIER----------------------------------- ");
            Console.WriteLine(" -------------------------------------------------------------------------- ");
            Console.Write("Veuillez entrer une année : ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Lundi (0), Mardi (1), Mercredi (2), Jeudi (3), Vendredi (4), Samedi (5), Dimanche (6)");
            Console.Write("Veuillez saisir le jour du premier janvier : ");
            int j = Convert.ToInt32(Console.ReadLine());
            while (j > 6 || j < 0)
            {
                Console.Write("Veuillez saisir le jour du premier janvier (entre 0 et 6) : ");
                j = Convert.ToInt32(Console.ReadLine());
            }

            for (int m = 1; m <= 12; m++)
            {
                int nbj;
                if (m == 2)
                {
                    nbj = Bissextile2(a) ? 29 : 28;
                }
                else
                {
                    nbj = (m == 4 || m == 6 || m == 9 || m == 11) ? 30 : 31;
                }

                string calendrierMois = Mois(j, m, a, nbj);
                Console.WriteLine(calendrierMois);
                j = (j + nbj) % 7;
            }
        }

    static bool Bissextile2(int annee)
    {
        return (annee % 4 == 0 && annee % 100 != 0) || (annee % 400 == 0);      
    }

    static string Mois(int j, int m, int a, int nbj)
        {
            string[] moisNoms = { "Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre" };
            StringBuilder calendrier = new StringBuilder();
            calendrier.AppendLine("\n\n" + moisNoms[m - 1]);
            calendrier.AppendLine("Lu Ma Me Je Ve Sa Di");

            int espaceDebut = j;
            for (int i = 0; i < espaceDebut; i++)
            {
                calendrier.Append("   ");
            }

            for (int x = 1; x <= nbj; x++)
            {
                if ((espaceDebut + x) % 7 == 1)
                {
                    calendrier.AppendLine();
                }
                calendrier.AppendFormat("{0,2} ", x);
            }

            return calendrier.ToString();
       


}
}