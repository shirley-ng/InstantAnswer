using RestSharp;

namespace InstantAnswer.Service
{
    public class QueryService
    {
        public DuckDuckGoResponse Query(string queryInput)
        {
            // This is the API we're trying to call into. The base URL is "https://api.duckduckgo.com/". The request parameters are "q" and "format".
            // https://api.duckduckgo.com/?q=Google,%20Inc.&format=xml
            var queryClient = new RestClient("https://api.duckduckgo.com/");

            var queryRequest = new RestRequest();
            queryRequest.AddParameter("q", queryInput);
            queryRequest.AddParameter("format", "xml");

            IRestResponse<DuckDuckGoResponse> queryResponse = queryClient.Execute<DuckDuckGoResponse>(queryRequest);

            DuckDuckGoResponse duckDuckGoResponse = queryResponse.Data;
            return duckDuckGoResponse;
        }
    }
}