using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project41.HomeWork1
{
    public partial class Forecast : Form
    {
        List<Tournament> list;
        double buy_in;
        int players;
        Speed speed;
        double p1, p2, p3;
        double moneyForFirstPlace;
        double moneyForSecondPlace;

        Dictionary<int[], NodeValue> dictionary = 
            new Dictionary<int[], NodeValue>();

        private int currentPointIndex = 0;

        public Forecast(List<Tournament> listOfTournaments, int paramPlayers, double paramBuy_in,
            Speed paramSpeed, double paramFirst, double paramSecond)
        {
            InitializeComponent();

            chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Number;
            chart.ChartAreas[0].AxisY.Maximum = 100;
            chart.Series[0].ChartType = SeriesChartType.Line;
            chart.Series[1].ChartType = SeriesChartType.Line;

            list = listOfTournaments;

            buy_in = paramBuy_in;
            players = paramPlayers;
            speed = paramSpeed;
            moneyForFirstPlace = paramFirst;
            moneyForSecondPlace = paramSecond;

            if (players != 6)
            {
                MessageBox.Show("We work with tournaments where there are only 6 players",
                    "Error", MessageBoxButtons.OK);
                this.Close();
            }
            CalculateOdds();
            RefreshAll();
        }

        public void CalculateOdds()
        {
            p1 = 0;
            p2 = 0;
            p3 = 0;

            List<Tournament> ourList = list.Where(tournament => 
            Math.Round(tournament.Buy_in + tournament.Fee, 2) == buy_in &&
            tournament.Players == players && 
            tournament.Speed == speed).ToList();

            foreach (Tournament t in ourList)
            {
                switch (t.Place)
                {
                    case 1:
                        p1 += 1;
                        break;
                    case 2:
                        p2 += 1;
                        break;
                    default:
                        p3 += 1;
                        break;
                }
            }

            p1 /= ourList.Count;
            p2 /= ourList.Count;
            p3 /= ourList.Count;
        }

        public void Calculate()
        {
            Scenarios(trackBar.Value);
            rtb.Clear();

            StringBuilder builder = new StringBuilder();
            foreach (var pair in dictionary.OrderBy(kvp => -kvp.Value.Earnings))
            {
                string earnings = pair.Value.Earnings >= 0
                    ? string.Format("+${0:F2}", pair.Value.Earnings)
                    : string.Format("-${0:F2}", -pair.Value.Earnings);
                builder.Append(string.Format("first - {0}, second - {1}, other - {2} : {3} - {4:F2}%\n",
                    pair.Key[0],
                    pair.Key[1],
                    pair.Key[2],
                    earnings,
                    pair.Value.Odds * 100));
            }
            rtb.AppendText(builder.ToString());

            lblNumberOfTournaments.Text = string.Format(
                "Number of tournaments: {0}", trackBar.Value);
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            RefreshAll();
        }



        private void RefreshAll()
        {
            dictionary.Clear();
            Calculate();
            Draw();

            currentPointIndex = 0;
            try
            {

                while (chart.Series[0].Points[currentPointIndex++].YValues[0] > 50) ;
                currentPointIndex -= 2;
                DrawPoint();
            }
            catch
            {
                currentPointIndex = 0;
            }
        }

        public void Scenarios(int level)
        {
            int k1 = level;
            int k2, k3;
            
            while(k1 != -1)
            {
                for (k3 = 0; k3 < level - k1 + 1; k3++)
                {
                    k2 = level - k3 - k1;
                    CalculateAndAdd(k1, k2, k3);
                }
                k1--;
            }
        }

        public void DrawPoint()
        {
            DataPoint dataPoint = chart.Series[0].Points[currentPointIndex];
            DrawPoint(dataPoint.XValue, dataPoint.YValues[0]);
        }

        public void DrawPoint(double x, double y)
        {
            Series series = chart.Series[1];

            series.Points.Clear();
            series.Points.AddXY(chart.ChartAreas[0].AxisX.Minimum, y);
            series.Points.AddXY(x, y);

            DataPoint point = series.Points.Last();
            point.IsValueShownAsLabel = true;
            string earnings = point.XValue > 0
                ? string.Format("+${0:F2}", point.XValue)
                : string.Format("-${0:F2}", -point.XValue);
            series.Points.Last().Label = string.Format("Earnings {0} or more\nOdds: {1:F2}%",
                earnings, point.YValues[0]);

            series.Points.AddXY(x, 0);
        }

        private void trackBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (trackBar.Value != trackBar.Minimum)
                {
                    trackBar.Value--;
                }

                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.Right)
            {
                if (trackBar.Value != trackBar.Maximum)
                {
                    trackBar.Value++;
                }

                e.Handled = true;
                return;
            }

            if (e.KeyCode == Keys.Up)
            {
                try
                {
                    currentPointIndex--;
                    DrawPoint();
                }
                catch
                {
                    currentPointIndex = 0;
                }

                e.Handled = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                try
                {
                    currentPointIndex++;
                    DrawPoint();
                }
                catch
                {
                    currentPointIndex = chart.Series[0].Points.Count - 1;
                }

                e.Handled = true;
            }
        }

        public void CalculateAndAdd(int k1, int k2, int k3)
        {
            int n = k1 + k2 + k3;
            //long n_f = 1;
            BigInteger N_F = 1;
            while (n > 1)
            {
                //n_f *= n;
                N_F *= n;
                n--;
            }

            int k1_ = k1;
            //long k1_f = 1;
            BigInteger K1_F = 1;
            while (k1_ > 1)
            {
                //k1_f *= k1_;
                K1_F *= k1_;
                k1_--;
            }

            int k2_ = k2;
            //long k2_f = 1;
            BigInteger K2_F = 1;
            while (k2_ > 1)
            {
                //k2_f *= k2_;
                K2_F *= k2_;
                k2_--;
            }

            int k3_ = k3;
            //long k3_f = 1;
            BigInteger K3_F = 1;
            while (k3_ > 1)
            {
                //k3_f *= k3_;
                K3_F *= k3_;
                k3_--;
            }

            //long numberOfPermutations = ((n_f / k1_f) / k2_f) / k3_f;
            BigInteger numberOfPermutations = (((N_F) / K1_F) / K2_F) / K3_F;
            
            const long precision = 1000000000000000000;
            BigInteger P1_K = new BigInteger(Math.Pow(p1, k1) * precision);
            BigInteger P2_K = new BigInteger(Math.Pow(p2, k2) * precision);
            BigInteger P3_K = new BigInteger(Math.Pow(p3, k3) * precision);
            BigInteger BigIntegerOdds = (numberOfPermutations * P1_K * P2_K * P3_K) / precision;
            BigIntegerOdds /= precision;

            double odds = 0;
            try
            {
                odds = (double)BigIntegerOdds;
                odds /= precision;
            }
            catch (OverflowException e)
            {
                MessageBox.Show("");
            }

            NodeValue value = new NodeValue
            {
                Earnings = moneyForFirstPlace * k1 + moneyForSecondPlace * k2 - buy_in * k3,
                Odds = odds
            };
            dictionary.Add(new int[3] { k1, k2, k3 }, value);
        }

        private void Draw()
        {
            if (checkBox_updateCoordinateGrid.Checked)
            {
                ChartArea area = chart.ChartAreas[0];
                area.AxisX.Minimum = dictionary.OrderBy(pair => pair.Value.Earnings).First().Value.Earnings;
                area.AxisX.Maximum = dictionary.OrderBy(pair => -pair.Value.Earnings).First().Value.Earnings;
                area.AxisX.Interval = (int)(area.AxisX.Maximum - area.AxisX.Minimum) / 5 + 1;
            }

            Series series = chart.Series[0];
            series.Points.Clear();
            double odds = 1;
            double prevEarn = double.MaxValue;
            foreach(var pair in dictionary.OrderBy(kvp => kvp.Value.Earnings))
            {
                if (Math.Round(prevEarn, 2) == Math.Round(pair.Value.Earnings, 2))
                {
                    odds -= pair.Value.Odds;
                    continue;
                }
                series.Points.AddXY(pair.Value.Earnings, odds * 100);
                string earnings = pair.Value.Earnings > 0
                    ? string.Format("+${0:F2}", pair.Value.Earnings)
                    : string.Format("-${0:F2}", -pair.Value.Earnings);
                series.Points.Last().ToolTip = string.Format("Earnings more than: {0}\nOdds: {1:F2}%",
                    earnings, odds * 100);
                odds -= pair.Value.Odds;
                prevEarn = pair.Value.Earnings;
            }
        }

        private void btnLoseAll_Click(object sender, EventArgs e)
        {
            Lose_all window = new Lose_all(moneyForFirstPlace, moneyForSecondPlace, buy_in, p1, p2, p3);
            window.ShowDialog();
        }
    }

    

    public class NodeValue
    {
        public double Earnings { get; set; }
        public double Odds { get; set; }
    }
}
