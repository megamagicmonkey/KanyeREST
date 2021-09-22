using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace KanyeREST
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var kanyeURL = "https://api.kanye.rest/";
            

            var swansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            //.ToString().Replace('[', ' ').Replace(']', ' ').Trim();
            
            
            for (int i = 0; i < 5; i++)
            {

                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

                var swansonResponse = client.GetStringAsync(swansonURL).Result;
                var swansonQuote = JArray.Parse(swansonResponse);

                Console.WriteLine("The Kanye says:");
                Console.WriteLine(kanyeQuote);
                Console.WriteLine("The Ron retorts:");
                Console.WriteLine(swansonQuote[0]);
                

            }
        }
    }
}
