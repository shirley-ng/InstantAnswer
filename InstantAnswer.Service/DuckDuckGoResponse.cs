using System.Collections.Generic;

namespace InstantAnswer.Service
{
    public class DuckDuckGoResponse
    {
        public string Type { get; set; } // A=Article, D=Disambiguation
        public string Heading { get; set; }
        public string AbstractText { get; set; }
        public string AbstractSource { get; set; }
        public string AbstractURL { get; set; }
        public string Image { get; set; }
        public List<RelatedTopic> RelatedTopics { get; set; }
    }
}