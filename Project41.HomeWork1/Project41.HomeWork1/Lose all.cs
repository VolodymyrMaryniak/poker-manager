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
    public partial class Lose_all : Form
    {
        double[] moneyForPlace = null;
        double buy_in;
        double[] P = null;

        double bankroll = 0;
        int countOfTournaments = 5;

        public Lose_all(double[] money, double[] p)
        {
            moneyForPlace = new double[money.Length];
            money.CopyTo(moneyForPlace, 0);
            P = new double[p.Length];
            p.CopyTo(p, 0);
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            double chances = ChancesToLoseAll(bankroll, countOfTournaments);

            lblAnswer.Text = string.Format("Chances to lose all: {0:F2}%", chances * 100);
        }

        private void textBoxBankroll_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bankroll = Convert.ToDouble(textBoxBankroll.Text.Replace(".", ","));
                textBoxBankroll.ForeColor = Color.Black;
            }
            catch
            {
                textBoxBankroll.ForeColor = Color.Red;
            }

            Check();
        }

        private void Check()
        {
            try
            {
                Convert.ToDouble(textBoxBankroll.Text.Replace(".", ","));
                Convert.ToInt32(textBox1.Text);
                btnCalculate.Enabled = true;
            }
            catch
            {
                btnCalculate.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                countOfTournaments = Convert.ToInt32(textBox1.Text);
                textBox1.ForeColor = Color.Black;
            }
            catch
            {
                textBox1.ForeColor = Color.Red;
            }

            Check();
        }

        private void ChancesToLoseAll(double bankroll, ref double chancesToLoseAll, 
            int level, double chances)
        {
            if (bankroll < buy_in)
            {
                chancesToLoseAll += chances;
                return;
            }

            if (level * buy_in < bankroll)
            {
                return;
            }

            if (level < 1)
            {
                return;
            }

            for (int i = 0; i < moneyForPlace.Length; i++)
            {
                ChancesToLoseAll(bankroll + moneyForPlace[i], ref chancesToLoseAll, level - 1, chances * P[i]);
            }
        }

        private double ChancesToLoseAll(double bankroll, int level)
        {
            double chancesToLoseAll = 0;
            ChancesToLoseAll(bankroll, ref chancesToLoseAll, level, 1);

            return chancesToLoseAll;
        }
    }
}
