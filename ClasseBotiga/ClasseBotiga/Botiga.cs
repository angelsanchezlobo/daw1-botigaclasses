﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            object[] productes = new object[10];
            nElem = 0;
        }
        public Botiga(string nom, int nombreDeProductes)
        {
            this.nomBotiga = nom;
            object[] productes = new object[nombreDeProductes];
            nElem = 0;
        }
        public Botiga(string nom, object[] productesA) 
        {
            this.nomBotiga = nom;
            object[] productes = new object[productesA.Length];
            for(int i = 0; i < productesA.Length; i++)
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
        public int EspaiLliure()
        {
            int espai = 0;
            for(int i = 0; i < productes.Length; i++)
            {
                if (productes[i] == null)
                {
                    espai = i;
                }
            }
            return espai;
        }
        public int Indexador(string n)
        {
            int posicio = 0;
            for(int i = 0; i < productes.Length;i++)
            {
                if (n == productes[i].Nom)
                    posicio = i;
            }
            return posicio;
        }
    }
}