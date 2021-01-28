using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VäderDataForms.Classes;

namespace VäderDataForms
{
    public partial class Form1 : Form
    {
        List<string[]> resultList = new List<string[]>();
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            List<ComboItem> items = new List<ComboItem>();
            items.Add(new ComboItem { ID = 1, Text = "  Utomhus" });
            items.Add(new ComboItem { ID = 2, Text = "Varmaste till kallaste dag" });
            items.Add(new ComboItem { ID = 3, Text = "Torraste till fuktigaste dag" });
            items.Add(new ComboItem { ID = 4, Text = "Lägsta till högsta mögelrisk" });
            items.Add(new ComboItem { ID = 5, Text = "Meteorologisk höst" });
            items.Add(new ComboItem { ID = 6, Text = "Meteorologisk vinter" });
            items.Add(new ComboItem { ID = 7, Text = "  Inomhus" });
            items.Add(new ComboItem { ID = 8, Text = "Varmaste till kallaste dag" });
            items.Add(new ComboItem { ID = 9, Text = "Torraste till fuktigaste dag" });
            items.Add(new ComboItem { ID = 10, Text = "Lägsta till högsta mögelrisk" });

            statisticsCombo.DataSource = items;
            statisticsCombo.DisplayMember = "Text";
            statisticsCombo.ValueMember = "ID";

            dateInput.ForeColor = Color.Gray;
            dateInput.Text = "(YYYY-MM-DD)";

            dateInput.GotFocus += RemoveText;
            dateInput.LostFocus += AddText;

        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (dateInput.Text == "(YYYY-MM-DD)")
            {
                dateInput.ForeColor = Color.Black;
                dateInput.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dateInput.Text))
            {
                dateInput.ForeColor = Color.Gray;
                dateInput.Text = "(YYYY-MM-DD)";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = (int)statisticsCombo.SelectedValue;
            

            
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Refresh();

            switch (id)
            {
                case 1:
                    //Outdoor
                    break;
                case 2:
                    resultList = OutdoorQuery.SortWarmestDayOutdoor();
                    listView1.Columns.Add("Datum", 90, HorizontalAlignment.Center);
                    listView1.Columns.Add("Medeltemperatur", 120, HorizontalAlignment.Center);
                    break;

                case 3:
                    resultList = OutdoorQuery.SortMostAridDayOutdoor();
                    listView1.Columns.Add("Datum", 90, HorizontalAlignment.Center);
                    listView1.Columns.Add("Medelfuktighet", 120, HorizontalAlignment.Center);
                    break;

                case 4:
                    resultList = OutdoorQuery.LowestToHighestMoldOutdoor();
                    listView1.Columns.Add("Datum", 90, HorizontalAlignment.Center);
                    listView1.Columns.Add("Mögelrisk", 100, HorizontalAlignment.Center);
                    break;

                case 5:
                    resultList = OutdoorQuery.MeteorologicalAutumn();
                    listView1.Columns.Add("Datum", 150, HorizontalAlignment.Center);
                    break;

                case 6:
                    resultList = OutdoorQuery.MeteorologicalWinter();
                    listView1.Columns.Add("Datum", 140, HorizontalAlignment.Center);
                    break;
                case 7:
                    //Indoor
                    break;

                case 8:
                    resultList = IndoorQuery.SortWarmestDayIndoor();
                    listView1.Columns.Add("Datum", 90, HorizontalAlignment.Center);
                    listView1.Columns.Add("Medeltemperatur", 120, HorizontalAlignment.Center);
                    break;

                case 9:
                    resultList = IndoorQuery.SortMostAridDayIndoor();
                    listView1.Columns.Add("Datum", 90, HorizontalAlignment.Center);
                    listView1.Columns.Add("Medelfuktighet", 120, HorizontalAlignment.Center);
                    break;

                case 10:
                    resultList = IndoorQuery.LowestToHighestMoldIndoor();
                    listView1.Columns.Add("Datum", 90, HorizontalAlignment.Center);
                    listView1.Columns.Add("Mögelrisk", 100, HorizontalAlignment.Center);
                    break;

                default:
                    break;
            }

            foreach (var item in resultList)
            {
                listView1.Items.Add(new ListViewItem(item));
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxIndoor.Checked = !checkBoxOutdoor.Checked;
        }

        public void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxOutdoor.Checked = !checkBoxIndoor.Checked;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Refresh();

            try
            {
                if (checkBoxOutdoor.Checked)
                {
                    DateTime date = Convert.ToDateTime(dateInput.Text);
                    resultList = OutdoorQuery.SearchOutdoors(date);

                }
                else if (checkBoxIndoor.Checked)
                {
                    DateTime date = Convert.ToDateTime(dateInput.Text);
                    resultList = IndoorQuery.SearchIndoors(date);
                }

                if (resultList != null)
                {
                    listView1.Columns.Add("Datum", 90, HorizontalAlignment.Center);
                    listView1.Columns.Add("Medeltemperatur", 120, HorizontalAlignment.Center);

                    foreach (var item in resultList)
                    {
                        listView1.Items.Add(new ListViewItem(item));
                    }

                    if (faultyInputLabel.Visible)
                    {
                        faultyInputLabel.Visible = false;
                    }
                    else { }
                }
            }
            catch (Exception)
            {
                faultyInputLabel.Visible = true;
            }
        }
    }
}
