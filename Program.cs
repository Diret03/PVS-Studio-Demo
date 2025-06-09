// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Specialized;

namespace PVS_Studio_Demo
{
    internal class Program
    {
        private static int counter; 
        private static List<string> data;
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {

            // se realiza el mismo codigo en ambas condiciones
            if (counter == 0)
                counter = 1;
            else
                counter = 1;

            // punto y coma al final de la sentencia for
            for (int i = 0; i < 10; i++) ;
            {
                if (data == null)
                    data = new List<string>();
                data.Add("Item " + i);
            }

            // desbordamiento de entero
            int maxInt = int.MaxValue;
            int overflowResult = maxInt + 1; 
            Console.WriteLine($"Resultado: {overflowResult}");




            int a = 5;
            int b = 10;
            // la condicion siempre es verdadera
            if (a > 3)
                b = b + a;

            //string upperWord = converToUppercase("codigo");
          

        }


        public static string converToUppercase(string word) 
        {
            if (word.Length <= 0)
            {
                // falta throw para lanzar una excepción
                new ArgumentOutOfRangeException();

            }
            else {
                
                return word.ToUpper();
            }

        }

     
    }
}
