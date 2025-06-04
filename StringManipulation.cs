// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System;
using System.Text;
using System.Globalization;

namespace PVS_Studio_Demo
{
    public class StringManipulation
    {
        public void ManipulateStrings()
        {
            // Concatenación ineficiente de cadenas en un bucle
            string result = "";
            for (int i = 0; i < 1000; i++)
            {
                result += i.ToString(); // Debería usar StringBuilder
            }
            
            // Vulnerabilidad de cadena de formato
            string userInput = GetUserInput();
            Console.WriteLine(userInput); // Vulnerabilidad de cadena de formato si la entrada contiene especificadores de formato
            
            // Comparación de cadenas sensible a cultura en ruta crítica
            string input = "turkish";
            if (input.ToLower() == "turkish") // Debería usar ToLowerInvariant o especificar cultura
            {
                Console.WriteLine("Matched");
            }
            
            // Potencial dereferencia nula con cadena
            string nullableStr = GetNullableString();
            int length = nullableStr.Length; // Potencial NullReferenceException
            
            // Comparación incorrecta de cadenas
            string str1 = "value";
            object obj = "value";
            if (str1 == obj) // Usando == en lugar de Equals
            {
                Console.WriteLine("Strings are equal");
            }
            
            // Usando sobrecarga incorrecta
            string text = "  trim me  ";
            char[] charsToTrim = { ' ' };
            text = text.Trim(charsToTrim); // Usando array explícito cuando Trim() simple funcionaría
        }
        
        private string GetUserInput()
        {
            // Simular entrada de usuario que podría contener especificadores de formato
            return "Test {0} {1}";
        }
        
        private string GetNullableString()
        {
            Random rand = new Random();
            return rand.Next(0, 2) == 0 ? null : "Not null";
        }
    }
}