using System.Text.Json.Serialization;

namespace automation.imdb.movies.entities
{
    public class MovieDescription
    {
        [JsonPropertyName("data.title.plot.plotText.plaidHtml")]
        public string PlaidHtml { get; set; }
    }
}
