using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project41.HomeWork1
{
    public partial class ChooseTypeOfTournament : Form
    {
        public int Players { get; private set; }
        public Speed Speed { get; private set; }
        public double Buy_in { get; private set; }
        public double First { get; private set; }
        public double Second { get; private set; }

        private List<Tournament> list;
        public ChooseTypeOfTournament(List<Tournament> tournaments)
        {
            InitializeComponent();

            list = tournaments;
            Players = 6;
            Speed = Speed.Turbo;
            Buy_in = 3;

            Check();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void tournamentType_checkedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio != null && radio.Checked)
            {
                try
                {
                    Players = Convert.ToInt32(radio.Tag.ToString());
                }
                catch
                { }
            }

            Check();
        }

        private void tournamentSpeed_checkedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio != null && radio.Checked)
            {
                switch(radio.Text)
                {
                    case "Regular":
                        Speed = Speed.Regular;
                        break;
                    case "Turbo":
                        Speed = Speed.Turbo;
                        break;
                    case "Super turbo":
                        Speed = Speed.SuperTurbo;
                        break;
                    default:
                        break;
                }
            }

            Check();
        }

        private void buy_in_checkedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio != null && radio.Checked)
            {
                try
                {
                    Buy_in = Convert.ToDouble(radio.Tag.ToString());
                }
                catch
                { }
            }

            Check();
        }

        private bool Check(out int count, out double first, out double second)
        {
            List<Tournament> ourTournaments = list.Where(t =>
            t.Players == Players
            && t.Speed == Speed
            && Math.Round(t.Buy_in + t.Fee, 2) == Buy_in).ToList();

            count = ourTournaments.Count;
            first = 0;
            second = 0;

            try
            {
                first = ourTournaments.First(t => t.Place == 1).Earnings - Buy_in;
                second = ourTournaments.First(t => t.Place == 2).Earnings - Buy_in;
                ourTournaments.First(t => t.Place != 1 && t.Place != 2);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Check()
        {
            int count;
            double first, second;
            if (Check(out count, out first, out second))
            {
                btnOk.Enabled = true;
                lblError.Visible = false;
                First = first;
                Second = second;
            }
            else
            {
                lblError.Visible = true;
                btnOk.Enabled = false;
            }

            lblCount.Text = string.Format("Count: {0}", count);
        }
    }
}
