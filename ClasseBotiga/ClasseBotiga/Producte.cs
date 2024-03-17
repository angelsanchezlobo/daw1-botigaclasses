using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseBotiga
{
    public class Producte
    {
        //Atributs
        private string nom; //Nom del producte
        private double preu_sense_iva; //Preu sense l'IVA sumat
        private double iva; //L'IVA que te el rpoducte
        private int quantitat; //La quantitat de producte que hi ha

        //Constructors
        /// <summary>
        /// Constructor de la classe Producte que inicialitza un nou Producte amb valors per defecte.
        /// </summary>
        public Producte()
        {
            iva = 0.21;
            quantitat = 0;
        }
        /// <summary>
        /// Constructor de la classe Producte que inicialitza un nou Producte amb un nom i un preu inicial.
        /// </summary>
        /// <param name="n">El nom del producte.</param>
        /// <param name="preuini">El preu sense IVA del producte.</param>
        public Producte(string n, double preuini)
        {
            this.nom = n;
            this.preu_sense_iva = preuini;
        }
        /// <summary>
        /// Constructor de la classe Producte que inicialitza un nou producte amb un nom, un preu inicial, un valor d'IVA i una quantitat.
        /// </summary>
        /// <param name="n">El nom del producte.</param>
        /// <param name="preuini">El preu sense IVA del producte.</param>
        /// <param name="iva">El valor de l'IVA aplicable al producte.</param>
        /// <param name="q">La quantitat disponible del producte.</param>
        public Producte(string n, double preuini, double iva, int q) : this(n, preuini)
        {
            this.iva = iva;
            this.quantitat = q;
        }
        /// <summary>
        /// Constructor de la classe Producte que inicialitza un nou producte amb les mateixes propietats d'un altre producte d'una botiga i una quantitat.
        /// </summary>
        /// <param name="Botiga">El producte d'una botiga del qual es copiaran les propietats.</param>
        /// <param name="quantitat">La quantitat del nou producte.</param>
        public Producte(Producte Botiga, int quantitat)
        {
            nom = Botiga.nom;
            preu_sense_iva = Botiga.preu_sense_iva;
            iva = Botiga.iva;
            this.quantitat = quantitat;
        }

        //Propietats
        public string Nom
        {
            get { return nom; }
            set { nom = NomValid(value); }
        }
        public double Preu_sense_iva
        {
            get { return preu_sense_iva; }
            set { preu_sense_iva = PreuValid(value); }
        }
        public double Iva
        {
            get { return iva; }
            set { iva = IvaValid(value); }
        }
        public int Quantitat
        {
            get { return quantitat; }
            set { quantitat = QuantitatValid(value); }
        }

        //Validacions

        /// <summary>
        /// Verifica si un nom és vàlid, sense números ni espais, i retorna el nom vàlid.
        /// </summary>
        /// <param name="value">El nom a comprovar.</param>
        /// <returns>
        /// El nom vàlid sense números ni espais.
        /// </returns>
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
        /// <summary>
        /// Verifica si un preu és vàlid (és un valor numèric positiu) i retorna el preu vàlid.
        /// </summary>
        /// <param name="value">El preu a comprovar.</param>
        /// <returns>
        /// El preu vàlid, que és un valor numèric positiu.
        /// </returns>
        private double PreuValid(double value)
        {
            bool comprovacio = false;
            double numero;
            string valor = value.ToString();
            do
            {
                bool sortir = false;
                int aux = 0;
                if (!double.TryParse(valor, out numero))
                {
                    if (numero < 0)
                    {
                        Console.WriteLine("Has d'indicar un numero de preu vàlid, sense lletres o caracters especials: ");
                        value = Convert.ToDouble(Console.ReadLine());
                        BorrarConsola();
                        sortir = true;
                        aux++;
                    }
                }
                else if (aux == 0)
                    comprovacio = true;

            } while (!comprovacio);
            return value;
        }
        /// <summary>
        /// Verifica si un valor d'IVA és vàlid (entre 0 i 21%) i retorna el valor vàlid com un decimal entre 0 i 0.21.
        /// </summary>
        /// <param name="value">El valor d'IVA a comprovar.</param>
        /// <returns>
        /// El valor d'IVA vàlid, representat com un decimal entre 0 i 0.21.
        /// </returns>
        private double IvaValid(double value)
        {
            bool comprovacio = false;
            double numero;
            string valor = value.ToString();
            do
            {
                bool sortir = false;
                int aux = 0;
                if (!double.TryParse(valor, out numero))
                {
                    if (numero < 0 || numero > 21)
                    {
                        Console.WriteLine("Has d'indicar un IVA vàlid, entre el 0 - 21% i sense caràcters especials: ");
                        value = Convert.ToDouble(Console.ReadLine());
                        BorrarConsola();
                        sortir = true;
                        aux++;
                    }
                }
                else if (aux == 0)
                    comprovacio = true;

            } while (!comprovacio);
            value = value / 100;
            return value;
        }
        /// <summary>
        /// Verifica si una quantitat és vàlida (és un enter positiu) i retorna la quantitat vàlida.
        /// </summary>
        /// <param name="value">La quantitat a comprovar.</param>
        /// <returns>
        /// La quantitat vàlida, que és un enter positiu.
        /// </returns>
        private int QuantitatValid(int value)
        {
            bool comprovacio = false;
            int numero;
            string valor = value.ToString();
            do
            {
                bool sortir = false;
                int aux = 0;
                if (!int.TryParse(valor, out numero))
                {
                    if (numero <= 0)
                    {
                        Console.WriteLine("Has d'indicar una quantitat vàlida, no pot ser 0: ");
                        value = Convert.ToInt32(Console.ReadLine());
                        BorrarConsola();
                        sortir = true;
                        aux++;
                    }
                }
                else if (aux == 0)
                    comprovacio = true;

            } while (!comprovacio);
            return value;
        }

        //Metodes Públics 

        /// <summary>
        /// Calcula el preu total del producte, tenint en compte l'IVA.
        /// </summary>
        /// <returns>
        /// El preu total del producte, incloent l'IVA.
        /// </returns>
        public double Preu()
        {
            double ivaCalculat = preu_sense_iva / iva;
            return preu_sense_iva + ivaCalculat;
        }
        /// <summary>
        /// Retorna una representació en cadena del producte, incloent el nom, el preu i la quantitat.
        /// </summary>
        /// <returns>
        /// Una cadena que representa el producte amb el seu nom, preu i quantitat.
        /// </returns>
        public override string ToString()
        {
            return $"Nom del producte: {nom} \n" +
                   $"Preu del producte: {Preu()} \n" +
                   $"Quantitat: {quantitat}";
        }
        /// <summary>
        /// Esborra el contingut de la consola.
        /// </summary>
        static void BorrarConsola()
        {
            Console.Clear();
            return;
        }
    }
}
