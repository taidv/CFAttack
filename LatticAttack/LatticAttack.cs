using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Numerics;

namespace LatticAttack
{
    public partial class LatticAttack : Form
    {

        public LatticAttack()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            Lattic lt = new Lattic(BigInteger.Parse(txtN.Text), BigInteger.Parse(txtE.Text));
            BigInteger d = lt.CalculatePrivateKey();
            MessageBox.Show(d.ToString());
        }

    }
}
