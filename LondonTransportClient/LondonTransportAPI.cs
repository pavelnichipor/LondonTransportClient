using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using Tfl.Api.Presentation.Entities;

namespace LondonTransportClient
{
    public class LondonTransportApi
    {
        private const string AppId = "b33d3ede";
        private const string AppKey = "c942f0e5cf4ab318421a9cad61fc0ae4";
        private const string ApiRootUrl = @"https://api.tfl.gov.uk";

        public RouteSearchResponse StationSearch(string term)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient($"{ApiRootUrl}/Line/Search/{term}?app_id={AppId}&app_key={AppKey}");
            var request = new RestRequest("/", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = (RestResponse)client.Execute(request);
            var content = response.Content;
            var deserialised = JsonConvert.DeserializeObject<RouteSearchResponse>(content);
            return deserialised;
        }

        public List<RoadCorridor> RoadState()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient($"{ApiRootUrl}/Road/?app_id={AppId}&app_key={AppKey}");
            var request = new RestRequest("/", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = (RestResponse)client.Execute(request);
            var content = response.Content;
            var deserialised = JsonConvert.DeserializeObject<List<RoadCorridor>>(content);
            return deserialised;
        }

        public LondonAirForecast AirQuality()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient($"{ApiRootUrl}/AirQuality?app_id={AppId}&app_key={AppKey}");
            var request = new RestRequest("/", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = (RestResponse)client.Execute(request);
            var content = response.Content;
            var deserialised = JsonConvert.DeserializeObject<LondonAirForecast>(content);
            return deserialised;
        }
    }
}