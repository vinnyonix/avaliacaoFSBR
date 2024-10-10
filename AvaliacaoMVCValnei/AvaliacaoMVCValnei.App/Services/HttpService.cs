using AvaliacaoMVCValnei.App.Utils.Http.Constants;
using AvaliacaoMVCValnei.App.Utils.Http.Models;
using Newtonsoft.Json;

namespace AvaliacaoMVCValnei.App.Service
{
    public class HttpService
    {
        public static async Task<IList<Localidade?>> GetIBGEAsync()
        {
            var httpClient = new HttpClient();

            using HttpResponseMessage response = await httpClient.GetAsync(

                string.Format("{0}{1}",
                    HttpConstants.Uri,
                    HttpConstants.Endpoint
                )
            );

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<IList<Localidade?>>(jsonResponse);

            return model;
        }
    }
}
