using System;
using RestSharp;

namespace InstantAnswer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool askAgain = true;

            while (askAgain)
            {
                Console.Out.Write("What is: ");
                string queryInput = Console.In.ReadLine();


                // This is the API we're trying to call into. The base URL is "https://api.duckduckgo.com/". The request parameters are "q" and "format".
                // https://api.duckduckgo.com/?q=Google,%20Inc.&format=xml
                var queryClient = new RestClient("https://api.duckduckgo.com/");

                var queryRequest = new RestRequest();
                queryRequest.AddParameter("q", queryInput);
                queryRequest.AddParameter("format", "xml");

                var queryResponse = queryClient.Execute<DuckDuckGoResponse>(queryRequest);

                var duckDuckGoResponse = queryResponse.Data;

                // Check the response type returned and only output the answer if one is found
                if (duckDuckGoResponse.Type.ToUpper() == "A")
                {
                    Console.Out.WriteLine("Located an answer for {0} @ {1}",
                        duckDuckGoResponse.Heading, duckDuckGoResponse.AbstractSource);
                    Console.Out.WriteLine(duckDuckGoResponse.AbstractText);
                }
                else if (duckDuckGoResponse.Type.ToUpper() == "D")
                {
                    Console.Out.WriteLine("Found more than one match. See {0} @ {1}", duckDuckGoResponse.AbstractSource, duckDuckGoResponse.AbstractURL);
                }
                else
                {
                    Console.Out.WriteLine("Could not find an answer for: {0}", queryInput);
                }

                Console.WriteLine();

                Console.Write("Ask me another (Y/N)?");
                string askAnotherInput = (Console.In.ReadLine() ?? "").ToUpper().Trim();
                askAgain = askAnotherInput == "Y";
                Console.WriteLine();
            }
        }
    }

    public class DuckDuckGoResponse
    {
        public string Type { get; set; } // A=Article, D=Disambiguation
        public string Heading { get; set; }
        public string AbstractText { get; set; }
        public string AbstractSource { get; set; }
        public string AbstractURL { get; set; }
    }
}