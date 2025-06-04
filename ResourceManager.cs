// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System;
using System.IO;
using System.Threading;

namespace PVS_Studio_Demo
{
    public class ResourceManager : IDisposable
    {
        private FileStream file;
        private bool disposed = false;
        
        public void UseResources()
        {
            // Fuga de recursos - archivo no cerrado correctamente
            file = new FileStream("temp.txt", FileMode.Create);
            byte[] data = new byte[100];
            new Random().NextBytes(data);
            file.Write(data, 0, data.Length);
            
            // Olvidar liberar otros recursos
            var reader = new StreamReader(new MemoryStream(data));
            string text = reader.ReadToEnd();
            // reader no liberado
            
            // Uso de un objeto liberado
            DisposeSelf();
            file.Flush(); // Usando objeto liberado
        }
        
        private void DisposeSelf()
        {
            Dispose();
        }
        
        // Implementación incorrecta de IDisposable
        public void Dispose()
        {
            // No se verifica la bandera disposed
            if (file != null)
            {
                file.Dispose();
            }
            // No se establece disposed = true
            // No se suprime la finalización
        }
        
        // Finalizador incorrecto que no llama a Dispose
        ~ResourceManager()
        {
            // Debería llamar a Dispose(false) pero no lo hace
            if (file != null)
            {
                file.Close(); // Lógica de limpieza duplicada en lugar de llamar a Dispose
            }
        }
    }
}