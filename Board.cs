using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TictactestBacke
{
    public class Board
    {
        List<Square> TheBoard;

        public Board() // Board ska innehålla en lista ELLER 2D array som innehåller 9 positioner, en för varje ruta.
        {
            TheBoard = new List<Square>(9);
            Square NW = new Square("NW");
            TheBoard.Add(NW);
            Square NC = new Square("NC");
            TheBoard.Add(NC);
            Square NE = new Square("NE");
            TheBoard.Add(NE);
            Square CW = new Square("CW");
            TheBoard.Add(CW);
            Square CC = new Square("CC");
            TheBoard.Add(CC);
            Square CE = new Square("CE");
            TheBoard.Add(CE);
            Square SW = new Square("SW");
            TheBoard.Add(SW);
            Square SC = new Square("SC");
            TheBoard.Add(SC);
            Square SE = new Square("SE");
            TheBoard.Add(SE);
        }

        public Square GetSquare(Player player, Board board, string input) // Tar emot namnet på en square, kollar igenom listan TheBoard efter en Square med detta namn,
        {                                                               // om det matchar, kör GetPosition på denna square.
            foreach (Square square in board.TheBoard)
            {
                if (input == square.name)
                {
                    square.ChangeStatus(player, square);
                    return square;
                }    
            }
            return null; /// Bra+???
        }

        // Board ska känna av ifall 3 av dess squares som är i rad är ifyllda av samma spelare, och då deklarera vinst

        public int WinCondition(List<Square> list) // returnerar int eftersom inten ska skickas till det större brädet som skriver ut något. 
        {
            {
                for (int i = 0; i < 7; i += 3) // Vågrätt vinst i ruta
                {
                    if (list[i].status != 0 && list[i].status == list[i + 1].status && list[i + 1].status == list[i + 2].status && list[i + 2].status == list[i].status)
                    {
                        return list[i].status;
                    }
                }
                for (int i = 0; i < 3; i++) // Lodrätt vinst i ruta
                {
                    if (list[i].status != 0 && list[i].status == list[i + 3].status && list[i + 3].status == list[i + 6].status && list[i + 6].status == list[i].status)
                    {
                        return list[i].status;
                    }
                }

                if (list[0].status != 0 && list[0].status == list[4].status && list[4].status == list[8].status && list[8].status == list[0].status ||
                    list[2].status != 0 && list[2].status == list[4].status && list[4].status == list[6].status && list[6].status == list[0].status)
                {
                    return list[4].status;
                }
                return 0;
            }
        }
    }
}
