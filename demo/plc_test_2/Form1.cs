using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;
using System.Threading;
using SpeechLib;
using DevExpress.XtraCharts;
using Kepware.ClientAce.OpcDaClient;
using System.Windows.Forms.DataVisualization.Charting;
using Timer = System.Windows.Forms.Timer;

namespace plc_test_2
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        Plc plc;

        private void btn_conncet_Click(object sender, EventArgs e)
        {
            CpuType cpu = (CpuType)Enum.Parse(typeof(CpuType), "S71200");
            plc = new Plc(cpu, "192.168.0.1", rack: Convert.ToInt16("0"), slot: Convert.ToInt16("1"));

            try
            {
                label5.Text = "Bağlantı kuruluyor, lütfen bekleyin...";
                plc.Open();
                if (plc.IsConnected == true)
                {
                    MessageBox.Show("PLC ile bağlantı kuruldu. !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_conncet.Enabled = true;
                    label5.Text = "PLC ile bağlantı kuruldu. !";
                }
                else
                {
                    MessageBox.Show("Aktif bir PLC'ye bağlı değilsiniz. !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label5.Text = "Bağlantı kurulamadı";
                    btn_conncet.Enabled = false;
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                label5.Text = "Bağlantı hatalı";
            }
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            var veri = ((uint)plc.Read(txt_adres_read.Text)).ConvertToInt();
            txt_read.Text = veri.ToString();
        }

        private void btn_write_Click(object sender, EventArgs e)
        {
            int value = int.Parse(txt_write.Text);
            plc.Write(txt_adres_write.Text, value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "boş geçilmez");
            }
            
        }

        #region thread and task async
        Thread th1;
        Thread th2;
        Thread th3;
        Thread th4;
        Thread th5;
        Thread th6;
        Thread th7;
        Thread th8;

        int say1 = 0;
        int say2 = 0;
        int say3 = 0;
        int say4 = 0;
        int say5 = 0;
        int say6 = 0;
        int say7 = 0;
        int say8 = 0;

        bool veri1 = true;
        bool veri2 = true;
        bool veri3 = true;
        bool veri4 = true;
        bool veri5 = true;
        bool veri6 = true;
        bool veri7 = true;
        bool veri8 = true;

        Task sayac1_()
        {
            return Task.Run(() =>
            {
                while (1 == 1)
                {
                    say1 += 1;
                    sayac1.Text = "" + say1;

                    if (veri2 == true)
                    {
                        sayac_durum2.Text = "False";
                        sayac_durum1.Text = "True";
                        veri2 = false;
                        veri1 = true;
                    }
                    Thread.Sleep(500);
                }
            });
        }

        Task sayac2_()
        {
            return Task.Run(() =>
            {
                while (1 == 1)
                {
                    say2 += 1;
                    sayac2.Text = "" + say2;
                    Thread.Sleep(300);
                    if (veri1 == true)
                    {
                        sayac_durum1.Text = "False";
                        sayac_durum2.Text = "True";
                        veri1 = false;
                        veri2 = true;
                    }
                }
            });
        }

        Task sayac3_()
        {
            return Task.Run(() =>
            {
                while (1 == 1)
                {
                    say3 += 1;
                    sayac3.Text = "" + say3;
                    Thread.Sleep(60);
                    if(veri4 == true)
                    {
                        sayac_durum4.Text = "False";
                        sayac_durum3.Text = "True";
                        veri4 = false;
                        veri3 = true;
                    }
                }
            });
        }

        Task sayac4_()
        {
            return Task.Run(() =>
            {
                while (1 == 1)
                {
                    say4 += 1;
                    sayac4.Text = "" + say4;
                    Thread.Sleep(100);
                    if (veri3 == true)
                    {
                        sayac_durum3.Text = "False";
                        sayac_durum4.Text = "True";
                        veri3 = false;
                        veri4 = true;
                    }
                }
            });
        }

        Task sayac5_()
        { 
            return Task.Run(() =>
            {
                while (1 == 1)
                {
                    say5 += 1;
                    sayac5.Text = "" + say5;
                    Thread.Sleep(240);
                    if (veri6 == true)
                    {
                        sayac_durum6.Text = "False";
                        sayac_durum5.Text = "True";
                        veri6 = false;
                        veri5 = true;
                    }
                }
            });
        }

        Task sayac6_()
        {
            return Task.Run(() =>
            {
                while (1 == 1)
                {
                    say6 += 1;
                    sayac6.Text = "" + say6;
                    Thread.Sleep(150);
                    if (veri5 == true)
                    {
                        sayac_durum5.Text = "False";
                        sayac_durum6.Text = "True";
                        veri5 = false;
                        veri6 = true;
                    }
                }
            });
        }

        Task sayac7_()
        {
            return Task.Run(() =>
            {
                while (1 == 1)
                {
                    say7 += 1;
                    sayac7.Text = "" + say7;
                    Thread.Sleep(900);
                    if (veri8 == true)
                    {
                        sayac_durum8.Text = "False";
                        sayac_durum7.Text = "True";
                        veri8 = false;
                        veri7 = true;
                    }
                }
            });
        }

        Task sayac8_()
        {
            return Task.Run(() =>
            {
                while (1 == 1)
                {
                    say8 += 1;
                    sayac8.Text = "" + say8;
                    Thread.Sleep(500);
                    if (veri7 == true)
                    {
                        sayac_durum7.Text = "False";
                        sayac_durum8.Text = "True";
                        veri7 = false;
                        veri8 = true;
                    }
                }
            });
        }
        #endregion

        private async void btn_sayac1_Click(object sender, EventArgs e)
        {
            await sayac1_();

        }

        private async void btn_sayac2_Click(object sender, EventArgs e)
        {
            await sayac2_();
        }

        private async void btn_sayac3_Click(object sender, EventArgs e)
        {
            await sayac3_();
        }

        private async void btn_sayac4_Click(object sender, EventArgs e)
        {
            await sayac4_();
        }

        private async void btn_sayac8_Click(object sender, EventArgs e)
        {
            await sayac8_();
        }

        private async void btn_sayac7_Click(object sender, EventArgs e)
        {
            await sayac7_();
        }

        private async void btn_sayac6_Click(object sender, EventArgs e)
        {
            await sayac6_();
        }

        private async void btn_sayac5_Click(object sender, EventArgs e)
        {
            await sayac5_();
        }


        DaServerMgt daServerMgt = new DaServerMgt();
        private void button5_Click(object sender, EventArgs e)
        {
            String url = "opc.tcp://PC-05:49320";
            //String url = "opc.tcp://192.168.1.195:49320";

            int clientHandle = 1;
            ConnectInfo connectInfo = new ConnectInfo();
            connectInfo.LocalId = "en";
            connectInfo.KeepAliveTime = 60000;
            connectInfo.RetryAfterConnectionError = true;
            connectInfo.RetryInitialConnection = false;
            bool connectFailed = false;
            try
            {
                daServerMgt.Connect(url, clientHandle, ref connectInfo, out connectFailed);
                if (connectFailed)
                {
                    MessageBox.Show("Bağlantı kurulamadı...");
                }
                else
                    MessageBox.Show($"Bağlantı kuruldu...");

            }
            catch(Exception ex)
            {
                MessageBox.Show($"Bağlantı hatası...\nAçıklama : {ex.Message}");
            }
        }





        int saniye = 0;
        void zaman()
        {
            for (; ; )
            {
                saniye++;
                Thread.Sleep(1000);
            }
        }





        //---------------------- GRAPH START ----------------
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        Timer timer;
        Random random;
        //-------------------------- CHART 1 ---------------------
        private void chart1Button_Click(object sender, EventArgs e)
        {
            random = new Random();
            timer1 = new Timer();
            timer1.Interval = 100;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }
        private void chart1ButtonStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        int xaxis;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            Random rnd = new Random();
            float RastgeleSayi9 = rnd.Next(100);
            progressBarChartOne.Value = (int)RastgeleSayi9;
            labelChart1.Text = String.Format("{0:0.00}%", RastgeleSayi9);
            chart1.Series[0].Points.AddXY(xaxis++, RastgeleSayi9);

            if (chart1.Series[0].Points.Count > 10)
            {
                chart1.Series[0].Points.Remove(chart1.Series[0].Points[0]);
                chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
                chart1.ChartAreas[0].AxisX.Maximum = xaxis;
            }


        }
        //--------------------------- FINISH ------------------------------

        //--------------------------- CHART 2 -----------------------------
        private void chart2Button_Click(object sender, EventArgs e)
        {
            timer2 = new Timer();
            timer2.Interval = 100;
            timer2.Tick += timer2_Tick;
            timer2.Start();

        }
        private void chart2ButtonStop_Click(object sender, EventArgs e)
        {
            timer2.Stop();
        }

        int xaxis2;
        private void timer2_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            float RastgeleSayi10 = rnd.Next(100);
            progressBarChartTwo.Value = (int)RastgeleSayi10;
            labelChart2.Text = String.Format("{0:0.00}%", RastgeleSayi10);
            chart2.Series[0].Points.AddXY(xaxis2++,RastgeleSayi10);

            if (chart2.Series[0].Points.Count > 10)
            {
                chart2.Series[0].Points.Remove(chart2.Series[0].Points[0]);
                chart2.ChartAreas[0].AxisX.Minimum = chart2.Series[0].Points[0].XValue;
                chart2.ChartAreas[0].AxisX.Maximum = xaxis2;
            }
        }
        //--------------------------- FINISH ------------------------------

        //--------------------------- CHART 3 -----------------------------
        private void chart3Button_Click(object sender, EventArgs e)
        {

            timer3 = new Timer();
            timer3.Interval = 100;
            timer3.Tick += timer3_Tick;
            timer3.Start();

        }
        private void chart3ButtonStop_Click(object sender, EventArgs e)
        {
            timer3.Stop();
        }

        int xaxis3;
        private void timer3_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            float RastgeleSayi11 = rnd.Next(100);
            progressBarChartThree.Value = (int)RastgeleSayi11;
            labelChart3.Text = String.Format("{0:0.00}%", RastgeleSayi11);
            chart3.Series[0].Points.AddXY(xaxis3++, RastgeleSayi11);

            if (chart3.Series[0].Points.Count > 10)
            {
                chart3.Series[0].Points.Remove(chart3.Series[0].Points[0]);
                chart3.ChartAreas[0].AxisX.Minimum = chart3.Series[0].Points[0].XValue;
                chart3.ChartAreas[0].AxisX.Maximum = xaxis3;
            }
        }
        //--------------------------- FINISH ------------------------------

        //--------------------------- CHART 4 -----------------------------
        private void chart4Button_Click(object sender, EventArgs e)
        {
            timer4 = new Timer();
            timer4.Interval = 100;
            timer4.Tick += timer4_Tick;
            timer4.Start();
        }
        private void chart4ButtonStop_Click(object sender, EventArgs e)
        {
            timer4.Stop();
        }

        int xaxis4;
        private void timer4_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            float RastgeleSayi12 = rnd.Next(100);
            progressBarChartFour.Value = (int)RastgeleSayi12;
            labelChart4.Text = String.Format("{0:0.00}%", RastgeleSayi12);
            chart4.Series[0].Points.AddXY(xaxis4++, RastgeleSayi12);

            if (chart4.Series[0].Points.Count > 10)
            {
                chart4.Series[0].Points.Remove(chart4.Series[0].Points[0]);
                chart4.ChartAreas[0].AxisX.Minimum = chart4.Series[0].Points[0].XValue;
                chart4.ChartAreas[0].AxisX.Maximum = xaxis4;
            }
        }
        //--------------------------- FINISH ------------------------------

        //--------------------------- CHART 5 -----------------------------
        private void chart5Button_Click(object sender, EventArgs e)
        {
            timer5 = new Timer();
            timer5.Interval = 100;
            timer5.Tick += timer5_Tick;
            timer5.Start();
        }
        private void chart5ButtonStop_Click(object sender, EventArgs e)
        {
            timer5.Stop();
        }

        int xaxis5;
        private void timer5_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            float RastgeleSayi13 = rnd.Next(100);
            progressBarChartFive.Value = (int)RastgeleSayi13;
            labelChart5.Text = String.Format("{0:0.00}%", RastgeleSayi13);
            chart5.Series[0].Points.AddXY(xaxis5++, RastgeleSayi13);

            if (chart5.Series[0].Points.Count > 10)
            {
                chart5.Series[0].Points.Remove(chart5.Series[0].Points[0]);
                chart5.ChartAreas[0].AxisX.Minimum = chart5.Series[0].Points[0].XValue;
                chart5.ChartAreas[0].AxisX.Maximum = xaxis5;
            }
        }
        //--------------------------- FINISH ------------------------------

        //--------------------------- CHART 6 -----------------------------
        private void chart6Button_Click(object sender, EventArgs e)
        {
            timer6 = new Timer();
            timer6.Interval = 100;
            timer6.Tick += timer6_Tick;
            timer6.Start();
        }
        private void chart6ButtonStop_Click(object sender, EventArgs e)
        {
            timer6.Stop();
        }
        int xaxis6;
        private void timer6_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            float RastgeleSayi14 = rnd.Next(100);
            progressBarChartSix.Value = (int)RastgeleSayi14;
            labelChart6.Text = String.Format("{0:0.00}%", RastgeleSayi14);
            chart6.Series[0].Points.AddXY(xaxis6++, RastgeleSayi14);

            if (chart6.Series[0].Points.Count > 10)
            {
                chart6.Series[0].Points.Remove(chart6.Series[0].Points[0]);
                chart6.ChartAreas[0].AxisX.Minimum = chart6.Series[0].Points[0].XValue;
                chart6.ChartAreas[0].AxisX.Maximum = xaxis6;
            }
        }
        //--------------------------- FINISH ------------------------------

        //--------------------------- CHART 7 -----------------------------
        private void chart7Button_Click(object sender, EventArgs e)
        {
            timer7 = new Timer();
            timer7.Interval = 100;
            timer7.Tick += timer7_Tick;
            timer7.Start();
        }
        private void chart7ButtonStop_Click(object sender, EventArgs e)
        {
            timer7.Stop();
        }

        int xaxis7;
        private void timer7_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            float RastgeleSayi15 = rnd.Next(100);
            progressBarChartSeven.Value = (int)RastgeleSayi15;
            labelChart7.Text = String.Format("{0:0.00}%", RastgeleSayi15);
            chart7.Series[0].Points.AddXY(xaxis7++, RastgeleSayi15);

            if (chart7.Series[0].Points.Count > 10)
            {
                chart7.Series[0].Points.Remove(chart7.Series[0].Points[0]);
                chart7.ChartAreas[0].AxisX.Minimum = chart7.Series[0].Points[0].XValue;
                chart7.ChartAreas[0].AxisX.Maximum = xaxis7;
            }
        }
        //--------------------------- FINISH ------------------------------

        //--------------------------- CHART 8 -----------------------------
        private void chart8Button_Click(object sender, EventArgs e)
        {
            timer8 = new Timer();
            timer8.Interval = 100;
            timer8.Tick += timer8_Tick;
            timer8.Start();
        }
        private void chart8ButtonStop_Click(object sender, EventArgs e)
        {
            timer8.Stop();
        }

        int xaxis8;
        private void timer8_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            float RastgeleSayi16 = rnd.Next(100);
            progressBarChartEight.Value = (int)RastgeleSayi16;
            labelChart8.Text = String.Format("{0:0.00}%", RastgeleSayi16);
            chart8.Series[0].Points.AddXY(xaxis8++, RastgeleSayi16);

            if (chart8.Series[0].Points.Count > 10)
            {
                chart8.Series[0].Points.Remove(chart8.Series[0].Points[0]);
                chart8.ChartAreas[0].AxisX.Minimum = chart8.Series[0].Points[0].XValue;
                chart8.ChartAreas[0].AxisX.Maximum = xaxis8;
            }
        }
        //--------------------------- FINISH ------------------------------
        //------------------------ GRAPH FINISH ----------------------


        int sayac = 0;
    
        private void button6_Click(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(richTextBox1.Text);
        }

        private void sayac_durum2_Click(object sender, EventArgs e)
        {

        }
        int l1maxx = 30;
        int l1minn = 0;
        int l2maxx = 30;
        int l2minn = 0;
        int l3maxx = 30;
        int l3minn = 0;
         
        

        long min = 0;
        long max = 30;

        long min1 = 0;
        long max1 = 30;

        long min2 = 0;
        long max2 = 30;

        private void sayac1_Click(object sender, EventArgs e)
        {

        }

        private void sayac_durum5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

      

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart5_Click(object sender, EventArgs e)
        {

        }

        
    }
}
