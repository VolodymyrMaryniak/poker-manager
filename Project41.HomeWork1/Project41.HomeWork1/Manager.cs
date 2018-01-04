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
    public partial class Manager : Form
    {
        // Форма для редагування турнірів
        private TournamentsEditor editor = new TournamentsEditor();
        // Діалог для вибору каталогу, з якого 
        // будемо завантажуавти інформацію ро турніри
        private FolderBrowserDialog BrowserDialog = new FolderBrowserDialog();
        // Витрачений час
        private TimeSpan TimeSpent = new TimeSpan(0, 0, 0);
        // Зароблені гроші
        private double Money = 0.0;
        // К-ть турнірів
        private uint Count = 0;

        List<Tournament> selectedTournaments = new List<Tournament>();
        List<Tournament> allTournaments = new List<Tournament>();

        public Manager()
        {
            InitializeComponent();
            Data.SortCompare += Data_SortCompare;
        }

        private void Data_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "Id")
            {
                e.SortResult = Convert.ToInt32(e.CellValue1.ToString()).CompareTo(
                    Convert.ToInt32(e.CellValue2.ToString()));
            }

            if (e.Column.Name == "Started")
            {
                e.SortResult = DateTime.Compare(
                        Convert.ToDateTime(e.CellValue1.ToString()),
                        Convert.ToDateTime(e.CellValue2.ToString()));
            }

            if (e.Column.Name == "Buy_in")
            {
                double value1 = Convert.ToDouble(e.CellValue1.ToString().Substring(1));
                double value2 = Convert.ToDouble(e.CellValue2.ToString().Substring(1));
                e.SortResult = value1.CompareTo(value2);

                if (e.SortResult == 0)
                {
                    DateTime dt_Value1 = GetTournament(e.RowIndex1).Started;
                    DateTime dt_Value2 = GetTournament(e.RowIndex2).Started;
                    e.SortResult = DateTime.Compare(
                        dt_Value1,
                        dt_Value2);
                }
            }

            if (e.Column.Name == "SpeedEnum")
            {
                string str1 = e.CellValue1.ToString();
                string str2 = e.CellValue2.ToString();
                int value1 = str1 == "Regular" ? 1 : str1 == "Turbo" ? 2 : 3;
                int value2 = str2 == "Regular" ? 1 : str2 == "Turbo" ? 2 : 3;

                e.SortResult = value1.CompareTo(value2);

                if (e.SortResult == 0)
                {
                    DateTime dt_Value1 = GetTournament(e.RowIndex1).Started;
                    DateTime dt_Value2 = GetTournament(e.RowIndex2).Started;
                    e.SortResult = DateTime.Compare(
                        dt_Value1,
                        dt_Value2);
                }
            }

            if (e.Column.Name == "Players")
            {
                int value1 = Convert.ToInt32(e.CellValue1.ToString());
                int value2 = Convert.ToInt32(e.CellValue2.ToString());

                e.SortResult = value1.CompareTo(value2);

                if (e.SortResult == 0)
                {
                    DateTime dt_Value1 = GetTournament(e.RowIndex1).Started;
                    DateTime dt_Value2 = GetTournament(e.RowIndex2).Started;
                    e.SortResult = DateTime.Compare(
                        dt_Value1,
                        dt_Value2);
                }

            }

            if (e.Column.Name == "Duration")
            {
                string[] duration1 = (e.CellValue1.ToString()).Split(':');
                TimeSpan value1 = new TimeSpan(
                    Convert.ToInt32(duration1[0]),
                    Convert.ToInt32(duration1[1]),
                    0);

                string[] duration2 = (e.CellValue2.ToString()).Split(':');
                TimeSpan value2 = new TimeSpan(
                    Convert.ToInt32(duration2[0]),
                    Convert.ToInt32(duration2[1]),
                    0);

                e.SortResult = TimeSpan.Compare(value1, value2);

                if (e.SortResult == 0)
                {
                    DateTime dt_Value1 = GetTournament(e.RowIndex1).Started;
                    DateTime dt_Value2 = GetTournament(e.RowIndex2).Started;
                    e.SortResult = DateTime.Compare(
                        dt_Value1,
                        dt_Value2);
                }
            }

            if (e.Column.Name == "Place")
            {
                int value1 = Convert.ToInt32(e.CellValue1.ToString());
                int value2 = Convert.ToInt32(e.CellValue2.ToString());

                e.SortResult = value1.CompareTo(value2);

                if (e.SortResult == 0)
                {
                    DateTime dt_Value1 = GetTournament(e.RowIndex1).Started;
                    DateTime dt_Value2 = GetTournament(e.RowIndex2).Started;
                    e.SortResult = DateTime.Compare(
                        dt_Value1,
                        dt_Value2);
                }
            }

            if (e.Column.Name == "Earnings")
            {
                double value1 = Convert.ToDouble(e.CellValue1.ToString().Substring(1));
                double value2 = Convert.ToDouble(e.CellValue2.ToString().Substring(1));
                e.SortResult = value1.CompareTo(value2);

                if (e.SortResult == 0)
                {
                    DateTime dt_Value1 = GetTournament(e.RowIndex1).Started;
                    DateTime dt_Value2 = GetTournament(e.RowIndex2).Started;
                    e.SortResult = DateTime.Compare(
                        dt_Value1,
                        dt_Value2);
                }
            }

            e.Handled = true;
        }

        // Повертає об'єкт турніру, якому відповідає заданий рядок таблиці
        private Tournament GetTournament(int index)
        {
            Tournament tournament = null;
            try
            {
                int id = Convert.ToInt32(Data.Rows[index].Cells["Id"].Value.ToString());
                tournament = allTournaments.FirstOrDefault(t => t.Id == id);
            }
            catch { }

            return tournament;
        }

        // Відкриває редактор турнірів, для створення нового турніру
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Tournament Editor requires an update
            return;

            editor.Clear();
            DialogResult result = editor.ShowDialog();
            if (result == DialogResult.Yes)
            {
                AddTournament(editor.tournament);
                Calculate();
            }
        }

        // Додаємо турнір в таблицю
        private void AddTournament(Tournament tournament)
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

        // Видаляємо виділений турнір з таблиці
        private void btnRemove_Click(object sender, EventArgs e)
        {
            Data.Rows.RemoveAt(Data.SelectedRows[0].Index);
            Calculate();
        }

        private void Search()
        {
            if (allTournaments == null)
            {
                // Турніри ще не завантажені.
                return;
            }

            Data.Rows.Clear();
            selectedTournaments = new List<Tournament>();

            if (checkBoxFilter.Checked)
            {

                #region Filters
                // Players Filter
                List<int> numberOfPlayers = new List<int>();
                if (checkBox_number_2.Checked)
                    numberOfPlayers.Add(2);
                if (checkBox_number_6.Checked)
                    numberOfPlayers.Add(6);
                if (checkBox_number_9.Checked)
                    numberOfPlayers.Add(9);
                if (checkBox_number_10.Checked)
                    numberOfPlayers.Add(10);

                // Speed Filter
                List<Speed> speedList = new List<Speed>();
                if (checkBox_speed_regular.Checked)
                    speedList.Add(Speed.Regular);
                if (checkBox_speed_turbo.Checked)
                    speedList.Add(Speed.Turbo);
                if (checkBox_speed_superTurbo.Checked)
                    speedList.Add(Speed.SuperTurbo);

                // Buy-in Filter
                List<double> buy_inList = new List<double>();
                if (buy_in_0_10.Checked)
                    buy_inList.Add(0.10);
                if (buy_in_0_40.Checked)
                    buy_inList.Add(0.40);
                if (buy_in_1.Checked)
                    buy_inList.Add(1.00);
                if (buy_in_3.Checked)
                    buy_inList.Add(3.00);
                if (buy_in_5.Checked)
                    buy_inList.Add(5.00);
                if (buy_in_10.Checked)
                    buy_inList.Add(10.00);
                if (buy_in_20.Checked)
                    buy_inList.Add(20.00);
                if (buy_in_30.Checked)
                    buy_inList.Add(30.00);
                if (buy_in_50.Checked)
                    buy_inList.Add(50.00);
                if (buy_in_100.Checked)
                    buy_inList.Add(100.00);
                if (buy_in_200.Checked)
                    buy_inList.Add(200.00);
                if (buy_in_500.Checked)
                    buy_inList.Add(500.00);
                if (buy_in_1000.Checked)
                    buy_inList.Add(1000.00);

                #endregion


                foreach (Tournament t in allTournaments)
                {
                    // SnG Filter
                    if (!checkBoxSNG.Checked && t.SnG)
                        continue;

                    // MTT Filter
                    if (!checkBoxMTT.Checked && !t.SnG)
                        continue;

                    // Start Filter
                    if (t.Started < dtFrom.Value || t.Started > dtTo.Value)
                        continue;

                    // Players Filter
                    if (!numberOfPlayers.Contains(t.Players))
                        continue;

                    // Speed Filter
                    if (!speedList.Contains(t.Speed))
                        continue;

                    // Buy-in Filter
                    if (!buy_inList.Contains(Math.Round(t.Buy_in + t.Fee, 2)))
                        continue;

                    selectedTournaments.Add(t);
                    AddTournament(t);
                }
            }
            else
            {
                foreach (Tournament t in allTournaments)
                {
                    selectedTournaments.Add(t);
                    AddTournament(t);
                }
            }

            FillDGVDays();
            Calculate();
        }

        private void FillDGVDays()
        {
            DGVDays.Rows.Clear();

            DateTime date = DateTime.MinValue;
            TimeSpan timeSpent = new TimeSpan(0, 0, 0);
            int countOfTournaments = 0;
            double sumOfBuyins = 0;
            double earnings = 0;

            DateTime lastFinished = DateTime.MinValue;

            foreach (Tournament tournament in selectedTournaments.OrderBy(t => t.Started))
            {
                if (date.Date != tournament.Started.Date)
                {
                    if (date != DateTime.MinValue)
                    {
                        DGVDays.Rows.Add(
                            date.ToString("dd'.'MM'.'yyyy"),
                            timeSpent.ToString("h':'mm"),
                            countOfTournaments,
                            String.Format("${0:F2}", sumOfBuyins),
                            string.Format(earnings < 0
                            ? "-${0:F2} / год."
                            : "+${0:F2} / год.", Math.Abs(earnings / timeSpent.TotalHours)),
                            string.Format(earnings < 0
                            ? "-${0:F2}"
                            : "+${0:F2}", Math.Abs(earnings)));
                    }

                    date = tournament.Started.Date;
                    timeSpent = new TimeSpan(0, 0, 0);
                    countOfTournaments = 0;
                    sumOfBuyins = 0;
                    earnings = 0;

                    lastFinished = DateTime.MinValue;
                }

                if (lastFinished > tournament.Started)
                {
                    if (lastFinished < tournament.Started + tournament.Duration)
                    {
                        timeSpent += tournament.Started + tournament.Duration - lastFinished;
                        lastFinished = tournament.Started + tournament.Duration;
                    }
                }
                else
                {
                    timeSpent += tournament.Duration;
                    lastFinished = tournament.Started + tournament.Duration;
                }

                countOfTournaments++;
                sumOfBuyins += tournament.Buy_in + tournament.Fee;
                earnings += tournament.Earnings - tournament.Buy_in - tournament.Fee;
            }

            try
            {
                DGVDays.Rows.Add(
                    date.ToString("dd'.'MM'.'yyyy"),
                    timeSpent.ToString("h':'mm"),
                    countOfTournaments,
                    string.Format("${0:F2}", sumOfBuyins),
                    string.Format(earnings < 0
                    ? "-${0:F2} / год."
                    : "+${0:F2} / год.", Math.Abs(earnings / timeSpent.TotalHours)),
                    string.Format(earnings < 0
                    ? "-${0:F2}"
                    : "+${0:F2}", Math.Abs(earnings)));
            }
            catch { }
        }

        // Обчислимо витрачений час, зароблені гроші
        // та к-ть турнірів
        private void Calculate()
        {
            Count = 0;
            Money = 0.0;
            TimeSpent = new TimeSpan(0, 0, 0);
            DateTime lastFinished = DateTime.MinValue;
            foreach (Tournament tournament in selectedTournaments.OrderBy(t => t.Started))
            {
                Count++;
                Money += tournament.Earnings - tournament.Buy_in - tournament.Fee;
                if (lastFinished > tournament.Started)
                {
                    if (lastFinished < tournament.Started + tournament.Duration)
                    {
                        TimeSpent += tournament.Started + tournament.Duration - lastFinished;
                        lastFinished = tournament.Started + tournament.Duration;
                    }
                }
                else
                {
                    TimeSpent += tournament.Duration;
                    lastFinished = tournament.Started + tournament.Duration;
                }
            }

            lblNumOfTournaments.Text = Count.ToString();
            lblEarnings.Text = String.Format(Money < 0 ? "-${0:F2}" : "+${0:F2}", Math.Abs(Money));
            lblTimeSpent.Text = TimeSpent.ToString("dd'.'h':'mm");
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void checkBox_all_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var control in panel1.Controls)
            {
                CheckBox checkBox = control as CheckBox;
                if (checkBox != null)
                {
                    checkBox.CheckedChanged -= 
                        new System.EventHandler(this.checkBox_CheckedChanged);
                    checkBox.Checked = checkBox_all.Checked;
                    checkBox.CheckedChanged +=
                        new System.EventHandler(this.checkBox_CheckedChanged);
                }
            }

            Search();
        }

        private void selectDirectoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BrowserDialog.SelectedPath = @"C:\Users\Volodymyr\Desktop\export\888 Poker";

            if (BrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(BrowserDialog.SelectedPath))
                {
                    DownloadFromPokerTrackerExport(BrowserDialog.SelectedPath);
                    FillPopularTournamentsItem();
                    Search();
                }
            }
        }

        private void selectDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrowserDialog.SelectedPath = @"C:\Users\Volodymyr\Documents\888poker\HandHistory\vov4uk33";
            if (BrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(BrowserDialog.SelectedPath))
                {
                    DownloadFromPoker888(BrowserDialog.SelectedPath);
                    FillPopularTournamentsItem();
                    Search();
                }
            }
        }

        private void DownloadFromPokerTrackerExport(string path)
        {
            DirectoryInfo di = null;
            FileInfo[] files = null;
            try
            {
                di = new DirectoryInfo(path);
                files = di.GetFiles("*Summary.txt");
                DownloadFromPokerTrackerExport(files);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error");
                return;
            }
        }

        private void DownloadFromPoker888(string path)
        {
            DirectoryInfo di = null;
            FileInfo[] files = null;
            try
            {
                di = new DirectoryInfo(path);
                files = di.GetFiles();
                DownloadFromPoker888(files);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error");
                return;
            }
        }

        // Add tournaments from files to list which name's 'allTournaments'
        private void DownloadFromPokerTrackerExport(FileInfo[] files)
        {
            foreach (FileInfo file in files)
            {
                try
                {
                    Tournament tournament = Tournament.FromPokerTracker4File(file);

                    if (allTournaments.FirstOrDefault(t => t.Id == tournament.Id) != null)
                    {
                        continue;
                    }

                    allTournaments.Add(tournament);
                }
                catch
                {
                    continue;
                }
            }
        }

        private void DownloadFromPoker888(FileInfo[] files)
        {
            FileInfo errorsFile = new FileInfo("errors2.txt");

            using (StreamWriter writer = new StreamWriter(errorsFile.Open(FileMode.Create)))
            {

                foreach (FileInfo file in files)
                {

                    if (!file.Name.Contains("Summary"))
                    {
                        string message = "Can not find summary file.";
                        try
                        {
                            FileInfo summary = files.First(f => f.Name == file.Name + " - Summary.txt");

                            message = null;
                            Tournament tournament = Tournament.From888PokerFiles(file, summary, false);

                            message = "Something is bad.";
                            if (allTournaments.FirstOrDefault(t => t.Id == tournament.Id) != null)
                            {
                                continue;
                            }

                            allTournaments.Add(tournament);
                        }
                        catch (Exception exc)
                        {
                            if (message == null)
                            {
                                message = exc.Message;
                            }

                            writer.WriteLine(file.Name + " : ");
                            writer.WriteLine(message);
                            writer.WriteLine();
                            continue;
                        }
                    }
                }
            }

        }

        private void FillPopularTournamentsItem()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (Tournament t in allTournaments)
            {
                if (dictionary.ContainsKey(t.Type))
                {
                    dictionary[t.Type]++;
                }
                else
                {
                    dictionary.Add(t.Type, 1);
                }
            }

            List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
            foreach (KeyValuePair<string, int> pair in dictionary)
            {
                if (pair.Value >= 10)
                {
                    list.Add(pair);
                }
            }

            list.Sort((KeyValuePair<string, int> p1, KeyValuePair<string, int> p2) =>
            {
                return p2.Value.CompareTo(p1.Value);
            });

            foreach (KeyValuePair<string, int> pair in list)
            {
                popularTournamentsToolStripMenuItem.DropDownItems.Add(
                    pair.Key + " (" + pair.Value + ")", null,
                    (object o, EventArgs args) =>
                    {
                        List<Tournament> tournaments = (from t in allTournaments
                                                        where t.Type == pair.Key
                                                        select t).ToList<Tournament>();
                        Chart chart = new Chart(tournaments);
                        chart.ShowDialog();
                    });
            }
        }

        private void forecastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allTournaments == null || allTournaments.Count == 0)
                return;
            ChooseTypeOfTournament w = new ChooseTypeOfTournament(allTournaments);
            w.ShowDialog();
            if (w.DialogResult == DialogResult.OK)
            {
                Forecast window = new Forecast(allTournaments, w.Players, w.Buy_in, w.Speed,
                    w.First, w.Second);
                window.Show();
            }
        }

        private void drawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedTournaments.Count > 0)
            {
                Chart chart = new Chart(selectedTournaments);
                chart.ShowDialog();
            }
        }

        private void playPokerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tournaments window = new Tournaments();
            window.Show();
        }

        private void selectFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFilter.Checked)
            {
                panel1.Enabled = true;
            }
            else
            {
                panel1.Enabled = false;
            }

            Search();
        }

        private void сhancesOfBankruptcyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allTournaments == null || allTournaments.Count == 0)
                return;
            ChooseTypeOfTournament w = new ChooseTypeOfTournament(allTournaments);
            w.ShowDialog();
            if (w.DialogResult == DialogResult.OK)
            {
                Forecast window = new Forecast(allTournaments, w.Players, w.Buy_in, w.Speed,
                    w.First, w.Second);
                window.Show();
            }
        }
    }
}
