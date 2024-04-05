using System;

namespace sesion7herencia
{

    class calculadora
    {
        private string marca { get; set; }
        private string serie { get; set; }
        
        public calculadora(string marca, string serie)
        {
            this.marca = marca;
            this.serie = serie;
        }

        public double sumar(double a, double b)
        {
            return a + b;
        }
        public double resta(double a, double b)
        {
            return a - b;
        }

        public double multiplicacion(double a, double b)
        {
            return a * b;
        }

        public double division(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("No se puede dividir");
            }
            return a / b;
        }
    }

    class CalculadoraCientifica : calculadora
    {
        public CalculadoraCientifica(string marca, string serie) : base(marca, serie) { }
        
        public double Potencia(double BaseNum, double exponente)
        {
            return Math.Pow(BaseNum ,exponente);
        }

        public double Raiz(double numero)
        {
            return Math.Sqrt(numero);
        }

        public double Modulo(double dividendo, double divisor)
        {
            return dividendo % divisor;
        }

        public double Logaritmo(double numero, double baseLog)
        {
            return Math.Log(numero,baseLog);
        }

    }


    class Progam
    {
        public static void Main(String[] args)
        {

            calculadora CalculadoraBasiico = new calculadora("Texas", "915");

            Console.WriteLine("Suma: " + CalculadoraBasiico.sumar(5,3));
            Console.WriteLine("Resta: " + CalculadoraBasiico.resta(5, 3));
            Console.WriteLine("Multiplicacion: " + CalculadoraBasiico.multiplicacion(5, 3));
            Console.WriteLine("Division: " + CalculadoraBasiico.division(5, 3));

            CalculadoraCientifica CalculadoraAvanzada = new CalculadoraCientifica("PH","576");

            Console.WriteLine("Potencia: " + CalculadoraAvanzada.Potencia(2,3));
            Console.WriteLine("Raiz: " + CalculadoraAvanzada.Raiz(25));
            Console.WriteLine("Modulo: " + CalculadoraAvanzada.Potencia(10, 3));
            Console.WriteLine("Logaritmo: " + CalculadoraAvanzada.Potencia(100, 10));
        }
    }
}