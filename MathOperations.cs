// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System;

namespace PVS_Studio_Demo
{
    public class MathOperations
    {
        public void PerformOperations()
        {
            // Posibilidad de división por cero
            int denominator = new Random().Next(-1, 2);
            int result = 100 / denominator; // Potencial división por cero
            
            // Error de desplazamiento por uno en acceso a array
            int[] numbers = new int[5];
            for (int i = 0; i <= numbers.Length; i++) // Debería ser i < numbers.Length
            {
                try
                {
                    numbers[i] = i * 10;
                    Console.WriteLine($"Number at index {i}: {numbers[i]}");
                }
                catch (Exception) { /* Ignorando error silenciosamente */ }
            }
            
            // Desbordamiento de entero en un bucle
            int sum = 0;
            for (int i = 1; i < 100; i++)
            {
                sum += int.MaxValue / 99; // Eventualmente desbordará
            }
            
            // Conversiones implícitas de tipo causando pérdida de datos
            double largeValue = 1000000.56;
            int truncated = (int)largeValue; // Pérdida de precisión
            
            // Comparación de valores de punto flotante para igualdad
            double a = 0.1;
            double b = 0.2;
            double c = 0.3;
            if (a + b == c) // Problema de comparación de punto flotante
            {
                Console.WriteLine("Equal"); // Puede no ejecutarse debido a la precisión de punto flotante
            }
            
            // Confusión de operación a nivel de bit
            bool flag1 = true;
            bool flag2 = true;
            if (flag1 & flag2) // Probablemente debería ser && para evaluación de cortocircuito
            {
                Console.WriteLine("Both flags are true");
            }
        }
    }
}