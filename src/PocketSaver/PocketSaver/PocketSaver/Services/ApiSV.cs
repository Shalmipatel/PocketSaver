using Newtonsoft.Json;
using PocketSaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PocketSaver.Services
{
    /// <summary>
    /// Class for the Api Service for the entire PocketSaver Application. In this service, GET, POST, PUT, and DELETE Methods are defined in a 
    /// generic form for whatever Object the Database will return.
    /// </summary>
    public class ApiSV
    {
        /// <summary>
        /// Initializing the HTTP client, url, and StringContent that is to be used for the service.
        /// </summary>
        HttpClient client;
        public string url { get; set; }
        StringContent stringContent;

        /// <summary>
        /// Constructor for the ApiSV which constructs the new HTTP Client and adds the default headers.
        /// </summary>
        public ApiSV()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            
            client.DefaultRequestHeaders.Add("x-apikey", "59ed1d1316d89bb77832946f");
            
        }

        /// <summary>
        /// Method used to create the URL for the ApiSV
        /// </summary>
        /// <param name="query">String which is added to the end of the string for additional database queries</param>
        /// <returns>String for the final url.</returns>
        public String UrlBuilder(String query)
        {
            return "https://testdb-014a.restdb.io/rest/test" + query;
        }

        /// <summary>
        /// Method used to create a query to the database.
        /// </summary>
        /// <param name="query">String for the query parameters to be added to the url.</param>
        /// <param name="aggregate">String for the aggregate queries to be added to the url.</param>
        /// <returns>Final string with all query parameters to the database.</returns>
        public String QueryBuilder(String query, String aggregate)
        {
            return "?q={" + query + "}" + aggregate;
        }

        /// <summary>
        /// Method used to create the HttpBody of the POST Api request.
        /// </summary>
        /// <typeparam name="T">T is a generic object to be used in the HttpBody</typeparam>
        /// <param name="obj">T object which will be serialized into a StringContent object.</param>
        public void HttpBodyBuilder<T>(T obj)
        {
            stringContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        /// <summary>
        /// Api GET Request method.
        /// </summary>
        /// <typeparam name="T">Generic type T</typeparam>
        /// <returns>T object retrieved from the Api request.</returns>
        public async Task<T> Get<T>()
        {
            T data = default(T);
            client.BaseAddress = new Uri(String.Format(url));

            try
            {
                var response = await client.GetAsync(client.BaseAddress);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    data = JsonConvert.DeserializeObject<T>(Convert.ToString(content));

                }
                else
                {
                    throw new Exception("Could not retrieve data");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return data;
        }

        /// <summary>
        /// Api POST Request
        /// </summary>
        /// <typeparam name="T">Model that the POST Request will map to.</typeparam>
        /// <returns>T Object after successfully posting object to the Database.</returns>
        public async Task<T> Post<T>()
        {
            T data = default(T);

            using(client)
            {
                client.BaseAddress = new Uri(String.Format(url));

                var response = await client.PostAsync(client.BaseAddress, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    data = JsonConvert.DeserializeObject<T>(Convert.ToString(content));

                    return data;
                } else
                {
                    throw new Exception("Returned Null");
                }
            }
        }

        /// <summary>
        /// Api PUT Request
        /// </summary>
        /// <typeparam name="T">Model that the PUT Request will map to.</typeparam>
        /// <returns>Object T that is put into the database.</returns>
        public async Task<T> Put<T>()
        {
            T result = default(T);

            using (client)
            {
                client.BaseAddress = new Uri(String.Format(url));
                var response = await client.PutAsync(client.BaseAddress, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    result = JsonConvert.DeserializeObject<T>(Convert.ToString(content));

                } else
                {
                    throw new Exception("Returned Null");
                }
                return result;
            }
        }

        /// <summary>
        /// Api DELETE Request
        /// </summary>
        /// <typeparam name="T">Model that the DELETE request will map to.</typeparam>
        /// <returns>T Object that will be deleted by the Api Delete request.</returns>
        public async Task<T> Delete<T>()
        {
            T result = default(T);

            using (client)
            {
                client.BaseAddress = new Uri(String.Format(url));
                var response = await client.DeleteAsync(client.BaseAddress);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    result = JsonConvert.DeserializeObject<T>(Convert.ToString(content));
                } else
                {
                    throw new Exception("Returned Null");
                }
                return result;
            }
        }
    }
}
