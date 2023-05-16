using Microsoft.AspNetCore.Server.IIS.Core;

namespace api_call_HttpClient.Models
{
    public class PostModel
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        List<PostModel> pList = new List<PostModel>();

        public List<PostModel> GetPostData()
        {
            string url = "https://jsonplaceholder.typicode.com/posts";

            HttpClient client = new HttpClient();


            //we have to make the calling environment common for all the client,
            //some client will use Chrome, some, IE, some android, some MacOS, Iphone, desktop etc, they have all different default data calling format
            //eg. IE has JSON, Chrome has XML, desktop app has binary, we have to remove this default for our site, and make JSON as data format

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var make_a_call = client.GetAsync(url).Result;
            if (make_a_call.IsSuccessStatusCode)
            {
                var data = make_a_call.Content.ReadAsAsync<List<PostModel>>();

                 data.Wait();
                pList = data.Result;
                return pList;
            }
            else
            {
                throw new Exception("Could not get data, please contact admin");
            }

        }
    } 
}
