using System;

/// <summary>
/// Clase que representa un Cuadrado con encapsulación de datos primitivos
/// y métodos para calcular área y perímetro
/// </summary>
public class Cuadrado
{
    // Encapsulación del tipo de dato primitivo double para el lado
    private double lado;
    
    /// <summary>
    /// Constructor que inicializa el cuadrado con un lado específico
    /// Valida que el lado sea mayor que cero
    /// </summary>
    /// <param name="lado">Lado del cuadrado (debe ser mayor que 0)</param>
    public Cuadrado(double lado)
    {
        if (lado <= 0)
            throw new ArgumentException("El lado debe ser mayor que cero");
        this.lado = lado;
    }
    
    /// <summary>
    /// Propiedad para acceder y modificar el lado de forma controlada
    /// Implementa encapsulación del dato primitivo
    /// </summary>
    public double Lado
    {
        get 
        { 
            return lado; 
        }
        set 
        { 
            if (value <= 0)
                throw new ArgumentException("El lado debe ser mayor que cero");
            lado = value; 
        }
    }
    
    /// <summary>
    /// CalcularArea es una función que devuelve un valor double,
    /// se utiliza para calcular el área de un cuadrado,
    /// requiere el lado del cuadrado almacenado en la clase
    /// Fórmula: lado²
    /// </summary>
    /// <returns>Área del cuadrado</returns>
    public double CalcularArea()
    {
        return lado * lado;
    }
    
    /// <summary>
    /// CalcularPerimetro es una función que devuelve un valor double,
    /// se utiliza para calcular el perímetro de un cuadrado
    /// Fórmula: 4 × lado
    /// </summary>
    /// <returns>Perímetro del cuadrado</returns>
    public double CalcularPerimetro()
    {
        return 4 * lado;
    }
    
    /// <summary>
    /// CalcularDiagonal es una función que devuelve un valor double,
    /// se utiliza para calcular la diagonal de un cuadrado
    /// Fórmula: lado × √2
    /// </summary>
    /// <returns>Diagonal del cuadrado</returns>
    public double CalcularDiagonal()
    {
        return lado * Math.Sqrt(2);
    }
    
    /// <summary>
    /// Método para mostrar información completa del cuadrado
    /// </summary>
    public void MostrarInformacion()
    {
        Console.WriteLine("=== INFORMACIÓN DEL CUADRADO ===");
        Console.WriteLine($"Lado: {lado:F2}");
        Console.WriteLine($"Área: {CalcularArea():F2}");
        Console.WriteLine($"Perímetro: {CalcularPerimetro():F2}");
        Console.WriteLine($"Diagonal: {CalcularDiagonal():F2}");
        Console.WriteLine();
    }
}

/// <summary>
/// Clase que representa un Triángulo Equilátero con encapsulación de datos primitivos
/// y métodos para calcular área y perímetro
/// </summary>
public class TrianguloEquilatero
{
    // Encapsulación del tipo de dato primitivo double para el lado
    private double lado;
    
    /// <summary>
    /// Constructor que inicializa el triángulo equilátero con un lado específico
    /// Valida que el lado sea mayor que cero
    /// </summary>
    /// <param name="lado">Lado del triángulo equilátero (debe ser mayor que 0)</param>
    public TrianguloEquilatero(double lado)
    {
        if (lado <= 0)
            throw new ArgumentException("El lado debe ser mayor que cero");
        this.lado = lado;
    }
    
    /// <summary>
    /// Propiedad para acceder y modificar el lado de forma controlada
    /// Implementa encapsulación del dato primitivo
    /// </summary>
    public double Lado
    {
        get 
        { 
            return lado; 
        }
        set 
        { 
            if (value <= 0)
                throw new ArgumentException("El lado debe ser mayor que cero");
            lado = value; 
        }
    }
    
    /// <summary>
    /// CalcularArea es una función que devuelve un valor double,
    /// se utiliza para calcular el área de un triángulo equilátero,
    /// requiere el lado del triángulo almacenado en la clase
    /// Fórmula: (√3 / 4) × lado²
    /// </summary>
    /// <returns>Área del triángulo equilátero</returns>
    public double CalcularArea()
    {
        return (Math.Sqrt(3) / 4) * lado * lado;
    }
    
    /// <summary>
    /// CalcularPerimetro es una función que devuelve un valor double,
    /// se utiliza para calcular el perímetro de un triángulo equilátero
    /// Fórmula: 3 × lado
    /// </summary>
    /// <returns>Perímetro del triángulo equilátero</returns>
    public double CalcularPerimetro()
    {
        return 3 * lado;
    }
    
    /// <summary>
    /// CalcularAltura es una función que devuelve un valor double,
    /// se utiliza para calcular la altura de un triángulo equilátero
    /// Fórmula: (√3 / 2) × lado
    /// </summary>
    /// <returns>Altura del triángulo equilátero</returns>
    public double CalcularAltura()
    {
        return (Math.Sqrt(3) / 2) * lado;
    }
    
