string peonn = "[¡]";
string peonb = "[!]";
string espacio = "[ ]";
string alfilb = "[?]";
string alfiln = "[¿]";
string[,] tablerov = { { "[ ]"  , "[ ]"  ,"[?]"  ,"[ ]"  ,"[ ]"  ,"[?]"  ,"[ ]"  ,"[ ]"  ,},
                       {"[!]","[!]","[!]","[!]","[!]","[!]","[!]","[!]"},
                       { "[ ]"  , "[ ]"  ,"[ ]"  ,"[ ]"  ,"[ ]"  ,"[ ]"  ,"[ ]"  ,"[ ]"  ,},
                        { "[ ]"  , "[ ]"  ,"[ ]"  ,"[ ]"  ,"[ ]"  ,"[ ]"  ,"[ ]"  ,"[ ]"  ,},
                        { "[ ]"  , "[ ]"  ,"[ ]"  ,"[ ]"  ,"[ ]"  ,"[ ]"  ,"[ ]"  ,"[ ]"  ,},
                       { "[ ]"  , "[ ]"  ,"[ ]"  ,"[ ]"  ,"[ ]"  ,"[ ]"  ,"[ ]"  ,"[ ]"  ,},
                       { "[¡]",  "[¡]",  "[¡]",  "[¡]",  "[¡]",  "[¡]",  "[¡]",  "[¡]"},
                        { "[ ]"  , "[ ]"  ,"[¿]"  ,"[ ]"  ,"[ ]"  ,"[¿]"  ,"[ ]"  ,"[ ]"  ,}
                     };
