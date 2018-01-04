using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project41.HomeWork1
{
    public partial class Tournaments : Form
    {
        private bool handsGetting = false;
        private Timer timer = new Timer();
        private double bankroll = 0.0;
        private double earnings = 0.0;
        private double nowInTournaments = 0.0;
        public string path { get; set; }

        private List<Tournament> tournaments = new List<Tournament>();

        public Tournaments()
        {
            InitializeComponent();
            dateTimePicker.Value = DateTime.Now;
            lblCurrent.Text = string.Format("Now you have ${0:F2} and ${1:F2} in tournaments",
                bankroll + earnings, nowInTournaments);
            timer.Interval = 15000;
            timer.Tick += Timer_Tick;

            path = @"C:\Users\Volodymyr\Documents\888poker\HandHistory\vov4uk33";
        }

        public void FillDGV()
        {
            Data.Rows.Clear();

            foreach (Tournament tournament in tournaments)
            {
                Data.Rows.Add(
                    tournament.Id,
                    tournament.Started.ToString("dd'.'MM'.'yyyy HH':'mm"),
                    tournament.Buy_in == 0.0 ? "Free" : String.Format("${0:F2}",
                    tournament.Buy_in + tournament.Fee),
                    tournament.Speed,
                    tournament.Players,
                    tournament.Duration.ToString("h':'mm"),
                    tournament.Place.ToString(),
                    String.Format("${0:F2}", tournament.Earnings)
                    );
            }
        }

        public void Download()
        {
            DirectoryInfo di = null;
            FileInfo[] files = null;
            try
            {
                di = new DirectoryInfo(path);
                files = di.GetFiles();
                Download(files);
            }
            catch
            {
                return;
            }
        }

        public void Download(FileInfo[] files)
        {
            tournaments.Clear();

            foreach (FileInfo file in files)
            {
                if (!file.Name.Contains("Summary"))
                {
                    try
                    {
                        FileInfo summary = files.FirstOrDefault(f => f.Name == file.Name + " - Summary.txt");

                        if (summary == null)
                        {
                            Tournament tournament = Tournament.From888PokerFile(file);
                            tournaments.Add(tournament);
                        }
                        else
                        {
                            Tournament tournament = Tournament.From888PokerFiles(file, summary, false);

                            if (tournament.Started >= dateTimePicker.Value)
                            {
                                tournaments.Add(tournament);
                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Download();
            FillDGV();

            earnings = 0;
            nowInTournaments = 0;

            foreach (Tournament tournament in tournaments.Where(t => t.Finished != null))
            {
                earnings += tournament.Earnings - tournament.Buy_in - tournament.Fee;
            }

            foreach(Tournament tournament in tournaments.Where(t => t.Finished == null))
            {
                nowInTournaments += tournament.Buy_in + tournament.Fee;
            }

            lblCurrent.Text = string.Format("Now you have ${0:F2} and ${1:F2} in tournaments",
                bankroll + earnings, nowInTournaments);
        }

        private void btnHands_Click(object sender, EventArgs e)
        {
            if (handsGetting)
            {
                timer.Stop();
                handsGetting = false;
                btnHands.Text = "Start getting hands";
            }
            else
            {
                timer.Start();
                handsGetting = true;
                btnHands.Text = "Stop getting hands";
            }
        }

        private void textBoxBankroll_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bankroll = Convert.ToDouble(textBoxBankroll.Text);
                textBoxBankroll.ForeColor = Color.Black;
            }
            catch
            {
                textBoxBankroll.ForeColor = Color.Red;
            }
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.SelectedPath = path;

            if (dialog.ShowDialog() == DialogResult.OK)
                path = dialog.SelectedPath;

            if (Directory.Exists(path))
            {

            }
            else
            {

            }
        }
    }
}
