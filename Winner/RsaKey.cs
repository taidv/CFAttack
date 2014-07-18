using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ContinuedFractionAttack
{
    class RsaKey
    {
        private BigInteger modulus; // modulus = pq
        private BigInteger publicKey; // public exponent = e
        private BigInteger privateKey; // private exponent = d
        
        public BigInteger Modulus
        {
            get { return modulus; }
            set { modulus = value; }
        }
        public BigInteger PublicKey
        {
            get { return publicKey; }
            set { publicKey = value; }
        }
        public BigInteger PrivateKey
        {
            get { return privateKey; }
            set { privateKey = value; }
        }

        public RsaKey(BigInteger e, BigInteger n)
        {
            PublicKey = e;
            Modulus = n;
        }

        public bool TestKey()
        {
            BigInteger m = 2;
            BigInteger c = BigInteger.ModPow(m, PublicKey, Modulus);
            BigInteger rm = BigInteger.ModPow(c, PrivateKey, Modulus);
            if (m == rm)
                return true;
            else
                return false;
        }
        
    }
}
