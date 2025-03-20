using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Deliver.Core.Models

{

    using System.Collections.Generic;

    namespace Deliver.Core.Models.GoogleMapsApi.Models
    {
        public class RouteResponse
        {
            public string Status { get; set; }
            public List<Route> Routes { get; set; }
        }

        public class Route
        {
            public List<Leg> Legs { get; set; }
            public List<int> waypoint_order { get; set; }

        }

        public class Leg
        {
            public string StartAddress { get; set; }
            public string EndAddress { get; set; }
            public Distance Distance { get; set; }
            public Duration Duration { get; set; }
        }

        public class Distance
        {
            public string Text { get; set; }
            public int Value { get; set; }
        }

        public class Duration
        {
            public string Text { get; set; }
            public int Value { get; set; }
        }
    }



  
}