    /// <summary>
    /// Método para mostrar información completa del triángulo equilátero
    /// </summary>
    public void MostrarInformacion()
    {
        Console.WriteLine("=== INFORMACIÓN DEL TRIÁNGULO EQUILÁTERO ===");
        Console.WriteLine($"Lado: {lado:F2}");
        Console.WriteLine($"Área: {CalcularArea():F2}");
        Console.WriteLine($"Perímetro: {CalcularPerimetro():F2}");
        Console.WriteLine($"Altura: {CalcularAltura():F2}");
        Console.WriteLine();
    }
}

/// <summary>
/// Clase utilitaria para realizar comparaciones entre figuras geométricas
/// </summary>
public static class ComparadorFiguras
{
    /// <summary>
    /// Compara las áreas de un cuadrado y un triángulo equilátero
    /// </summary>
    /// <param name="cuadrado">Instancia de cuadrado</param>
    /// <param name="triangulo">Instancia de triángulo equilátero</param>
    public static void CompararAreas(Cuadrado cuadrado, TrianguloEquilatero triangulo)
    {
        double areaCuadrado = cuadrado.CalcularArea();
        double areaTriangulo = triangulo.CalcularArea();
        
        Console.WriteLine("=== COMPARACIÓN DE ÁREAS ===");
        Console.WriteLine($"Área del cuadrado: {areaCuadrado:F2}");
        Console.WriteLine($"Área del triángulo: {areaTriangulo:F2}");
        
        if (areaCuadrado > areaTriangulo)
        {
            double diferencia = areaCuadrado - areaTriangulo;
            Console.WriteLine($"El cuadrado tiene {diferencia:F2} unidades cuadradas más de área");
        }
        else if (areaTriangulo > areaCuadrado)
        {
            double diferencia = areaTriangulo - areaCuadrado;
            Console.WriteLine($"El triángulo tiene {diferencia:F2} unidades cuadradas más de área");
        }
        else
        {
            Console.WriteLine("Ambas figuras tienen la misma área");
        }
        Console.WriteLine();
    }
    
    /// <summary>
    /// Encuentra la figura con mayor perímetro
    /// </summary>
    /// <param name="cuadrado">Instancia de cuadrado</param>
    /// <param name="triangulo">Instancia de triángulo equilátero</param>
    public static void CompararPerimetros(Cuadrado cuadrado, TrianguloEquilatero triangulo)
    {
        double perimetroCuadrado = cuadrado.CalcularPerimetro();
        double perimetroTriangulo = triangulo.CalcularPerimetro();
        
        Console.WriteLine("=== COMPARACIÓN DE PERÍMETROS ===");
        Console.WriteLine($"Perímetro del cuadrado: {perimetroCuadrado:F2}");
        Console.WriteLine($"Perímetro del triángulo: {perimetroTriangulo:F2}");
        
        if (perimetroCuadrado > perimetroTriangulo)
        {
            Console.WriteLine("El cuadrado tiene mayor perímetro");
        }
        else if (perimetroTriangulo > perimetroCuadrado)
        {
            Console.WriteLine("El triángulo tiene mayor perímetro");
        }
        else
        {
            Console.WriteLine("Ambas figuras tienen el mismo perímetro");
        }
        Console.WriteLine();
    }
}

