using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ContinuedFractionAttack
{
    class CFAAlgorithm
    {
        //List<BigInteger> m_lstD = new List<BigInteger>();
        private List<BigInteger> m_lstContinuedFraction; // Continued Fraction Array
        private RsaKey m_rsaKey;
        //private ContinuedFractionAttack m_form;

        public CFAAlgorithm(BigInteger e, BigInteger n)
        {
            m_rsaKey = new RsaKey(e, n);
            m_lstContinuedFraction = new List<BigInteger>();
            //m_form = new ContinuedFractionAttack();
        }

        /// <summary>
        /// Convert continued fraction to fraction 
        ///     Step 1:  
        ///         q0 = a / b
        ///         remainder: ri = a / b - q0
        ///     Step 2: Repeat
        ///          i <- i + 1
        ///          qi <- [1 / r(i - 1)]
        ///          ri <- [1 / r(i - 1)] - qi
        ///          until ri = 0
        ///          m <- i
        /// </summary>
        /// <param name="_fraction">Fraction with numerator a and denominator b</param>
        /// <returns> continued fraction < q0, q1, ... , qm> </returns>
        private List<BigInteger> FractiontoContinuedFraction(BigFraction _fraction)
        {
            List<BigInteger> _lstCF = new List<BigInteger>();
            List<BigFraction> _lstFraction = new List<BigFraction>();
            BigInteger _remainder; 
            BigInteger _qi;
            
            _qi = BigInteger.DivRem(_fraction.Numerator, _fraction.Denominator, out _remainder);
            _lstCF.Add(_qi);
            BigFraction _bfrac = new BigFraction(_remainder, _fraction.Denominator);
            _lstFraction.Add(_bfrac);
            int i = 0;
            while (true)
            {
                i++;
                _qi = BigInteger.DivRem(_lstFraction[i - 1].Denominator, _lstFraction[i - 1].Numerator, out _remainder);
                _lstCF.Add(_qi);
                _bfrac = new BigFraction(_remainder, _lstFraction[i - 1].Numerator);
                _lstFraction.Add(_bfrac);
                if (_remainder <= BigInteger.Zero)
                {
                    break;
                }
            }
            return _lstCF;
        }
        
        /// <summary>
        /// Convert continued fraction to fraction
        ///     n0 = q0
        ///     d0 = 1
        ///     n1 = q0 * q1 + 1
        ///     d1 = q1
        ///     for i = 2 -> m do
        ///         ni <- qi * n(i - 1) + n(i - 2)
        ///         di <- qi * d(i - 1) + d(i - 2)
        ///     end for
        /// </summary>
        /// <param name="_contfraction"> Continued fraction <q0, q1, ..., qm></param>
        /// <returns> Fraction n/d </returns>
        private BigFraction ContinuedFractiontoFraction(List<BigInteger> _contfraction)
        {
            BigFraction _bfraction = new BigFraction();
            List<BigInteger> _lstNumerator = new List<BigInteger>();
            List<BigInteger> _lstDenominator = new List<BigInteger>();
            int _iCount = _contfraction.Count;
            _lstNumerator.Add(_contfraction[0]);
            _lstDenominator.Add(1);
            if (_iCount > 1)
            {
                _lstNumerator.Add(_contfraction[0] * _contfraction[1] + 1);
                _lstDenominator.Add(_contfraction[1]);
                for (int i = 2; i < _iCount; i++)
                {
                    _lstNumerator.Add(_contfraction[i] * _lstNumerator[i - 1] + _lstNumerator[i - 2]);
                    _lstDenominator.Add(_contfraction[i] * _lstDenominator[i - 1] + _lstDenominator[i - 2]);
                }
            }
            _bfraction.Numerator = _lstNumerator.Last();
            _bfraction.Denominator = _lstDenominator.Last();

            return _bfraction;
        }

        /// <summary>
        /// ContinuedFractionAttack attack algorithm
        /// Step 1: 
        ///     Calculate continued fraction from e/N 
        ///     <q`0, q`1, ..., q`m> <- e/N
        /// Step 2:
        ///     for i = 0 -> m do
        ///         ni/di <- <q`0, q`1, ..., q`i>
        ///         k/dg  <- <q`0, q`1, ..., q`i + 1>       if i is even.
        ///         k/dg  <- <q`0, q`1, ..., q`i>           if i is odd.
        ///         phi   <- [edg/k]   // phi = euler totient
        ///         g <- edg mod k
        ///         
        ///         if phi = 0 then
        ///             increment i and restart the loop
        ///         end if
        ///         
        ///         anpha <- [pq - (p - 1)(q - 1) + 1]/2
        ///         beta  <- anpha * anpha - pq
        ///         
        ///         if "beta" is not square number then
        ///             increment i and restart the loop
        ///         end if
        ///         d <- dg/g
        ///     end for
        /// </summary>
        /// <param name="_key"> Public key (e, N) </param>
        /// <returns> Secrect key d </returns>
        public BigInteger WienerAlgorithm()
        {
            //m_form.UpdateListbox("Calculating continued fraction from e/N");
            BigFraction _bfraction = new BigFraction(m_rsaKey.PublicKey, m_rsaKey.Modulus);
            m_lstContinuedFraction = FractiontoContinuedFraction(_bfraction);
            List<BigInteger> tmp_lstContFraction = new List<BigInteger>();
            tmp_lstContFraction = m_lstContinuedFraction.Clone().ToList();
            int iCount = m_lstContinuedFraction.Count;

            BigFraction tmp_fraction, _bfrK_DG, _bfrEulerToitient;
            BigInteger _iEulerToitient, _iG, _bintAnpha, _biBeta;
            for (int i = 0; i < iCount; i++)
            {
                tmp_fraction = new BigFraction();
                 _bfrK_DG = new BigFraction(); 

                tmp_lstContFraction = m_lstContinuedFraction.Take(i + 1).ToList();
                tmp_fraction = ContinuedFractiontoFraction(tmp_lstContFraction);

                if (0 == i % 2)
                {
                    tmp_lstContFraction[i] = tmp_lstContFraction[i] + 1;
                }

                _bfrK_DG = ContinuedFractiontoFraction(tmp_lstContFraction);
                _bfrEulerToitient = new BigFraction(_bfrK_DG.Denominator * m_rsaKey.PublicKey, _bfrK_DG.Numerator);

                _iEulerToitient = _bfrEulerToitient.Floor();
                 _iG = BigInteger.Remainder(_bfrEulerToitient.Numerator, _bfrEulerToitient.Denominator);

                if (0 == _iEulerToitient || 0 == _iG)
                {
                    continue;
                }

                 _bintAnpha = BigInteger.Divide((m_rsaKey.Modulus - _iEulerToitient + 1), 2);
                 _biBeta = BigInteger.Pow(_bintAnpha, 2) - m_rsaKey.Modulus;

                if (!isSquare(_biBeta))
                {
                    continue;
                }

                m_rsaKey.PrivateKey = BigInteger.Divide(_bfrK_DG.Denominator, _iG);
                if (m_rsaKey.TestKey())
                    return m_rsaKey.PrivateKey;
            }

            return BigInteger.Zero;
        }

        private bool isSquare(BigInteger _bInt)
        {
            double _dbSqrtBeta = Math.Exp(BigInteger.Log(_bInt) / 2);
            if (_dbSqrtBeta == Math.Round(_dbSqrtBeta))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }

    public static class Extentions
    {
        public static T Clone<T>(this T original) where T : class 
        {
            using(MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, original);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return (T)binaryFormatter.Deserialize(memoryStream);
            }
        }
    }

}

