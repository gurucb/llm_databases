using com.sun.corba.se.impl.protocol.giopmsgheaders;
using javax.management.loading;
using Newtonsoft.Json;
using System.Net.Http;


namespace WebSyntheticGPTKQL.Builder
{
    public class SQLExecutor : QueryExecutor
    {
        public override async Task<String> executeQuery(string queryType, string query)
        {
            String results = "";

            Dictionary<string, string> values = new Dictionary<string, string>();
            values["Type"] = queryType;
            values["Query"] = query.Replace("\n", " ");

            using (HttpClient client = new HttpClient())
            {

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8000/getData");
                var content = new StringContent(JsonConvert.SerializeObject(values),System.Text.Encoding.UTF8,"application/json");
                var response = await client.PostAsync("http://localhost:8000/getData", content);
                var responseString = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    results = await response.Content.ReadAsStringAsync();
                }
            }

            

            return results;
        }
    }
}
