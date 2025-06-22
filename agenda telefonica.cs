using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AgendaTelefonica
{
    // Clase principal que representa un contacto
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        // Constructor vacío para serialización JSON
        public Contacto() { }

        // Constructor con parámetros
        public Contacto(string nombre, string apellido, string telefono, string email = "", string direccion = "")
        {
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;
        }

        // Método para mostrar información del contacto
        public override string ToString()
        {
            return $"ID: {Id} | {Nombre} {Apellido} | Tel: {Telefono} | Email: {Email} | Dir: {Direccion}";
        }

        // Método para validar el contacto
        public bool EsValido()
        {
            return !string.IsNullOrWhiteSpace(Nombre) && 
                   !string.IsNullOrWhiteSpace(Apellido) && 
                   !string.IsNullOrWhiteSpace(Telefono);
        }
    }

    // Clase para manejar las operaciones de la agenda
    public class AgendaTelefonica
    {
        private List<Contacto> contactos;
        private int siguienteId;
        private readonly string archivoContactos = "contactos.txt";

        public AgendaTelefonica()
        {
            contactos = new List<Contacto>();
            siguienteId = 1;
            CargarContactos();
        }

        // Agregar un nuevo contacto
        public bool AgregarContacto(Contacto contacto)
        {
            try
            {
                if (!contacto.EsValido())
                {
                    Console.WriteLine("Error: El contacto no tiene todos los campos requeridos.");
                    return false;
                }

                // Verificar si ya existe un contacto con el mismo teléfono
                if (contactos.Any(c => c.Telefono == contacto.Telefono))
                {
                    Console.WriteLine("Error: Ya existe un contacto con ese número de teléfono.");
                    return false;
                }

                contacto.Id = siguienteId++;
                contacto.FechaCreacion = DateTime.Now;
                contacto.FechaModificacion = DateTime.Now;
                contactos.Add(contacto);
                GuardarContactos();
                Console.WriteLine("Contacto agregado exitosamente.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar contacto: {ex.Message}");
                return false;
            }
        }

        // Buscar contactos por nombre
        public List<Contacto> BuscarPorNombre(string nombre)
        {
            return contactos.Where(c => 
                c.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase) ||
                c.Apellido.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Buscar contacto por teléfono
        public Contacto BuscarPorTelefono(string telefono)
        {
            return contactos.FirstOrDefault(c => c.Telefono == telefono);
        }

        // Buscar contacto por ID
        public Contacto BuscarPorId(int id)
        {
            return contactos.FirstOrDefault(c => c.Id == id);
        }

        // Modificar un contacto existente
        public bool ModificarContacto(int id, Contacto contactoModificado)
        {
            try
            {
                var contactoExistente = BuscarPorId(id);
                if (contactoExistente == null)
                {
                    Console.WriteLine("Error: No se encontró el contacto especificado.");
                    return false;
                }

                if (!contactoModificado.EsValido())
                {
                    Console.WriteLine("Error: Los datos del contacto no son válidos.");
                    return false;
                }

                // Verificar si el nuevo teléfono ya existe en otro contacto
                var contactoConMismoTelefono = contactos.FirstOrDefault(c => 
                    c.Telefono == contactoModificado.Telefono && c.Id != id);
                
                if (contactoConMismoTelefono != null)
                {
                    Console.WriteLine("Error: Ya existe otro contacto con ese número de teléfono.");
                    return false;
                }

                // Actualizar los campos
                contactoExistente.Nombre = contactoModificado.Nombre;
                contactoExistente.Apellido = contactoModificado.Apellido;
                contactoExistente.Telefono = contactoModificado.Telefono;
                contactoExistente.Email = contactoModificado.Email;
                contactoExistente.Direccion = contactoModificado.Direccion;
                contactoExistente.FechaModificacion = DateTime.Now;

                GuardarContactos();
                Console.WriteLine("Contacto modificado exitosamente.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar contacto: {ex.Message}");
                return false;
            }
        }

        // Eliminar un contacto
        public bool EliminarContacto(int id)
        {
            try
            {
                var contacto = BuscarPorId(id);
                if (contacto == null)
                {
                    Console.WriteLine("Error: No se encontró el contacto especificado.");
                    return false;
                }

                contactos.Remove(contacto);
                GuardarContactos();
                Console.WriteLine("Contacto eliminado exitosamente.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar contacto: {ex.Message}");
                return false;
            }
        }

        // Obtener todos los contactos
        public List<Contacto> ObtenerTodosLosContactos()
        {
            return contactos.OrderBy(c => c.Apellido).ThenBy(c => c.Nombre).ToList();
        }

        // Obtener estadísticas de la agenda
        public void MostrarEstadisticas()
        {
            Console.WriteLine($"\n=== ESTADÍSTICAS DE LA AGENDA ===");
            Console.WriteLine($"Total de contactos: {contactos.Count}");
            Console.WriteLine($"Contactos con email: {contactos.Count(c => !string.IsNullOrWhiteSpace(c.Email))}");
            Console.WriteLine($"Contactos con dirección: {contactos.Count(c => !string.IsNullOrWhiteSpace(c.Direccion))}");
            
            if (contactos.Any())
            {
                var contactoMasReciente = contactos.OrderByDescending(c => c.FechaCreacion).First();
                Console.WriteLine($"Contacto más reciente: {contactoMasReciente.Nombre} {contactoMasReciente.Apellido}");
            }
        }

        // Guardar contactos en archivo de texto plano
        private void GuardarContactos()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivoContactos))
                {
                    foreach (var contacto in contactos)
                    {
                        // Formato: ID|Nombre|Apellido|Telefono|Email|Direccion|FechaCreacion|FechaModificacion
                        string linea = $"{contacto.Id}|{contacto.Nombre}|{contacto.Apellido}|{contacto.Telefono}|{contacto.Email}|{contacto.Direccion}|{contacto.FechaCreacion:yyyy-MM-dd HH:mm:ss}|{contacto.FechaModificacion:yyyy-MM-dd HH:mm:ss}";
                        writer.WriteLine(linea);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar contactos: {ex.Message}");
            }
        }

        // Cargar contactos desde archivo de texto plano
        private void CargarContactos()
        {
            try
            {
                if (File.Exists(archivoContactos))
                {
                    string[] lineas = File.ReadAllLines(archivoContactos);
                    
                    foreach (string linea in lineas)
                    {
                        if (string.IsNullOrWhiteSpace(linea)) continue;
                        
                        string[] partes = linea.Split('|');
                        if (partes.Length >= 8)
                        {
                            var contacto = new Contacto
                            {
                                Id = int.Parse(partes[0]),
                                Nombre = partes[1],
                                Apellido = partes[2],
                                Telefono = partes[3],
                                Email = partes[4],
                                Direccion = partes[5],
                                FechaCreacion = DateTime.Parse(partes[6]),
                                FechaModificacion = DateTime.Parse(partes[7])
                            };
                            contactos.Add(contacto);
                        }
                    }
                    
                    // Actualizar el siguiente ID
                    if (contactos.Any())
                    {
                        siguienteId = contactos.Max(c => c.Id) + 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar contactos: {ex.Message}");
                contactos = new List<Contacto>();
            }
        }
    }

    // Clase para manejar la interfaz de usuario
    public class InterfazUsuario
    {
        private AgendaTelefonica agenda;

        public InterfazUsuario()
        {
            agenda = new AgendaTelefonica();
        }

        public void IniciarPrograma()
        {
            Console.WriteLine("=== AGENDA TELEFÓNICA ===");
            Console.WriteLine("Sistema de gestión de contactos");
            Console.WriteLine("=============================\n");

            bool continuar = true;
            while (continuar)
            {
                MostrarMenu();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarContactoDesdeConsola();
                        break;
                    case "2":
                        BuscarContactos();
                        break;
                    case "3":
                        ModificarContactoDesdeConsola();
                        break;
                    case "4":
                        EliminarContactoDesdeConsola();
                        break;
                    case "5":
                        MostrarTodosLosContactos();
                        break;
                    case "6":
                        agenda.MostrarEstadisticas();
                        break;
                    case "0":
                        continuar = false;
                        Console.WriteLine("¡Gracias por usar la Agenda Telefónica!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

                if (continuar)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private void MostrarMenu()
        {
            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Agregar contacto");
            Console.WriteLine("2. Buscar contactos");
            Console.WriteLine("3. Modificar contacto");
            Console.WriteLine("4. Eliminar contacto");
            Console.WriteLine("5. Mostrar todos los contactos");
            Console.WriteLine("6. Mostrar estadísticas");
            Console.WriteLine("0. Salir");
            Console.Write("\nSeleccione una opción: ");
        }

        private void AgregarContactoDesdeConsola()
        {
            Console.WriteLine("\n=== AGREGAR CONTACTO ===");
            
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            
            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();
            
            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine();
            
            Console.Write("Email (opcional): ");
            string email = Console.ReadLine();
            
            Console.Write("Dirección (opcional): ");
            string direccion = Console.ReadLine();

            var nuevoContacto = new Contacto(nombre, apellido, telefono, email, direccion);
            agenda.AgregarContacto(nuevoContacto);
        }

        private void BuscarContactos()
        {
            Console.WriteLine("\n=== BUSCAR CONTACTOS ===");
            Console.WriteLine("1. Buscar por nombre/apellido");
            Console.WriteLine("2. Buscar por teléfono");
            Console.Write("Seleccione opción: ");
            
            string opcion = Console.ReadLine();
            
            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese nombre o apellido: ");
                    string nombre = Console.ReadLine();
                    var contactosPorNombre = agenda.BuscarPorNombre(nombre);
                    MostrarListaContactos(contactosPorNombre);
                    break;
                case "2":
                    Console.Write("Ingrese teléfono: ");
                    string telefono = Console.ReadLine();
                    var contactoPorTelefono = agenda.BuscarPorTelefono(telefono);
                    if (contactoPorTelefono != null)
                    {
                        Console.WriteLine("\nContacto encontrado:");
                        Console.WriteLine(contactoPorTelefono);
                    }
                    else
                    {
                        Console.WriteLine("No se encontró ningún contacto con ese teléfono.");
                    }
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        private void ModificarContactoDesdeConsola()
        {
            Console.WriteLine("\n=== MODIFICAR CONTACTO ===");
            Console.Write("Ingrese el ID del contacto a modificar: ");
            
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var contactoExistente = agenda.BuscarPorId(id);
                if (contactoExistente == null)
                {
                    Console.WriteLine("No se encontró un contacto con ese ID.");
                    return;
                }

                Console.WriteLine($"Contacto actual: {contactoExistente}");
                Console.WriteLine("Ingrese los nuevos datos (presione Enter para mantener el valor actual):");

                Console.Write($"Nombre [{contactoExistente.Nombre}]: ");
                string nombre = Console.ReadLine();
                nombre = string.IsNullOrWhiteSpace(nombre) ? contactoExistente.Nombre : nombre;

                Console.Write($"Apellido [{contactoExistente.Apellido}]: ");
                string apellido = Console.ReadLine();
                apellido = string.IsNullOrWhiteSpace(apellido) ? contactoExistente.Apellido : apellido;

                Console.Write($"Teléfono [{contactoExistente.Telefono}]: ");
                string telefono = Console.ReadLine();
                telefono = string.IsNullOrWhiteSpace(telefono) ? contactoExistente.Telefono : telefono;

                Console.Write($"Email [{contactoExistente.Email}]: ");
                string email = Console.ReadLine();
                email = string.IsNullOrWhiteSpace(email) ? contactoExistente.Email : email;

                Console.Write($"Dirección [{contactoExistente.Direccion}]: ");
                string direccion = Console.ReadLine();
                direccion = string.IsNullOrWhiteSpace(direccion) ? contactoExistente.Direccion : direccion;

                var contactoModificado = new Contacto(nombre, apellido, telefono, email, direccion);
                agenda.ModificarContacto(id, contactoModificado);
            }
            else
            {
                Console.WriteLine("ID no válido.");
            }
        }

        private void EliminarContactoDesdeConsola()
        {
            Console.WriteLine("\n=== ELIMINAR CONTACTO ===");
            Console.Write("Ingrese el ID del contacto a eliminar: ");
            
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var contacto = agenda.BuscarPorId(id);
                if (contacto != null)
                {
                    Console.WriteLine($"Contacto a eliminar: {contacto}");
                    Console.Write("¿Está seguro? (s/n): ");
                    string confirmacion = Console.ReadLine();
                    
                    if (confirmacion?.ToLower() == "s")
                    {
                        agenda.EliminarContacto(id);
                    }
                    else
                    {
                        Console.WriteLine("Operación cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontró un contacto con ese ID.");
                }
            }
            else
            {
                Console.WriteLine("ID no válido.");
            }
        }

        private void MostrarTodosLosContactos()
        {
            Console.WriteLine("\n=== TODOS LOS CONTACTOS ===");
            var contactos = agenda.ObtenerTodosLosContactos();
            MostrarListaContactos(contactos);
        }

        private void MostrarListaContactos(List<Contacto> contactos)
        {
            if (contactos.Count == 0)
            {
                Console.WriteLine("No se encontraron contactos.");
                return;
            }

            Console.WriteLine($"\nSe encontraron {contactos.Count} contacto(s):");
            Console.WriteLine(new string('-', 100));
            
            foreach (var contacto in contactos)
            {
                Console.WriteLine(contacto);
            }
            
            Console.WriteLine(new string('-', 100));
        }
    }

    // Clase principal del programa
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var interfaz = new InterfazUsuario();
                interfaz.IniciarPrograma();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error crítico en la aplicación: {ex.Message}");
                Console.WriteLine("Presione cualquier tecla para salir...");
                Console.ReadKey();
            }
        }
    }
}