/// <summary>
/// Clase principal que demuestra el uso de las nuevas figuras geométricas
/// con ejemplos prácticos y casos de prueba avanzados
/// </summary>
public class Program
{
    /// <summary>
    /// Método principal que ejecuta ejemplos de uso de las clases
    /// </summary>
    /// <param name="args">Argumentos de línea de comandos</param>
    public static void Main(string[] args)
    {
        // Encabezado del programa con información del archivo
        Console.WriteLine("================================================================");
        Console.WriteLine("        FIGURAS GEOMÉTRICAS");
        Console.WriteLine("================================================================");
        Console.WriteLine("Archivo: FigurasGeometricas 2.0");
        Console.WriteLine("Fecha: 08 de Junio, 2025");
        Console.WriteLine("Área: Estructura de Datos C");
        Console.WriteLine("Figuras: Cuadrado y Triángulo Equilátero");
        Console.WriteLine("================================================================");
        Console.WriteLine();
        
        try
        {
            // EJEMPLO 1: Trabajando con un Cuadrado
            Console.WriteLine("EJEMPLO 1: Creación y Manipulación de un Cuadrado");
            Console.WriteLine("--------------------------------------------------");
            
            // Crear cuadrado con lado 6.0
            Cuadrado cuadrado1 = new Cuadrado(6.0);
            cuadrado1.MostrarInformacion();
            
            // Modificar el lado usando la propiedad encapsulada
            Console.WriteLine("Modificando el lado a 8.0...");
            cuadrado1.Lado = 8.0;
            cuadrado1.MostrarInformacion();
            
            // EJEMPLO 2: Trabajando con un Triángulo Equilátero
            Console.WriteLine("EJEMPLO 2: Creación y Manipulación de un Triángulo Equilátero");
            Console.WriteLine("-------------------------------------------------------------");
            
            // Crear triángulo equilátero con lado 5.0
            TrianguloEquilatero triangulo1 = new TrianguloEquilatero(5.0);
            triangulo1.MostrarInformacion();
            
            // Modificar el lado usando la propiedad encapsulada
            Console.WriteLine("Modificando el lado a 7.0...");
            triangulo1.Lado = 7.0;
            triangulo1.MostrarInformacion();
            
            // EJEMPLO 3: Comparaciones entre figuras
            Console.WriteLine("EJEMPLO 3: Comparaciones Avanzadas");
            Console.WriteLine("-----------------------------------");
            
            Cuadrado cuadrado2 = new Cuadrado(4.0);
            TrianguloEquilatero triangulo2 = new TrianguloEquilatero(6.0);
            
            // Usar la clase utilitaria para comparaciones
            ComparadorFiguras.CompararAreas(cuadrado2, triangulo2);
            ComparadorFiguras.CompararPerimetros(cuadrado2, triangulo2);
            
            // EJEMPLO 4: Cálculos específicos
            Console.WriteLine("EJEMPLO 4: Cálculos Específicos Avanzados");
            Console.WriteLine("-----------------------------------------");
            
            Cuadrado cuadradoEspecial = new Cuadrado(10.0);
            TrianguloEquilatero trianguloEspecial = new TrianguloEquilatero(12.0);
            
            Console.WriteLine("=== CUADRADO ESPECIAL ===");
            Console.WriteLine($"Lado: {cuadradoEspecial.Lado:F2}");
            Console.WriteLine($"Área: {cuadradoEspecial.CalcularArea():F2}");
            Console.WriteLine($"Diagonal: {cuadradoEspecial.CalcularDiagonal():F2}");
            Console.WriteLine($"Razón diagonal/lado: {(cuadradoEspecial.CalcularDiagonal() / cuadradoEspecial.Lado):F2}");
            Console.WriteLine();
            
            Console.WriteLine("=== TRIÁNGULO ESPECIAL ===");
            Console.WriteLine($"Lado: {trianguloEspecial.Lado:F2}");
            Console.WriteLine($"Área: {trianguloEspecial.CalcularArea():F2}");
            Console.WriteLine($"Altura: {trianguloEspecial.CalcularAltura():F2}");
            Console.WriteLine($"Razón altura/lado: {(trianguloEspecial.CalcularAltura() / trianguloEspecial.Lado):F2}");
            Console.WriteLine();
            
            // EJEMPLO 5: Validación de datos
            Console.WriteLine("EJEMPLO 5: Pruebas de Validación");
            Console.WriteLine("--------------------------------");
            
            try
            {
                Console.WriteLine("Intentando crear cuadrado con lado negativo...");
                Cuadrado cuadradoInvalido = new Cuadrado(-3.0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"✓ Error capturado correctamente: {ex.Message}");
            }
            
            try
            {
                Console.WriteLine("Intentando crear triángulo con lado cero...");
                TrianguloEquilatero trianguloInvalido = new TrianguloEquilatero(0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"✓ Error capturado correctamente: {ex.Message}");
            }
            
            // EJEMPLO 6: Array de figuras (simulando polimorfismo)
            Console.WriteLine("\nEJEMPLO 6: Colección de Figuras");
            Console.WriteLine("-------------------------------");
            
            // Crear arrays de cada tipo de figura
            Cuadrado[] cuadrados = {
                new Cuadrado(2.0),
                new Cuadrado(4.0),
                new Cuadrado(6.0)
            };
            
            TrianguloEquilatero[] triangulos = {
                new TrianguloEquilatero(3.0),
                new TrianguloEquilatero(5.0),
                new TrianguloEquilatero(7.0)
            };
            
            // Calcular área total de cuadrados
            double areaTotalCuadrados = 0;
            foreach (Cuadrado c in cuadrados)
            {
                areaTotalCuadrados += c.CalcularArea();
            }
            
            // Calcular área total de triángulos
            double areaTotalTriangulos = 0;
            foreach (TrianguloEquilatero t in triangulos)
            {
                areaTotalTriangulos += t.CalcularArea();
            }
            
            Console.WriteLine($"Área total de cuadrados: {areaTotalCuadrados:F2}");
            Console.WriteLine($"Área total de triángulos: {areaTotalTriangulos:F2}");
            Console.WriteLine($"Área total combinada: {(areaTotalCuadrados + areaTotalTriangulos):F2}");
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado: {ex.Message}");
        }
        
        Console.WriteLine("\n================================================================");
        Console.WriteLine("Ejemplo adicional completado exitosamente.");
        Console.WriteLine("Presione cualquier tecla para salir...");
        Console.WriteLine("================================================================");
        Console.ReadKey();
    }
}
