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


    // Requires an update
    public partial class TournamentsEditor : Form
    {
        public Tournament tournament { get; private set; }
        ToolTip tt = new ToolTip();

        public TournamentsEditor()
        {
            InitializeComponent();

            comboBoxType.TextChanged += (Sender, Ea) =>
            {
                if (comboBoxType.Text == "")
                    lblComboBoxTypeInputError.Visible = true;
                else
                    lblComboBoxTypeInputError.Visible = false;
                CheckAvailabilitySaveButton();
            };

            textBuy_in.TextChanged += (Sender, Ea) =>
            {
                if (textBuy_in.Text.ToLower() != "free")
                {
                    try
                    {
                        if (textBuy_in.Text.Length > 1)
                        {
                            if (textBuy_in.Text[0] != '$' || Convert.ToDouble(textBuy_in.Text.Substring(1)) < 0)
                                lblTextFinishedInputError.Visible = true;
                            else
                                lblTextBuy_inInputError.Visible = false;
                        }
                        else
                            lblTextFinishedInputError.Visible = true;
                    }
                    catch
                    {
                        lblTextBuy_inInputError.Visible = true;
                    }
                }
                else
                    lblTextBuy_inInputError.Visible = false;
                CheckAvailabilitySaveButton();
            };
            tt.SetToolTip(lblTextBuy_inInputError,
                "Enter buy-in\nFor example:\"$3\", \n\"$5.50\" or \"Free\"");

            textFinished.TextChanged += (Sender, Ea) =>
            {
                try
                {
                    if (Convert.ToInt32(textFinished.Text) < 1)
                        lblTextFinishedInputError.Visible = true;
                    else
                        lblTextFinishedInputError.Visible = false;
                }
                catch
                {
                    lblTextFinishedInputError.Visible = true;
                }
                CheckAvailabilitySaveButton();
            };
            tt.SetToolTip(lblTextFinishedInputError,
                "Enter a positive integer");

            textEarnings.TextChanged += (Sender, Ea) =>
            {
                try
                {
                    if (textEarnings.Text.Length > 1)
                    {
                        if (Convert.ToDouble(textEarnings.Text.Substring(1)) < 0)
                            lblTextEarningsInputError.Visible = true;
                        else
                            lblTextEarningsInputError.Visible = false;
                    }
                    else
                        lblTextEarningsInputError.Visible = true;
                }
                catch
                {
                    lblTextEarningsInputError.Visible = true;
                }
                CheckAvailabilitySaveButton();
            };
            tt.SetToolTip(lblTextEarningsInputError,
                "Enter earnings\nFor example:\"$3\", \"$5.50\"");


        }

        private void CheckAvailabilitySaveButton()
        {
            if (!lblComboBoxTypeInputError.Visible
                && !lblTextBuy_inInputError.Visible
                && !lblTextFinishedInputError.Visible
                && !lblTextEarningsInputError.Visible)
            {
                btnSave.Enabled = true;
            }
            else
                btnSave.Enabled = false;
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            tournament = new Tournament();
            try
            {
                tournament.Started = Convert.ToDateTime(dtPickerStarted.Text);

                /*
                tournament.Duration =
                    new TimeSpan(Convert.ToInt32(dtPickerDuration.Text.Substring(0, dtPickerDuration.Text.IndexOf(':'))),
                    Convert.ToInt32(dtPickerDuration.Text.Substring(dtPickerDuration.Text.IndexOf(':') + 1)), 0);
                */
                tournament.Buy_in = textBuy_in.Text.ToLower() == "free" ? 0.0 : Convert.ToDouble(textBuy_in.Text.Substring(1));
                tournament.Place = Convert.ToInt32(textFinished.Text);
                tournament.Earnings = Convert.ToDouble(textEarnings.Text.Substring(1));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Source + ": " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(tournament.ToLongString() + "\n\nSave changes?\n", "Tournaments editor", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Cancel)
                return;

            DialogResult = result;
            Close();
        }
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Clear()
        {
            comboBoxType.Text = "";
            dtPickerStarted.Text = "01.01.2016 12:00";
            dtPickerDuration.Text = "0:00";
            textBuy_in.Text = "";
            textFinished.Text = "";
            textEarnings.Text = "";

            lblComboBoxTypeInputError.Visible =
                lblTextBuy_inInputError.Visible =
                lblTextFinishedInputError.Visible =
                lblTextEarningsInputError.Visible = true;
        }
    }
}
