using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Numerics;

namespace ContinuedFractionAttack
{
    class Key
    {
        [JsonProperty("modulus")]
        public BigInteger Modulus { get; set; }

        [JsonProperty("pubkey")]
        public BigInteger PublicKey { get; set; }
        
        [JsonProperty("prikey")]
        public BigInteger PrivateKey { get; set; }

        [JsonProperty("time")]
        public double Time { get; set; }
    }
}
