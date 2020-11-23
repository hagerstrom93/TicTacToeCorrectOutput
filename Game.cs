using System;
using System.Collections.Generic;
using System.Text;

namespace TictactestBacke
{
    public class Game
    {
        Board TheBoard;
        string winner;
        int index;
        
        public Game() // Konstruktor för nytt Game. 1 bräde och 2 spelare
        {
            index = -1;
        }     
        
        public Board GetList()
        {
            return TheBoard;    
        }

        public Player XorO(Player player1, Player player2) // FÖrsök till metod att byta plats på spelarna för att köra RunGame
        {
            if (index % 2 != 0)
            {
                index++;
                return player1;
            }
            else
            {
                index++;
                return player2;
            }
        }

        
        public void RunGame(Player player1, Player player2, Board board, string input) // Kör programmet på hela argumentet som passas in för att starta spelet, lång string
        {
            string[] arr = input.Split(',', StringSplitOptions.RemoveEmptyEntries); // splittar stringen till koordinater med 2 värden, tex NE.SW
            List<string> ReturnList = new List<string>();
            foreach (string DoubleCoord in arr)
            {
                Player player = XorO(player1, player2); // Etablerar vilken spelare som ska få göra draget för varje foreach iteration
                string[] temp = DoubleCoord.Trim().Split('.');  // Splittar koordinaten till en för square och en för position
                Square square = board.GetSquare(player, board, temp[0]); // Hämtar rätt Square att göra move i utifrån första delen av dubbelkoordinaten
                Position position = square.GetPosition(player, square, temp[1]); // Hämtar rätt position och ändrar dess status till samma som spelaren vars tur det är
                
                if (square.WinCondition() > 0) // Ifall en ruta är vunnen är rutans status samma som spelarens och därmed över 0.
                {
                    player.WonSquares.Add(square); // Denna ruta läggs då till i spelarens lista av vunna rutor
                }
                if (player.WonSquares.Count > 2) //Ifall spelaren har fler än 2 vunna rutor 
                {
                    if (board.WinCondition(player.WonSquares) > 0) // Kollar igenom current spelares WonSquares och om 3 finns i rad skickar den tillbaka en siffra som motsvarar spelarens status
                    {
                        foreach (Square won in player.WonSquares) // kollar igenom alla vunna rutor hos spelarens vunna rutor
                        {
                            Console.WriteLine(won.name);  
                        }
                    }
                }
            }
        }
    }
}
