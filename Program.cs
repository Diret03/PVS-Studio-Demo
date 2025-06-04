// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PVS_Studio_Demo
{
    internal class Program
    {
        private static int counter; // Variable de clase no inicializada
        private static List<string> data;
        private static readonly Random random = new Random();
        
        static void Main(string[] args)
        {
            // referencia nula
            data = null;
            Console.WriteLine($"Data count: {data.Count}"); 
            
            // Código inalcanzable después del retorno
            if (args.Length > 0)
                return;
            Console.WriteLine("This will never be reached if args exist");
            
            // Uso de variable no inicializada
            int value;
            if (random.Next(0, 10) > 5)
                value = 10;
            Console.WriteLine($"Value is: {value}"); // value podría no estar inicializada
            
            // Potencial desbordamiento de entero
            int maxInt = int.MaxValue;
            int overflowResult = maxInt + 1; // Desbordamiento
            Console.WriteLine($"Result: {overflowResult}");
            
           
            int a = 5;
            int b = 10;
            if (a > 3)
                b = b + a;
            if (a > 4)
                b = b + a; 
                
            // Condición redundante
            if (a == 5 && a > 0 && a == 5)
            {
                Console.WriteLine("Redundant condition");
            }
            
            MethodWithUnusedParameter(42, "Unused");
            
            // Llamar a otro código problemático
            var math = new MathOperations();
            math.PerformOperations();
            
            var resources = new ResourceManager();
            resources.UseResources();
            
            var threading = new ThreadingIssues();
            threading.DemonstrateIssues();
            
            var stringOps = new StringManipulation();
            stringOps.ManipulateStrings();
            
            Console.ReadKey();
        }
        
        // Método con parámetro no utilizado
        static void MethodWithUnusedParameter(int used, string unused)
        {
            Console.WriteLine($"Used parameter: {used}");
            // 'unused' nunca se utiliza
        }
    }
}
