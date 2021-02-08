using System;
using System.Collections.Generic;
using System.Text;

namespace Gissa_nummer_del_2
{
    class GuessNumber
    {
        private static bool runGame;
        private Score gameScore;
        private HighScore scoreList;
        private List<Score> gameSessionScores;
        public GuessNumber()
        {
            gameScore = new Score();
            scoreList = new HighScore();
            gameSessionScores = new List<Score>();
        }
        public void PlayGame(string input)
        {
            runGame = WillPlay(input);
            Console.WriteLine("Ange ditt namn");
            gameScore.Name = Console.ReadLine();
            
            int guess = 0;
            int numberOfguesses = 0;
            

            while (runGame)
            {
                Random random = new Random();
                int numberToGuess = random.Next(1, 101);
                while (guess != numberToGuess)
                {
                    Console.WriteLine("Skriv in en siffra mellan 1-100 följt av enter");
                    int.TryParse(Console.ReadLine(), out guess);
                    numberOfguesses++;
                    if (guess > numberToGuess)
                    {
                        Console.WriteLine("Din gissning är för hög! Försök igen");
                        Console.WriteLine();
                    }
                    else if (guess < numberToGuess)
                    {
                        Console.WriteLine("Din gissning är för låg! Försök igen");
                        Console.WriteLine();
                    }
                }
                Console.WriteLine($"Du gissade rätt! Den hemliga siffran är {numberToGuess}. Du gissade {numberOfguesses} gånger.");
                gameScore.Guess = numberOfguesses;
                
                gameSessionScores.Add(gameScore);
                numberOfguesses = 0;
                
                Console.WriteLine();
                Console.WriteLine("Vill du spela igen? Tryck på valfri tangent. Tryck 0 för att avsluta.");
                runGame = WillPlay(Console.ReadLine());
            }
            scoreList.SaveScore(gameSessionScores);
        }
        public bool WillPlay(string play)
        {
            if(!int.TryParse(play, out int answer) || answer != 0)
            {
                string name = gameScore.Name;
                gameScore = new Score();
                gameScore.Name = name;
                return true;
            }
            return false;
        }
    }
}
