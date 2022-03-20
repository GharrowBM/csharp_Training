using EXO_02.Helpers;
using EXO_02.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EXO_02.Logic
{
    public class VenueLogic
    {
        public async static Task<List<Venue>> GetVenues(double latitude, double longitude)
        {
            List<Venue> venues = new List<Venue>();

            //var url = Venue.GenerateURL(latitude, longitude);

            //var client = new RestClient(url);
            //var request = new RestRequest();
            //request.Method = Method.Get;
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Authorization", Constants.API_KEY);
            //RestResponse response = await client.ExecuteAsync(request);
            //var json = response.Content.ToString();

            //using (HttpClient client = new HttpClient())
            //{
            //    client.DefaultRequestHeaders.Add("Accept", "application/json");
            //    client.DefaultRequestHeaders.Add("Authorization", Constants.API_KEY);
            //    var response = await client.GetAsync(url);
            //    var json = await response.Content.ReadAsStringAsync();

            //}

            return venues;
        }
    }
}
