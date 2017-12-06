using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.Http
{
    public class Httphelper
    {
        public static string GetData(string url)
        {
            return GetDataAsync(url).Result;

        }
        public static Task<string> GetDataAsync(string url)
        {
            using (var client = new HttpClient())
            {
                var responseString = client.GetStringAsync(url);
                return responseString;
            }

        }
        public static string PostData(string url, Dictionary<string, object> param)
        {
            return PostDataAsync(url, param).Result;

        }
        public static async Task<string> PostDataAsync(string url, Dictionary<string, object> param)
        {
            using (var client = new HttpClient())
            {
                var values = new List<KeyValuePair<string, string>>();
                foreach (var p in param)
                {
                    values.Add(new KeyValuePair<string, string>(p.Key,p.Value.ToString()));
                }

                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync(url, content);
                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }


        }
    }
}
