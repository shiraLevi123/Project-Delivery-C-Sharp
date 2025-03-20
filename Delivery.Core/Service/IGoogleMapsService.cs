using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Deliver.Core.Models;
using Deliver.Core.Models.Deliver.Core.Models.GoogleMapsApi.Models;

namespace Deliver.Core.Service
    {
        public interface IGoogleMapsService
        {
        Task<List<string>> GetOptimizedRouteAsync(string origin, string destination, string[] waypoints);


    }
}


