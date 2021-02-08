using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Gissa_nummer_del_2;

namespace Gissa_nummer_del_2
{
    class HighScore
    {
        private FileStream fStream;
        private StreamReader sReader;
        private StreamWriter sWriter;
        private List<Score> highScores;
        public HighScore()
        {
            highScores = new List<Score>();
        }
        public bool SaveScore(List<Score> scores)
        {
            CreateFilestream(true);
            bool success = true;
            using (sWriter = new StreamWriter(fStream))
            {
                try
                {
                    foreach (Score x in scores)
                    {
                        sWriter.WriteLine($"{x.Name}-{x.Guess}");
                    }
                }
                catch
                {
                    success = false;
                }
            }
            return success; 
        }
        #region första savescore-försöket
        //public bool SaveScore(List<Score> scores)
        //{
        //    try
        //    {
        //        //Open the File
        //        sWriter = new StreamWriter("C:\\Users\\AsaMa\\OneDrive\\Skrivbord\\HighScore.txt", true, Encoding.ASCII);

        //        foreach (Score x in scores)
        //        {
        //            sWriter.WriteLine($"{x.Name}-{x.Guess}");
        //        }

        //        //close the file
        //        sWriter.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Exception: " + e.Message);
        //        return false;
        //    }
        //    return true;
        //}
        #endregion

        public List<Score> PrintScore()
        {
            CreateFilestream(false);
            using (sReader = new StreamReader(fStream))
            {
                    highScores = new List<Score>();
                    while (sReader.Peek() >= 0)
                    {
                        string score = sReader.ReadLine();
                        string[] splitscore = score.Split('-');
                        string n = splitscore[0];
                        int.TryParse(splitscore[1], out int g);
                        Score s = new Score();
                        s.Name = n;
                        s.Guess = g;
                        highScores.Add(s);
                    }

                    highScores = highScores
                        .OrderBy(s => s.Guess)
                        .ToList<Score>();

                    return highScores;
            }
        }

        private void CreateFilestream(bool write)
        {
            string fileName = "HighScore.txt";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);

            if (write)
            {
                fStream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None);
            }
            else //if read only
            {
                fStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            }
        }
        //if(sReader != null)
        //{
        //    string[] lines = System.IO.File.ReadAllLines(@"C:\\Users\\AsaMa\\OneDrive\\Skrivbord\\HighScore.txt");
        //    //läsa varje rad text i filen, lägga till i en lista
        //    //foreach rad gör om till typen Score och lägg till i listan highScores.Add(score);
        //    foreach (string score in lines)
        //    {
        //        string[] splitscore = score.Split('-');
        //        string n = splitscore[0];
        //        int.TryParse(splitscore[1], out int g);
        //        Score s = new Score();
        //        s.Name = n;
        //        s.Guess = g;
        //        //hur gör jag om till Score-objekt
        //        highScores.Add(s);
        //        //sortera listan redan här? på ngt sätt. kan man använda sorted list minns ej 
        //    }

        //}

    }
}
