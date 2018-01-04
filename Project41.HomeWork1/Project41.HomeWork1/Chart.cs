using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project41.HomeWork1
{
    public partial class Chart : Form
    {
        private List<Tournament> list;
        public Chart(List<Tournament> tournamentList)
        {
            InitializeComponent();
            list = tournamentList;

            DrawCurve();
            Calculate();
        }

        public void DrawCurve()
        {
            ChartArea area = ChartArea.ChartAreas[0];
            area.AxisX.IntervalType = DateTimeIntervalType.Number;
            area.AxisX.Minimum = 0;
            area.AxisX.Maximum = list.Count;
            area.AxisX.Interval = list.Count / 12 + 1;
            double value = 0.0;
            int count = 0;
            Series series = ChartArea.Series[0];
            series.Points.AddXY(0, 0);
            foreach (Tournament t in list.OrderBy(t => t.Started))
            {
                count++;
                value += t.Earnings - t.Buy_in - t.Fee;
                series.Points.AddXY(count, value);
            }
        }

        public void Calculate()
        {
            bool equals = true;
            string name = "";
            foreach (Tournament t in list)
            {
                if (name == "")
                {
                    name = t.Type;
                }

                if (t.Type != name)
                {
                    equals = false;
                    break;
                }
            }

            if (equals)
            {
                int first = 0;
                int second = 0;
                int other = 0;

                foreach (Tournament t in list)
                {
                    switch(t.Place)
                    {
                        case 1:
                            first++;
                            break;
                        case 2:
                            second++;
                            break;
                        default:
                            other++;
                            break;
                    }
                }

                Tournament firstPlace = list.FirstOrDefault(t => t.Place == 1);
                if (firstPlace != null)
                {
                    lblFirst.Text = string.Format("First place (+${0:F2}). Count - {1}; In total: +${3:F2}; {2:F2}%",
                        firstPlace.Earnings - firstPlace.Buy_in,
                        first,
                        (double)first * 100 / list.Count,
                        (firstPlace.Earnings - firstPlace.Buy_in) * first);
                }

                Tournament secondPlace = list.FirstOrDefault(t => t.Place == 2);
                if (secondPlace != null)
                {
                    lblSecond.Text = string.Format("Second place (+${0:F2}). Count - {1}; In total: +${3:F2}; {2:F2}%",
                        secondPlace.Earnings - secondPlace.Buy_in,
                        second,
                        (double)second * 100 / list.Count,
                        (secondPlace.Earnings - secondPlace.Buy_in) * second);
                }

                Tournament otherPlace = list.FirstOrDefault(t => t.Place != 1 && t.Place != 2);
                if (otherPlace != null)
                {
                    lblOther.Text = string.Format("Other place (-${0:F2}). Count - {1}; In total: -${3:F2}; {2:F2}%",
                        otherPlace.Buy_in,
                        other,
                        (double)other * 100 / list.Count,
                        otherPlace.Buy_in * other);
                }
            }
        }
    }
}
