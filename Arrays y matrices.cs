using System;

namespace RegistroEstudiantes
{
    public class Estudiante
    {
        // Propiedades con validación simple en setters
        private int id;
        private string nombres;
        private string apellidos;
        private string direccion;
        private string[] telefonos;

        public int Id
        {
            get => id;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El ID debe ser un número positivo.");
                id = value;
            }
        }

        public string Nombres
        {
            get => nombres;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                    throw new ArgumentException("El nombre debe tener al menos 2 caracteres.");
                nombres = value.Trim();
            }
        }

        public string Apellidos
        {
            get => apellidos;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                    throw new ArgumentException("El apellido debe tener al menos 2 caracteres.");
                apellidos = value.Trim();
            }
        }

        public string Direccion
        {
            get => direccion;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La dirección no puede estar vacía.");
                direccion = value.Trim();
            }
        }

        public string[] Telefonos
        {
            get => telefonos;
            set
            {
                if (value == null || value.Length == 0)
                    throw new ArgumentException("Debe registrar al menos un teléfono.");
                telefonos = value;
            }
        }

        // Constructor
        public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;
            Telefonos = telefonos;
        }

        // Método para mostrar información del estudiante
        public void MostrarInformacion()
        {
            Console.WriteLine("----- Información del Estudiante -----");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombres: {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Teléfonos registrados:");
            foreach (var tel in Telefonos)
            {
                Console.WriteLine($" - {tel}");
            }
            Console.WriteLine("-------------------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Creación de array de teléfonos
                string[] telefonos = new string[] { "0968963105", "0980340001", "0992453631" };

                // Instanciación del estudiante
                Estudiante estudiante = new Estudiante(0705487981, "Luis Enrique", "Astudillo Ramirez", "Av. Arizaja y Av Luis Angel Leon Mera, Machala", telefonos);

                // Mostrar información
                estudiante.MostrarInformacion();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error en los datos ingresados: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }

            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
