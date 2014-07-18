using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LatticAttack
{
    public class Lattic
    {
        private BVector _vector1;
        private BVector _vector2;

        private BigInteger m_bIntN;
        private BigInteger m_bIntE;

        public Lattic()
        {
            _vector1 = new BVector();
            _vector2 = new BVector();
        }

        /// <summary>
        /// Khoi tao mot dan
        /// </summary>
        /// <param name="_N"></param>
        /// <param name="_e"></param>
        public Lattic(BigInteger _N, BigInteger _e)
        {
            _vector1 = new BVector(_e, (BigInteger)Math.Exp(BigInteger.Log(_N) / 2));
            _vector2 = new BVector(_N, 0);
            m_bIntN = _N;
        }

        /// <summary>
        /// Xet he ma hoa RSA trong truong hop 0 < d < n ^ 1/4 va cac so p,q la cung chieu dai bit
        /// Ta co cac uoc luong sau:
        ///     p,q ~ sqrt(n), phi(n) = (p - 1)(q - 1) = n - p - q + 1 = n + O(sqrt(n)).
        ///     Do ed = 1 (mod phi(n)) nen ed  = 1 + k * phi(n) = 1 + O(n + sqrt(n)) (k thuoc Z, k = O(d)).
        ///     Nhu vay neu dat l = ed - kn thi l = O(d * sqrt(n))
        ///     
        /// Xet dan 2 chieu trong R2 voi 2 vector co so la v1 = (e, sqrt(n)), v2 = (n, 0). L se chua vector 
        /// t = d * v1 - k * v2 = (l, d * sqrt(n)) ma ||t|| = sqrt(l * l + d * d * n) ~ d * sqrt(n), ngoai ra 
        /// det(L) = n * sqrt(n) = n ^ 3/2. Do d < n ^ 1/4 nen d * sqrt(n) < sqrt(det(L)). 
        /// Ta du doan t la vector ngan nhat cua L bang cach dung thuat toan Gauss cho co so khoi dau v1, v2 ta tim
        /// ra t, tu do tim ra d
        /// 
        /// 
        /// *********** Gaussian Algorithm *************
        ///     Loop
        ///         If ||v2|| < ||v1|| then hoan doi v1, v2
        ///         
        ///         Tinh m = <v1, v2> / (||v1|| ^ 2) ---- nearest value
        ///         
        ///         If m = 0 then STOP
        ///             Else v2 = v2 - m * v1.
        ///         
        ///     EndLoop
        /// ********************************************
        /// 
        /// </summary>
        private void GaussianAlgorithm()
        {
            while(true)
            {
                if (_vector2.LengthSquare > _vector1.LengthSquare)
                    Swap();
                BigInteger m = new BigInteger();

                m = (_vector1 * _vector2) / _vector1.LengthSquare;

                if (m == 0)
                    break;
                else
                    _vector2 = _vector2 - (m * _vector1);
            }
        }

        /// <summary>
        /// Tim khoa bi mat
        /// </summary>
        /// <returns></returns>
        public BigInteger CalculatePrivateKey()
        {
            GaussianAlgorithm();
            BigInteger _privateKey = BigInteger.Divide(_vector2.Y, (BigInteger)Math.Exp(BigInteger.Log(m_bIntN) / 2));
            return _privateKey;
        }

        /// <summary>
        /// Hoan vi 2 vector trong dan
        /// </summary>
        private void Swap()
        {
            BVector tmp_vector = new BVector();
            tmp_vector.X = _vector2.X;
            tmp_vector.Y = _vector2.Y;
            _vector2.X = _vector1.X;
            _vector2.Y = _vector1.Y;
            _vector1.X = tmp_vector.X;
            _vector1.Y = tmp_vector.Y;
        }


    }
}
