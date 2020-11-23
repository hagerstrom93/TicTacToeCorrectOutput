using System;

namespace TictactestBacke
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                
                Board TheBoard = new Board();
                Player player1 = new Player("X");
                Player player2 = new Player("O");
                Game TicTacToe = new Game();
                TicTacToe.RunGame(player1, player2, TheBoard, "NW.CC,NC.CC,NW.NW,NE.CC,NW.SE,CE.CC,CW.CC,SE.CC,CW.NW,CC.CC,CW.SE, CC.NW,CC.SE, CE.NW,SW.CC, CE.SE,SW.NW, SE.SE,SW.SE");
                
                
                
                
            }
        }
    }
}
