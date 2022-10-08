namespace Lab3CommSeriePartieCBarin
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
            this.textBoxTx = new System.Windows.Forms.TextBox();
            this.textBoxRx = new System.Windows.Forms.TextBox();
            this.buttonTx = new System.Windows.Forms.Button();
            this.comPort = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.buttonConfig = new System.Windows.Forms.Button();
            this.buttonQuitter = new System.Windows.Forms.Button();
            this.buttonOuvrir = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelInfos = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelOuvert = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxTx
            // 
            this.textBoxTx.Location = new System.Drawing.Point(12, 55);
            this.textBoxTx.Name = "textBoxTx";
            this.textBoxTx.Size = new System.Drawing.Size(379, 22);
            this.textBoxTx.TabIndex = 0;
            this.textBoxTx.Text = "Vive C#";
            // 
            // textBoxRx
            // 
            this.textBoxRx.Location = new System.Drawing.Point(12, 189);
            this.textBoxRx.Name = "textBoxRx";
            this.textBoxRx.Size = new System.Drawing.Size(379, 22);
            this.textBoxRx.TabIndex = 1;
            this.textBoxRx.Text = "Vive C#";
            // 
            // buttonTx
            // 
            this.buttonTx.Enabled = false;
            this.buttonTx.Location = new System.Drawing.Point(12, 83);
            this.buttonTx.Name = "buttonTx";
            this.buttonTx.Size = new System.Drawing.Size(75, 23);
            this.buttonTx.TabIndex = 2;
            this.buttonTx.Text = "TX";
            this.buttonTx.UseVisualStyleBackColor = true;
            this.buttonTx.Click += new System.EventHandler(this.buttonTx_Click);
            // 
            // comPort
            // 
            this.comPort.PortName = "COMx";
            this.comPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Réception:";
            // 
            // buttonConfig
            // 
            this.buttonConfig.Location = new System.Drawing.Point(12, 222);
            this.buttonConfig.Name = "buttonConfig";
            this.buttonConfig.Size = new System.Drawing.Size(141, 36);
            this.buttonConfig.TabIndex = 6;
            this.buttonConfig.Text = "Config port série";
            this.buttonConfig.UseVisualStyleBackColor = true;
            this.buttonConfig.Click += new System.EventHandler(this.buttonConfig_Click);
            // 
            // buttonQuitter
            // 
            this.buttonQuitter.Location = new System.Drawing.Point(316, 401);
            this.buttonQuitter.Name = "buttonQuitter";
            this.buttonQuitter.Size = new System.Drawing.Size(88, 37);
            this.buttonQuitter.TabIndex = 7;
            this.buttonQuitter.Text = "Quitter";
            this.buttonQuitter.UseVisualStyleBackColor = true;
            this.buttonQuitter.Click += new System.EventHandler(this.buttonQuitter_Click);
            // 
            // buttonOuvrir
            // 
            this.buttonOuvrir.Location = new System.Drawing.Point(250, 222);
            this.buttonOuvrir.Name = "buttonOuvrir";
            this.buttonOuvrir.Size = new System.Drawing.Size(141, 36);
            this.buttonOuvrir.TabIndex = 8;
            this.buttonOuvrir.Text = "Ouvrir";
            this.buttonOuvrir.UseVisualStyleBackColor = true;
            this.buttonOuvrir.Click += new System.EventHandler(this.buttonOuvrir_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelInfos,
            this.toolStripStatusLabelOuvert});
            this.statusStrip1.Location = new System.Drawing.Point(0, 450);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(416, 26);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelInfos
            // 
            this.toolStripStatusLabelInfos.ActiveLinkColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelInfos.Name = "toolStripStatusLabelInfos";
            this.toolStripStatusLabelInfos.Size = new System.Drawing.Size(164, 20);
            this.toolStripStatusLabelInfos.Text = "COMx:9600,None,8,One";
            // 
            // toolStripStatusLabelOuvert
            // 
            this.toolStripStatusLabelOuvert.ActiveLinkColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelOuvert.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelOuvert.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.toolStripStatusLabelOuvert.Name = "toolStripStatusLabelOuvert";
            this.toolStripStatusLabelOuvert.Size = new System.Drawing.Size(50, 20);
            this.toolStripStatusLabelOuvert.Text = "Fermé";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 476);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonOuvrir);
            this.Controls.Add(this.buttonQuitter);
            this.Controls.Add(this.buttonConfig);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonTx);
            this.Controls.Add(this.textBoxRx);
            this.Controls.Add(this.textBoxTx);
            this.Name = "Form1";
            this.Text = "Lab série Barin";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTx;
        private System.Windows.Forms.TextBox textBoxRx;
        private System.Windows.Forms.Button buttonTx;
        private System.IO.Ports.SerialPort comPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonConfig;
        private System.Windows.Forms.Button buttonQuitter;
        private System.Windows.Forms.Button buttonOuvrir;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInfos;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelOuvert;
    }
}

