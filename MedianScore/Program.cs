using System;
using System.Collections.Generic;


namespace MedianScore
{
    class Program
    {
        static void Main(string[] args)
        {
            const int LengthLimit = 5 * 10 * 10 * 10 * 10;
            const int ScoreLimit = 10 * 10 * 10 * 10 * 10 * 10;

            List<int> scores = new List<int>();
            List<int> medians = new List<int>();

            int numberOfGrades = 0;
            while (numberOfGrades < LengthLimit)
            {
                Console.WriteLine("Enter a new score: ");

                int current = -1;

                //read user input and check the Guaranteed Constraints
                if (int.TryParse(Console.ReadLine(), out current) && current >= 0 &&
                    current <= ScoreLimit)
                {
                    scores.Add(current);
                    Console.WriteLine("Current array of scores: ");
                    PrintScores(scores);

                    Console.WriteLine("Current array of medians: ");
                    medians = MedianScores(scores, medians);
                    PrintScores(medians);

                    numberOfGrades++;
                }
                else
                {
                    Console.WriteLine("A score must be an integer in range [0 - 1000000].");
                }
            }
        }

        private static List<int> MedianScores(List<int> scores, List<int> medians)
        {
            scores.Sort();

            int medianIndex = scores.Count / 2;
            int medianValue = -1;

            //if number of scores is even, get the ceiling of the average of the middle two scores
            if(scores.Count%2 ==0)
            {
                medianValue = (int)Math.Ceiling(
                    (scores[medianIndex - 1] + scores[medianIndex]) / 2.0);
            }
            //number of scores must be odd here, get the score in the middle of the list
            else
            {
                medianValue = scores[medianIndex];
            }

            medians.Add(medianValue);
            return medians;
        }

        //prints a list of integers in this format: [100, 20, 50, 70, 45]
        private static void PrintScores(List<int> scores)
        {
            char[] trim = { ' ', ',' };
            string result = "[";

            foreach(int score in scores)
            {
                result += score.ToString() + ", ";
            }

            result = result.TrimEnd(trim);
            result += "]\n";

            Console.WriteLine(result);
        }
    }
}
