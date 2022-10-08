/**
 * @file   MachineDistributrice.cs
 * @author Mohammad Barin Wahidi
 * @date   8 octobre 2022
 * @brief  Programme séparé en deux fenêtres. La première fenêtre permet d'envoyer et recevoir du texte
 *         sur un port série, en plus de pouvoir ouvrir et fermer le port série. La seconde fenêtre permet
 *         de configurer les paramètres du port série. Le bouton ReScan sur la deuxième fenêtre permet de 
 *         rafraîchir la liste de ports disponibles. Le programme est robuste et ne plante pas en cas d'erreur
 *         (d'après les tests effectués). Une barre de statut sur la première fenêtre permet de voir les 
 *         paramètres actuels du port série.
 *
 * Environnement: Visual Studio 2022
 */

using System;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace Lab3CommSeriePartieCBarin
{
    public partial class Form1 : Form
    {
        // variables membres de la form1

        // définition du prototype de la fonction d'affichage du texte reçu sur le port série
        public delegate void monProtoDelegate(string ligneRecu);
        monProtoDelegate objDelegate; // déclaration d'un objet delegate

        public Form1()
        {
            InitializeComponent();

            // on instancie l'objet delegate en lui assignant l'adresse de la méthode d'affichage
            objDelegate = methodeDelegateAffiche;

            // on empêche à l'utilisateur d'écrire dans la boîte qui affiche le texte reçu
            textBoxRx.ReadOnly = true;

            // Les caractères ASCII étendus (é, ç, à, etc.) doivent s'afficher correctement si on est en 8 bits par caractère.
            comPort.Encoding = Encoding.GetEncoding(28591);

        }

        /// <summary>
        /// Lorsqu'on clique sur le bouton TX, on envoie le texte de la boîte d'édition par
        /// le port série, sauf si l'usager n'a rien écrit dans la boîte. Dans tel cas, on 
        /// affiche à l'usager que la boîte d'édition est vide.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTx_Click(object sender, EventArgs e)
        {
            if (textBoxTx.Text.Length != 0) // si la longueur du texte est différente de 0
            {
                try // on essaie d'écrire le texte avec le port série
                {
                    comPort.WriteLine(textBoxTx.Text);
                }
                catch (InvalidOperationException) // dans le cas d'une opération invalide
                {
                    // on affiche que le port est fermé avec un message et sur la barre de
                    // statut en rouge, on désactive le bouton TX et on met le texte Ouvrir
                    // sur le bouton pour ouvrir/fermer le port
                    MessageBox.Show("Port fermé");
                    buttonTx.Enabled = false;
                    toolStripStatusLabelOuvert.ForeColor = Color.Red;
                    toolStripStatusLabelOuvert.Text = "Fermé";
                    buttonOuvrir.Text = "Ouvrir";
                }
            }
            else // sinon, on affiche que la boîte de texte est vide
                MessageBox.Show("Boite d'édition vide");

        }

        /// <summary>
        /// Lorsque le port série reçoit des données, on lit la ligne reçue et on invoque la méthode delegate
        /// avec la ligne en argument.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string sRx;
            sRx = comPort.ReadLine();

            BeginInvoke(objDelegate, sRx); // appel de la méthode delegate 
        }

        /// <summary>
        /// Méthode delegate qui est appelée par le thread de réception de caractères sur le port série.
        /// </summary>
        /// <param name="stLigne"> la ligne reçue sur le port série </param>
        private void methodeDelegateAffiche(string stLigne)
        {
            textBoxRx.Text = stLigne; // on affiche le texte reçu en argument
        }

        /// <summary>
        /// Lorsqu'on appuie sur le bouton Config, si le port série est ouvert, on le ferme. Puis,
        /// on crée la fenêtre de configuration et on l'affiche à l'usager. Si l'usager a fermé la
        /// fenêtre avec le bouton OK, on récupère les informations de configuration et on les assigne
        /// au port série. Si l'usager a fermé la fenêtre avec le bouton Annuler, on ne fait rien.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfig_Click(object sender, EventArgs e)
        {
            if (comPort.IsOpen) // si le port série est ouvert
            {
                // on ferme le port, on affiche qu'il est fermé sur la barre de
                // statut en rouge, on désactive le bouton TX et on met le texte Ouvrir
                // sur le bouton pour ouvrir/fermer le port
                comPort.Close();
                buttonTx.Enabled = false;
                toolStripStatusLabelOuvert.ForeColor = Color.Red;
                toolStripStatusLabelOuvert.Text = "Fermé";
                buttonOuvrir.Text = "Ouvrir";
            }
            // Crée la feuille de config. Appelle le constructeur et on lui passe la config. actuelle du port série.
            frmConfigPort fConfig = new frmConfigPort(comPort.PortName, comPort.BaudRate, comPort.DataBits, comPort.Parity,
                                                     (int)comPort.StopBits);

            // Ouvre la fenêtre de config et attend que l'usager la ferme par le bouton OK ou Annuler
            if (fConfig.ShowDialog() == DialogResult.OK) // Si l'usager a appuyé sur OK dans la fenêtre de config
            {
                // On récupère les informations de configuration et on les assigne au port série
                comPort.PortName = fConfig.m_nom;
                comPort.BaudRate = fConfig.m_vitesse;
                comPort.DataBits = fConfig.m_nbBit;
                comPort.Parity = fConfig.m_parite;
                comPort.StopBits = (StopBits)fConfig.m_stopBit;

                // On simule un appui sur le bouton Ouvrir pour ouvrir le port série
                buttonOuvrir.PerformClick();
            }
        }

        /// <summary>
        /// Lorsqu'on appuie sur bouton Ouvrir, on ouvre le port série et on change le texte
        /// du bouton à Fermer. Lorsqu'on appuie sur le bouton Fermer (le port est ouvert), on 
        /// ferme le port série. On change aussi les informations sur la barre de statut en conséquence.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOuvrir_Click(object sender, EventArgs e)
        {
            if (comPort.IsOpen) // si le port série est ouvert
            {
                // on ferme le port, on affiche qu'il est fermé sur la barre de
                // statut en rouge, on désactive le bouton TX et on met le texte Ouvrir
                // sur le bouton pour ouvrir/fermer le port
                comPort.Close();
                buttonTx.Enabled = false;
                toolStripStatusLabelOuvert.ForeColor = Color.Red;
                toolStripStatusLabelOuvert.Text = "Fermé";
                buttonOuvrir.Text = "Ouvrir";
            }
            else // sinon (le port est fermé)
            {
                try // on essaie de mettre à jour la barre de statut et d'ouvrir le port
                {
                    // mise à jour de la barre de statut avec la config. actuelle du port série
                    toolStripStatusLabelInfos.Text = comPort.PortName + ":";
                    toolStripStatusLabelInfos.Text += comPort.BaudRate + ",";
                    toolStripStatusLabelInfos.Text += comPort.Parity + ",";
                    toolStripStatusLabelInfos.Text += comPort.DataBits + ",";
                    toolStripStatusLabelInfos.Text += comPort.StopBits;


                    // on ouvre le port, on affiche qu'il est ouvert sur la barre de
                    // statut en vert, on active le bouton TX et on met le texte Fermer
                    // sur le bouton pour ouvrir/fermer le port
                    comPort.Open();
                    buttonTx.Enabled = true;
                    toolStripStatusLabelOuvert.ForeColor = Color.Green;
                    toolStripStatusLabelOuvert.Text = "Ouvert";
                    buttonOuvrir.Text = "Fermer";
                }
                catch (UnauthorizedAccessException) // dans le cas d'une exception d'accès non autorisé
                {
                    // on affiche à l'usager que le port COM est utilisé par une autre app
                    // et on désactive le bouton TX
                    MessageBox.Show("Port COM utilisé par une autre application.");
                    buttonTx.Enabled = false;
                }
                catch (System.IO.IOException) // dans le cas d'une exception d'I/O
                {
                    // on affiche à l'usager que le port COM sélectionné est fermé (n'existe plus)
                    // et on désactive le bouton TX
                    MessageBox.Show("Port COM fermé.");
                    buttonTx.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Lorsqu'on appuie sur le bouton Quitter, on quitte l'application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
