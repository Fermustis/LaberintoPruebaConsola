using System.Collections;
using System.Runtime.CompilerServices;

namespace LaberintoPruebaConsola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Laberinto laberinto = new Laberinto(5,4);
            laberinto.CrearLaberintoPredefinido();
            laberinto.imprimirLaberinto();
            laberinto.resolverLaberinto();
            

        }
        #region Laberinto
        class Laberinto
        {
            int filas;
            int columnas;
            int[,] laberinto;
            public Laberinto(int filas, int columnas)
            {
                this.filas = filas;
                this.columnas = columnas;
                laberinto = new int[filas, columnas];
                
            }
            public void CrearLaberintoPredefinido()
            {
                laberinto= new int[,]{ {1,1,1,1 },{0,1,1,0, },{0,1,1,0 },{0,0,1,1 },{0,0,0,1 } };

            }
            public void imprimirLaberinto()
            {
                //imprimr matriz
                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        Console.Write("{0} ", laberinto[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            public void Laberinto_Aleatorio()
            {
                
            }
            public void resolverLaberinto()
            {
                Console.WriteLine("donde estoy");
                // econtrar solucion por el metodo stack
                Stack Pila1 = new Stack();
                Stack<int[,]> Pila2 = new Stack<int[,]>();
                int[,] TemporaryPosition = new int[1, 1];
                TemporaryPosition[0, 0] = laberinto[0,0];
                Pila2.Push(laberinto);
                int i = 0, j = 0;

                while (Pila2.Count != 0)
                {

                    if (laberinto[0, 0] == 0 || laberinto[filas - 1, columnas - 1] == 0)
                    {
                        Console.WriteLine("no hay salida");
                        break;
                    }
                    else
                    {
                        int[,] laberintoProvisional = new int[filas,columnas];
                        laberintoProvisional = Pila2.Pop();
                        
                    }

                }

            }
        }
        #endregion Laberinto
        #region Posicion
        class CoordinateAndValue
        {
            int x, y;
            int v;
            CoordinateAndValue(int x,int y, int value)
            {
                this.x = x;
                this.y = y;
                this.v = value;
            }
            public int posX()
            {
                return this.x;
            }
            public int posY()
            {
                return this.y;
            }
            public int value()
            {
                return this.v;
            }
        }
        #endregion Posicion

    }
}