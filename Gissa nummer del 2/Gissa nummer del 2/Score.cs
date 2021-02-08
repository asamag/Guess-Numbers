using System;
using System.Collections.Generic;
using System.Text;

namespace Gissa_nummer_del_2
{
    class Score
    {
        private string name;
        private int guess;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Guess
        {
            get { return guess; }
            set { guess = value; }
        }

        public Score()
        {

        }
        public override string ToString()
        {
            if(Name.Length < 5)
                return $"{Name}\t\t:\t\t{Guess}";
            else
            return $"{Name}\t:\t\t{Guess}";
        }
    }
}
