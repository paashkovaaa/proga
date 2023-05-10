using System.Net.Http;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Services;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace booksReviews
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
            _httpclient.BaseAddress = new Uri(_adress);
        }

        public async Task<BookModel> SearchBooksAsync(string query)
        {
            var url = $"/books/v1/volumes?q={query}";
        
            var response = await _httpclient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BookModel>(content);
        
            return result;
        }

        

    }
}


