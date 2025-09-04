using System;

namespace Figuras_Geometricas
{
    abstract class FiguraGeometrica
    {
        public abstract string Descripcion();
        public abstract double Area();
        public virtual void MostrarInformacion()
        {
            Console.WriteLine(Descripcion());
            Console.WriteLine($"Área: {Area():F2} unidades cuadradas");
        }
    }

    class Cuadrilatero : FiguraGeometrica
    {
        private double baseCuadrilatero;
        private double altura;

        public Cuadrilatero(double baseCuadrilatero, double altura)
        {
            if (baseCuadrilatero <= 0 || altura <= 0)
                throw new ArgumentException("Las dimensiones deben ser valores positivos");

            this.baseCuadrilatero = baseCuadrilatero;
            this.altura = altura;
        }

        public override string Descripcion()
        {
            if (baseCuadrilatero == altura)
                return "Figura geométrica: Cuadrado";
            else
                return "Figura geométrica: Rectángulo";
        }

        public override double Area()
        {
            return baseCuadrilatero * altura;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Base: {baseCuadrilatero}, Altura: {altura}");
        }
    }

    class Triangulo : FiguraGeometrica
    {
        private double baseTriangulo;
        private double altura;

        public Triangulo(double baseTriangulo, double altura)
        {
            if (baseTriangulo <= 0 || altura <= 0)
                throw new ArgumentException("Las dimensiones deben ser valores positivos");

            this.baseTriangulo = baseTriangulo;
            this.altura = altura;
        }

        public override string Descripcion()
        {
            return "Figura geométrica: Triángulo";
        }

        public override double Area()
        {
            return (baseTriangulo * altura) / 2;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Base: {baseTriangulo}, Altura: {altura}");
        }
    }

    class Circulo : FiguraGeometrica
    {
        private double radio;

        public Circulo(double radio)
        {
            if (radio <= 0)
                throw new ArgumentException("El radio debe ser un valor positivo");

            this.radio = radio;
        }

        public override string Descripcion()
        {
            return "Figura geométrica: Círculo";
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(radio, 2);
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Radio: {radio}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== CALCULADORA DE ÁREAS DE FIGURAS GEOMÉTRICAS ===");
                Console.WriteLine("Seleccione una Figura Geométrica");
                Console.WriteLine("1. Cuadrilátero");
                Console.WriteLine("2. Triángulo");
                Console.WriteLine("3. Círculo");
                Console.Write("Ingrese un número entero del 1 al 3: ");

                string input = Console.ReadLine();
                if (!int.TryParse(input, out int opcion) || opcion < 1 || opcion > 3)
                {
                    Console.WriteLine("Error: Debe ingresar un número entero válido entre 1 y 3.");
                    return;
                }

                FiguraGeometrica figura = null;

                switch (opcion)
                {
                    case 1:
                        figura = CrearCuadrilatero();
                        break;
                    case 2:
                        figura = CrearTriangulo();
                        break;
                    case 3:
                        figura = CrearCirculo();
                        break;
                }

                if (figura != null)
                {
                    Console.WriteLine("\n=== RESULTADOS ===");
                    figura.MostrarInformacion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nPresione cualquier tecla para salir...");
                Console.ReadKey();
            }
        }

        static Cuadrilatero CrearCuadrilatero()
        {
            Console.Write("Ingrese la base del cuadrilátero: ");
            if (!double.TryParse(Console.ReadLine(), out double baseFigura) || baseFigura <= 0)
                throw new ArgumentException("Debe ingresar un número válido y positivo para la base");

            Console.Write("Ingrese la altura del cuadrilátero: ");
            if (!double.TryParse(Console.ReadLine(), out double altura) || altura <= 0)
                throw new ArgumentException("Debe ingresar un número válido y positivo para la altura");

            return new Cuadrilatero(baseFigura, altura);
        }

        static Triangulo CrearTriangulo()
        {
            Console.Write("Ingrese la base del triángulo: ");
            if (!double.TryParse(Console.ReadLine(), out double baseFigura) || baseFigura <= 0)
                throw new ArgumentException("Debe ingresar un número válido y positivo para la base");

            Console.Write("Ingrese la altura del triángulo: ");
            if (!double.TryParse(Console.ReadLine(), out double altura) || altura <= 0)
                throw new ArgumentException("Debe ingresar un número válido y positivo para la altura");

            return new Triangulo(baseFigura, altura);
        }

        static Circulo CrearCirculo()
        {
            Console.Write("Ingrese el radio del círculo: ");
            if (!double.TryParse(Console.ReadLine(), out double radio) || radio <= 0)
                throw new ArgumentException("Debe ingresar un número válido y positivo para el radio");

            return new Circulo(radio);
        }
    }
}