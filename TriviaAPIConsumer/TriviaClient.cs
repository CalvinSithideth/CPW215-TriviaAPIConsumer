using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TriviaAPIConsumer
{
    // Trivia API: https://opentdb.com/api_config.php
    public class TriviaClient
    {
        static readonly HttpClient client = new HttpClient();

        // Static constructor; Runs once per class
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-constructors
        static TriviaClient()
        {
            // Initialize all HttpClient settings

            // Base address must end in '/' to use relative paths like in GetAsync()
            // https://stackoverflow.com/questions/23438416/why-is-httpclient-baseaddress-not-working
            client.BaseAddress = new Uri("https://opentdb.com/");
        }

        public async Task<TriviaResponse> GetTriviaQuestions(byte numQuestions)
        {
            HttpResponseMessage response = await client.GetAsync($"api.php?amount={numQuestions}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                TriviaResponse result = JsonConvert.DeserializeObject<TriviaResponse>(data);

                return result;
            }
            else
            {   // If not successful, null is returned
                return null;
            }
        }

        // Difficulty query seems to be bugged in the API
        public async Task<TriviaResponse> GetTriviaQuestions(byte numQuestions, string difficulty)
        {
            HttpResponseMessage response = await client.GetAsync($"api.php?amount={numQuestions}&amp;difficulty={difficulty}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                TriviaResponse result = JsonConvert.DeserializeObject<TriviaResponse>(data);

                return result;
            }
            else
            {   // If not successful, null is returned
                return null;
            }
        }
    }

    // Json Attributes
    // https://www.jerriepelser.com/blog/deserialize-different-json-object-same-class/
    public class Result
    {
        public string category { get; set; }

        [JsonProperty("type")]
        public string QuestionType { get; set; }

        public string difficulty { get; set; }

        [JsonProperty("question")]
        public string QuestionText { get; set; }

        [JsonProperty("correct_answer")]
        public string CorrectAnswer { get; set; }

        [JsonProperty("incorrect_answers")]
        public List<string> IncorrectAnswer { get; set; }
    }

    public class TriviaResponse
    {
        public int response_code { get; set; }
        public List<Result> results { get; set; }
    }
}
