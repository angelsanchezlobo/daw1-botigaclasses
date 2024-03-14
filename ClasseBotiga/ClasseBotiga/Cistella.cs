using System;

namespace ClasseBotiga
{
    internal class Cistella
    {
        // Atributos
        private Botiga botiga;
        private DateTime data;
        private Producte[] productes;
        private int nElements;
        private double diners;

        // Constructores
        public Cistella()
        {
            botiga = null;
            data = DateTime.Now;
            productes = new Producte[10];
            nElements = 0;
            diners = 0;
        }

        public Cistella(Producte[] productes, int quantitat)
        {
            if (diners - CostTotal() < 0)
            {
                Console.WriteLine("No hi ha prous diners");
            }
            else if (nElements >= productes.Length)
            {
                Console.WriteLine("No hi ha espai, vols afegir?");
                string resposta = Console.ReadLine();
                if (resposta == "si" || resposta == "Si")
                {
                    Producte[] aux = new Producte[productes.Length + 1];
                    for (int i = 0; i < productes.Length; i++)
                        aux[i] = productes[i];
                    productes = aux;
                }
            }
            else
            {
                this.productes[nElements] = productes[nElements];
                nElements = this.productes.Length;
            }
        }

        // Propiedades
        public Producte[] Productes
        {
            get { return productes; }
            set { productes = value; }
        }

        public int NElements
        {
            get { return nElements; }
        }

        public double Diners
        {
            get { return diners; }
            set { diners += value; }
        }

        public DateTime Data
        {
            get { return data; }
        }

        // Métodos
        /// <summary>
        /// Afegeix al array de productes un producte en base al objecte producte que se l'hi passa
        /// </summary>
        /// <param name="producte"> És el objecte producte que s'ha de afegir al array de productes de la cistella</param>
        public void ComprarProducte(Producte producte)
        {
            if (nElements >= productes.Length)
            {
                string resposta;
                Console.WriteLine("No hi ha espai, vols afegir?");
                resposta = Console.ReadLine();
                if (resposta == "si" || resposta == "Si")
                {
                    Producte[] aux = new Producte[productes.Length + 1];
                    for (int i = 0; i < productes.Length; i++)
                        aux[i] = productes[i];
                    productes = aux;
                }
            }
            else if (diners - CostTotal() > 0)
            {
                Console.WriteLine("No hi ha prous diners, vols afegir?");
                string resposta = Console.ReadLine();
                if (resposta == "si" || resposta == "Si")
                {
                    Console.WriteLine("Quants vols afegir?");
                    double afegir = Convert.ToDouble(Console.ReadLine());
                    Diners = afegir;
                }
            }
            else
            {
                productes[nElements].Nom = producte.Nom;
                productes[nElements].Preu_sense_iva = producte.Preu_sense_iva;
                productes[nElements].Iva = producte.Iva;
                productes[nElements].Quantitat = producte.Quantitat;
                nElements++;
            }
        }
        /// <summary>
        /// Ordena el array de productes per nom amb bubble sort
        /// </summary>
        public void OrdenarCistella()
        {
            for (int i = 0; i < nElements - 1; i++)
            {
                for (int j = 0; j < nElements - i - 1; j++)
                {
                    if (productes[j].Nom.CompareTo(productes[j + 1].Nom) > 0)
                    {
                        Producte temp = productes[j];
                        productes[j] = productes[j + 1];
                        productes[j + 1] = temp;
                    }
                }
            }
        }
        /// <summary>
        /// Imprimeix el array de productes de manera amigable, mostrant preu unitari, amb impost...
        /// </summary>
        public void Mostrar()
        {
            for (int i = 0; i < NElements; i++)
            {
                Console.WriteLine($"Producte: {productes[i].Nom}");
                Console.WriteLine($"Sense IVA: {productes[i].Preu_sense_iva}");
                Console.WriteLine($"IVA: {productes[i].Iva}");
                Console.WriteLine($"Preu unitari: {productes[i].Preu_sense_iva + productes[i].Iva}");
                Console.WriteLine($"Quantitat: {productes[i].Quantitat}");
                Console.WriteLine($"Total: {productes[i].Quantitat * (productes[i].Preu_sense_iva + productes[i].Iva)}");
            }
            Console.WriteLine($"TOTAL: {CostTotal()}");
        }
        /// <summary>
        /// Calcula el preu de tot el que hi ha a la cistella amb iva inclós
        /// </summary>
        /// <returns> Total es el total de diners que costa la cistella </returns>
        public double CostTotal()
        {
            double total = 0;
            for (int i = 0; i < nElements; i++)
            {
                double ivaCalculat = productes[i].Preu_sense_iva * productes[i].Iva;
                total += (productes[i].Preu_sense_iva + ivaCalculat) * productes[i].Quantitat;
            }
            return total;
        }
        /// <summary>
        /// Retorna el nom del producte y el total de tot amb IVA inclós
        /// </summary>
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < NElements; i++)
            {
                result += $"Producte: {productes[i].Nom}\n";
            }
            result += $"Total: {CostTotal()}";
            return result;
        }
    }
}