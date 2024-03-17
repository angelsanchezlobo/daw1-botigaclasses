using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace ClasseBotiga
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Botiga[] botiguesA = new Botiga[20]; //Array de botigues creades.
            Producte[] productesA = new Producte[20]; //Array de productes creats.
            Cistella[] cistellaProd = new Cistella[20]; //Array de productes de la cistella
            int nElemB = 0, nElemP = 0, nElemC = 0; //Nombre d'elements de cada array
            int opcio; //Opció introduida pel usuari per accedir a una part del menú
            do
            {
                Console.Clear();
                Console.WriteLine("1. Venedor ");
                Console.WriteLine("2. Comprador \n");
                Console.WriteLine("0. Sortir \n");
                Console.Write("Vols entrar com a: ");
                opcio = Convert.ToInt32(Console.ReadLine());
                while (opcio > 2 || opcio < 0)
                {
                    Console.WriteLine("INCORRECTE, posa de nou");
                    opcio = Convert.ToInt32(Console.ReadLine());
                }
                switch (opcio)
                {
                    case 1:
                        Console.Clear();
                        int opcio1;
                        Console.WriteLine("1. Botiga ");
                        Console.WriteLine("2. Producte\n");
                        Console.WriteLine("0. Sortir\n");
                        opcio1 = Convert.ToInt32(Console.ReadLine());
                        while (opcio1 > 2 || opcio1 < 0)
                        {
                            Console.WriteLine("INCORRECTE, posa de nou");
                            opcio1 = Convert.ToInt32(Console.ReadLine());
                        }
                        switch (opcio1)
                        {
                            case 1:
                                int opcio2;
                                do
                                {
                                    Console.Clear();
                                    Console.WriteLine("       BOTIGA      \n");
                                    Console.WriteLine("1. Crear Botiga ");
                                    Console.WriteLine("2. Afegir Producte ");
                                    Console.WriteLine("3. Ampliar Botiga");
                                    Console.WriteLine("4. Modificar Preu");
                                    Console.WriteLine("5. Modificar Producte");
                                    Console.WriteLine("6. Ordenar Productes");
                                    Console.WriteLine("7. Ordenar Preu");
                                    Console.WriteLine("8. Mostrar\n");
                                    Console.WriteLine("0. Sortir \n");
                                    Console.Write("Que vols fer: ");
                                    opcio2 = Convert.ToInt32(Console.ReadLine());
                                    while (opcio2 > 8 || opcio2 < 0)
                                    {
                                        Console.Write("INCORRECTE, posa de nou: ");
                                        opcio2 = Convert.ToInt32(Console.ReadLine());
                                    }
                                    switch (opcio2)
                                    {
                                        case 1: //Crear Botiga
                                            CrearBotiga(ref nElemB, botiguesA);
                                            Console.Write($"Botiga creada {botiguesA[nElemB - 1].NomBotiga}.");
                                            Thread.Sleep(2000);
                                            //Clear
                                            break;
                                        case 2: //Afegir Producte
                                            Console.Write("Indica la botiga per afegir el producte: ");
                                            string nomBotiga = Convert.ToString(Console.ReadLine());
                                            //Clear
                                            int i = TrobarBotiga(botiguesA, nElemB, nomBotiga);
                                            Console.Write("Quin es el producte a afegir? ");
                                            string nomProducte = Convert.ToString(Console.ReadLine());
                                            //Clear
                                            int k = TrobarProducte(productesA, nElemB, nomProducte);
                                            if (botiguesA[i].AfegirProducte(productesA[k]))
                                                botiguesA[i].Productes = productesA[k];
                                            else Console.WriteLine("No s'ha pogut afegir per falta d'espai.");
                                            //Volver uno para atras.
                                            break;
                                        case 3: //Ampliar Botiga
                                            Console.Write("Indica la botiga per afegir el producte: ");
                                            nomBotiga = Convert.ToString(Console.ReadLine());
                                            //Clear
                                            i = TrobarBotiga(botiguesA, nElemB, nomBotiga);
                                            Console.Write("Quants espais vols afegir?");
                                            int espai = Convert.ToInt32(Console.ReadLine());
                                            //Clear
                                            botiguesA[i].AmpliarBotiga(espai);
                                            Console.WriteLine($"Ara hi han {ContarArray(botiguesA[i])}");
                                            //Clear
                                            break;
                                        case 4:// Modificar Preu
                                            Console.WriteLine("Indica el nom de la botiga per a modificar el preu d'un producte: ");
                                            nomBotiga = Convert.ToString(Console.ReadLine());
                                            i = TrobarBotiga(botiguesA, nElemB, nomBotiga);
                                            Console.WriteLine("Quin producte vols modificar?");
                                            nomProducte = Convert.ToString(Console.ReadLine());
                                            Console.WriteLine("Quin es el preu que vols posar?");
                                            double preu = Convert.ToDouble(Console.ReadLine());
                                            if (botiguesA[i].ModificarPreu(nomProducte, preu))
                                                Console.WriteLine("Preu modificat.");
                                            else Console.WriteLine("No s'ha pogut modificar.");
                                            break;
                                        case 5: //Modificar Producte
                                            Console.WriteLine("Indica el nom de la botiga per a modificar el preu d'un producte: ");
                                            nomBotiga = Convert.ToString(Console.ReadLine());
                                            i = TrobarBotiga(botiguesA, nElemB, nomBotiga);
                                            Console.WriteLine("Quin producte vols modificar?");
                                            nomProducte = Convert.ToString(Console.ReadLine());
                                            Console.WriteLine("Quin es el preu que vols posar?");
                                            preu = Convert.ToDouble(Console.ReadLine());
                                            Console.WriteLine("Quin es el nom que vols posar?");
                                            nomProducte = Convert.ToString(Console.ReadLine());
                                            Console.WriteLine("Quina quantitat vols posar?");
                                            int quantitatNova = Convert.ToInt32(Console.ReadLine());
                                            if (botiguesA[i].ModificarProducte(botiguesA[i].Productes, nomProducte, preu, quantitatNova))
                                                Console.WriteLine("Producte modificat.");
                                            else Console.WriteLine("No s'ha pogut modificar.");
                                            break;
                                        case 6: //Ordenar Botiga String
                                            Console.WriteLine("Quina botiga vols ordenar");
                                            string nomB = Console.ReadLine();
                                            i = TrobarBotiga(botiguesA, nElemB, nomB);
                                            botiguesA[i].OrdenarProducte();
                                            break;
                                        case 7: //Ordenar Botiga Preu
                                            Console.WriteLine("Quina botiga vols ordenar");
                                            nomB = Console.ReadLine();
                                            i = TrobarBotiga(botiguesA, nElemB, nomB);
                                            botiguesA[i].OrdenarPreus();
                                            break;
                                        case 8: //Mostrar
                                            Console.WriteLine("Quina botiga vols mostrar");
                                            nomB = Console.ReadLine();
                                            i = TrobarBotiga(botiguesA, nElemB, nomB);
                                            botiguesA[i].Mostrar();
                                            break;
                                        case 0: // Sortir
                                            break;
                                    }
                                } while (opcio2 != 0);
                                break;
                            case 2:
                                int opcio3;
                                do
                                {
                                    Console.Clear();
                                    Console.WriteLine("       PRODUCTES      \n");
                                    Console.WriteLine("1. Crear Producte ");
                                    Console.WriteLine("2. Consultar Preu");
                                    Console.WriteLine("3. Mostrar\n");
                                    Console.WriteLine("0. Sortir \n");
                                    Console.Write("Que vols fer: ");
                                    opcio3 = Convert.ToInt32(Console.ReadLine());
                                    while (opcio3 > 4 || opcio3 < 0)
                                    {
                                        Console.Write("INCORRECTE, posa de nou: ");
                                        opcio3 = Convert.ToInt32(Console.ReadLine());
                                    }
                                    switch (opcio3)
                                    {
                                        case 1:
                                            Console.Clear();
                                            CrearProducte(ref nElemP, productesA);
                                            Console.WriteLine($"Nom producte: {productesA[nElemP - 1].Nom}");
                                            Thread.Sleep(2000);
                                            break;
                                        case 2:
                                            Console.Clear();
                                            Console.Write("Indica el producte: ");
                                            string nomP = Console.ReadLine();
                                            int i = TrobarProducte(productesA, nElemP, nomP);
                                            Console.WriteLine($"El preu es de {productesA[i].Preu()} Euros");
                                            Thread.Sleep(4000);
                                            break;
                                        case 3:
                                            Console.Clear();
                                            MostrarProductes(productesA, nElemP);
                                            Thread.Sleep(4000); break;
                                        case 0: // Sortir
                                            break;
                                    }
                                } while (opcio3 != 0);
                                break;
                        }
                        break;
                    case 2:
                        int opcio4;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("       CISTELLA      \n");
                            Console.WriteLine("1. Comprar Producte ");
                            Console.WriteLine("2. Cost Total ");
                            Console.WriteLine("3. Ordenar Cistella");
                            Console.WriteLine("4. Mostrar\n");
                            Console.WriteLine("0. Sortir \n");
                            Console.Write("Que vols fer: ");
                            opcio4 = Convert.ToInt32(Console.ReadLine());
                            while (opcio4 > 4 || opcio4 < 0)
                            {
                                Console.Write("INCORRECTE, posa de nou: ");
                                opcio4 = Convert.ToInt32(Console.ReadLine());
                            }
                            switch (opcio4)
                            {
                                case 1:
                                    Console.WriteLine("Quin producte vols afegir");
                                    string producte = Console.ReadLine();
                                    int posP = -1;
                                    for (int i = 0; i < productesA.Length || posP == -1; i++)
                                    {
                                        if (producte == productesA[i].Nom)
                                        {
                                            posP = i;
                                        }
                                    }
                                    cistellaProd[nElemC].ComprarProducte(productesA[posP]);
                                    break;
                                case 2:
                                    Console.WriteLine($"El cost total es de {cistellaProd[nElemC].CostTotal()}");
                                    break;
                                case 3:
                                    cistellaProd[nElemC].OrdenarCistella();
                                    break;
                                case 4:
                                    cistellaProd[nElemC].Mostrar();
                                    break;
                                case 0:
                                    // Sortir
                                    break;
                            }
                        } while (opcio4 != 0);
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("ADEU!");
                        break;
                }
            }
            while (opcio != 0);
        }
        /// <summary>
        /// Crea una nova botiga i l'afegeix a l'array de botigues.
        /// </summary>
        /// <param name="nElemB">Quantitat d'elements en l'array de botigues.</param>
        /// <param name="botigues">Array de botigues on s'afegirà la nova botiga.</param>
        static void CrearBotiga(ref int nElemB, Botiga[] botigues)
        {
            //Clear
            Console.Write("Indica un nom per la nova botiga: ");
            string nom = Convert.ToString(Console.ReadLine());
            //Clear
            Console.WriteLine("Indica el nombre de productes");
            int nomProductes = Convert.ToInt32(Console.ReadLine());
            Botiga botiga = new Botiga(nom, nomProductes);
            botigues[nElemB] = botiga;
            nElemB++;
        }
        /// <summary>
        /// Troba la posició d'una botiga amb un nom específic dins d'un array de botigues.
        /// </summary>
        /// <param name="botigues">Array de botigues on es buscarà la botiga.</param>
        /// <param name="nElemB">Quantitat d'elements en l'array de botigues.</param>
        /// <param name="nomB">Nom de la botiga a buscar.</param>
        /// <returns>
        /// La posició de la botiga amb el nom dins de l'array de botigues. Retorna -1 si no s'ha trobat.
        /// </returns>
        static int TrobarBotiga(Botiga[] botigues, int nElemB, string nomB)
        {
            bool trobat = false;
            int posicio = 0;
            for (int i = 0; i < nElemB && !trobat; i++)
            {
                if (nomB == botigues[i].NomBotiga)
                {
                    posicio = i;
                    trobat = true;
                }
            }
            return posicio;
        }
        /// <summary>
        /// Troba la posició d'un producte amb un nom específic dins d'un array de productes.
        /// </summary>
        /// <param name="productes">Array de productes on es buscarà el producte.</param>
        /// <param name="nElemP">Quantitat d'elements en l'array de productes.</param>
        /// <param name="nomP">Nom del producte a buscar.</param>
        /// <returns>
        static int TrobarProducte(Producte[] productes, int nElemP, string nomP)
        {
            bool trobat = false;
            int posicio = 0;
            for (int i = 0; i < nElemP && !trobat; i++)
            {
                if (nomP == productes[i].Nom)
                {
                    posicio = i;
                    trobat = true;
                }
            }
            return posicio;
        }
        /// <summary>
        /// Compta els elements en un array de productes d'una botiga.
        /// </summary>
        /// <param name="botiga">La botiga amb l'array de productes a contar.</param>
        /// <returns>
        /// El nombre d'elements en l'array de productes de la botiga.
        /// </returns>
        static int ContarArray(Botiga botiga)
        {
            int total = 0;
            for (int i = 0; i < botiga.NElem; i++)
            {
                total = i;
            }
            return total;
        }
        /// <summary>
        /// Crea un nou producte i l'afegeix a l'array de productes.
        /// </summary>
        /// <param name="nElemP">Nombre d'elements en l'array de productes.</param>
        /// <param name="productes">Array de productes on s'afegirà el nou producte.</param>
        static void CrearProducte(ref int nElemP, Producte[] productes)
        {
            Console.Write("Indica un nom per el nou producte: ");
            string nom = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Indica el preu unitari");
            int preuUnitari = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Indica el iva");
            int iva = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Indica la quantitat");
            int quantitat = Convert.ToInt32(Console.ReadLine());
            Producte producte = new Producte(nom, preuUnitari, iva, quantitat);
            productes[nElemP] = producte;
            nElemP++;
        }
        /// <summary>
        /// Mostra els productes i les seves quantitats disponibles.
        /// </summary>
        /// <param name="productes">L'array de productes a mostrar.</param>
        /// <param name="nElemP">Elements en l'array de productes.</param>
        static void MostrarProductes(Producte[] productes, int nElemP)
        {
            for (int i = 0; i < nElemP; i++)
            {
                if (productes[i].Nom != null)
                {
                    Console.WriteLine($"Producte: {productes[i].Nom} Stock: {productes[i].Quantitat}");
                }
            }
        }
    }
}