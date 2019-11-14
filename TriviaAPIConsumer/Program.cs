using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TriviaAPIConsumer
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Retrieving trivia questions....");

            TriviaClient triviaClient = new TriviaClient();
            TriviaResponse result = await triviaClient.GetTriviaQuestions(3);

            Console.WriteLine("Recieved trivia questions. \n");

            // Print out each question one by one, followed by their answers, then the correct answer
            DisplayQuestions(result.results);

            Console.ReadKey();
        }

        static void DisplayQuestions(List<Result> questionList)
        {
            foreach (var q in questionList)
            {
                Console.WriteLine($"{q.category}\t{q.QuestionType}\t{q.difficulty}");
                Console.WriteLine(q.QuestionText + "\n\n");

                foreach (var answer in q.IncorrectAnswer)
                {
                    Console.WriteLine(answer);
                }
                Console.WriteLine(q.CorrectAnswer);

                Console.WriteLine("Hit a key to show the correct answer");
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine("The correct answer is " + q.CorrectAnswer);
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine("\n\n");
            }
        }
    }
}
