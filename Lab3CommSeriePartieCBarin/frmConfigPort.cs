/**
 * @file   frmConfigPort.cs
 * @author Mohammad Barin Wahidi
 * @date   8 octobre 2022
 * @brief  Fenêtre qui permet à l'usager de choisir la configuration
 *         du port série.
 *
 * Environnement: Visual Studio 2022
 */

using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace Lab3CommSeriePartieCBarin
{
    public partial class frmConfigPort : Form
    {
        //variables membres de la form frmConfigPort pour la config. du port série
        public string m_nom { get; set; }
        public int m_vitesse { get; set; }
        public int m_nbBit { get; set; }
        public Parity m_parite { get; set; }
        public int m_stopBit { get; set; }


        public frmConfigPort(string nom, int vitesse, int nbBit, Parity parite, int stopBit)
        {
            InitializeComponent();
            // on enregistre la config. du port série dans les variables membres de la fenêtre
            // lorsqu'on construit la fenêtre
            m_nom = nom;
            m_vitesse = vitesse;
            m_nbBit = nbBit;
            m_parite = parite;
            m_stopBit = stopBit;

            // L’utilisateur ne peut choisir que le texte présenté par le ComboBox
            comboBoxPort.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxVitesse.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxParite.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDataBits.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStopBits.DropDownStyle = ComboBoxStyle.DropDownList;

            // remplissage des ComboBox
            comboBoxPort.DataSource = (System.IO.Ports.SerialPort.GetPortNames());
            comboBoxVitesse.DataSource = new int[] { 2400, 4800, 9600, 14400, 19200, 38400, 56000, 57600, 115200, 128000, 256000 };
            comboBoxParite.DataSource = Enum.GetValues(typeof(Parity));
            comboBoxDataBits.DataSource = new int[] { 7, 8 };
            comboBoxStopBits.DataSource = new int[] { 1, 2 };

            // Sélectionne dans les ComboBox la config. actuelle du port série
            comboBoxPort.SelectedItem = m_nom;
            comboBoxVitesse.SelectedItem = m_vitesse;
            comboBoxParite.SelectedItem = m_parite;
            comboBoxDataBits.SelectedItem = m_parite;
            comboBoxStopBits.SelectedItem = m_stopBit;
        }

        /// <summary>
        /// Lorsqu'on clique sur le bouton ReScan, on rafraîchit les ports dans le ComboBox
        /// des ports pour afficher les ports disponibles seulement.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReScan_Click(object sender, EventArgs e)
        {
            comboBoxPort.DataSource = (System.IO.Ports.SerialPort.GetPortNames());
        }

        /// <summary>
        /// Lorsqu'on appuie sur le bouton OK, on met à jour la configuration du port 
        /// série avec les sélections de l'usager, sauf si l'usager n'a choisi aucun
        /// port. Dans tel cas, on affiche à l'usager un message pour lui dire qu'aucun
        /// port n'est sélectionné.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            // si aucun port n'est sélectionné, on affiche un message pour le dire à l'usager
            if (comboBoxPort.SelectedIndex == -1)
                MessageBox.Show("Aucun port sélectionné");
            else    // sinon, on change les 
            {
                // On met à jour les informations de configuration selon les sélections de l'usager
                m_nom = (comboBoxPort.SelectedItem).ToString(); ;
                m_vitesse = Convert.ToInt32((comboBoxVitesse.SelectedItem).ToString());
                m_nbBit = Convert.ToInt32((comboBoxDataBits.SelectedItem).ToString());
                m_parite = (Parity)comboBoxParite.SelectedItem;
                m_stopBit = (comboBoxStopBits.SelectedIndex + 1);
            }
        }
    }
}
