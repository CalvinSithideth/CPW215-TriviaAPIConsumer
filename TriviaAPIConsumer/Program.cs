using System;
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

            Console.WriteLine(result.results[0].question);
            Console.WriteLine(result.results[0].incorrect_answers);
            Console.WriteLine(result.results[0].correct_answer);

            Console.ReadKey();
        }
    }
}
