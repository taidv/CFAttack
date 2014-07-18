using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace ContinuedFractionAttack
{
    public partial class ContinuedFractionAttack : Form
    {
        private KeyReports keyImport;
        private KeyReports keyReport;
        public delegate void UpdateListBox(string str);
        public UpdateListBox lbUpdateDelegate;
        public object tLock;
        private Key key;

        public ContinuedFractionAttack()
        {
            InitializeComponent();
            lbUpdateDelegate = new UpdateListBox(UpdateListbox);
            tLock = new object();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            lstResult.Items.Clear();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            key = new Key();
            key.Modulus = BigInteger.Parse(txtN.Text);
            key.PublicKey = BigInteger.Parse(txtE.Text);
            btnProcess.Enabled = false;
            bgWorker2.RunWorkerAsync();
        }

        private void btnLoadJson_Click(object sender, EventArgs e)
        {
            keyImport = ImportFromJSON();
            if (keyImport != null)
            {
                btnImportJson.Enabled = false;
                bgWorker.RunWorkerAsync();
            }

        }

        public void UpdateListbox(string msg)
        {
            lstResult.Items.Add(msg);
            lstResult.SelectedIndex = lstResult.Items.Count - 1;
        }

        private KeyReports ImportFromJSON()
        {
            if (openJsonFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openJsonFileDialog.FileName))
                {
                    string json = sr.ReadToEnd();
                    KeyReports keys = JsonConvert.DeserializeObject<KeyReports>(json);
                    return keys;
                }
            }
            else
                return null;
        }

        private void ExportToJSON(KeyReports keyReport)
        {
            string json = JsonConvert.SerializeObject(keyReport);
            string filename = "KeyReport-" + keyReport.Size + "-" + keyReport.NumKeys + ".JSON";
            //write string to file
            System.IO.File.WriteAllText(filename, json);
        }

        private void txtN_Enter(object sender, EventArgs e)
        {
            txtN.ResetText();
        }

        private void txtE_Enter(object sender, EventArgs e)
        {
            txtE.ResetText();
        }

        private void btLoadReport_Click(object sender, EventArgs e)
        {
            KeyReports reports = new KeyReports();
            if (openJsonFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openJsonFileDialog.FileName))
                {
                    string json = sr.ReadToEnd();
                    reports = JsonConvert.DeserializeObject<KeyReports>(json);
                }
            }
            if (reports != null)
            {
                lbKeyLength.Text = "Key length: " + reports.Size;
                lbNumKeys.Text = "Number of keys: " + reports.NumKeys;
                lbNumSuccessfull.Text = "Number of successfull: " + reports.NumSuccessfull;
                lbNumFailures.Text = "Number of failures: " + reports.NumFailures;
                lbTotalTime.Text = "Total time calculate: " + Math.Round(reports.TotalTime, 2) + " ms.";
                lbAverageTime.Text ="Average time calculate: " + Math.Round(reports.AverageTime, 2) + " ms.";
                lbSuccessRate.Text = "Success rate: " + reports.SuccessPercent * 100 + "%.";

                pnReport.Visible = true;
                btCloseReport.Visible = true;
                btLoadReport.Visible = false;
            }
        }

        private void btCloseReport_Click(object sender, EventArgs e)
        {
            pnReport.Visible = false;
            btCloseReport.Visible = false;
            btLoadReport.Visible = true;
        }

        private void bgWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if(key == null) return;

            string str = "Calculating secrect key (d, n) of public key (e = " + key.PublicKey + ", N = " + key.Modulus + ")";
           
            lstResult.Invoke(lbUpdateDelegate, new Object[] { str });

            Key _key = bgAttack(key.PublicKey, key.Modulus);

            if (_key.PrivateKey == BigInteger.Zero)
            {
                str = "Cannot find the private key";
                lstResult.Invoke(lbUpdateDelegate, new Object[] { str });
            }
            else
            {
                str = "The private key calculated is " + _key.PrivateKey + ", calculate in " + _key.Time + " ms.";
                lstResult.Invoke(lbUpdateDelegate, new Object[] { str });
            }
        }

        private void bgWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string str = "Attack done!";
            btnProcess.Enabled = true;
            lstResult.Invoke(lbUpdateDelegate, new Object[] { str });
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (keyImport == null) return;
            if (keyImport.ListKeys == null) return;
            int _iCount = keyImport.ListKeys.Count - 1;
            keyReport = new KeyReports();
            keyReport.NumKeys = keyImport.NumKeys;
            keyReport.Size = keyImport.Size;
            ThreadPool.SetMaxThreads(250, 10);
            List<WaitHandle> events = new List<WaitHandle>();

            string str = "Calculating...";
            lstResult.Invoke(lbUpdateDelegate, new Object[] { str });

            while (_iCount >= 0)
            {
                ManualResetEvent mre = new ManualResetEvent(false);
                object[] obj = new object[] { (keyImport.ListKeys[_iCount]), mre };
                ThreadPool.QueueUserWorkItem(ThrDoAttack, obj);
                events.Add(mre);
                _iCount--;

            }
            int i = 0;
            foreach (var evt in events)
            {
                evt.WaitOne();
                i++;
                if (i > 100)
                    i = 100;
                bgWorker.ReportProgress((i * 100) / events.Count);

            }

            keyReport.SuccessPercent = ((double)keyReport.NumSuccessfull / (double)keyReport.NumKeys);
            keyReport.AverageTime = keyReport.TotalTime / (double)keyReport.NumKeys;
            ExportToJSON(keyReport);
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            Application.DoEvents();
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string filename = "- KeyReport-" + keyImport.Size + "-" + keyImport.NumKeys + ".json  ";
            string str = "Attack " + keyImport.NumKeys + " keys with key length - " + keyImport.Size +
                " bit is done!.";
            lstResult.Invoke(lbUpdateDelegate, new Object[] { str });
            str = "Read file report: " + filename + " to see detail.";
            lstResult.Invoke(lbUpdateDelegate, new Object[] { str });
            btnImportJson.Enabled = true;
        }

        private void ThrDoAttack(Object obj)
        {
            Key _key = (Key)((Object[])obj)[0];
            Key _keyReturn = new Key();
            DateTime _time1 = DateTime.Now;
            CFAAlgorithm _contFractAttack = new CFAAlgorithm(_key.PublicKey, _key.Modulus);
            BigInteger _bIntD = _contFractAttack.WienerAlgorithm();
            DateTime _time2 = DateTime.Now;
            TimeSpan _time = _time2 - _time1;
            _keyReturn.Modulus = _key.Modulus;
            _keyReturn.PublicKey = _key.PublicKey;
            _keyReturn.PrivateKey = _bIntD;
            _keyReturn.Time = _time.TotalMilliseconds;
            
            lock (tLock)
            {
                keyReport.ListKeys.Add(_keyReturn);
                keyReport.TotalTime += _time.TotalMilliseconds;
                if (_keyReturn.PrivateKey != 0)
                    keyReport.NumSuccessfull++;
                else
                    keyReport.NumFailures++;
            }
            ((ManualResetEvent)((Object[])obj)[1]).Set();
        }

        private Key bgAttack(BigInteger _bIntE, BigInteger _bIntN)
        {
            Key _key = new Key();
            DateTime _time1 = DateTime.Now;
            CFAAlgorithm _contFractAttack = new CFAAlgorithm(_bIntE, _bIntN);
            BigInteger _bIntD = _contFractAttack.WienerAlgorithm();
            DateTime _time2 = DateTime.Now;
            TimeSpan _time = _time2 - _time1;
            _key.Modulus = _bIntN;
            _key.PublicKey = _bIntE;
            _key.PrivateKey = _bIntD;
            _key.Time = _time.TotalMilliseconds;
            return _key;
        }

    }
}
