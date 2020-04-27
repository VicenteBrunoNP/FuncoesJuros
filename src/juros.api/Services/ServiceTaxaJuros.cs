using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RestSharp;
using System;

namespace juros.api.Services
{
    public static class ServiceTaxaJuros
    {
        public static double GetTaxaJuros()
        {
            double resp;

            try
            {
                var client = new RestClient("http://localhost:5000/taxaJuros");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);

                resp = Convert.ToDouble(response.Content.Replace(".",","));
            }
            catch (Exception)
            {
                throw new Exception();
            }               

            return resp;
           
        }
    }
}
