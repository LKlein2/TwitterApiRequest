using JsonClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TwitterApiRequest
{
    public class TwitterRequest
    {


        public static async Task<string> GetAccessToken()
        {
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.twitter.com/oauth2/token ");
            var customerInfo = Convert.ToBase64String(new UTF8Encoding()
                                      .GetBytes("yeEjP9jfgQxFbdj82f130pdze" + ":" + "D6TAJSmye7vycfRFdnNny1mwYWaZQmlc4cfKD2wqlzBzXxqIqq"));
            request.Headers.Add("Authorization", "Basic " + customerInfo);
            request.Content = new StringContent("grant_type=client_credentials",
                                                    Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage response = await httpClient.SendAsync(request);

            string json = await response.Content.ReadAsStringAsync();
            var serializer = await response.Content.ReadAsStringAsync();
            dynamic item = JsonConvert.DeserializeObject(serializer);
            return item["access_token"];
        }

        public static async Task<string> GetTweets(string search, int count, string accessToken = null, long maxId = 0)
        {
            if (accessToken == null)
            {
                accessToken = await GetAccessToken();
            }

            var requestUserTimeline = new HttpRequestMessage(HttpMethod.Get,
                string.Format(@"https://api.twitter.com/1.1/search/tweets.json?q={0}&result_type=recent&count={1}" + (maxId != 0 ? $"&max_id={maxId}" : ""), search, count));
            requestUserTimeline.Headers.Add("Authorization", "Bearer " + accessToken);
            var httpClient = new HttpClient();
            HttpResponseMessage responseUserTimeLine = await httpClient.SendAsync(requestUserTimeline);

            var result = await responseUserTimeLine.Content.ReadAsStringAsync();
            return result;              
        }
    }
}
