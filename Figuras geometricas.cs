using System;

// Clase abstracta base para todas las figuras geométricas
public abstract class FiguraGeometrica
{
    // Método abstracto para calcular área - debe ser implementado por cada figura
    public abstract double CalcularArea();
    
    // Método abstracto para calcular perímetro - debe ser implementado por cada figura
    public abstract double CalcularPerimetro();
    
    // Método virtual para mostrar información de la figura
    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Área: {CalcularArea():F2}");
        Console.WriteLine($"Perímetro: {CalcularPerimetro():F2}");
    }
}

// Clase Círculo que hereda de FiguraGeometrica
public class Circulo : FiguraGeometrica
{
    // Encapsulación del dato primitivo radio
    private double radio;
    
    // Constructor que recibe el radio del círculo
    public Circulo(double radio)
    {
        if (radio <= 0)
            throw new ArgumentException("El radio debe ser mayor que cero");
        this.radio = radio;
    }
    
    // Propiedad para acceder al radio de forma controlada (encapsulación)
    public double Radio
    {
        get { return radio; }
        set 
        { 
            if (value <= 0)
                throw new ArgumentException("El radio debe ser mayor que cero");
            radio = value; 
        }
    }
    
    // Implementación del método CalcularArea usando la fórmula: π × r²
    public override double CalcularArea()
    {
        return Math.PI * radio * radio;
    }
    
    // Implementación del método CalcularPerimetro usando la fórmula: 2 × π × r
    public override double CalcularPerimetro()
    {
        return 2 * Math.PI * radio;
    }
    
    // Sobrescritura del método MostrarInformacion para mostrar datos específicos del círculo
    public override void MostrarInformacion()
    {
        Console.WriteLine("=== CÍRCULO ===");
        Console.WriteLine($"Radio: {radio:F2}");
        base.MostrarInformacion();
        Console.WriteLine();
    }
}

// Clase Cuadrado que hereda de FiguraGeometrica
public class Cuadrado : FiguraGeometrica
{
    // Encapsulación del dato primitivo lado
    private double lado;
    
    // Constructor que recibe el lado del cuadrado
    public Cuadrado(double lado)
    {
        if (lado <= 0)
            throw new ArgumentException("El lado debe ser mayor que cero");
        this.lado = lado;
    }
    
    // Propiedad para acceder al lado de forma controlada (encapsulación)
    public double Lado
    {
        get { return lado; }
        set 
        { 
            if (value <= 0)
                throw new ArgumentException("El lado debe ser mayor que cero");
            lado = value; 
        }
    }
    
    // Implementación del método CalcularArea usando la fórmula: lado²
    public override double CalcularArea()
    {
        return lado * lado;
    }
    
    // Implementación del método CalcularPerimetro usando la fórmula: 4 × lado
    public override double CalcularPerimetro()
    {
        return 4 * lado;
    }
    
    // Sobrescritura del método MostrarInformacion para mostrar datos específicos del cuadrado
    public override void MostrarInformacion()
    {
        Console.WriteLine("=== CUADRADO ===");
        Console.WriteLine($"Lado: {lado:F2}");
        base.MostrarInformacion();
        Console.WriteLine();
    }
}

// Clase Rectangulo que hereda de FiguraGeometrica
public class Rectangulo : FiguraGeometrica
{
    // Encapsulación de los datos primitivos largo y ancho
    private double largo;
    private double ancho;
    
    // Constructor que recibe el largo y ancho del rectángulo
    public Rectangulo(double largo, double ancho)
    {
        if (largo <= 0 || ancho <= 0)
            throw new ArgumentException("El largo y ancho deben ser mayores que cero");
        this.largo = largo;
        this.ancho = ancho;
    }
    
    // Propiedades para acceder a las dimensiones de forma controlada (encapsulación)
    public double Largo
    {
        get { return largo; }
        set 
        { 
            if (value <= 0)
                throw new ArgumentException("El largo debe ser mayor que cero");
            largo = value; 
        }
    }
    