char cerrar = ' ';
while (cerrar != 's')
{
    Console.BackgroundColor = ConsoleColor.White;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("====AJEDREZ====");
    Console.WriteLine("Quiere jugar?  \n[1]Si          \n[2]No          ");
    char opcion = char.Parse(Console.ReadLine());
    switch (opcion)
    {
        case '1':
            Imprimirtablero();
            break;

        case '2':
            cerrar = 's';
            break;

        default:
            Console.WriteLine("Ingrese una opcion valida");
            break;
    }
    Movimientoblanco();
}
void Imprimirtablero()
{
    Console.Clear();
    Console.BackgroundColor=ConsoleColor.DarkGray;
    ConsoleColor[] colores = { ConsoleColor.Black, ConsoleColor.White };
    int k = 0;
    int fila = 1;
    Console.WriteLine("  1  2  3  4  5  6  7  8 ");
    for (int i = 0; i <= 7; i++)
    {
        Console.Write(fila);
        for (int j=0; j <= 7;j++)
        {
            if(i % 2 == 0)
            {
                Console.ForegroundColor = colores[j % 2];
            }
            else
            {
                Console.ForegroundColor = colores[(j + 1) % 2];
            }
            Console.Write(tablerov[i, j]);
        }                    
        Console.WriteLine();
        fila++;
    }
}
void Movimientoblanco()
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Turno:Jugador Blanco");
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("Ingresa que la columna de la pieza que quiere mover");
    int columna = int.Parse(Console.ReadLine());
    columna = columna - 1;
    Console.WriteLine("Ingresa que la fila de la pieza que quiere mover");
    int fila = int.Parse(Console.ReadLine());
    fila--;
    string piezaSeleccionada = tablerov[fila, columna];
    switch(piezaSeleccionada)
    {

        //piezas prohibidas
        case "[ ]":
            Console.WriteLine("Casilla vacia, intentalo de nuevo");
            Movimientoblanco();
            break;
        case "[¡]":
            Console.WriteLine("Pieza del contrincante, intentalo de nuevo");
            Movimientoblanco();
            break;
        case "[¿]":
            Console.WriteLine("Pieza del contrincante, intentalo de nuevo");
            Movimientoblanco();
            break;
            //Tiene que haber un case con las piezas negras
    }
    //CalcularPosicionesMovibles();
    Console.WriteLine("Ingresa que la columna a donde mover");
    int columnaDestino = int.Parse(Console.ReadLine());
    columnaDestino--;
    Console.WriteLine("Ingresa que la fila a donde mover");
    int filaDestino = int.Parse(Console.ReadLine());
    filaDestino--;
    string posiblePieza = tablerov[filaDestino, columnaDestino];

    //comparacion para el movimiento de peonblanco
    string peonavanza = tablerov[filaDestino - 1, columnaDestino];
    //comparacion para el primer movimiento de peonblanco
    string peonavanza2 = tablerov[filaDestino-2, columnaDestino];
   
   
    if (posiblePieza == espacio||posiblePieza==peonn||posiblePieza==alfiln)
    {
        //peon
        if(piezaSeleccionada==peonb)
        {
          
            if (peonavanza==peonb)
            {
                tablerov[fila, columna] = espacio;
                tablerov[filaDestino, columnaDestino] = piezaSeleccionada;
                Imprimirtablero();
                MovimientoNegro();
            }
        
            if (peonavanza2 == tablerov[1,columna])
            {
                tablerov[fila, columna] = espacio;
                tablerov[filaDestino, columnaDestino] = piezaSeleccionada;
                Imprimirtablero();
                MovimientoNegro();
            }
            
                //peon come
                string peoncome = tablerov[filaDestino - 1, columnaDestino - 1];
                if (peoncome == peonb && posiblePieza==peonb || peoncome == alfiln&&posiblePieza==alfiln)
                {
                    tablerov[fila, columna] = espacio;
                    tablerov[filaDestino, columnaDestino] = piezaSeleccionada;
                    Imprimirtablero();
                    MovimientoNegro();
                }

            



            Console.WriteLine("El peon blanco no puede avanzar mas o hacia atras");
                Movimientoblanco();
            

        }

        //alfil
        if(piezaSeleccionada == alfilb)
        {
            tablerov[fila, columna] = espacio;
            tablerov[filaDestino, columnaDestino] = piezaSeleccionada;
            Imprimirtablero();
            MovimientoNegro();
        }
       /* tablerov[fila, columna] = espacio;
        tablerov[filaDestino, columnaDestino] = piezaSeleccionada;
        Imprimirtablero();
        MovimientoNegro();*/
    }
    else
    {
        Console.WriteLine("Error, reintentalo");
        Movimientoblanco();
    }
}
void MovimientoNegro()
{
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("Turno:Jugador Negro  ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Ingresa que la columna de la pieza que quiere mover");
    int columna = int.Parse(Console.ReadLine());
    columna = columna - 1;
    Console.WriteLine("Ingresa que la fila de la pieza que quiere mover");
    int fila = int.Parse(Console.ReadLine());
    fila--;
    string piezaSeleccionada = tablerov[fila, columna];
    switch (piezaSeleccionada)
    {
        case "[ ]":
            Console.WriteLine("Casilla vacia, intentalo de nuevo");
            MovimientoNegro();
            break;
        case "[!]":
            Console.WriteLine("Pieza del contrincante, intentalo de nuevo");
            MovimientoNegro();
            break;
            //Tiene que haber un case con las piezas blancas
    }
    //CalcularPosicionesMovibles();
    Console.WriteLine("Ingresa que la columna a donde mover");
    int columnaDestino = int.Parse(Console.ReadLine());
    columnaDestino--;
    Console.WriteLine("Ingresa que la fila a donde mover");
    int filaDestino = int.Parse(Console.ReadLine());
    filaDestino--;
    string posiblePieza = tablerov[filaDestino, columnaDestino];
    if (posiblePieza == espacio)
    {
        tablerov[fila, columna] = espacio;
        tablerov[filaDestino, columnaDestino] = piezaSeleccionada;
        Imprimirtablero();
        Movimientoblanco();
    }
    else
    {
        Console.WriteLine("Error, reintentalo");
        MovimientoNegro();
    }
}