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
            data = DateTime.Today;
            Producte[] productes = new Producte[10];
            nElements = 0;
            diners = 0;
        }
        public Cistella(Producte productes, int quantitat)
        {
            this.botiga = botiga;
            this.productes[nElements] = productes;
            nElements = this.productes.Length;

            // Caluclar si hi han diners suficients

        }

        // Propietats

        // Inserir productes
        public Producte Productes
        {
            get { return Productes; }
            set {  }
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
    }
}
