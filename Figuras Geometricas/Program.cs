using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras_Geometricas
{
    abstract class FigureGeometrica {
        public abstract string Description();
        public abstract double Area();
    }
    class Cuadrilatero : FigureGeometrica {
        private double baseCuadrilatero;
        private double altura;
        public Cuadrilatero(double baseCuadrilatero, double altura) {
            this.baseCuadrilatero = baseCuadrilatero;
            this.altura = altura;
        }

        public override string Description()
        {
            //If condicional de comparacion de altura con base
            //para determinar si es cuadro o rectangulo
            return "Figura geometrica Cuadrilatero";
            //throw new NotImplementedException();
        }
        public override double Area(){
            return baseCuadrilatero * altura;
            }
    }
    class Triangulo : FigureGeometrica {
        private double baseTriangulo;
        private double altura;

        public Triangulo(double baseTriangulo, double altura) {
            this.baseTriangulo = baseTriangulo;
            this.altura = altura;
        }
        public override string Description()
        {
            return "Figura geometrica Triangulo";
            //throw new NotImplementedException();){ }
        }
        public override double Area()
        {
            return (baseTriangulo * altura) / 2;
            //throw new NotImplementedException();)
        }
    }
    class Circulo : FigureGeometrica {
        private double radio;
        public Circulo(double radio) {
            this.radio = radio;
        }
        //Overrider es el palabra clave para
        //la relacion con la clase abstracta (Principal)
        public override string Description() {
            return "Figura geometrica circulo";
        }
        public override double Area() {
            return (radio * radio) * Math.PI;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seleccione una Figura Geometrica");
            Console.WriteLine("1. Cuadrilatero");
            Console.WriteLine("2. Triangulo");
            Console.WriteLine("3. Circulo");
            Console.WriteLine("Ingrese un numero entero del 1 al 3");
            string input = Console.ReadLine();
            int opcion;
            if (!int.TryParse(input, out opcion))
            {
                Console.WriteLine("Error: Debes Ingresar un numero entero.");
                return;
            }
            else
            {
                FigureGeometrica figura = null;
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese la base del Cuadrilatero");
                        if (!double.TryParse(Console.ReadLine(), out double baseCuadrilatero)) {
                            Console.WriteLine("Error: Debes Ingresar un numero para la base del cuadrilatero.");
                            return;
                        }
                        Console.WriteLine("Ingrese la altura del Cuadrilatero");
                        if (!double.TryParse(Console.ReadLine(), out double altura))
                        {
                            Console.WriteLine("Error: Debes Ingresar un numero para la altura del cuadrilatero.");
                            return;
                        }
                        figura = new Cuadrilatero(baseCuadrilatero, altura);
                        break;
                    case 2:
                        Console.WriteLine("Ingrese la base del triángulo: ");
                        if (!double.TryParse(Console.ReadLine(), out double baseTri))
                        {
                            Console.WriteLine("Error: Entrada inválida para la base.");
                            return;
                        }
                        Console.Write("Ingrese la altura del triángulo: ");
                        if (!double.TryParse(Console.ReadLine(), out double alturaTri))
                        {
                            Console.WriteLine("Error: Entrada inválida para la altura.");
                            return;
                        }
                        figura = new Triangulo(baseTri, alturaTri);
                        break;
                    case 3:
                        Console.Write("Ingrese el radio del círculo: ");
                        if (!double.TryParse(Console.ReadLine(), out double radio))
                        {
                            Console.WriteLine("Error: Entrada inválida para el radio.");
                            return;
                        }
                        figura = new Circulo(radio);
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        return;
                }
                Console.WriteLine(figura.Description());
                Console.WriteLine($"El área es: {figura.Area():F2}");
                Console.ReadKey();
            }
        }
    }
}
