using System;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        /*Zajci

		  Orjak;2.5.2010;311;Samica
		  Novozelandec;4.4.2010;210;Samica
		  Levjegrivec;11.12.2010;330;Samec
		  Rjavko;11.10.2010;500;Samica
		  Angora;10.12.2010;450;Samec
		  Flex;6.6.2011;11;Samec
		  Dolgodlaki;7.7.2011;811;Samica
		  Pritlikavi;9.9.2011;389;Samec

       */

        class Zajci
        {

            string ime;
            string datum;
            int teza;
            string spol;
            public Zajci(string ime, string d, int t, string s)
            {
                this.ime = ime;
                datum = d;
                teza = t;
                spol = s;
            }
            public override string ToString()
            {
                return ime + ";" + datum + ";" + teza + ";" + spol;
            }
            public string Vrneime()
            {
                return ime;
            }
        }
        static void Vizitka()
        {
            Console.WriteLine("\nIzpis osebnih podatkov");
            Console.WriteLine("Avtor: Rok Kovačič");
            Console.WriteLine("Datum rojstva: 19. 10. 1997");
            Console.WriteLine("E-poštni naslov: rokkovacic.rk@gmail.com");
        }

        static void Main(string[] args)
        {
            string[] vsebinaTabele = File.ReadAllLines("C:\\tmp\\Zajci.txt", Encoding.UTF8);

            Zajci[] tabZajcev = new Zajci[vsebinaTabele.Length];
            for (int i = 0; i < tabZajcev.Length; i++)
            {
                string vrstica = vsebinaTabele[i];
                string[] zacasna = vrstica.Split(';');

                Zajci nov = new Zajci(zacasna[0], zacasna[1], Convert.ToInt32(zacasna[2]), zacasna[3]);

                tabZajcev[i] = nov;
            }

            Console.WriteLine(" PROGRAM ZAJCI\n\n");
            Console.WriteLine(" Pritisnite 1 za izpis, \n Pritisnite 2 za Vnos, \n Pritisnite 3 za brisanje, \n Pritisnite 4 za urejanje, " +
                              "\n Pritisnite 5 za poizvedbe, \n Pritisnite tipko V za izpis vizitke,  \n Pritisnite tipko  X za izhod in shranjevanje");

            char vnos = Console.ReadKey().KeyChar;

            while (vnos != 'X' || vnos != 'x')
            {
                while (vnos != '1' && vnos != '2' && vnos != '3' && vnos != '4' && vnos != 27 && vnos != '5' && vnos != 'X' && vnos != 'x' && vnos != 'v' && vnos != 'V')
                {
                    Console.Clear();
                    Console.WriteLine("Nepravilen vnos, prosimo poskusite ponovno\n");
                    Console.WriteLine(" Pritisnite 1 za izpis, \n Pritisnite 2 za Vnos, \n Pritisnite 3 za brisanje, \n Pritisnite 4 za urejanje, " +
                              "\n Pritisnite 5 za poizvedbe, \n Pritisnite tipko V za izpis vizitke,  \n Pritisnite tipko  X za izhod in shranjevanje");
                    vnos = Console.ReadKey().KeyChar;

                }
                while (vnos == '1' || vnos == '2' || vnos == '3' || vnos == '4' || vnos == 27 || vnos == '5' || vnos == 'x' || vnos == 'X' || vnos == 'v' || vnos == 'V')
                {
                    if (vnos == '1') // Izpis
                    {
                        Console.Clear();
                        Console.WriteLine("\n");
                        for (int i = 0; i < tabZajcev.Length; i++)
                            Console.WriteLine((i + 1) + ". " + tabZajcev[i].ToString());
                        Console.WriteLine("\nNov vnos?d/n");
                        char vnos2 = Console.ReadKey().KeyChar;

                        if (vnos2 == 'd')
                        {
                            Console.Clear();
                            Console.WriteLine(" Pritisnite 1 za izpis, \n Pritisnite 2 za Vnos, \n Pritisnite 3 za brisanje, \n Pritisnite 4 za urejanje, " +
                              "\n Pritisnite 5 za poizvedbe, \n Pritisnite tipko V za izpis vizitke,  \n Pritisnite tipko  X za izhod in shranjevanje");
                            vnos = Console.ReadKey().KeyChar;
                        }
                        else if (vnos2 == 'n')
                        {
                            vnos = 'x';
                        }
                        break;

                    }
                    else if (vnos == '2') // Vnos
                    {
                        try
                        {
                            Console.Clear();
                            Array.Resize(ref tabZajcev, tabZajcev.Length + 1);
                            int indeks = tabZajcev.Length;
                            Console.Write("Ime zajca: ");
                            string ime = Console.ReadLine();
                            Console.Write("Datum rojstva: ");
                            string datum = Console.ReadLine();
                            Console.Write("Teža: ");
                            int teza = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Spol (Samica/Samec): ");
                            string spol = Convert.ToString(Console.ReadLine());
                            Zajci spremenjen = new Zajci(ime, datum, teza, spol);
                            tabZajcev[indeks - 1] = spremenjen;


                            Console.WriteLine("\nStanje v tabeli");
                            for (int i = 0; i < tabZajcev.Length; i++)
                                Console.WriteLine((i + 1) + ". " + tabZajcev[i].ToString());
                            Console.WriteLine("\n");

                            Console.WriteLine("\nNov vnos?d/n");
                            char vnos2 = Console.ReadKey().KeyChar;
                            if (vnos2 == 'd')
                            {
                                Console.Clear();
                                Console.WriteLine(" Pritisnite 1 za izpis, \n Pritisnite 2 za Vnos, \n Pritisnite 3 za brisanje, \n Pritisnite 4 za urejanje, " +
                              "\n Pritisnite 5 za poizvedbe, \n Pritisnite tipko V za izpis vizitke,  \n Pritisnite tipko  X za izhod in shranjevanje");
                                vnos = Console.ReadKey().KeyChar;
                            }
                            else if (vnos2 == 'n')
                            {
                                vnos = 'x';
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Niste pravilno vnesli podatkov, poskusite ponovno!");
                            Console.ReadKey();
                        }
                        break;
                    }
                    else if (vnos == '3') // Brisanje
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Vnesite indeks celice ki bi jo radi izbrisali:\n");
                            int indeks = Convert.ToInt32(Console.ReadLine());
                            indeks = indeks - 1;
                            Zajci[] novaVsebina = new Zajci[tabZajcev.Length];

                            Console.WriteLine("\nStanje v tabeli pred izbrisom: \n");
                            for (int i = 0; i < tabZajcev.Length; i++)
                                Console.WriteLine((i + 1) + ". " + tabZajcev[i].ToString());


                            for (int i = 0; i < tabZajcev.Length; i++)
                            {
                                if (i != indeks)
                                    novaVsebina[i] = tabZajcev[i];
                            }


                            Array.Resize(ref tabZajcev, tabZajcev.Length - 1);

                            for (int i = 0, j = 0; i < tabZajcev.Length; i++, j++)
                            {
                                if (novaVsebina[j] != null)
                                {
                                    tabZajcev[i] = novaVsebina[j];

                                }
                                else
                                {

                                    i--;
                                }
                            }

                            Console.WriteLine("\nStanje v tabeli");
                            for (int i = 0; i < tabZajcev.Length; i++)
                                Console.WriteLine((i + 1) + ". " + tabZajcev[i].ToString());
                            Console.WriteLine("\n");
                        }
                        catch
                        {
                            Console.WriteLine("Niste pravilno vnesli podatkov, poskusite ponovno!");
                            Console.ReadKey();
                        }

                        Console.WriteLine("\nNov vnos?d/n");
                        char vnos2 = Console.ReadKey().KeyChar;

                        if (vnos2 == 'd')
                        {
                            Console.Clear();
                            Console.WriteLine(" Pritisnite 1 za izpis, \n Pritisnite 2 za Vnos, \n Pritisnite 3 za brisanje, \n Pritisnite 4 za urejanje, " +
                              "\n Pritisnite 5 za poizvedbe, \n Pritisnite tipko V za izpis vizitke,  \n Pritisnite tipko  X za izhod in shranjevanje");
                            vnos = Console.ReadKey().KeyChar;
                        }
                        else if (vnos2 == 'n')
                        {
                            vnos = 'x';
                        }
                        break;

                    }
                    else if (vnos == '4') // Urejanje
                    {
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("\nVnesite indeks:");
                            int indeks = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine(tabZajcev[indeks - 1].ToString());

                            Console.Write("Ime: ");
                            string ime = Console.ReadLine();
                            if (ime.Length == 0)
                                ime = tabZajcev[indeks - 1].Vrneime();

                            Console.Write("Datum: ");
                            string datum = Console.ReadLine();

                            Console.Write("Teza: ");
                            int teza = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Spol (Samica/Samec): ");
                            string spol = Convert.ToString(Console.ReadLine());

                            Zajci spremenjen = new Zajci(ime, datum, teza, spol);

                            tabZajcev[indeks - 1] = spremenjen;
                            Console.WriteLine("\n");

                            for (int i = 0; i < tabZajcev.Length; i++)
                                Console.WriteLine((i + 1) + ". " + tabZajcev[i].ToString());


                            Console.WriteLine("\nNov vnos?d/n");
                            char vnos2 = Console.ReadKey().KeyChar;
                            if (vnos2 == 'd')
                            {
                                Console.Clear();
                                Console.WriteLine(" Pritisnite 1 za izpis, \n Pritisnite 2 za Vnos, \n Pritisnite 3 za brisanje, \n Pritisnite 4 za urejanje, " +
                              "\n Pritisnite 5 za poizvedbe, \n Pritisnite tipko V za izpis vizitke,  \n Pritisnite tipko  X za izhod in shranjevanje");
                                vnos = Console.ReadKey().KeyChar;
                            }
                            else if (vnos2 == 'n')
                            {
                                vnos = 'x';
                            }

                        }
                        catch
                        {
                            Console.WriteLine("Niste pravilno vnesli podatkov, poskusite ponovno!");
                            Console.ReadKey();
                        }

                        break;
                    }
                    else if (vnos == '5')
                    {
                        Console.Clear();
                        Console.WriteLine("\n\nOBDELAVA -");
                        Console.WriteLine("Vnesite 1 za izpis zajcev na poljubno črko, \nVnesite 2 za izpis samcev \nVnesite 3 za izpis zajcev rojenih v poljubnem letu\n\n");
                        char vnos1 = Console.ReadKey().KeyChar;

                        while (vnos1 != '1' && vnos1 != '2' && vnos1 != '3')
                        {
                            Console.WriteLine("\nVnesli ste napačno izbiro\n");
                            Console.WriteLine("Vnesite 1 za izpis zajcev na poljubno črko, \nVnesite 2 za izpis samcev \nVnesite 3 za izpis zajcev rojenih v poljubnem letu\n\n");
                            vnos1 = Console.ReadKey().KeyChar;
                        }

                        if (vnos1 == '1')
                        {
                            Console.WriteLine("Vnesite črko:\n");
                            char crka = char.ToUpper(Console.ReadKey().KeyChar);
                            Boolean najdel = false;

                            Console.WriteLine("\nIzpis zajcev na črko " + crka);
                            for (int i = 0; i < tabZajcev.Length; i++)
                            {
                                string vrstica = tabZajcev[i].ToString();
                                string[] zacasna = vrstica.Split(';');
                                string ime = zacasna[0];

                                if (ime[0] == crka)
                                {
                                    Console.WriteLine(ime);
                                    najdel = true;
                                }
                            }
                            if (najdel == false)
                                Console.WriteLine("V tabeli ni zajca, katerega ime bi se začelo na črko " + crka);
                        }
                        else if (vnos1 == '2')
                        {
                            for (int i = 0; i < tabZajcev.Length; i++)
                            {
                                string vrstica = tabZajcev[i].ToString();
                                string[] zacasna = vrstica.Split(';');
                                string ime = zacasna[0];

                                string spol = zacasna[3];

                                if (spol == "Samec")
                                    Console.WriteLine(ime);
                            }
                        }
                        else if (vnos1 == '3')
                        {
                            Console.WriteLine("Vnesite leto rojstva zajcev (npr.:2010):");
                            string leto = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Izpis zajcev rojenih v letu " + leto);
                            for (int i = 0; i < tabZajcev.Length; i++)
                            {
                                string vrstica = tabZajcev[i].ToString();
                                string[] zacasna = vrstica.Split(';');
                                string rojstvo = zacasna[1];
                                string ime = zacasna[0];

                                string[] datum = rojstvo.Split('.');
                                string letnik = datum[2].ToString();

                                if (letnik == leto)
                                    Console.WriteLine(ime);
                            }
                        }

                        Console.WriteLine("\nNov vnos?d/n");
                        char vnos2 = Console.ReadKey().KeyChar;

                        if (vnos2 == 'd')
                        {
                            Console.Clear();
                            Console.WriteLine(" Pritisnite 1 za izpis, \n Pritisnite 2 za Vnos, \n Pritisnite 3 za brisanje, \n Pritisnite 4 za urejanje, " +
                              "\n Pritisnite 5 za poizvedbe, \n Pritisnite tipko V za izpis vizitke,  \n Pritisnite tipko  X za izhod in shranjevanje");
                            vnos = Console.ReadKey().KeyChar;
                        }
                        else if (vnos2 == 'n')
                        {
                            vnos = 'x';
                        }

                        break;
                    }
                    else if (vnos == 'v' || vnos == 'V')
                    {
                        Vizitka();

                        Console.WriteLine("\nNov vnos?d/n");
                        char vnos2 = Console.ReadKey().KeyChar;

                        if (vnos2 == 'd')
                        {
                            Console.Clear();
                            Console.WriteLine(" Pritisnite 1 za izpis, \n Pritisnite 2 za Vnos, \n Pritisnite 3 za brisanje, \n Pritisnite 4 za urejanje, " +
                              "\n Pritisnite 5 za poizvedbe, \n Pritisnite tipko V za izpis vizitke,  \n Pritisnite tipko  X za izhod in shranjevanje");
                            vnos = Console.ReadKey().KeyChar;
                        }
                        else if (vnos2 == 'n')
                        {
                            vnos = 'x';
                        }
                    }
                    else if (vnos == 'x' || vnos == 'X')
                    {
                        string[] novaVsebina2 = new string[tabZajcev.Length];
                        for (int i = 0; i < novaVsebina2.Length; i++)
                        {
                            novaVsebina2[i] = tabZajcev[i].ToString();
                        }

                        File.WriteAllLines("C:\\tmp\\Zajci.txt", novaVsebina2, Encoding.UTF8);
                        Console.ReadKey();

                        Console.WriteLine("\nZaključek in shranjevanje");
                        break;
                    }
                }

            }
            Console.ReadKey();
        }
    }
}