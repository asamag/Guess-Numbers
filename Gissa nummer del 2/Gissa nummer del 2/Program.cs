using Gissa_nummer_del_2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NET.övning1
{
    class Program
    {
        public static void Main()
        {
            UI ui = new UI();
            string play = ui.DrawUI();
            GuessNumber number = new GuessNumber();
            number.PlayGame(play);
        }

    }
}

