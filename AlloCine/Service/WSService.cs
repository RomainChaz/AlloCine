using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WSFilms.Models.Entity;

namespace AlloCine.Service
{
    public class WSService
    {

        private static HttpClient client = HttpClientSingleton.getInstance();

        public WSService()
        {

        }

        public static async Task<T_E_COMPTE_CPT> getCompteByMailAsync(String email)
        {
            T_E_COMPTE_CPT compte = new T_E_COMPTE_CPT();

            HttpResponseMessage response = await client.GetAsync(email);
            if (response.IsSuccessStatusCode)
            {
                compte = await response.Content.ReadAsAsync<T_E_COMPTE_CPT>();
            }

            return compte;
        }
    }

    public class HttpClientSingleton
    {
        private static HttpClient client;

        public static HttpClient getInstance()
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:64276/api/Compte/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            return client;
        }
    }
}
