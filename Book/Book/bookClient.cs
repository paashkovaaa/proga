using System.Net.Http;
using System.Web;
using Newtonsoft.Json;

namespace Book
{
    public class bookClient
    {
        private HttpClient _httpclient;
        public static string _apikey;
        public static string _adress;

        public bookClient()
        {
            _httpclient = new HttpClient();
            _apikey = Constants.apiKey;
            _adress = Constants.adress;
            _httpclient.BaseAddress = new Uri(_apikey);
        }

        public async Task<IEnumerable<BookModel>> SearchBooksAsync(string query)
        {
            var url = $"{_apikey}{Constants.SearchEndpoint}?q={query}&key={_apikey}";

            var response = await _httpclient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var searchResult = JsonConvert.DeserializeObject<BookModel>(json);
                return searchResult?.Items;
            }

            return null;
        }
        //public class SearchResult
        //{
        //    [JsonProperty("kind")]
        //    public string Kind { get; set; }

        //    [JsonProperty("totalItems")]
        //    public int TotalItems { get; set; }

        //    [JsonProperty("items")]
        //    public List<BookModel> Items { get; set; }
        //}
        
    }
}
