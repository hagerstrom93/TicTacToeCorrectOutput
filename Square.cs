using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TictactestBacke
{
    public class Square
    {
        public string name; //2-bokstavigt namnet för rutan, alltså ex. NE eller CW
        public int status; // Värdet som avgör om rutan är spelad och i såfall av vem
        public List<Position> Positions; //Listan av Positioner som finns i varje Square

        public Square(string name) // Ta emot ett namn för vad varje ruta ska heta
        {
            this.name = name;
            status = 0;
            Positions = new List<Position>(9); // skapa en lista med 9 platser som heter som string inputen
            Position NW = new Position("NW");
            Positions.Add(NW);
            Position NC = new Position("NC");
            Positions.Add(NC);
            Position NE = new Position("NE");
            Positions.Add(NE);
            Position CW = new Position("CW");
            Positions.Add(CW);
            Position CC = new Position("CC");
            Positions.Add(CC);
            Position CE = new Position("CE");
            Positions.Add(CE);
            Position SW = new Position("SW");
            Positions.Add(SW);
            Position SC = new Position("SC");
            Positions.Add(SC);
            Position SE = new Position("SE");
            Positions.Add(SE);
        }

        public Position GetPosition(Player player, Square thesquare, string input) // Hittar rätt position att ändra på.
        {
            foreach (Position position in thesquare.Positions)
            {
                if (input == position.name)
                {
                    position.ChangeStatus(player, position);
                    return position;
                }
            }
            return null; // Bra???
        }

        public int ChangeStatus(Player player, Square thesquare) // Ändrar status på en specifik position. Värdet beror på spelare.
        {
            return thesquare.status += player.status;
        }

        public int WinCondition() // returnerar int eftersom inten ska skickas till det större brädet som skriver ut något. 
        {
            {
                for (int i = 0; i < 7; i += 3) // Vågrätt vinst i ruta
                {
                    if (Positions[i].status != 0 && Positions[i].status == Positions[i + 1].status && Positions[i + 1].status == Positions[i + 2].status && Positions[i + 2].status == Positions[i].status)
                    {
                        return Positions[i].status;
                    }
                }
                for (int i = 0; i < 3; i++) // Lodrätt vinst i ruta
                {
                    if (Positions[i].status != 0 && Positions[i].status == Positions[i + 3].status && Positions[i + 3].status == Positions[i + 6].status && Positions[i + 6].status == Positions[i].status)
                    {
                        return Positions[i].status;
                    }
                }

                if (Positions[0].status != 0 && Positions[0].status == Positions[4].status && Positions[4].status == Positions[8].status && Positions[8].status == Positions[0].status ||
                    Positions[2].status != 0 && Positions[2].status == Positions[4].status && Positions[4].status == Positions[6].status && Positions[6].status == Positions[0].status)
                {
                    return Positions[4].status;
                }
                else
                {
                    return 0;
                }
                
            }
        }
    }
}
