﻿using Newtonsoft.Json;
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
    public class ApiSV
    {
        
        HttpClient client;
        public string url { get; set; }
        StringContent stringContent;

        public ApiSV()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            

            var byteArray = Encoding.UTF8.GetBytes("59ed1d1316d89bb77832946f");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-apikey", Convert.ToBase64String(byteArray));
            client.DefaultRequestHeaders.Add("x-apikey", "59ed1d1316d89bb77832946f");
            


        }

        public String UrlBuilder(String query)
        {
            return "https://testdb-014a.restdb.io/rest/test" + query;
        }

        public String QueryBuilder(String query)
        {
            return "?q=" + query;
        }

        public void HttpBodyBuilder<T>(T obj)
        {
            stringContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

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
    }
}