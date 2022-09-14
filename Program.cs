using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;

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
            CoordinateAndValue[,] laber;
            public Laberinto(int filas, int columnas)
            {
                this.filas = filas;
                this.columnas = columnas;
                laber = new CoordinateAndValue[filas, columnas];
                
            }
            public int NumFilas()
            {
                return this.filas;
            }
            public int NumColumnas()
            {
                return this.columnas;
            }
            public void CrearLaberintoPredefinido()
            {
                //   laberinto= new int[,]{ {1,1,1,1 },{0,1,1,0, },{0,1,1,0 },{0,0,1,1 },{0,0,0,1 } };
                // CoordinateAndValue coordinateAndValue1 = new CoordinateAndValue(0, 0, 1);
                laber = new CoordinateAndValue[,] { { new CoordinateAndValue(0,0,1) , new CoordinateAndValue(0, 1, 1), new CoordinateAndValue(0, 2, 1), new CoordinateAndValue(0, 3, 1) },
                                                         {new CoordinateAndValue(1,0,0) , new CoordinateAndValue(1, 1, 1), new CoordinateAndValue(1, 2, 1), new CoordinateAndValue(1, 3, 0) },
                                                         { new CoordinateAndValue(2,0,0) , new CoordinateAndValue(2, 1, 1), new CoordinateAndValue(2, 2, 1), new CoordinateAndValue(2, 3, 0) },
                                                         { new CoordinateAndValue(3,0,0) , new CoordinateAndValue(3, 1, 0), new CoordinateAndValue(3, 2, 1), new CoordinateAndValue(3, 3, 1) },
                                                         { new CoordinateAndValue(4,0,0) , new CoordinateAndValue(4, 1, 0), new CoordinateAndValue(4, 2, 0), new CoordinateAndValue(4, 3, 1) } };
            }
            public void imprimirLaberinto()
            {
                //imprimr matriz
                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        Console.Write("{0} {1} ", laber[i, j].posX(), laber[i, j].posY());
                    }
                    Console.WriteLine();
                }
            }
            public void Laberinto_Aleatorio()
            {
                
            }
            public void resolverLaberinto()
            {
                Console.WriteLine("Empezando a resolver");
                // econtrar solucion por el metodo stack
                Stack<CoordinateAndValue> Pila1 = new Stack<CoordinateAndValue>();
                Stack<CoordinateAndValue> Pila2 = new Stack<CoordinateAndValue>();
                CoordinateAndValue[,] TemporaryPosition = new CoordinateAndValue[1, 1];
                TemporaryPosition[0, 0] = laber[0,0];
                Pila2.Push(TemporaryPosition[0,0]);
            
                
                while (Pila2.Count != 0)
                {

                    if (laber[0, 0].value() == 0 || laber[filas - 1, columnas - 1].value() == 0)
                    {
                        Console.WriteLine("no hay salida");

                    }
                    else
                    {
                        //  TemporaryPosition[0,0] = Pila2.Pop();
                        // moverse de posicion
                        #region moverse
                        CoordinateAndValue PositionTemporary, next;
                        PositionTemporary = Pila2.Pop();
                        Console.WriteLine($"sacando de de pila 2 {PositionTemporary.posX()},{PositionTemporary.posY()}");

                        if (PositionTemporary.posX() == filas - 1 && PositionTemporary.posY() == columnas - 1)
                        {
                            Console.WriteLine("LLEGAMOS!");
                            while (Pila1.Count != 0)
                            {
                                CoordinateAndValue aux;
                                aux = Pila1.Pop();
                                Console.WriteLine($"El recorrido fue {aux.posX()},{aux.posY()}\n ");
                            }
                            break;
                        }
                        int ElemtosDePila = Pila2.Count;
                        next = PositionTemporary.Arriba();
                        if (EstaAdentroDelMaze(next) && MePuedoMover(next))
                        {


                            if (!Pila2.Contains(laber[next.posX(), next.posY()]))
                            {
                                bool estaAdentro = Pila1.Contains(laber[next.posX(), next.posY()]);
                                if (estaAdentro == false)
                                {
                                    Pila2.Push(laber[next.posX(), next.posY()]);
                                    Console.WriteLine($"Guardando en Pila2 {next.posX()},{next.posY()}\n ");
                                }

                            }

                        }
                        next = PositionTemporary.Abajo();
                        if (EstaAdentroDelMaze(next) && MePuedoMover(next))
                        {

                            if (!Pila2.Contains(laber[next.posX(), next.posY()]))
                            {
                                bool estaAdentro = Pila1.Contains(laber[next.posX(), next.posY()]);
                                if (estaAdentro == false)
                                {
                                    Pila2.Push(laber[next.posX(), next.posY()]);
                                    Console.WriteLine($"Guardando en Pila2 {next.posX()},{next.posY()}\n ");
                                }

                            }
                        }
                        next = PositionTemporary.Derecha();
                        if (EstaAdentroDelMaze(next) && MePuedoMover(next))
                        {



                            if (!Pila2.Contains(laber[next.posX(), next.posY()]))
                            {
                                bool estaAdentro = Pila1.Contains(laber[next.posX(), next.posY()]);
                                if (estaAdentro == false)
                                {
                                    Pila2.Push(laber[next.posX(), next.posY()]);
                                    Console.WriteLine($"Guardando en Pila2 {next.posX()},{next.posY()}\n ");
                                }

                            }
                        }
                        next = PositionTemporary.Izquierda();
                        if (EstaAdentroDelMaze(next) && MePuedoMover(next))
                        {
                            #region prueba de if
                            /*
                            if (Pila1.Contains(next))
                               {
                                   Console.WriteLine("Next esta adentro de pila 1");
                               }
                               if (next.Equals(laber[0, 0]))
                               {
                                   Console.WriteLine("la pila next es7 la posicion inicial");
                               }
                               if (next== laber[0,0])
                               {
                                   Console.WriteLine("la pila next es la posicion inicial");
                               }
                               if (!Pila1.Contains(next))//aqui si acepta que ya hay uno igual adentro
                               {
                                   Console.WriteLine("!Next esta adentro de pila 1");
                               }
                               if (Pila2.Contains(next))
                               {
                                   Console.WriteLine(" next ya esta en pila2 esta adentro");
                               }
                               if (!Pila2.Contains(next))//me dice que no hay uno igual adentro
                               {
                                   Console.WriteLine("!next ya esta en pila2 adentro");
                               }
                               
                            if((Pila1.Contains(laber[next.posX(), next.posY()]) == true)){
                                Console.WriteLine("contine pila-1 a next");
                            }*/
                            #endregion prueba de if

                            if (!Pila2.Contains(laber[next.posX(),next.posY()]))
                            {
                                bool estaAdentro = Pila1.Contains(laber[next.posX(), next.posY()]);
                                if (estaAdentro==false) {
                                    Pila2.Push(laber[next.posX(), next.posY()]);
                                    Console.WriteLine($"Guardando en Pila2 {next.posX()},{next.posY()}\n ");
                                }
                               
                            }
                        }
                        
                        if (ElemtosDePila == Pila2.Count)
                        {
                            Console.WriteLine("Con este camino no llegamos");
                        }
                        else
                        {
                            if (!Pila1.Contains(laber[PositionTemporary.posX(), PositionTemporary.posY()]))
                            {

                                Pila1.Push(laber[PositionTemporary.posX(), PositionTemporary.posY()]);
                                Console.WriteLine($"Metiendo a la pila1 nuestro recorrido {PositionTemporary.posX()},{PositionTemporary.posY()}\n ");
                            }
                        }
                        #endregion fin moverse

                        if (Pila2.Count == 0)
                        {
                            Console.WriteLine("Estas atrapado");
                        }
                    }
                   

                }
                

            }
            public bool EstaAdentroDelMaze(CoordinateAndValue posicion )
            {
                return EstaAdentroDelMaze(posicion.posX(), posicion.posY());
            }
            public bool EstaAdentroDelMaze(int x,int y)
            {
                if (x>=0 && x< filas && y>=0 && y<columnas)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
            public bool MePuedoMover(CoordinateAndValue libre)
            {
                
                return MePuedoMover(libre.posX(),libre.posY());
            }
            public bool MePuedoMover(int x,int y)
            {
                
                if (x>=0 && x < filas && y >= 0 && y < columnas)
                {
                    
                    if (laber[x,y].value()== 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            public bool Contains(CoordinateAndValue c1)
            {
                return c1 == laber[c1.posX(), c1.posY()];
            }
        }
        #endregion Laberinto
        #region Posicion
        public class CoordinateAndValue
        {
            int x, y;
            int v;
            public CoordinateAndValue(int x,int y, int value)
            {
                this.x = x;
                this.y = y;
                v = value;
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
            public CoordinateAndValue Arriba()
            {
                return new CoordinateAndValue(this.x - 1, this.y, this.v);
            }
            public CoordinateAndValue Abajo()
            {
                return new CoordinateAndValue(this.x + 1, this.y, this.v);
            }
            public CoordinateAndValue Derecha()
            {
                return new CoordinateAndValue(this.x, this.y+1, this.v);
            }
            public CoordinateAndValue Izquierda()
            {
                return new CoordinateAndValue(this.x, this.y-1, this.v);
            }
            public static bool operator ==(CoordinateAndValue c1, CoordinateAndValue c2) => c1.v == c2.v && c1.y == c2.y && c1.x == c2.x;
            public static bool operator !=(CoordinateAndValue c1, CoordinateAndValue c2) => c1.v != c2.v || c1.y != c2.y || c1.x != c2.x;
            
        }
        #endregion Posicion

    }
}