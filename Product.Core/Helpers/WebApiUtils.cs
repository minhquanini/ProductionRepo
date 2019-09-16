using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core.Helpers
{
    public class WebApiUtils
    {
        public static async Task<T> GetWebApi<T>(string apiUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(data);
                        return result;
                    }
                    return (T)Convert.ChangeType(apiUrl, typeof(T));
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<bool> PostWebApi<T>(string apiUrl, T model)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    string stringData = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                    var contentData = new StringContent(stringData, Encoding.UTF8,"application/json");
                    HttpResponseMessage response = await client.PostAsync(apiUrl, contentData);
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
