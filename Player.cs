using System;
using System.Collections.Generic;
using System.Text;

namespace TictactestBacke
{
    public class Player
    {
        public string Name {  get; private set; }
        public int status;
        public List<Square> WonSquares;

        public Player(string name)
        {
            WonSquares = new List<Square>(0);
            this.Name = name;
            
            if (name == "X")
            {
                status = 1;
            }
            else if (name == "O")
            {
                status = 2;
            }
        }       
    }
}
