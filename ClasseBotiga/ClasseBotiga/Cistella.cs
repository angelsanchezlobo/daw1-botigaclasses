using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseBotiga
{
    internal class Cistella
    {
        // Atributs
        private Botiga botiga;
        private DateTime data;
        private Producte[] productes;
        private int nElements;
        private double diners;

        // Constructors
        public Cistella()
        {
            botiga = null;
            data = "";
            productes = 10;
            nElements = 0;
            diners = 0;
        }
        public Cistella(Producte productes, int quantitat)
        {
            if(diners - CostTotal() < 0)
            {
                Console.WriteLine("No hi han prous diners");
            }
            else if (nElements > productes.Length)
            {
                string resposta;
                Console.WriteLine("No hi ha espai, vols afegir?");
                resposta = Console.ReadLine();
                if (resposta == "si" || resposta == "Si")
                {
                    productes aux = new productes[productes.GetLength + 1];
                    for (int i = 0; i < productes.GetLength(); i++)
                        aux[i] = productes[i];
                    productes = aux;
                }
            }
            else
            {
                this.botiga = botiga;
                this.productes[nElements] = productes;
                nElements = this.productes.Length;
            }


        }

        // Propietats
        public Producte Productes
        {
            get { return Productes; }
            set
            {
                if(diners - CostTotal()< 0) 
                {
                    Console.WriteLine("No hi han prous diners");
                }
                else if(nElements > productes.Length)
                {
                    string resposta;
                    Console.WriteLine("No hi ha espai, vols afegir?");
                    resposta = Console.ReadLine();
                    if (resposta == "si" || resposta == "Si")
                    {
                        productes aux = new productes[productes.GetLength + 1];
                        for (int i = 0; i < productes.GetLength(); i++)
                            aux[i] = productes[i];
                        productes = aux;
                    }
                }
                else
                {
                    productes[nElements].Preu_sense_iva = value;
                    productes[nElements].Iva = value;
                    productes[nElements].Quantitat = value;
                }
            }
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

        // Metodos
        /// <summary>
        /// Afegeix al array de productes un producte en base al objecte producte que se l'hi passa
        /// </summary>
        /// <param name="producte"> És el objecte producte que s'ha de afegir al array de productes de la cistella</param>
        public void ComprarProducte(Producte producte)
        {
            bool existeix = false;
             
            if (nElements > productes.Length)
            {
                string resposta;
                Console.WriteLine("No hi ha espai, vols afegir?");
                resposta = Console.ReadLine();
                if (resposta == "si" || resposta == "Si")
                {
                    productes aux = new productes[productes.GetLength + 1];
                    for (int i = 0; i < productes.GetLength(); i++)
                        aux[i] = productes[i];
                    productes = aux;
                }
                Producte.data = DateTime.now();
            }
           else if(diners - CostTotal() > 0)
            {
                Console.WriteLine("No hi han prous diners, vols afegir?");
                string resposta = Console.ReadLine();
                if (resposta == "si" || resposta == "Si")
                {
                    Console.WriteLine("Cuants vols afegir?");
                    double afegir = Convert.ToDouble(Conosle.ReadLine());
                    Producte.Diners(afegir);
                }
            }
            else
            {
                productes[nElements].nom = producte.Nom;
                productes[nElements].preu_sense_iva = producte.Preu_sense_iva;
                productes[nElements].iva = producte.Iva;
                productes[nElements].quantitat = producte.Quantitat;
                nElements++;
            }
        }
        /// <summary>
        /// Ordena el array de productes per nom amb bubble sort
        /// </summary>
        public void OrdenarCistella()
        {
            int n = productes.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (productes[j].nom > productes[j + 1].nom)
                    {
                        int temp = productes[j].nom;
                        productes[j].nom = productes[j + 1].nom;
                        productes[j + 1].nom = temp;
                    }
                }
            }
        }
        /// <summary>
        /// Imprimeix el array de productes de manera amigable, mostrant preu unitari, amb impost...
        /// </summary>
        public void Mostrar()
        {
            for(int i = 0;i < NElements;i++)
            {
                if (productes[i].Nom != null)
                {
                    Console.Write($"Producte: {productes[i].nom}    ");
                    Console.Write($"Sense IVA: {productes[i].preu_sense_iva}    ");
                    Console.Write($"IVA: {productes[i].iva}    ");
                    Console.Write($"Preu unitari: {productes[i].preu_sense_iva + productes[i].iva}    ");
                    Console.Write($"Quantitat: {productes[i].quantitat}     ");
                    Console.Write($"Total: {productes[i].quantitat * (productes[i].preu_sense_iva + productes[i].iva)}     ");
                }
            }
            Console.Write($"TOTAL: {CostTotal()}");
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
                double ivaCalculat = productes[i].Preu_sense_iva / productes[i].Iva;
                total = (productes[i].Preu_sense_iva + ivaCalculat) * productes[i].Quantitat;
            }
            return total;
        }
        /// <summary>
        /// Mostra el nom del producte y el total de tot amb IVA inclós
        /// </summary>
        public void ToString()
        {
            for (int i = 0; i < NElements; i++)
            {
                if (productes[i].Nom != null)
                {
                    Console.Write($"Producte: {productes[i].nom}    ");
                }
            }
            Console.Write($"TOTAL: {CostTotal()}");
        }
    }
}
