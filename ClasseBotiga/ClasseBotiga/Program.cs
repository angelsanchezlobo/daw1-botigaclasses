namespace ClasseBotiga
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcio;
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
                                        case 1:
                                            // Crear botiga
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
                                            // Ordenar Productes
                                            break;
                                        case 7:
                                            // Ordenar Preu
                                            break;
                                        case 8:
                                            // Mostrar
                                            break;
                                        case 0:
                                            // Sortir
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
                                    Console.WriteLine("2. Modificar Producte ");
                                    Console.WriteLine("3. Consultar Preu");
                                    Console.WriteLine("4. Mostrar\n");
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
                                            // Crear Producte
                                            break;
                                        case 2:
                                            // Modificar Producte
                                            break;
                                        case 3:
                                            // Consultar Preu
                                            break;
                                        case 4:
                                            // Mostrar
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
    }
}
