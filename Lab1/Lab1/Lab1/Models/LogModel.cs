using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models
{
    public class LogModel
    {

    }

    public class LogRequest : Request
    {
        public static async Task<LogRequest> InsertLogAsync(string message)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri uri = new Uri("http://23.96.107.11/MobileInterface/api/BaseCore/InsertLog");

                var json = JsonConvert.SerializeObject(new
                {
                    CultureInfo = "ES-CR",
                    Message = message,
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(uri, content);

                string ans = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<LogRequest>(ans);


            }
        }
    }
}
