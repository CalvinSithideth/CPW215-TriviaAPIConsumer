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
            string result = await triviaClient.GetTriviaQuestions();

            Console.WriteLine("Recieved trivia questions. \n");

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
