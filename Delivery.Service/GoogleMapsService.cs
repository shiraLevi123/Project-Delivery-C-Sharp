using System.Net.Http;
using System.Threading.Tasks;
using Deliver.Core.Models.Deliver.Core.Models.GoogleMapsApi.Models;
using Deliver.Core.Service;
using GoogleApi.Entities.Maps.Geocoding;
using Newtonsoft.Json;

namespace Deliver.Service
{
    public class GoogleMapsService : IGoogleMapsService
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public GoogleMapsService(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
        }

        public async Task<List<string>> GetOptimizedRouteAsync(string origin, string destination, string[] waypoints)
        {
            string waypointsStr = string.Join("|", waypoints.Select(Uri.EscapeDataString));
            string url = $"https://maps.googleapis.com/maps/api/directions/json?origin={Uri.EscapeDataString(origin)}&destination={Uri.EscapeDataString(destination)}&waypoints=optimize:true|{waypointsStr}&key={_apiKey}";


            HttpResponseMessage response = await _httpClient.GetAsync(url);
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var routeResponse = JsonConvert.DeserializeObject<RouteResponse>(jsonResponse);

            if (routeResponse == null || routeResponse.Routes.Count == 0)
                return null;

            var optimizedOrder = routeResponse.Routes[0].waypoint_order;

            List<string> optimizedAddresses = new List<string> { origin };

            foreach (int index in optimizedOrder)
            {
                optimizedAddresses.Add(waypoints[index]);
               
            }
            optimizedAddresses.Add(destination);
            return optimizedAddresses;
        }

    }
}

