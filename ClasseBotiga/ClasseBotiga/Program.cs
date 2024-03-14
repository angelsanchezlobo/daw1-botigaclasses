namespace ClasseBotiga
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Botiga[] botigues = new Botiga[20];
            int nElemB = 0;
            Producte[] productes = new Producte[20];
            int nElemP = 0;
            Cistella[] cistellaProd = new Cistella[20];
            int nElemC = 0;
            int opcio = 0;
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
                    int opcio1 = 0;
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
                                int opcio2 = 0;
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
                                        case 1:
                                            Console.Clear();
                                            CrearBotiga(ref nElemB, botigues);
                                            break;
                                        case 2:
                                            // Afegir Producte
                                            break;
                                        case 3:
                                            // Ampliar Botiga
                                            break;
                                        case 4:
                                            // Modificar Preu
                                            break;
                                        case 5:
                                            // Modificar Producte
                                            break;
                                        case 6:
                                            Console.WriteLine("Quina botiga vols ordenar");
                                            string nomB = Console.ReadLine();
                                            int pos = TrobarBotiga(botigues, nElemB, nomB);
                                            botigues[pos].OrdenarProducte();
                                            break;
                                        case 7:
                                            Console.WriteLine("Quina botiga vols ordenar");
                                            nomB = Console.ReadLine();
                                            pos = TrobarBotiga(botigues, nElemB, nomB);
                                            botigues[pos].OrdenarPreus();
                                            break;
                                        case 8:
                                            Console.WriteLine("Quina botiga vols mostrar");
                                            nomB = Console.ReadLine();
                                            pos = TrobarBotiga(botigues, nElemB, nomB);
                                            botigues[pos].Mostrar();
                                            break;
                                        case 0:
                                            // Sortir
                                            break;
                                    }
                                } while (opcio2 != 0);
                                break;
                            case 2:
                                int opcio3 = 0;
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
                                    while (opcio3 > 3 || opcio3 < 0)
                                    {
                                        Console.Write("INCORRECTE, posa de nou: ");
                                        opcio3 = Convert.ToInt32(Console.ReadLine());
                                    }
                                    switch (opcio3)
                                    {
                                        case 1:
                                            Console.Clear();
                                            CrearProducte(ref nElemP, productes);
                                            Console.WriteLine($"Nom producte: {productes[nElemP - 1].Nom}");
                                            Thread.Sleep(2000);
                                            break;
                                        case 2:
                                            // Consultar Preus
                                            Console.Clear();
                                            Console.Write("Indica el producte: ");
                                            string nomP = Console.ReadLine();
                                            int pos = TrobarProducte(productes, nElemP, nomP);
                                            Console.WriteLine($"El preu es de {productes[pos].Preu()} Euros");
                                            Thread.Sleep(4000);
                                            break;
                                        case 3:
                                            Console.Clear();
                                            MostrarProductes(productes, nElemP);
                                            Thread.Sleep(4000);
                                            break;
                                        case 0:
                                            // Sortir
                                            break;
                                    }
                                }while (opcio3 != 0);
                                break;
                        }
                        
                    break;
                case 2:
                        int opcio4 = 0;
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
                                    // Comprar Producte
                                    break;
                                case 2:
                                    // Cost Total
                                    break;
                                case 3:
                                    // Ordenar Cistella
                                    break;
                                case 4:
                                    // Mostrar
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
            while(opcio != 0);  
        }
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
        static int TrobarProducte(Producte[] productes, int nElemP, string nomP)
        {
            bool trobat = false;
            int posicio = 0;
            for (int i = 0; i <= nElemP && !trobat; i++)
            {
                if (nomP == productes[i].Nom)
                {
                    posicio = i;
                    trobat = true;
                }
            }
            return posicio;
        }
        static int TrobarBotiga(Botiga[] botigues, int nElemB, string nomB)
        {
            bool trobat = false;
            int posicio = 0;
            for (int i = 0; i <= nElemB && !trobat; i++)
            {
                if (nomB == botigues[i].NomBotiga)
                {
                    posicio = i;
                    trobat = true;
                }
            }
            return posicio;
        }
        static void MostrarProductes(Producte[] productes, int nElemP)
        {
            for(int i = 0;i < nElemP; i++)
            {
                if (productes[i].Nom != null)
                {
                    Console.WriteLine($"Producte: {productes[i].Nom} Stock: {productes[i].Quantitat}");
                }
            }
        }
    }
}
