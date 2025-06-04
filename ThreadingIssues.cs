// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System;
using System.Threading;
using System.Collections.Generic;

namespace PVS_Studio_Demo
{
    public class ThreadingIssues
    {
        private int sharedCounter = 0;
        private readonly List<int> sharedList = new List<int>();
        private readonly object lockObj1 = new object();
        private readonly object lockObj2 = new object();
        
        public void DemonstrateIssues()
        {
            // Condición de carrera - sin sincronización
            Thread t1 = new Thread(() => {
                for (int i = 0; i < 1000; i++)
                {
                    sharedCounter++; // Sin bloqueo - condición de carrera
                }
            });
            
            Thread t2 = new Thread(() => {
                for (int i = 0; i < 1000; i++)
                {
                    sharedCounter++; // Sin bloqueo - condición de carrera
                }
            });
            
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            
            Console.WriteLine($"Counter should be 2000, actual: {sharedCounter}");
            
            // Potencial interbloqueo
            Thread thread1 = new Thread(() => {
                lock (lockObj1)
                {
                    Thread.Sleep(100); // Aumentar la probabilidad de interbloqueo
                    lock (lockObj2)
                    {
                        sharedList.Add(1);
                    }
                }
            });
            
            Thread thread2 = new Thread(() => {
                lock (lockObj2)
                {
                    Thread.Sleep(100); // Aumentar la probabilidad de interbloqueo
                    lock (lockObj1)
                    {
                        sharedList.Add(2);
                    }
                }
            });
            
            thread1.Start();
            thread2.Start();
            
            // Patrón de bloqueo de doble verificación implementado incorrectamente
            InitializeSingleton();
        }
        
        private Singleton instance;
        
        private void InitializeSingleton()
        {
            // Patrón de bloqueo de doble verificación incorrecto (sin volatile)
            if (instance == null) // Primera verificación sin bloqueo
            {
                lock (lockObj1)
                {
                    if (instance == null)
                    {
                        instance = new Singleton(); // No es volatile, puede reordenarse
                    }
                }
            }
        }
        
        private class Singleton
        {
            // Implementación Singleton
        }
    }
}