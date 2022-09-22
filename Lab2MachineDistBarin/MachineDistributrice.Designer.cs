namespace Lab2MachineDistBarin
{
    partial class MachineDistributrice
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
            this.panelCredit = new System.Windows.Forms.Panel();
            this.button2Dollars = new System.Windows.Forms.Button();
            this.button1Dollar = new System.Windows.Forms.Button();
            this.button25Cents = new System.Windows.Forms.Button();
            this.button10Cents = new System.Windows.Forms.Button();
            this.button5Cents = new System.Windows.Forms.Button();
            this.labelCredit = new System.Windows.Forms.Label();
            this.listBoxDisplay = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAchat = new System.Windows.Forms.TabPage();
            this.panelClavier = new System.Windows.Forms.Panel();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.labelClavier = new System.Windows.Forms.Label();
            this.tabPageInv = new System.Windows.Forms.TabPage();
            this.buttonModInv = new System.Windows.Forms.Button();
            this.labelQuantite = new System.Windows.Forms.Label();
            this.labelPrix = new System.Windows.Forms.Label();
            this.labelColonne = new System.Windows.Forms.Label();
            this.textBoxQuantite = new System.Windows.Forms.TextBox();
            this.labelRangee = new System.Windows.Forms.Label();
            this.textBoxPrix = new System.Windows.Forms.TextBox();
            this.comboBoxColonne = new System.Windows.Forms.ComboBox();
            this.comboBoxRangee = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelCredit.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageAchat.SuspendLayout();
            this.panelClavier.SuspendLayout();
            this.tabPageInv.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCredit
            // 
            this.panelCredit.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panelCredit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelCredit.Controls.Add(this.button2Dollars);
            this.panelCredit.Controls.Add(this.button1Dollar);
            this.panelCredit.Controls.Add(this.button25Cents);
            this.panelCredit.Controls.Add(this.button10Cents);
            this.panelCredit.Controls.Add(this.button5Cents);
            this.panelCredit.Controls.Add(this.labelCredit);
            this.panelCredit.Location = new System.Drawing.Point(6, 163);
            this.panelCredit.Name = "panelCredit";
            this.panelCredit.Size = new System.Drawing.Size(257, 163);
            this.panelCredit.TabIndex = 1;
            // 
            // button2Dollars
            // 
            this.button2Dollars.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2Dollars.Location = new System.Drawing.Point(91, 94);
            this.button2Dollars.Name = "button2Dollars";
            this.button2Dollars.Size = new System.Drawing.Size(73, 31);
            this.button2Dollars.TabIndex = 5;
            this.button2Dollars.Text = "2.00$";
            this.button2Dollars.UseVisualStyleBackColor = true;
            this.button2Dollars.Click += new System.EventHandler(this.credit_Click);
            // 
            // button1Dollar
            // 
            this.button1Dollar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1Dollar.Location = new System.Drawing.Point(12, 94);
            this.button1Dollar.Name = "button1Dollar";
            this.button1Dollar.Size = new System.Drawing.Size(73, 31);
            this.button1Dollar.TabIndex = 4;
            this.button1Dollar.Text = "1.00$";
            this.button1Dollar.UseVisualStyleBackColor = true;
            this.button1Dollar.Click += new System.EventHandler(this.credit_Click);
            // 
            // button25Cents
            // 
            this.button25Cents.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button25Cents.Location = new System.Drawing.Point(170, 57);
            this.button25Cents.Name = "button25Cents";
            this.button25Cents.Size = new System.Drawing.Size(75, 31);
            this.button25Cents.TabIndex = 3;
            this.button25Cents.Text = "0.25$";
            this.button25Cents.UseVisualStyleBackColor = true;
            this.button25Cents.Click += new System.EventHandler(this.credit_Click);
            // 
            // button10Cents
            // 
            this.button10Cents.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10Cents.Location = new System.Drawing.Point(91, 57);
            this.button10Cents.Name = "button10Cents";
            this.button10Cents.Size = new System.Drawing.Size(73, 31);
            this.button10Cents.TabIndex = 2;
            this.button10Cents.Text = "0.10$";
            this.button10Cents.UseVisualStyleBackColor = true;
            this.button10Cents.Click += new System.EventHandler(this.credit_Click);
            // 
            // button5Cents
            // 
            this.button5Cents.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5Cents.Location = new System.Drawing.Point(12, 57);
            this.button5Cents.Name = "button5Cents";
            this.button5Cents.Size = new System.Drawing.Size(73, 31);
            this.button5Cents.TabIndex = 1;
            this.button5Cents.Text = "0.05$";
            this.button5Cents.UseVisualStyleBackColor = true;
            this.button5Cents.Click += new System.EventHandler(this.credit_Click);
            // 
            // labelCredit
            // 
            this.labelCredit.AutoSize = true;
            this.labelCredit.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCredit.Location = new System.Drawing.Point(3, 9);
            this.labelCredit.Name = "labelCredit";
            this.labelCredit.Size = new System.Drawing.Size(123, 27);
            this.labelCredit.TabIndex = 0;
            this.labelCredit.Text = "Crédit ($):";
            // 
            // listBoxDisplay
            // 
            this.listBoxDisplay.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxDisplay.FormattingEnabled = true;
            this.listBoxDisplay.ItemHeight = 19;
            this.listBoxDisplay.Location = new System.Drawing.Point(6, 6);
            this.listBoxDisplay.Name = "listBoxDisplay";
            this.listBoxDisplay.Size = new System.Drawing.Size(531, 118);
            this.listBoxDisplay.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAchat);
            this.tabControl1.Controls.Add(this.tabPageInv);
            this.tabControl1.Location = new System.Drawing.Point(3, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(551, 427);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.changeIndex);
            // 
            // tabPageAchat
            // 
            this.tabPageAchat.BackColor = System.Drawing.Color.Gray;
            this.tabPageAchat.Controls.Add(this.panelClavier);
            this.tabPageAchat.Controls.Add(this.listBoxDisplay);
            this.tabPageAchat.Controls.Add(this.panelCredit);
            this.tabPageAchat.Location = new System.Drawing.Point(4, 25);
            this.tabPageAchat.Name = "tabPageAchat";
            this.tabPageAchat.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAchat.Size = new System.Drawing.Size(543, 398);
            this.tabPageAchat.TabIndex = 0;
            this.tabPageAchat.Text = "Achat";
            // 
            // panelClavier
            // 
            this.panelClavier.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panelClavier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelClavier.Controls.Add(this.buttonEnter);
            this.panelClavier.Controls.Add(this.buttonClear);
            this.panelClavier.Controls.Add(this.button0);
            this.panelClavier.Controls.Add(this.button3);
            this.panelClavier.Controls.Add(this.button2);
            this.panelClavier.Controls.Add(this.button1);
            this.panelClavier.Controls.Add(this.button6);
            this.panelClavier.Controls.Add(this.button5);
            this.panelClavier.Controls.Add(this.button4);
            this.panelClavier.Controls.Add(this.button9);
            this.panelClavier.Controls.Add(this.button8);
            this.panelClavier.Controls.Add(this.button7);
            this.panelClavier.Controls.Add(this.labelClavier);
            this.panelClavier.Location = new System.Drawing.Point(269, 163);
            this.panelClavier.Name = "panelClavier";
            this.panelClavier.Size = new System.Drawing.Size(268, 218);
            this.panelClavier.TabIndex = 2;
            // 
            // buttonEnter
            // 
            this.buttonEnter.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEnter.Location = new System.Drawing.Point(183, 168);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(64, 31);
            this.buttonEnter.TabIndex = 12;
            this.buttonEnter.Text = "Enter";
            this.buttonEnter.UseVisualStyleBackColor = false;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.Location = new System.Drawing.Point(17, 168);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(64, 31);
            this.buttonClear.TabIndex = 11;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // button0
            // 
            this.button0.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button0.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button0.Location = new System.Drawing.Point(102, 168);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(64, 31);
            this.button0.TabIndex = 0;
            this.button0.UseVisualStyleBackColor = false;
            this.button0.Click += new System.EventHandler(this.clavier_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(183, 131);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 31);
            this.button3.TabIndex = 3;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.clavier_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(102, 131);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 31);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.clavier_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(17, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 31);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.clavier_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button6.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(183, 94);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(64, 31);
            this.button6.TabIndex = 6;
            this.button6.Text = "F";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.clavier_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(102, 94);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(64, 31);
            this.button5.TabIndex = 5;
            this.button5.Text = "E";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.clavier_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(17, 94);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(64, 31);
            this.button4.TabIndex = 4;
            this.button4.Text = "D";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.clavier_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button9.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(183, 57);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(64, 31);
            this.button9.TabIndex = 9;
            this.button9.Text = "C";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.clavier_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button8.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(102, 57);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(64, 31);
            this.button8.TabIndex = 8;
            this.button8.Text = "B";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.clavier_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button7.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(17, 57);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(64, 31);
            this.button7.TabIndex = 7;
            this.button7.Text = "A";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.clavier_Click);
            // 
            // labelClavier
            // 
            this.labelClavier.AutoSize = true;
            this.labelClavier.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClavier.Location = new System.Drawing.Point(3, 9);
            this.labelClavier.Name = "labelClavier";
            this.labelClavier.Size = new System.Drawing.Size(98, 27);
            this.labelClavier.TabIndex = 10;
            this.labelClavier.Text = "Clavier:";
            // 
            // tabPageInv
            // 
            this.tabPageInv.BackColor = System.Drawing.Color.LightGray;
            this.tabPageInv.Controls.Add(this.buttonModInv);
            this.tabPageInv.Controls.Add(this.labelQuantite);
            this.tabPageInv.Controls.Add(this.labelPrix);
            this.tabPageInv.Controls.Add(this.labelColonne);
            this.tabPageInv.Controls.Add(this.textBoxQuantite);
            this.tabPageInv.Controls.Add(this.labelRangee);
            this.tabPageInv.Controls.Add(this.textBoxPrix);
            this.tabPageInv.Controls.Add(this.comboBoxColonne);
            this.tabPageInv.Controls.Add(this.comboBoxRangee);
            this.tabPageInv.Location = new System.Drawing.Point(4, 25);
            this.tabPageInv.Name = "tabPageInv";
            this.tabPageInv.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInv.Size = new System.Drawing.Size(543, 398);
            this.tabPageInv.TabIndex = 1;
            this.tabPageInv.Text = "Inventaire";
            // 
            // buttonModInv
            // 
            this.buttonModInv.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModInv.Location = new System.Drawing.Point(266, 116);
            this.buttonModInv.Name = "buttonModInv";
            this.buttonModInv.Size = new System.Drawing.Size(201, 31);
            this.buttonModInv.TabIndex = 8;
            this.buttonModInv.Text = "Modifier inventaire";
            this.buttonModInv.UseVisualStyleBackColor = true;
            this.buttonModInv.Click += new System.EventHandler(this.buttonModInv_Click);
            // 
            // labelQuantite
            // 
            this.labelQuantite.AutoSize = true;
            this.labelQuantite.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuantite.Location = new System.Drawing.Point(246, 75);
            this.labelQuantite.Name = "labelQuantite";
            this.labelQuantite.Size = new System.Drawing.Size(82, 19);
            this.labelQuantite.TabIndex = 6;
            this.labelQuantite.Text = "Quantité:";
            // 
            // labelPrix
            // 
            this.labelPrix.AutoSize = true;
            this.labelPrix.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrix.Location = new System.Drawing.Point(246, 42);
            this.labelPrix.Name = "labelPrix";
            this.labelPrix.Size = new System.Drawing.Size(43, 19);
            this.labelPrix.TabIndex = 2;
            this.labelPrix.Text = "Prix:";
            // 
            // labelColonne
            // 
            this.labelColonne.AutoSize = true;
            this.labelColonne.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelColonne.Location = new System.Drawing.Point(16, 75);
            this.labelColonne.Name = "labelColonne";
            this.labelColonne.Size = new System.Drawing.Size(79, 19);
            this.labelColonne.TabIndex = 4;
            this.labelColonne.Text = "Colonne";
            // 
            // textBoxQuantite
            // 
            this.textBoxQuantite.Location = new System.Drawing.Point(346, 72);
            this.textBoxQuantite.Name = "textBoxQuantite";
            this.textBoxQuantite.Size = new System.Drawing.Size(121, 22);
            this.textBoxQuantite.TabIndex = 7;
            // 
            // labelRangee
            // 
            this.labelRangee.AutoSize = true;
            this.labelRangee.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRangee.Location = new System.Drawing.Point(22, 42);
            this.labelRangee.Name = "labelRangee";
            this.labelRangee.Size = new System.Drawing.Size(73, 19);
            this.labelRangee.TabIndex = 0;
            this.labelRangee.Text = "Rangée";
            // 
            // textBoxPrix
            // 
            this.textBoxPrix.Location = new System.Drawing.Point(346, 41);
            this.textBoxPrix.Name = "textBoxPrix";
            this.textBoxPrix.Size = new System.Drawing.Size(121, 22);
            this.textBoxPrix.TabIndex = 3;
            // 
            // comboBoxColonne
            // 
            this.comboBoxColonne.FormattingEnabled = true;
            this.comboBoxColonne.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxColonne.Location = new System.Drawing.Point(119, 72);
            this.comboBoxColonne.Name = "comboBoxColonne";
            this.comboBoxColonne.Size = new System.Drawing.Size(121, 24);
            this.comboBoxColonne.TabIndex = 5;
            this.comboBoxColonne.Text = "0";
            this.comboBoxColonne.SelectedIndexChanged += new System.EventHandler(this.changeIndex);
            // 
            // comboBoxRangee
            // 
            this.comboBoxRangee.FormattingEnabled = true;
            this.comboBoxRangee.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F"});
            this.comboBoxRangee.Location = new System.Drawing.Point(119, 42);
            this.comboBoxRangee.Name = "comboBoxRangee";
            this.comboBoxRangee.Size = new System.Drawing.Size(121, 24);
            this.comboBoxRangee.TabIndex = 1;
            this.comboBoxRangee.Text = "A";
            this.comboBoxRangee.SelectedIndexChanged += new System.EventHandler(this.changeIndex);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(557, 430);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Machine distributrice, Barin";
            this.panelCredit.ResumeLayout(false);
            this.panelCredit.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageAchat.ResumeLayout(false);
            this.panelClavier.ResumeLayout(false);
            this.panelClavier.PerformLayout();
            this.tabPageInv.ResumeLayout(false);
            this.tabPageInv.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelCredit;
        private System.Windows.Forms.ListBox listBoxDisplay;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAchat;
        private System.Windows.Forms.TabPage tabPageInv;
        private System.Windows.Forms.Panel panelClavier;
        private System.Windows.Forms.ComboBox comboBoxColonne;
        private System.Windows.Forms.ComboBox comboBoxRangee;
        private System.Windows.Forms.Label labelRangee;
        private System.Windows.Forms.TextBox textBoxPrix;
        private System.Windows.Forms.Label labelPrix;
        private System.Windows.Forms.Label labelColonne;
        private System.Windows.Forms.TextBox textBoxQuantite;
        private System.Windows.Forms.Label labelQuantite;
        private System.Windows.Forms.Button button2Dollars;
        private System.Windows.Forms.Button button1Dollar;
        private System.Windows.Forms.Button button25Cents;
        private System.Windows.Forms.Button button10Cents;
        private System.Windows.Forms.Button button5Cents;
        private System.Windows.Forms.Label labelCredit;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label labelClavier;
        private System.Windows.Forms.Button buttonModInv;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Timer timer1;
    }
}

