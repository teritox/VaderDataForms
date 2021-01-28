
namespace VäderDataForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statisticsCombo = new System.Windows.Forms.ComboBox();
            this.statisticsLabel = new System.Windows.Forms.Label();
            this.stastisticsSearch = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Datum = new System.Windows.Forms.ColumnHeader();
            this.Temperatur = new System.Windows.Forms.ColumnHeader();
            this.Fuktighet = new System.Windows.Forms.ColumnHeader();
            this.dateSearch = new System.Windows.Forms.Button();
            this.dateInput = new System.Windows.Forms.TextBox();
            this.checkBoxOutdoor = new System.Windows.Forms.CheckBox();
            this.checkBoxIndoor = new System.Windows.Forms.CheckBox();
            this.dateInputLabel = new System.Windows.Forms.Label();
            this.faultyInputLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // statisticsCombo
            // 
            this.statisticsCombo.BackColor = System.Drawing.Color.White;
            this.statisticsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statisticsCombo.FormattingEnabled = true;
            this.statisticsCombo.Items.AddRange(new object[] {
            "  Utomhus",
            "Medeltemperatur",
            "Varmaste till kallaste dag",
            "Torraste till fuktigaste dag",
            "Högsta till minsta mögelrisk",
            "Datum för meteorologisk höst",
            "Datum för meteorologisk vinter",
            "  Inomhus",
            "Medeltemperatur",
            "Varmaste till kallaste dag",
            "Torraste till fuktigaste dag",
            "Högsta till minska mögelrisk"});
            this.statisticsCombo.Location = new System.Drawing.Point(32, 44);
            this.statisticsCombo.Name = "statisticsCombo";
            this.statisticsCombo.Size = new System.Drawing.Size(218, 23);
            this.statisticsCombo.TabIndex = 0;
            this.statisticsCombo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // statisticsLabel
            // 
            this.statisticsLabel.AutoSize = true;
            this.statisticsLabel.BackColor = System.Drawing.Color.Transparent;
            this.statisticsLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statisticsLabel.Location = new System.Drawing.Point(32, 22);
            this.statisticsLabel.Name = "statisticsLabel";
            this.statisticsLabel.Size = new System.Drawing.Size(91, 19);
            this.statisticsLabel.TabIndex = 1;
            this.statisticsLabel.Text = "Väderstatistik";
            // 
            // stastisticsSearch
            // 
            this.stastisticsSearch.BackColor = System.Drawing.SystemColors.Control;
            this.stastisticsSearch.Location = new System.Drawing.Point(268, 44);
            this.stastisticsSearch.Name = "stastisticsSearch";
            this.stastisticsSearch.Size = new System.Drawing.Size(75, 23);
            this.stastisticsSearch.TabIndex = 2;
            this.stastisticsSearch.Text = "Visa";
            this.stastisticsSearch.UseVisualStyleBackColor = false;
            this.stastisticsSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Datum,
            this.Temperatur,
            this.Fuktighet});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(32, 218);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(311, 384);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Datum
            // 
            this.Datum.Name = "Datum";
            this.Datum.Text = "Datum";
            this.Datum.Width = 90;
            // 
            // Temperatur
            // 
            this.Temperatur.Name = "Temperatur";
            this.Temperatur.Text = "Temperatur";
            this.Temperatur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Temperatur.Width = 95;
            // 
            // Fuktighet
            // 
            this.Fuktighet.Name = "Fuktighet";
            this.Fuktighet.Text = "Fuktighet";
            this.Fuktighet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Fuktighet.Width = 85;
            // 
            // dateSearch
            // 
            this.dateSearch.Location = new System.Drawing.Point(268, 127);
            this.dateSearch.Name = "dateSearch";
            this.dateSearch.Size = new System.Drawing.Size(75, 23);
            this.dateSearch.TabIndex = 4;
            this.dateSearch.Text = "Sök";
            this.dateSearch.UseVisualStyleBackColor = true;
            this.dateSearch.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateInput
            // 
            this.dateInput.Location = new System.Drawing.Point(32, 156);
            this.dateInput.Name = "dateInput";
            this.dateInput.Size = new System.Drawing.Size(135, 23);
            this.dateInput.TabIndex = 6;
            this.dateInput.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // checkBoxOutdoor
            // 
            this.checkBoxOutdoor.AutoSize = true;
            this.checkBoxOutdoor.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxOutdoor.Checked = true;
            this.checkBoxOutdoor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOutdoor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxOutdoor.Location = new System.Drawing.Point(32, 127);
            this.checkBoxOutdoor.Name = "checkBoxOutdoor";
            this.checkBoxOutdoor.Size = new System.Drawing.Size(85, 23);
            this.checkBoxOutdoor.TabIndex = 7;
            this.checkBoxOutdoor.Text = "Utomhus";
            this.checkBoxOutdoor.UseVisualStyleBackColor = false;
            this.checkBoxOutdoor.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxIndoor
            // 
            this.checkBoxIndoor.AutoSize = true;
            this.checkBoxIndoor.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxIndoor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxIndoor.Location = new System.Drawing.Point(123, 127);
            this.checkBoxIndoor.Name = "checkBoxIndoor";
            this.checkBoxIndoor.Size = new System.Drawing.Size(82, 23);
            this.checkBoxIndoor.TabIndex = 9;
            this.checkBoxIndoor.Text = "Inomhus";
            this.checkBoxIndoor.UseVisualStyleBackColor = false;
            this.checkBoxIndoor.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // dateInputLabel
            // 
            this.dateInputLabel.AutoSize = true;
            this.dateInputLabel.BackColor = System.Drawing.Color.Transparent;
            this.dateInputLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateInputLabel.Location = new System.Drawing.Point(32, 96);
            this.dateInputLabel.Name = "dateInputLabel";
            this.dateInputLabel.Size = new System.Drawing.Size(94, 19);
            this.dateInputLabel.TabIndex = 10;
            this.dateInputLabel.Text = "Sök på datum";
            // 
            // faultyInputLabel
            // 
            this.faultyInputLabel.AutoSize = true;
            this.faultyInputLabel.BackColor = System.Drawing.Color.Transparent;
            this.faultyInputLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.faultyInputLabel.Location = new System.Drawing.Point(32, 182);
            this.faultyInputLabel.Name = "faultyInputLabel";
            this.faultyInputLabel.Size = new System.Drawing.Size(215, 19);
            this.faultyInputLabel.TabIndex = 11;
            this.faultyInputLabel.Text = "Ingen data hittas på det datumet.";
            this.faultyInputLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(653, 631);
            this.Controls.Add(this.faultyInputLabel);
            this.Controls.Add(this.dateInputLabel);
            this.Controls.Add(this.checkBoxIndoor);
            this.Controls.Add(this.checkBoxOutdoor);
            this.Controls.Add(this.dateInput);
            this.Controls.Add(this.dateSearch);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.stastisticsSearch);
            this.Controls.Add(this.statisticsLabel);
            this.Controls.Add(this.statisticsCombo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Väderdata";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.ComboBox statisticsCombo;
        private System.Windows.Forms.Label statisticsLabel;
        private System.Windows.Forms.Button stastisticsSearch;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Datum;
        private System.Windows.Forms.ColumnHeader Temperatur;
        private System.Windows.Forms.ColumnHeader Fuktighet;
        private System.Windows.Forms.Button dateSearch;
        private System.Windows.Forms.TextBox dateInput;
        private System.Windows.Forms.CheckBox checkBoxOutdoor;
        private System.Windows.Forms.CheckBox checkBoxIndoor;
        private System.Windows.Forms.Label dateInputLabel;
        private System.Windows.Forms.Label faultyInputLabel;
    }
}

