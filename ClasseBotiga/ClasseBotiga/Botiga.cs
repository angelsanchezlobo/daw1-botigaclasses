using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClasseBotiga
{
    public class Botiga
    {
        //Atributs
        private string nomBotiga;
        private Producte[] productes;
        private int nElem;

        //Constructors
        public Botiga()
        {
            Producte[] productes = new Producte[10];
            nElem = 0;
        }
        public Botiga(string nom, int nombreDeProductes)
        {
            this.nomBotiga = nom;
            object[] productes = new object[nombreDeProductes];
            nElem = 0;
        }
        public Botiga(string nom, Producte[] productesA)
        {
            this.nomBotiga = nom;
            Producte[] productes = new Producte[productesA.Length];
            for (int i = 0; i < productesA.Length; i++)
            {
                if (productesA[i] != null)
                {
                    productes[nElem] = productesA[i];
                    nElem++;
                }
            }
        }

        //Propietats
        public string NomBotiga
        {
            get { return nomBotiga; }
            set { nomBotiga = NomValid(value); }
        }
        public Producte Productes
        {
            get { return productes[nElem]; }
            set { productes[nElem] = value; nElem++; }
        }
        public int NElem
        {
            get { return nElem; }
            set { nElem = value; }
        }
        //Validar
        private string NomValid(string value)
        {
            bool comprovacio = false;
            do
            {
                bool sortir = false;
                int aux = 0;
                for (int i = 0; i < value.Length && !sortir; i++)
                {
                    if (!char.IsLetter(value[i]))
                    {
                        Console.WriteLine("Has d'indicar un nou nom vàlid, sense números i espais: ");
                        value = Convert.ToString(Console.ReadLine());
                        BorrarConsola();
                        sortir = true;
                        aux++;
                    }
                    else if (i == value.Length - 1 && aux == 0)
                        comprovacio = true;
                }
            } while (!comprovacio);
            return value;
        }

        //Mètodes
        static void BorrarConsola()
        {
            Console.Clear();
            return;
        }
        public int EspaiLliure() //Serveix per trobar l'espai lliure en cas de que en una posició del array sigui un valor "null".
        {
            int espai = -1;
            for (int i = 0; i < productes.Length; i++)
            {
                if (productes[i] == null)
                {
                    espai = i;
                }
            }
            return espai;
        }
        public int Indexador(string n) //Apartir d'un string trobem la posicio del producte amb aquest nom.
        {
            int posicio = -1;
            for (int i = 0; i < productes.Length; i++)
            {
                if (n == productes[i].Nom)
                    posicio = i;
            }
            return posicio;
        }
        public bool AfegirProducte(Producte producte)
        {
            bool validar = false, espai = false;
            int posicioVuida = 0;
            posicioVuida = EspaiLliure();
            if (posicioVuida >= 0)
            {
                productes[posicioVuida] = producte;
                validar = true;
                nElem++;
            }
            return validar;
        }
        //En cas de no cabre ens ha de preguntar si volem ampliar la tenda, fora del mètode... (Esto en el switch hacer un do while)
        public bool AfegirProductes(Producte[] producte)
        {
            bool validar = false;
            int posicioVuida = 0;
            do
            {
                posicioVuida = EspaiLliure();
                productes[posicioVuida] = producte[UltimaPos(producte) + 1];
                nElem++;
            } while (posicioVuida >= 0 && UltimaPos(producte) >= 0);
            return validar;
        }
        public int UltimaPos(Producte[] productes)
        {
            int ultimapos = -1;
            for (int i = 0; i < productes.Length; i++)
            {
                if (productes[i] == null)
                    ultimapos = i - 1;
            }
            return ultimapos;
        }
        public void AmpliarBotiga(int num) //Es crea un nou array amb la mida del array original + un número introduit, 
        {
            Producte[] aux = new Producte[productes.Length + num];
            for (int i = 0; i < productes.Length; i++)
            {
                aux[i] = productes[i];
            }
            productes = aux;
        }
        public bool ModificarPreu(string producte, double preu)
        {
            bool validar = false;
            int posicio = Indexador(producte);
            if (posicio >= 0)
            {
                productes[posicio].Preu_sense_iva = preu;
                validar = true;
            }
            return validar;
        }
        public bool BuscarProducte(Producte producte)
        {
            bool validar = false;
            if (Indexador(producte.Nom) >= 0)
                validar = true;
            return validar;
        }
        public bool ModificarProducte(Producte producte, string nouNom, double nouPreu, int novaQuantitat)
        {
            bool validar = false;
            int posicio = Indexador(producte.Nom);
            if (posicio >= 0)
            {
                productes[posicio].Nom = nouNom;
                productes[posicio].Preu_sense_iva = nouPreu;
                productes[posicio].Quantitat = novaQuantitat;
                validar = true;
            }
            return validar;
        }
        public void OrdenarProducte()
        {
            int n = productes.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (productes[j].Nom.CompareTo(productes[j + 1].Nom) > 0)
                    {
                        string temp = productes[j].Nom;
                        productes[j].Nom = productes[j + 1].Nom;
                        productes[j + 1].Nom = temp;
                    }
                }
            }
        }
        public void OrdenarPreus()
        {
            int n = productes.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (productes[j].Preu_sense_iva > productes[j + 1].Preu_sense_iva)
                    {
                        double temp = productes[j].Preu_sense_iva;
                        productes[j].Preu_sense_iva = productes[j + 1].Preu_sense_iva;
                        productes[j + 1].Preu_sense_iva = temp;
                    }
                }
            }
        }
        public void EsborrarProducte(Producte producte)
        {
            int posicio = Indexador(producte.Nom);
            if (posicio >= 0)
            {
                productes[posicio] = null;
            }
            OrdenarProducte();
        }
        public void Mostrar()
        {
            Console.WriteLine($"Productes de la botiga {nomBotiga}:");
            Console.WriteLine("--------------------------------------------------");

            for (int i = 0; i < productes.Length; i++)
            {
                if (productes[i] != null)
                {
                    Console.WriteLine($"Nom: {productes[i].Nom}");
                    Console.WriteLine($"Preu: {productes[i].Preu_sense_iva} €");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("--------------------------------------------------");
        }
        public override string ToString()
        {
            string res = $"Productes de la botiga {nomBotiga}:";
            res += "\n--------------------------------------------------";
            for (int i = 0; i < productes.Length; i++)
            {
                if (productes[i] != null)
                {
                    res += $"Nom: {productes[i].Nom}";
                    res += $"Preu: {productes[i].Preu_sense_iva} €";
                    res += $"Iva: {productes[i].Iva} €";
                    res += $"Total: {productes[i].Preu} €";
                    res += "";
                }
            }
            res += "--------------------------------------------------";
            return res;
        }

    }

}