    public double Ancho
    {
        get { return ancho; }
        set 
        { 
            if (value <= 0)
                throw new ArgumentException("El ancho debe ser mayor que cero");
            ancho = value; 
        }
    }
    
    // Implementación del método CalcularArea usando la fórmula: largo × ancho
    public override double CalcularArea()
    {
        return largo * ancho;
    }
    
    // Implementación del método CalcularPerimetro usando la fórmula: 2 × (largo + ancho)
    public override double CalcularPerimetro()
    {
        return 2 * (largo + ancho);
    }
    
    // Sobrescritura del método MostrarInformacion para mostrar datos específicos del rectángulo
    public override void MostrarInformacion()
    {
        Console.WriteLine("=== RECTÁNGULO ===");
        Console.WriteLine($"Largo: {largo:F2}");
        Console.WriteLine($"Ancho: {ancho:F2}");
        base.MostrarInformacion();
        Console.WriteLine();
    }
}

// Clase Triangulo que hereda de FiguraGeometrica
public class Triangulo : FiguraGeometrica
{
    // Encapsulación de los datos primitivos de los tres lados
    private double ladoA;
    private double ladoB;
    private double ladoC;
    
    // Constructor que recibe los tres lados del triángulo
    public Triangulo(double ladoA, double ladoB, double ladoC)
    {
        if (ladoA <= 0 || ladoB <= 0 || ladoC <= 0)
            throw new ArgumentException("Todos los lados deben ser mayores que cero");
        
        // Verificar que sea un triángulo válido usando la desigualdad triangular
        if (ladoA + ladoB <= ladoC || ladoA + ladoC <= ladoB || ladoB + ladoC <= ladoA)
            throw new ArgumentException("Los lados no forman un triángulo válido");
        
        this.ladoA = ladoA;
        this.ladoB = ladoB;
        this.ladoC = ladoC;
    }
    
    // Propiedades para acceder a los lados de forma controlada (encapsulación)
    public double LadoA
    {
        get { return ladoA; }
        set 
        { 
            if (value <= 0)
                throw new ArgumentException("El lado debe ser mayor que cero");
            ladoA = value; 
        }
    }
    
    public double LadoB
    {
        get { return ladoB; }
        set 
        { 
            if (value <= 0)
                throw new ArgumentException("El lado debe ser mayor que cero");
            ladoB = value; 
        }
    }
    
    public double LadoC
    {
        get { return ladoC; }
        set 
        { 
            if (value <= 0)
                throw new ArgumentException("El lado debe ser mayor que cero");
            ladoC = value; 
        }
    }
    
    // Implementación del método CalcularArea usando la fórmula de Herón
    public override double CalcularArea()
    {
        double semiperimetro = (ladoA + ladoB + ladoC) / 2;
        return Math.Sqrt(semiperimetro * (semiperimetro - ladoA) * 
                        (semiperimetro - ladoB) * (semiperimetro - ladoC));
    }
    
    // Implementación del método CalcularPerimetro sumando los tres lados
    public override double CalcularPerimetro()
    {
        return ladoA + ladoB + ladoC;
    }
    
    // Sobrescritura del método MostrarInformacion para mostrar datos específicos del triángulo
    public override void MostrarInformacion()
    {
        Console.WriteLine("=== TRIÁNGULO ===");
        Console.WriteLine($"Lado A: {ladoA:F2}");
        Console.WriteLine($"Lado B: {ladoB:F2}");
        Console.WriteLine($"Lado C: {ladoC:F2}");
        base.MostrarInformacion();
        Console.WriteLine();
    }
}

