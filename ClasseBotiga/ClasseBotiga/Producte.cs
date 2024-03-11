using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasseBotiga
{
    internal class Producte
    {
        //Atributs
        private string nom;
        private double preu_sense_iva;
        private double iva;
        private int quantitat;

        //Constructors
        public Producte()
        {
            iva = 0.21;
            quantitat = 0;
        }
        public Producte(string n, double preuini)
        {
            this.nom = n;
            this.preu_sense_iva = preuini;
        }
        public Producte(string n, double preuini, double iva, int q) : this(n, preuini)
        {
            this.iva = iva;
            this.quantitat = q;
        }

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
        public double Preu()
        {
            double ivaCalculat = preu_sense_iva / iva;
            return preu_sense_iva + ivaCalculat;
        }
        public string ToString()
        {
            return $"Nom del producte: {nom} \n" +
                   $"Preu del producte: {Preu()} \n" +
                   $"Quantitat: {quantitat}";
        }
    }
}
