using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace KanyeAndRonSwanson
{
    class Program
    {
        //POTENTIAL TODO: make each line distinct
        static void Main(string[] args)
        {
            var client = new HttpClient();

            var kanyeURL = "https://api.kanye.rest";
            var ronswanURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            Console.WriteLine("Kanye and Ron: A Play in One Act\n\n");

            Console.WriteLine("<<KANYE rushes in from OFF-STAGE.>>\n");

            for (int i = 0; i < 5; i++)
            {
                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

                var ronswanResponse = client.GetStringAsync(ronswanURL).Result;
                var ronswanQuote = JArray.Parse(ronswanResponse).ToString().Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();

                Console.WriteLine("KANYE: " + kanyeQuote + "\n");
                Console.WriteLine("RON SWANSON: " + ronswanQuote + "\n");
            }

            Console.WriteLine("<<LIGHTS FADE. END OF PLAY.>>");

        }
    }
}
