namespace Lab4StationMeteoBarin
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelInfos = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelOuvert = new System.Windows.Forms.ToolStripStatusLabel();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enregistrerSousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portSérieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.panelTemperature = new System.Windows.Forms.Panel();
            this.labelTemp = new System.Windows.Forms.Label();
            this.panelHumidite = new System.Windows.Forms.Panel();
            this.labelHumidity = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelDir = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelWind = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelPressure = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comPort = new System.IO.Ports.SerialPort(this.components);
            this.labelTemperature = new System.Windows.Forms.Label();
            this.labelHumidite = new System.Windows.Forms.Label();
            this.labelVitesse = new System.Windows.Forms.Label();
            this.labelDirection = new System.Windows.Forms.Label();
            this.labelPression = new System.Windows.Forms.Label();
            this.ColumnTemps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTemperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHumidite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVitesse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDirection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPression = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelTemperature.SuspendLayout();
            this.panelHumidite.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelInfos,
            this.toolStripStatusLabelOuvert});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1147, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelInfos
            // 
            this.toolStripStatusLabelInfos.Name = "toolStripStatusLabelInfos";
            this.toolStripStatusLabelInfos.Size = new System.Drawing.Size(164, 20);
            this.toolStripStatusLabelInfos.Text = "COMx:9600,None,8,One";
            // 
            // toolStripStatusLabelOuvert
            // 
            this.toolStripStatusLabelOuvert.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelOuvert.Name = "toolStripStatusLabelOuvert";
            this.toolStripStatusLabelOuvert.Size = new System.Drawing.Size(50, 20);
            this.toolStripStatusLabelOuvert.Text = "Fermé";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enregistrerSousToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // enregistrerSousToolStripMenuItem
            // 
            this.enregistrerSousToolStripMenuItem.Name = "enregistrerSousToolStripMenuItem";
            this.enregistrerSousToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.enregistrerSousToolStripMenuItem.Text = "Enregistrer sous...";
            this.enregistrerSousToolStripMenuItem.Click += new System.EventHandler(this.enregistrerSousToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(205, 26);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portSérieToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // portSérieToolStripMenuItem
            // 
            this.portSérieToolStripMenuItem.Name = "portSérieToolStripMenuItem";
            this.portSérieToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.portSérieToolStripMenuItem.Text = "Port série";
            this.portSérieToolStripMenuItem.Click += new System.EventHandler(this.portSérieToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.configurationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1147, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1147, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.portSérieToolStripMenuItem_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.enregistrerSousToolStripMenuItem_Click);
            // 
            // panelTemperature
            // 
            this.panelTemperature.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelTemperature.Controls.Add(this.labelTemp);
            this.panelTemperature.Controls.Add(this.labelTemperature);
            this.panelTemperature.Location = new System.Drawing.Point(12, 58);
            this.panelTemperature.Name = "panelTemperature";
            this.panelTemperature.Size = new System.Drawing.Size(221, 206);
            this.panelTemperature.TabIndex = 3;
            // 
            // labelTemp
            // 
            this.labelTemp.AutoSize = true;
            this.labelTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemp.Location = new System.Drawing.Point(3, 10);
            this.labelTemp.Name = "labelTemp";
            this.labelTemp.Size = new System.Drawing.Size(216, 29);
            this.labelTemp.TabIndex = 4;
            this.labelTemp.Text = "Température (°C)";
            // 
            // panelHumidite
            // 
            this.panelHumidite.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelHumidite.Controls.Add(this.labelHumidity);
            this.panelHumidite.Controls.Add(this.labelHumidite);
            this.panelHumidite.Location = new System.Drawing.Point(239, 58);
            this.panelHumidite.Name = "panelHumidite";
            this.panelHumidite.Size = new System.Drawing.Size(221, 206);
            this.panelHumidite.TabIndex = 6;
            // 
            // labelHumidity
            // 
            this.labelHumidity.AutoSize = true;
            this.labelHumidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHumidity.Location = new System.Drawing.Point(26, 10);
            this.labelHumidity.Name = "labelHumidity";
            this.labelHumidity.Size = new System.Drawing.Size(165, 29);
            this.labelHumidity.TabIndex = 4;
            this.labelHumidity.Text = "Humidité (%)";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel3.Controls.Add(this.labelDir);
            this.panel3.Controls.Add(this.labelSpeed);
            this.panel3.Controls.Add(this.labelWind);
            this.panel3.Controls.Add(this.labelVitesse);
            this.panel3.Controls.Add(this.labelDirection);
            this.panel3.Location = new System.Drawing.Point(466, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(221, 206);
            this.panel3.TabIndex = 7;
            // 
            // labelDir
            // 
            this.labelDir.AutoSize = true;
            this.labelDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDir.Location = new System.Drawing.Point(7, 122);
            this.labelDir.Name = "labelDir";
            this.labelDir.Size = new System.Drawing.Size(97, 25);
            this.labelDir.TabIndex = 8;
            this.labelDir.Text = "Direction";
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpeed.Location = new System.Drawing.Point(7, 47);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(153, 25);
            this.labelSpeed.TabIndex = 7;
            this.labelSpeed.Text = "Vitesse (km/h)";
            // 
            // labelWind
            // 
            this.labelWind.AutoSize = true;
            this.labelWind.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWind.Location = new System.Drawing.Point(76, 10);
            this.labelWind.Name = "labelWind";
            this.labelWind.Size = new System.Drawing.Size(65, 29);
            this.labelWind.TabIndex = 4;
            this.labelWind.Text = "Vent";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel4.Controls.Add(this.labelPressure);
            this.panel4.Controls.Add(this.labelPression);
            this.panel4.Location = new System.Drawing.Point(693, 58);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(221, 206);
            this.panel4.TabIndex = 7;
            // 
            // labelPressure
            // 
            this.labelPressure.AutoSize = true;
            this.labelPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPressure.Location = new System.Drawing.Point(26, 10);
            this.labelPressure.Name = "labelPressure";
            this.labelPressure.Size = new System.Drawing.Size(185, 29);
            this.labelPressure.TabIndex = 4;
            this.labelPressure.Text = "Pression (kPa)";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTemps,
            this.ColumnSource,
            this.ColumnTemperature,
            this.ColumnHumidite,
            this.ColumnVitesse,
            this.ColumnDirection,
            this.ColumnPression});
            this.dataGridView1.Location = new System.Drawing.Point(13, 271);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(913, 265);
            this.dataGridView1.TabIndex = 8;
            // 
            // comPort
            // 
            this.comPort.PortName = "COMx";
            this.comPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.comPort_DataReceived);
            // 
            // labelTemperature
            // 
            this.labelTemperature.BackColor = System.Drawing.SystemColors.Control;
            this.labelTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemperature.Location = new System.Drawing.Point(8, 79);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(197, 34);
            this.labelTemperature.TabIndex = 6;
            this.labelTemperature.Text = "18.4";
            this.labelTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHumidite
            // 
            this.labelHumidite.BackColor = System.Drawing.SystemColors.Control;
            this.labelHumidite.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHumidite.Location = new System.Drawing.Point(12, 79);
            this.labelHumidite.Name = "labelHumidite";
            this.labelHumidite.Size = new System.Drawing.Size(197, 34);
            this.labelHumidite.TabIndex = 7;
            this.labelHumidite.Text = "35";
            this.labelHumidite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVitesse
            // 
            this.labelVitesse.BackColor = System.Drawing.SystemColors.Control;
            this.labelVitesse.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVitesse.Location = new System.Drawing.Point(12, 79);
            this.labelVitesse.Name = "labelVitesse";
            this.labelVitesse.Size = new System.Drawing.Size(197, 34);
            this.labelVitesse.TabIndex = 8;
            this.labelVitesse.Text = "25";
            this.labelVitesse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDirection
            // 
            this.labelDirection.BackColor = System.Drawing.SystemColors.Control;
            this.labelDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDirection.Location = new System.Drawing.Point(12, 150);
            this.labelDirection.Name = "labelDirection";
            this.labelDirection.Size = new System.Drawing.Size(197, 34);
            this.labelDirection.TabIndex = 9;
            this.labelDirection.Text = "Nord";
            this.labelDirection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPression
            // 
            this.labelPression.BackColor = System.Drawing.SystemColors.Control;
            this.labelPression.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPression.Location = new System.Drawing.Point(14, 79);
            this.labelPression.Name = "labelPression";
            this.labelPression.Size = new System.Drawing.Size(197, 34);
            this.labelPression.TabIndex = 7;
            this.labelPression.Text = "102.3";
            this.labelPression.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColumnTemps
            // 
            this.ColumnTemps.HeaderText = "Temps";
            this.ColumnTemps.MinimumWidth = 6;
            this.ColumnTemps.Name = "ColumnTemps";
            this.ColumnTemps.Width = 90;
            // 
            // ColumnSource
            // 
            this.ColumnSource.HeaderText = "Source";
            this.ColumnSource.MinimumWidth = 6;
            this.ColumnSource.Name = "ColumnSource";
            this.ColumnSource.Width = 90;
            // 
            // ColumnTemperature
            // 
            this.ColumnTemperature.HeaderText = "Température (°C)";
            this.ColumnTemperature.MinimumWidth = 6;
            this.ColumnTemperature.Name = "ColumnTemperature";
            this.ColumnTemperature.Width = 90;
            // 
            // ColumnHumidite
            // 
            this.ColumnHumidite.HeaderText = "Humidité (%)";
            this.ColumnHumidite.MinimumWidth = 6;
            this.ColumnHumidite.Name = "ColumnHumidite";
            this.ColumnHumidite.Width = 90;
            // 
            // ColumnVitesse
            // 
            this.ColumnVitesse.HeaderText = "Vitesse vent (km/h)";
            this.ColumnVitesse.MinimumWidth = 6;
            this.ColumnVitesse.Name = "ColumnVitesse";
            this.ColumnVitesse.Width = 90;
            // 
            // ColumnDirection
            // 
            this.ColumnDirection.HeaderText = "Direction vent";
            this.ColumnDirection.MinimumWidth = 6;
            this.ColumnDirection.Name = "ColumnDirection";
            this.ColumnDirection.Width = 90;
            // 
            // ColumnPression
            // 
            this.ColumnPression.HeaderText = "Pression (kPa)";
            this.ColumnPression.MinimumWidth = 6;
            this.ColumnPression.Name = "ColumnPression";
            this.ColumnPression.Width = 90;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 565);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelHumidite);
            this.Controls.Add(this.panelTemperature);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Station météo Barin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelTemperature.ResumeLayout(false);
            this.panelTemperature.PerformLayout();
            this.panelHumidite.ResumeLayout(false);
            this.panelHumidite.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInfos;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelOuvert;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enregistrerSousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portSérieToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Panel panelTemperature;
        private System.Windows.Forms.Label labelTemp;
        private System.Windows.Forms.Panel panelHumidite;
        private System.Windows.Forms.Label labelHumidity;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelWind;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelPressure;
        private System.Windows.Forms.Label labelDir;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.IO.Ports.SerialPort comPort;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.Label labelHumidite;
        private System.Windows.Forms.Label labelDirection;
        private System.Windows.Forms.Label labelVitesse;
        private System.Windows.Forms.Label labelPression;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTemps;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTemperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHumidite;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVitesse;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDirection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPression;
    }
}

