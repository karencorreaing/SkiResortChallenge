using System;
using System.Collections.Generic;
namespace SkiResortChallenge.Utils
{
    public class SkiResponse
    {
        public SkiResponse()
        {
        }


        public int maximalPath { get; set; }
        public int maximalDrop { get; set; }
        public List<Route> Routes { get; set; }
    }
}
