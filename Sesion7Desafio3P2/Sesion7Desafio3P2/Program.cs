using System;
using System.IO;

namespace Empresa
{
    class Auto
    {
        public int HP { get; set; }
        public string Color { get; set; }
        public string Marca { get; protected set; } // Cambiado a protected para acceso en subclases
        public string Modelo { get; protected set; } // Cambiado a protected para acceso en subclases
        public string FilePath { get; protected set; } // Ruta de archivo para historial de reparaciones
        public List<string> HistorialReparaciones { get; private set; } // Lista para almacenar historial de reparaciones

        public Auto(int hp, string color, string marca, string modelo, string filePath)
        {
            this.HP = hp;
            this.Color = color;
            this.Marca = marca;
            this.Modelo = modelo;
            this.FilePath = filePath;
            this.HistorialReparaciones = new List<string>();
        }

        public void MostrarDetalles()
        {
            Console.WriteLine("Marca: {0} - Modelo: {1} - HP: {2} - Color: {3}", Marca, Modelo, HP, Color);
        }

        public virtual void Reparar()
        {
            Console.WriteLine($"El {Marca} {Modelo} ya está reparado");
            RegistrarReparacion();
        }

        private void RegistrarReparacion()
        {
            string reparacion = $"Reparación de {Marca} {Modelo} realizada el {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
            HistorialReparaciones.Add(reparacion); // Agregar reparación a la lista en memoria
            GuardarReparacionEnArchivo(reparacion); // Guardar reparación en archivo
        }

        private void GuardarReparacionEnArchivo(string reparacion)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine(reparacion);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error al guardar la reparación en el archivo: {e.Message}");
            }
        }

        public void HistoriaDeReparaciones()
        {
            Console.WriteLine($"Historia de reparaciones de {Marca} {Modelo}:");
            try
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error al leer el archivo de reparaciones: {e.Message}");
            }
        }
    }

    class BMW : Auto
    {
        public BMW(int hp, string color, string modelo) : base(hp, color, "BMW", modelo, "reparaciones_bmw.txt")
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BMW bmw = new BMW(300, "Negro", "Serie 3");
            bmw.Reparar(); // Realiza una reparación (simulada)
            bmw.HistoriaDeReparaciones(); // Muestra la historia de reparaciones

            Console.ReadLine();
        }
    }
}
