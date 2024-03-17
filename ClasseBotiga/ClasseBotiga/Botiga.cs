
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
        private Producte[] productes; //Array de productes de la botiga
        private int nElem; //Número d'elements de l'array de productes.

        //Constructors

        /// <summary> 
        /// Constructor vuit que initcialitza la taula de productes amb el nombre d'elements a 0 
        /// </summary>
        public Botiga()
        {
            Producte[] productes = new Producte[10];
            nElem = 0;
        }
        /// <summary>
        /// Constructor de la classe Botiga que inicialitza una nova botiga amb un nom i un nombre de productes.
        /// </summary>
        /// <param name="nom">El nom de la botiga.</param>
        /// <param name="nombreDeProductes">El nombre de productes que es pot gestionar a la botiga.</param>
        public Botiga(string nom, int nombreDeProductes)
        {
            this.nomBotiga = nom;
            object[] productes = new object[nombreDeProductes];
            nElem = 0;
        }
        /// <summary>
        /// Constructor de la classe Botiga que inicialitza una nova botiga amb un nom i una llista de productes.
        /// </summary>
        /// <param name="nom">El nom de la botiga.</param>
        /// <param name="productesA">L'array de productes que es vol afegir a la botiga.</param>
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

        /// <summary> 
        /// Verifica un string que pasa l'usuari fent una comprovació, fins que el nom sigui correcte.        
        /// </summary>
        /// <param name="value">Nom que pasa l'usuari.</param>
        /// <returns>S'acaba retornant un nom correcte al final.</returns>
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

        /// <summary> 
        /// Esborra la consola.        
        /// </summary>
        static void BorrarConsola()
        {
            Console.Clear();
            return;
        }
        /// <summary> 
        /// Serveix per trobar l'espai lliure en cas de que en una posició del array sigui un valor "null".    
        /// </summary>
        /// <returns>Retorna una posició en forma de INT. </returns>
        public int EspaiLliure()
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
        /// <summary>
        /// Mètode per trobar la posició d'un producte a partir del seu nom.
        /// </summary>
        /// <param name="n">El nom del producte a cercar.</param>
        /// <returns>
        /// La posició del producte a l'array si s'ha trobat; en cas contrari, 
        /// es retorna -1 indicant que el producte no s'ha trobat.
        /// </returns>
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
        /// <summary>
        /// Afegeix un nou producte a l'array de productes de la botiga.
        /// </summary>
        /// <param name="producte">El producte a afegir.</param>
        /// <returns>
        /// True si s'ha pogut afegir el producte amb èxit, False si no s'ha pogut afegir
        /// perquè no hi ha més espai.
        /// </returns>
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

        /// <summary>
        /// Afegeix una llista de productes a l'array de productes de la botiga si hi ha espai disponible.
        /// </summary>
        /// <param name="producte">La llista de productes a afegir.</param>
        /// <returns>
        /// True si s'han afegit els productes amb èxit, False si no s'han pogut afegir perquè no hi ha més espai.
        /// </returns>
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
        /// <summary>
        /// Troba la última posició ocupada en un array de productes.
        /// </summary>
        /// <param name="productes">L'array de productes.</param>
        /// <returns>
        /// La última posició ocupada en l'array de productes. Si tots els elements són nulls, retorna -1.
        /// </returns>
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
        /// <summary>
        /// Amplia la grandària de l'array de productes de la botiga amb un nombre addicional d'elements.
        /// </summary>
        /// <param name="num">El nombre addicional d'elements a afegir.</param>
        public void AmpliarBotiga(int num) //Es crea un nou array amb la mida del array original + un número introduit, 
        {
            Producte[] aux = new Producte[productes.Length + num];
            for (int i = 0; i < productes.Length; i++)
            {
                aux[i] = productes[i];
            }
            productes = aux;
        }
        /// <summary>
        /// Modifica el preu d'un producte de la botiga.
        /// </summary>
        /// <param name="producte">El nom del producte a modificar el preu.</param>
        /// <param name="preu">El nou preu a assignar al producte.</param>
        /// <returns>
        /// True si s'ha modificat el preu del producte amb èxit, False si el producte no existeix a la botiga.
        /// </returns>
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
        /// <summary>
        /// Busca un producte a l'array de productes de la botiga.
        /// </summary>
        /// <param name="producte">El producte a buscar.</param>
        /// <returns>
        /// True si el producte s'ha trobat a l'array, False si no s'ha trobat.
        /// </returns>
        public bool BuscarProducte(Producte producte)
        {
            bool validar = false;
            if (Indexador(producte.Nom) >= 0)
                validar = true;
            return validar;
        }
        /// <summary>
        /// Modifica les propietats d'un producte a l'array de productes de la botiga.
        /// </summary>
        /// <param name="producte">El producte a modificar.</param>
        /// <param name="nouNom">El nou nom per al producte.</param>
        /// <param name="nouPreu">El nou preu per al producte.</param>
        /// <param name="novaQuantitat">La nova quantitat per al producte.</param>
        /// <returns>
        /// True si el producte s'ha modificat amb èxit, False si el producte no s'ha trobat a l'array.
        /// </returns>
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
        /// <summary>
        /// Ordena els productes de la botiga en ordre alfabètic pel nom.
        /// </summary>
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
        /// <summary>
        /// Ordena els productes de la botiga en ordre creixent pel preu sense IVA.
        /// </summary>
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
        /// <summary>
        /// Esborra un producte de l'array de productes de la botiga.
        /// </summary>
        /// <param name="producte">El producte a esborrar.</param>
        public void EsborrarProducte(Producte producte)
        {
            int posicio = Indexador(producte.Nom);
            if (posicio >= 0)
            {
                productes[posicio] = null;
            }
            OrdenarProducte();
        }
        /// <summary>
        /// Mostra per la consola els productes de la botiga amb els seus noms i preus.
        /// </summary>
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
        /// <summary>
        /// Retorna una representació en cadena dels productes de la botiga, incloent els seus noms, preus sense IVA, IVA i preus totals.
        /// </summary>
        /// <returns>
        /// Una cadena que representa els productes de la botiga amb els seus detalls.
        /// </returns>
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
