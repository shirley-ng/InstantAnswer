using System;
using InstantAnswer.Service;

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

                var queryService = new QueryService();
                DuckDuckGoResponse duckDuckGoResponse = queryService.Query(queryInput);

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
}