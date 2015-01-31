using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliothequeGSS;
namespace Programme
{

    class Program
    {
        static void Main(string[] args)
        {
            
            SystemeSolaire sy = new SystemeSolaire();
            GenerateurSystemeSolaire gss = new GenerateurSystemeSolaire(sy);
            gss.GenererSysteme();

            Console.WriteLine(sy.tableEtoile.Count);
            sy.DeterminerTableEtoile();
            Console.WriteLine(sy.tableEtoile.Count);
            sy.DeterminerTableEtoile();
            Console.WriteLine(sy.tableEtoile.Count);
            Console.WriteLine(sy.portail);
            sy.NbPortail();
            Console.WriteLine(sy.portail);
            Console.ReadLine();



        }
    }
}
