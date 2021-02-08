using System;
using System.Collections.Generic;
using System.Text;


namespace Gissa_nummer_del_2
{
    public class UI
    {
        private HighScore scoreList;
        private List<Score> printList;
        public UI()
        {
            scoreList = new HighScore();
            printList = scoreList.PrintScore();
        }
        public string DrawUI()
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("Välkommen till Gissa Numret!");
            Console.WriteLine("***************************************");
            PrintHighscore();
            Console.WriteLine("Vill du spela? Tryck på valfri tangent. Tryck 0 för att avsluta.");
            return Console.ReadLine();
        }
        private void PrintHighscore()
        {
            if(printList.Count < 1)
            {
                Console.WriteLine("Det är ingen som spelat än! Bli den första att gissa den hemliga siffran");
            }
            else
            {
                foreach(Score s in printList)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
