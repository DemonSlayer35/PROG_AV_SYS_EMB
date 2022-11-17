/**
 * @file   Form1.cs
 * @author Mohammad Barin Wahidi
 * @date   17 novembre 2022
 * @brief  Programme qui lit et décode des trames de communication (envoyées par le port série
 *         ou par UDP). Les données météo sont affichées dans des étiquettes et dans un DataGridView.
 *         On peut enregistrer les données dans un fichier .csv avec le bouton "Disquette" ou avec
 *         le sous-menu Enregistrer sous... du menu Fichier. On peut configurer le port série avec le 
 *         bouton "Roue dentée" ou avec le sous-menu Port série du menu Configuration. Une fenêtre 
 *         s'ouvrira alors et la configuration du port série peut être sélectionnée avec des ComboBox.
 *         La barre d'état au bas de la fenêtre principale permet de voir les paramètres actuels du port série.
 *
 * Environnement: Visual Studio 2022
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Lab4StationMeteoBarin
{
    public partial class Form1 : Form
    {
        Thread objTh;  // On fera tourner l'objet objThUDP dans un Thread pour la rx de la trame
        ThreadRxUDP objUDP;
        // variables membres liées à la gestion des trames
        List<byte> m_lstTrameRx = new List<byte>();//conserve les octets reçus du port série
                                                   //Seule la méthode DataReceived du port 
                                                   //série utilise cette variable

        const Byte SOH = 0x01; // défini dans le protocole (la valeur du SOH doit égaler 1)
        const int LIMITE_BUFFER = 20;
        public enum enumTrame // les différentes positions sont les index des différents bytes
        {
            soh = 0, // début 
            tempEntier,
            tempFraction,
            humidite,
            dirVent,
            vitVent,
            pressionEntier,
            pressionFraction,
            intensiteMsb,
            intensiteLsb,
            tempIntEntier,
            tempIntFraction,
            checksum,
            maxTrame
        };

        // enum qui fait correspondre les chiffres de 0 à 7 à des directions du vent
        enum enumDirVent { Nord = 0, NordEst, Est, SudEst, Sud, SudOuest, Ouest, NordOuest };

        // définition du prototype de la fonction d'affichage des données reçues par le port série ou par UDP
        public delegate void monProtoDelegate(List<byte> bytes, string srcIp);
        monProtoDelegate objDelegate; // déclaration d'un objet delegate

        public Form1()
        {
            InitializeComponent();

            // On instancie les obj et on lance le Thread
            objUDP = new ThreadRxUDP(this);
            objTh = new Thread(objUDP.FaitTravail);
            objTh.Start();

            // on instancie l'objet delegate du Thread UDP (objDelegate est un pointeur de fonction qui pointe sur DelegateAffiche.)
            objUDP.objDelegate = methodeDelegateAffiche;

            // on instancie l'objet delegate de la Form1 en lui assignant l'adresse de la méthode d'affichage
            objDelegate = methodeDelegateAffiche;

            // Les caractères ASCII étendus (é, ç, à, etc.) doivent s'afficher correctement si on est en 8 bits par caractère.
            comPort.Encoding = Encoding.GetEncoding(28591);
        }

        /// <summary>
        /// Fonction pour quitter l'application associée au sous-menu Quitter du menu Fichier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Cette fonction est appelée lorsque le port série reçoit des données. Elle compte 
        /// les octets et les met dans une liste si la longueur ne dépasse pas le maximum de la trame (13).
        /// Si la trame est valide, la fonction d'affichage est appelée avec un delegate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int nbALire;
            byte[] lecture = new byte[LIMITE_BUFFER];
            nbALire = comPort.BytesToRead;  //on a reçu combien de bytes
            if (nbALire > 0)  //Petit test car, de temps en temps on a un événement dataReceive et il n'y a pas de bytes à lire !!!!
            {
                // si le nb d'octets à lire sur le port série est supérieur à la longueur max de la trame (13)
                if (nbALire > (int)enumTrame.maxTrame)
                {
                    comPort.DiscardInBuffer();  // on vide le buffer de réception du port série
                }
                else    // sinon (nb d'octets inférieur ou égal à 13)
                {
                    comPort.Read(lecture, 0, nbALire);
                    for (int i = 0; i < nbALire; i++)
                    {
                        m_lstTrameRx.Add(lecture[i]);
                    }

                    if (verifTrame(m_lstTrameRx))   // si la trame est correcte selon la vérification
                        BeginInvoke(objDelegate, m_lstTrameRx, comPort.PortName); // appel de la méthode delegate
                }
            }
        }

        /// <summary>
        /// Méthode delegate d'affichage qui est appelée par le thread de réception de caractères sur le port série
        /// ou par le thread de réception UDP.
        /// </summary>
        /// <param name="stLigne"> la ligne reçue sur le port série </param>
        private void methodeDelegateAffiche(List<byte> bytes, string src)
        {
            if(!src.Contains("COM"))    // si la source ne contient pas le mot COM, donc c'est une trame UDP non vérifiée
            {
                if (!verifTrame(bytes)) // si la liste d'octets est invalide, on sort de la fonction d'affichage
                    return;
            }

            string temps = string.Format("{0:HH:mm:ss tt}", DateTime.Now);  // formatage du temps heures/min/sec

            // transformation de la température en string
            sbyte tempEntier = (sbyte)bytes[(int)enumTrame.tempEntier];
            int tempFraction = bytes[(int)enumTrame.tempFraction];
            string temperature = tempEntier.ToString() + "." + tempFraction.ToString();

            // transformation de l'humidité en string
            string humidite = bytes[(int)enumTrame.humidite].ToString();
            string dirVent = ((enumDirVent)bytes[(int)enumTrame.dirVent]).ToString();

            // transformation de la vitesse du vent en string
            string vitVent = bytes[(int)enumTrame.vitVent].ToString();
            
            // transformation de la pression en string
            sbyte pressionEntier = (sbyte)bytes[(int)enumTrame.pressionEntier];
            int pressionFraction = bytes[(int)enumTrame.pressionFraction];
            string pression = pressionEntier.ToString() + "." + pressionFraction.ToString();

            labelTemperature.Text = temperature;    // affichage de la température sur l'étiquette correspondante
            labelHumidite.Text = humidite;          // affichage de l'humidité sur l'étiquette correspondante
            labelDirection.Text = dirVent;          // affichage de la direction du vent sur l'étiquette correspondante
            labelVitesse.Text = vitVent;            // affichage de la vitesse du vent sur l'étiquette correspondante
            labelPression.Text = pression;          // affichage de la pression sur l'étiquette correspondante

            // affichage des données dans la première rangée du datagriedview
            dataGridView1.Rows.Insert(0, temps, src, temperature, humidite, vitVent, dirVent, pression);
            dataGridView1.Rows[0].Selected = true;  // la première rangée du dgv est sélectionnée
            dataGridView1.Rows[1].Selected = false; // l'ancienne rangée sélectionnée n'est plus sélectionnée
            m_lstTrameRx.Clear();   // on vide la liste de la trame
        }

        /// <summary>
        /// Fonction appelée lorsqu'on appuie sur le sous-menu Port série du menu Configuration ou sur 
        /// le bouton avec une roue dentée. Si le port série est ouvert, on le ferme. Puis, on crée la
        /// fenêtre de configuration du port et on l'affiche à l'usager. Si l'usager a fermé la
        /// fenêtre avec le bouton OK, on récupère les informations de configuration et on les assigne
        /// au port série. Si l'usager a fermé la fenêtre avec le bouton Annuler, on ne fait rien.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void portSérieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comPort.IsOpen) // si le port série est ouvert
            {
                // on ferme le port et on affiche qu'il est fermé sur la barre de statut en rouge
                comPort.Close();
                toolStripStatusLabelOuvert.ForeColor = Color.Red;
                toolStripStatusLabelOuvert.Text = "Fermé";
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

                if (comPort.IsOpen) // si le port série est ouvert
                {
                    // on ferme le port, on affiche qu'il est fermé sur la barre de statut en rouge
                    comPort.Close();
                    toolStripStatusLabelOuvert.ForeColor = Color.Red;
                    toolStripStatusLabelOuvert.Text = "Fermé";
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

                        // on ouvre le port, on affiche qu'il est ouvert sur la barre de statut en vert
                        comPort.Open();
                        toolStripStatusLabelOuvert.ForeColor = Color.Green;
                        toolStripStatusLabelOuvert.Text = "Ouvert";
                    }
                    catch (UnauthorizedAccessException) // dans le cas d'une exception d'accès non autorisé
                    {
                        // on affiche à l'usager que le port COM est utilisé par une autre app
                        MessageBox.Show("Port COM utilisé par une autre application.");
                    }
                    catch (System.IO.IOException) // dans le cas d'une exception d'I/O
                    {
                        // on affiche à l'usager que le port COM sélectionné est fermé (n'existe plus)
                        MessageBox.Show("Port COM fermé.");
                    }
                }
            }
        }

        /// <summary>
        /// Fonction pour écrire et enregistrer les données dans un fichier CSV. La fonction 
        /// est associée au bouton avec une disquette et au sous-menu Enregistrer sous... du menu Fichier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enregistrerSousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter swFichier; // pour écrire des caractères dans un stream en utilisant l'encodage
            SaveFileDialog saveFileDialog = new SaveFileDialog(); // dialogue d'enregistrement de fichier

            saveFileDialog.InitialDirectory = saveFileDialog.FileName;
            saveFileDialog.DefaultExt = ".csv"; // l'extension de fichier par défaut est .csv
            saveFileDialog.AddExtension = true; // on ajoute l'extension si l'utilisateur l'oublie
            saveFileDialog.Filter = "txt files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1; // sélectionne l'extension à l'index 1 (.csv)

            // on affiche une boîte de dialogue à l'usager pour enregistrer un fichier
            if (saveFileDialog.ShowDialog() == DialogResult.OK) // s'il décide d'enregistrer un fichier
            {
                swFichier = File.CreateText(saveFileDialog.FileName);   // création du fichier
                string jour = DateTime.Now.ToString("dd/MM/yyyy");  // formatage de la date
                string heure = string.Format("{0:HH:mm:ss}", DateTime.Now); // formatage de l'heure
                // On écrit en haut du fichier la date et l'heure de la prise des données
                swFichier.WriteLine("Données de la station météo le " + jour + " à " + heure);

                foreach (DataGridViewRow row in dataGridView1.Rows) // boucle pour parcourir les rangées du datagridview
                {
                    foreach(DataGridViewCell cell in row.Cells) // boucle pour parcourir les cellules du datagridview
                    {
                        // si la cellule n'est pas vide, on écrit son contenu dans le fichier et on ajoute un point-virgule
                        if ((string)(dataGridView1.Rows[row.Index].Cells[cell.ColumnIndex].Value) != null)
                            swFichier.Write((string)(dataGridView1.Rows[row.Index].Cells[cell.ColumnIndex].Value) + ";");
                    }
                    swFichier.Write("\r");  // on ajoute un retour chariot dans le fichier après avoir terminé une rangée
                }
                swFichier.Close();  // à la fin, on ferme le stream d'écriture
            }
        }

        /// <summary>
        /// Fonction qui vérifie la validité de la liste d'octets de la trame série ou UDP.
        /// </summary>
        /// <param name="trame"></param>
        /// <returns>
        /// Vrai si la trame est valide. Faux si la trame est incomplète ou invalide.
        /// </returns>
        private bool verifTrame(List<byte> trame)
        {
            if (trame[0] != SOH)    // si le SOH est incorrect
            {
                m_lstTrameRx.Clear();   // on efface la liste
                return false;   // et on retourne faux
            }
            else if (trame.Count < (int)enumTrame.maxTrame) // si la longueur de la liste est inférieure au max
            {
                return false;   // on retourne faux
            }
            else if (trame.Count > (int)enumTrame.maxTrame) // si la longueur de la liste est supérieure au max
            {
                m_lstTrameRx.Clear();   // on efface la liste
                return false;   // et on retourne faux
            }
            else if (trame[(int)enumTrame.checksum] != calculChecksum(trame))   // si le checksum est incorrect
            {
                m_lstTrameRx.Clear();   // on efface la liste
                return false;   // et on retourne faux
            }
            else    // sinon
                return true;    // on retourne faux
        }

        /// <summary>
        /// Fonction qui calcule et retourne le checksum (la valeur des 8 LSB de la somme des octets de la trame).
        /// </summary>
        /// <param name="trame"> la liste d'octets reçue sur le port série ou par UDP</param>
        /// <returns>La valeur du checksum</returns>
        private byte calculChecksum(List<byte> trame)
        {
            byte checksum = 0;  // variable pour le checksum initialisée à 0

            // boucle qui additionne les octets de la trame (sauf le SOH et le checksum)
            for(int i = 1; i < (int)enumTrame.checksum; i++)
            {
                checksum += trame[i];
            }

            checksum &= 0xff;   // on utilise un masque pour ne garder que les 8 LSB de la somme

            return checksum;    // on retourne le checksum
        }

        /// <summary>
        /// Fonction qui arrête le Socket et le Thread lorsqu'on ferme la fenêtre principale.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            objUDP.ArreteClientUDP();
            objTh.Abort();
        }
    }
}