// Clase principal para demostrar el uso de las figuras geométricas
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("==========================================================");
        Console.WriteLine("     CALCULADORA DE FIGURAS GEOMÉTRICAS EN C#");
        Console.WriteLine("     Nombre: FigurasGeometricas.cs");
        Console.WriteLine("     Fecha: 07 de Junio, 2025");
        Console.WriteLine("     Hoja: 1");
        Console.WriteLine("==========================================================\n");
        
        try
        {
            // EJEMPLO 1: Creación y uso de un Círculo
            Console.WriteLine("EJEMPLO 1: Círculo con radio 5.0");
            Console.WriteLine("----------------------------------");
            Circulo circulo1 = new Circulo(5.0);
            circulo1.MostrarInformacion();
            
            // EJEMPLO 2: Creación y uso de un Cuadrado
            Console.WriteLine("EJEMPLO 2: Cuadrado con lado 4.0");
            Console.WriteLine("---------------------------------");
            Cuadrado cuadrado1 = new Cuadrado(4.0);
            cuadrado1.MostrarInformacion();
            
            // EJEMPLO 3: Creación y uso de un Rectángulo
            Console.WriteLine("EJEMPLO 3: Rectángulo 6.0 × 3.0");
            Console.WriteLine("---------------------------------");
            Rectangulo rectangulo1 = new Rectangulo(6.0, 3.0);
            rectangulo1.MostrarInformacion();
            
            // EJEMPLO 4: Creación y uso de un Triángulo
            Console.WriteLine("EJEMPLO 4: Triángulo con lados 3, 4, 5");
            Console.WriteLine("---------------------------------------");
            Triangulo triangulo1 = new Triangulo(3.0, 4.0, 5.0);
            triangulo1.MostrarInformacion();
            
            // EJEMPLO 5: Demostración de polimorfismo
            Console.WriteLine("EJEMPLO 5: Uso de polimorfismo con array de figuras");
            Console.WriteLine("----------------------------------------------------");
            FiguraGeometrica[] figuras = {
                new Circulo(2.5),
                new Cuadrado(3.0),
                new Rectangulo(4.0, 2.0),
                new Triangulo(5.0, 5.0, 6.0)
            };
            
            int contador = 1;
            foreach (FiguraGeometrica figura in figuras)
            {
                Console.WriteLine($"Figura #{contador}:");
                figura.MostrarInformacion();
                contador++;
            }
            
            // EJEMPLO 6: Modificación de propiedades (encapsulación en acción)
            Console.WriteLine("EJEMPLO 6: Modificación de propiedades");
            Console.WriteLine("--------------------------------------");
            Circulo circulo2 = new Circulo(1.0);
            Console.WriteLine("Estado inicial del círculo:");
            circulo2.MostrarInformacion();
            
            Console.WriteLine("Cambiando el radio a 3.0...");
            circulo2.Radio = 3.0;
            Console.WriteLine("Estado final del círculo:");
            circulo2.MostrarInformacion();
            
            // EJEMPLO 7: Comparación de áreas
            Console.WriteLine("EJEMPLO 7: Comparación de áreas entre figuras");
            Console.WriteLine("---------------------------------------------");
            Circulo circuloTest = new Circulo(3.0);
            Cuadrado cuadradoTest = new Cuadrado(5.0);
            
            Console.WriteLine($"Área del círculo (radio 3.0): {circuloTest.CalcularArea():F2}");
            Console.WriteLine($"Área del cuadrado (lado 5.0): {cuadradoTest.CalcularArea():F2}");
            
            if (circuloTest.CalcularArea() > cuadradoTest.CalcularArea())
                Console.WriteLine("El círculo tiene mayor área que el cuadrado.");
            else
                Console.WriteLine("El cuadrado tiene mayor área que el círculo.");
            
            Console.WriteLine();
            
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error de argumento: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado: {ex.Message}");
        }
        
        Console.WriteLine("==========================================================");
        Console.WriteLine("Programa finalizado. Presione cualquier tecla para salir...");
        Console.WriteLine("==========================================================");
        Console.ReadKey();
    }
}