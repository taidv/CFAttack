using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Numerics;

namespace ContinuedFractionAttack
{
    class KeyReports
    {
        public KeyReports()
        {
            ListKeys = new List<Key>();
        }

        [JsonProperty("numKeys")]
        public int NumKeys { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("totalTime")]
        public double TotalTime { get; set; }

        [JsonProperty("averageTime")]
        public double AverageTime { get; set; }

        [JsonProperty("NumSuccessfull")]
        public int NumSuccessfull { get; set; }

        [JsonProperty("NumFailures")]
        public int NumFailures { get; set; }

        [JsonProperty("successPercent")]
        public double SuccessPercent { get; set; }

        [JsonProperty("listKeys")]
        public List<Key> ListKeys { get; set; }
        
    }
}
