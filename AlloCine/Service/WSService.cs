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

            HttpResponseMessage response = await client.GetAsync(string.Concat("compte?email=", email));
            if (response.IsSuccessStatusCode)
            {
                compte = await response.Content.ReadAsAsync<T_E_COMPTE_CPT>();
            }

            return compte;
        }

        public static async Task<T_E_COMPTE_CPT> updateCompte(T_E_COMPTE_CPT compte)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(string.Concat("compte?id=", compte.CPT_ID), compte);

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
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri(resourceLoader.GetString("WebService"));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            return client;
        }
    }
}
