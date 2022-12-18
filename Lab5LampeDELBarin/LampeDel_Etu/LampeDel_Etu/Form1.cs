/**
 * @file   Form1.cs
 * @author Mohammad Barin Wahidi
 * @date   17 décembre 2022
 * @brief  Programme pour une lampe de DEL séparée en onglets. Dans l'onglet Interface, l'usager peut changer les 
 *         valeurs d'intensité des DEL avec des textbox, des trackbar et des boutons (+10, -10 et ràz). L'usager peut
 *         enregistrer ses valeurs pour le temps sélectionné sur la trackbar de temps avec le bouton Enregistrer. Dans
 *         le menu Communication, l'usager peut ouvrir un port série. Ensuite, s'il se met en mode Test avec le bouton radio,
 *         les valeurs des DEL seront envoyées par port série et seront affichées dans l'onglet Debug. 
 *         L'usager peut ouvrir un fichier de recette avec des valeurs pour les DEL grâce au menu Fichier. Les valeurs 
 *         enregistrées seront alors affichées dans l'onglet Tableau, dans l'onglet Graphique et sur les trackbar. Dans l'onglet
 *         Graphique, l'usager peut cliquer sur Interpoler pour interpoler et générer des valeurs là où il n'y a pas de valeur
 *         enregistrée. Par exemple, un sinus incomplet devient complet avec l'interpolation. C'est alors même affiché sur 
 *         le graphique. L'usager peut afficher et cacher les droites de DEL qu'il veut avec la checkedlistbox. Le bouton 
 *         Cacher tout cache toutes les droites sur le graphique. (Parties A à F du lab 5 de la lampe de DEL)
 *
 * Environnement: Visual Studio 2022
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LampeDel_Barin
{
    public partial class Form1 : Form
    {
        TrackBar[] m_LumTrackBar = new TrackBar[NB_DEL];  // Tableau de TrackBar pour les lumières (DEL et Halogènes)
        TextBox[] m_LumTextBox = new TextBox[NB_DEL];     // Tableau de TextBox pour les lumières (DEL et Halogènes)

        //Les constantes utiles:
        const int NB_DEMI_HRE = 48;    //Nombre de demi-heure par jour (pour la recette, on note les changements aux 30 min
        const int NB_DEL = 11;   //Nombre de trackbar et textbox pour les lumières (dels et halogènes)
        const byte SOH = 230; //Start of header pour la trame série
        const byte CMD_TEST = (byte)'1'; //Pour ta tx série. Mode test, ie on varie les lumìères et l'effet est directe sur la lampe
        const byte CMD_EXEC = (byte)'2'; //Pour ta tx série. Mode transmission de toute la recette (ie les 48 objRecette)
        const byte CMD_JOUE = (byte)'3'; //Pour jouer la recette complète
        const int BYTE_PAR_TRAME = 17;
        const char ACK = 'A'; //Caractère reçue en cas de réception réussie avec le microcontrôleur
        const char NACK = 'B'; //Caractère reçue en cas d'une mauvaise transmission de donnée avec le microcontrôleur

        List<Recette> objRecette = new List<Recette>(); //on devra instancier 48 objets recettes. 

        public Form1() // constructeur de la form principale
        {
            InitializeComponent();

            // Les caractères ASCII étendus (é, ç, à, etc.) doivent s'afficher correctement si on est en 8 bits par caractère.
            comPort.Encoding = Encoding.GetEncoding(28591);

            int i = 0;
            // on met les trackbars de lumière dans un tableau
            foreach (TrackBar tbar in lumierePanel.Controls.OfType<TrackBar>())
            {
                i = Convert.ToInt16(tbar.Tag); //on récupère le tag mis par l'interface usager
                m_LumTrackBar[i] = tbar;
                m_LumTrackBar[i].ValueChanged += new EventHandler(lumTrackBar_ValueChanged);
            }
            // on met les tbox de lumière dans un tableau
            foreach (TextBox tbox in lumierePanel.Controls.OfType<TextBox>())
            {
                i = Convert.ToInt16(tbox.Tag); //on récupère le tag mis par l'interface usager
                m_LumTextBox[i] = tbox;
                m_LumTextBox[i].TextChanged += new EventHandler(lumTextBox_TextChanged);
                m_LumTextBox[i].KeyPress += new KeyPressEventHandler(lumTextBox_Keypress);
            }

            // init datagridview et chart
            init_tableau();
            init_graph();

            // init recettes
            for (i = 0; i < NB_DEMI_HRE; i++)
            {
                objRecette.Add(new Recette(NB_DEL));
            }

            // init checked listbox ajout des 11 checkbox
            for (i = 1; i < NB_DEL; i++)
            {
                checkedListBox1.Items.Add("DEL" + i);
            }
            checkedListBox1.Items.Add("Halo");

            remplirGraphique();
        }

        #region PartieA

        /// <summary>
        /// Les seuls caractères acceptés dans les textbox de lumière
        /// sont les chiffres, le backspace et le delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lumTextBox_Keypress(object sender, KeyPressEventArgs e)
        {
            TextBox tbox = (TextBox)sender;
            char c = e.KeyChar;

            if ((!char.IsDigit(c) &&
                 (c != (char)ConsoleKey.Backspace) &&
                 (c != (char)ConsoleKey.Delete)) || (c == '.'))
                e.Handled = true;
        }

        /// <summary>
        /// Lorsque le texte dans un des textbox pour la valeur de la lumière est changé,
        /// on affiche la valeur sur le trackbar correspondant.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lumTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tbox = (TextBox)sender;
            try
            {
                // on essaie de convertir le texte du textbox en int
                int pourcent = int.Parse(tbox.Text);
                // si la valeur est plus grande que 100, on met à 100
                if (pourcent > 100) 
                {
                    pourcent = 100;
                    tbox.Text = "100";
                    tbox.SelectionStart = tbox.TextLength;
                    tbox.SelectionLength = 0;
                }
                // on affiche la valeur sur le trackbar
                m_LumTrackBar[Convert.ToInt16(tbox.Tag)].Value = pourcent;
            }
            catch (Exception) // s'il y a eu une erreur, on met le trackbar à 0
            {
                m_LumTrackBar[Convert.ToInt16(tbox.Tag)].Value = 0;
            }
        }

        /// <summary>
        /// Lorsque la valeur d'un trackbar de lumière change, on affiche
        /// la valeur dans le textbox correspondant.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lumTrackBar_ValueChanged(object sender, EventArgs e)
        {
            TrackBar tbar = (TrackBar)sender;
            m_LumTextBox[Convert.ToInt16(tbar.Tag)].Text = tbar.Value.ToString();
        }

        /// <summary>
        ///  Lorsqu'on appuie sur le bouton +10%, on essaie d'augmenter
        ///  la valeur dans chacun des textbox de lumière de 10.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addValeurLumiere_Click(object sender, EventArgs e)
        {
            try
            {
                int pourcent;
                foreach (TextBox tbox in m_LumTextBox)
                {
                    pourcent = int.Parse(tbox.Text);
                    pourcent += 10;
                    tbox.Text = pourcent.ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        ///  Lorsqu'on appuie sur le bouton -10%, on essaie de diminuer
        ///  la valeur dans chacun des textbox de lumière de 10. Si la 
        ///  valeur va en dessous de 0, on met à 0.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sousValeurLumiere_Click(object sender, EventArgs e)
        {
            try
            {
                int pourcent;
                foreach (TextBox tbox in m_LumTextBox)
                {
                    pourcent = int.Parse(tbox.Text);
                    pourcent -= 10;
                    if (pourcent < 0)
                        pourcent = 0;
                    tbox.Text = pourcent.ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        ///  Lorsqu'on appuie sur le bouton Ràz, on met la valeur
        ///  de chacun des textbox à 0.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void razDelsButton_Click(object sender, EventArgs e)
        {
            foreach (TextBox tbox in m_LumTextBox)
            {
                tbox.Text = "0";
            }
        }

        /// <summary>
        /// Lorsque la valeur du trackbar de temps change, on affiche l'heure
        /// correspondante en dessous.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tempsTrackBar_ValueChanged(object sender, EventArgs e)
        {
            int temps = tempsTrackBar.Value;
            if (objRecette[temps].pointEnr)
            {
                foreach (TrackBar tbar in m_LumTrackBar)
                    tbar.Value = objRecette[temps].del[Convert.ToInt16(tbar.Tag)];
            }
            else
            {
                foreach (TrackBar tbar in m_LumTrackBar)
                    tbar.Value = 0;
            }
            if (temps % 2 == 0)
                tempsConsigneTexteLabel.Text = "Temps de consigne : " + temps / 2 + "H00";
            else
                tempsConsigneTexteLabel.Text = "Temps de consigne : " + temps / 2 + "H30";
        }

        #endregion

        #region BoutonsMenu

        /// <summary>
        /// Quand on clique sur le bouton enregistrer, les valeurs des DEL pour
        /// l'heure actuelle sont enregistrées dans l'objet recette correspondant.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enregistrerButton_Click(object sender, EventArgs e)
        {
            foreach(TrackBar tbar in m_LumTrackBar)
            {
                objRecette[tempsTrackBar.Value].del[Convert.ToInt16(tbar.Tag)] = tbar.Value;
            }
            objRecette[tempsTrackBar.Value].pointEnr = true;
        }

        /// <summary>
        /// Quitte l'app lorsqu'on clique sur Quitter en haut dans le menu Fichier.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        /// <summary>
        /// Lorsqu'on clique sur Ouvrir dans le menu en haut, permet de choisir un fichier
        /// à ouvrir depuis l'explorateur de fichiers. Ensuite, si le fichier est bon, les 
        /// données sont envoyées dans les objets recette, ce qui permet de remplir les 
        /// trackbars, le tableau et le graphique.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader sr;
            string[] ligne;

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                //InitialDirectory = "C:\\Users\\user\\Downloads\\PROG_AV_SYS_EMB\\Lab5\\Fichiers tests lab 5",
                Filter = "txt files (*.txt;*.csv)|*.txt;*.csv|All files (*.*)|*.*"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sr = File.OpenText(openFileDialog1.FileName);
                // les deux premières lignes sont ignorées
                sr.ReadLine();
                sr.ReadLine();
                for (int i = 0; i < NB_DEMI_HRE; i++) // boucle à travers les demi-heures
                {
                    try // on essaie de lire le fichier ligne par ligne.
                    {
                        ligne = sr.ReadLine().Split(';');

                        // boucle pour lire les valeurs pour les DEL dans le fichier
                        for (int j = 1; j <= NB_DEL; j++)
                        {
                            if (ligne[j] == "") // s'il n'y a pas de valeur, on considère que c'est 0
                            {
                                objRecette[i].del[j - 1] = 0;
                                objRecette[i].pointEnr = false;
                            }
                            // sinon, on met la valeur dans l'objet recette correspondant si elle est entre 0 et 100
                            // et on met pointEnr à true pour indique que ce point était enregistré par l'usager
                            else
                            {
                                int del = Convert.ToInt16(ligne[j]);
                                if (del < 0 || del > 100)
                                    throw new ArgumentOutOfRangeException();
                                objRecette[i].del[j - 1] = del;
                                objRecette[i].pointEnr = true;
                            }
                        }
                        remplirTableau();
                        remplirGraphique();
                    }
                    catch(NullReferenceException) // fichier vide
                    {
                        sr.Close();
                        videTabGraph();
                        MessageBox.Show("La nada eterna");
                        return;
                    }
                    catch(ArgumentOutOfRangeException) // valeur hors-limites dans le fichier
                    {
                        sr.Close();
                        videTabGraph();
                        MessageBox.Show("Entre 0 et 100 svp");
                        return;
                    }
                    catch(FormatException) // valeur non-numérique
                    {
                        sr.Close();
                        videTabGraph();
                        MessageBox.Show("Illisible");
                        return;
                    }
                    catch(IndexOutOfRangeException) // comme junk 4, lorsque les heures ne sont pas toutes là
                    {
                        sr.Close();
                        videTabGraph();
                        MessageBox.Show("Valeur invalide");
                        return;
                    }
                    catch (Exception ex) // autres exceptions
                    {
                        sr.Close();
                        videTabGraph();
                        MessageBox.Show(ex.ToString());
                        return;
                    }
                }
                sr.Close();
            }
        }

        #endregion

        #region Tableau

        /// <summary>
        /// Fonction qui initialise le tableau avec des 0. Les rangées sont les demi-heures
        /// et les colonnes sont les DEL.
        /// </summary>
        private void init_tableau()
        {
            int i = 0;
            dataGridView1.Columns.Add("Column" + i, "Heure");
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            for (i = 1; i < NB_DEL; i++)
            {
                dataGridView1.Columns.Add("Column" + i, "Del" + i);
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridView1.Columns.Add("Column" + i, "Halo");
            dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            for (i = 0; i < NB_DEMI_HRE; i++)
            {
                if (i % 2 == 0)
                    dataGridView1.Rows.Add(i/2 + "H00",0,0,0,0,0,0,0,0,0,0,0);
                else
                    dataGridView1.Rows.Add(i/2 + "H30",0,0,0,0,0,0,0,0,0,0,0);
            }
        }

        /// <summary>
        /// Lorsqu'on entre dans l'onglet Tableau, on remplit à nouveau le tableau.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPTableau_Enter(object sender, EventArgs e)
        {
            remplirTableau();
            /*for (int i = 0; i < NB_DEL; i++)
            {
                for (int j = 0; j < NB_DEMI_HRE; j++)
                {
                    if (objRecette[j].pointEnr)
                    {
                        dataGridView1[0, j].Style.BackColor = Color.Orange;
                        dataGridView1[i + 1, j].Style.BackColor = Color.Orange;
                    }
                    dataGridView1[i+1, j].Value = objRecette[j].del[i];
                }
            }*/
        }

        /// <summary>
        /// Fonction pour vider le tableau, par exemple lorsqu'on lit un mauvais fichier.
        /// </summary>
        private void videTabGraph()
        {
            for (int i = 0; i <= NB_DEL; i++)
            {
                if(i < NB_DEL)
                    chart1.Series[i].Points.Clear();
                for (int j = 0; j < NB_DEMI_HRE; j++)
                {
                    dataGridView1[i, j].Style.BackColor = Color.White;
                    if (i == 0)
                    {
                        objRecette[j].pointEnr = false;
                    }
                    else
                    {
                        objRecette[j].del[i-1] = 0;
                        dataGridView1[i, j].Value = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Fonction pour mettre les valeurs des objets recette dans le tableau.
        /// </summary>
        private void remplirTableau()
        {
            for (int i = 0; i <= NB_DEL; i++)
            {
                for (int j = 0; j < NB_DEMI_HRE; j++)
                {
                    if (objRecette[j].pointEnr) // les valeurs enregistrées sont en orange
                        dataGridView1[i, j].Style.BackColor = Color.Orange;
                    else
                        dataGridView1[i, j].Style.BackColor = Color.White;
                    if (i != 0)
                        dataGridView1[i, j].Value = objRecette[j].del[i-1];
                }
            }
        }

        #endregion

        #region Graphique

        /// <summary>
        /// Fonction pour initialiser les séries des DEL dans le graphique
        /// et qui ajoute les titres du graphique et des axes.
        /// </summary>
        private void init_graph()
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Legends.Clear();

            chart1.Titles.Add("Recette pour chaque DEL");
            chart1.ChartAreas.Add("DEL");
            chart1.ChartAreas["DEL"].AxisX.Minimum = 0;
            chart1.ChartAreas["DEL"].AxisX.Maximum = 48;
            chart1.ChartAreas["DEL"].AxisX.Interval = 4;
            chart1.ChartAreas["DEL"].AxisX.Title = "Points de contrôle aux 30 minutes";
            chart1.ChartAreas["DEL"].AxisY.Minimum = 0;
            chart1.ChartAreas["DEL"].AxisY.Maximum = 100;
            chart1.ChartAreas["DEL"].AxisY.Title = "Intensité des DEL";

            for (int i = 0; i < NB_DEL; i++)
            {
                chart1.Series.Add("DEL" + (i + 1));
                chart1.Series[i].ChartType = SeriesChartType.Line;
            }
            // on ajoute une série bidon avec un point à 0,0 pour que le
            // graphe ne disparaisse pas lorsqu'on cache les séries de DEL
            chart1.Series.Add("Bidon");
            chart1.Series["Bidon"].Points.AddXY(0,0);
        }

        /// <summary>
        /// Lorsqu'on coche ou décoche une DEL dans la checkedlistbox,
        /// on affiche ou cache la série correspondante.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked)
            {
                chart1.Series[e.Index].Enabled = false;
            }
            else
            {
                chart1.Series[e.Index].Enabled = true;
            }
        }

        /// <summary>
        /// Bouton qui permet de cacher les séries de DEL sur le graphique.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCache_Click(object sender, EventArgs e)
        {
            /*for(int i = 0; i < NB_DEL; i++)
                chart1.Series[i].Enabled = false;*/
            for (int i = 0; i < NB_DEL; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        /// <summary>
        /// Lorsqu'on entre dans l'onglet du graphique, on remplit à nouveau le graphe.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPGraphique_Enter(object sender, EventArgs e)
        {
            remplirGraphique();
        }

        /// <summary>
        /// Efface, puis remplit le graphique à partir des valeurs dans les
        /// objets recette. Coche aussi toutes les DEL dans la checkedlistbox 
        /// afin d'afficher toutes les séries.
        /// </summary>
        private void remplirGraphique()
        {
            for (int i = 0; i < NB_DEL; i++)
                chart1.Series[i].Points.Clear();

            for (int i = 0; i < NB_DEMI_HRE; i++)
            {
                for (int j = 0; j < NB_DEL; j++)
                {
                    chart1.Series[j].Points.AddXY(i, objRecette[i].del[j]);
                    chart1.Series[j].Enabled = true;
                    checkedListBox1.SetItemChecked(j, true);
                }
            }
        }

        #endregion

        #region Interpol

        //Événement Click du bouton
        //Trouve deux points enregistrés consécutifs (une section) et appelle la méthode 
        //InterpolSection pour trouver les points de cette section.
        //Exemple où il y a 3 points enregistrés: à 6h00, à 11h30 et à 19h00.
        //La méthode fera 3 interpolations:
        //1- entre 6h00 et 11h30  --> InterpoleSection(12,23)
        //2- entre 11h30 et 19h00 --> InterpoleSection(23,38)
        //3- entre 19h00 et 6h00  --> InterpoleSection(38,12)
        //La méthode gère les cas suivants:
        // 1- Pas de point enregistré. 2- Un seul point enregistré, 3- Deux points consécutifs
        private void btnInterpol_Click(object sender, EventArgs e)
        {
            int points = 0; // variable pour compter le nombre de points enregistrés
            int x1 = 0, x2 = 0; // variables pour délimiter les sections à interpoler
            int premier = 0;    // variable pour enregistrer la valeur du premier point enregistré
            for(int i = 0; i < NB_DEMI_HRE; i++)
            {
                if (objRecette[i].pointEnr) // s'il y a un point enregistré à cette demi-heure
                {
                    points++;
                    if (points == 1) // si c'est le premier point enregistré, on l'enregistre dans les variable premier et x1
                        premier = x1 = i;
                    // si c'est le second point enregistré, on l'enregistre dans x2 et on interpole entre x1 et x2
                    else if (points == 2)
                    {
                        x2 = i;
                        InterpolSection(x1, x2);
                    }
                    else // après les 2 premiers points, on interpole entre le dernier point enregistré et le point actuel
                    {
                        x1 = x2;
                        x2 = i;
                        InterpolSection(x1, x2);
                    }
                }
            }
            if(points == 1) // s'il n'y avait qu'un point enregistré, on trace une droite horizontale
            {
                for(int i = 0; i < NB_DEMI_HRE; i++)
                {
                    for(int j = 0; j < NB_DEL; j++)
                        objRecette[i].del[j] = objRecette[x1].del[j];
                }
            }
            else if(points >= 2) // s'il y avait plus d'un point enregistré, il faut gérer les points avant et aprés minuit
            {
                for (int x = x2; x < (NB_DEMI_HRE + premier) ; x++) // boucle connectant la fin et le début
                {
                    for (int i = 0; i < NB_DEL; i++)
                    {
                        if(x >= NB_DEMI_HRE)
                            objRecette[x-NB_DEMI_HRE].del[i] = InterpolLineaire(x, x2, NB_DEMI_HRE + premier, objRecette[x2].del[i], objRecette[premier].del[i]);
                        else
                            objRecette[x].del[i] = InterpolLineaire(x, x2, NB_DEMI_HRE + premier, objRecette[x2].del[i], objRecette[premier].del[i]);
                    }
                }
                
            }
            remplirTableau();
        }

        //Fait l'interpolation de tous les points x (demi-heure) entre deux points enregistrés (x1 et x2). 
        //Utilisera la méthode InterpolLineaire
        private void InterpolSection(int x1, int x2)
        {
            for (int x = x1; x < x2; x++)
            {
                for(int i = 0; i < NB_DEL; i++)
                    objRecette[x].del[i] = InterpolLineaire(x, x1, x2, objRecette[x1].del[i], objRecette[x2].del[i]);
            }
        }

        //Permet de trouver la valeur y à partir de l'équation y=mx+b. Les points x_Start, x_Fin, y_Start et y_Fin
        //sont utilisés pour trouver les valeurs de m et de b
        private int InterpolLineaire(int x, int x_Start, int x_Fin, int y_Start, int y_Fin)
        {
            double m = 0, b = 0;

            m = (double)(y_Fin - y_Start) / (double)(x_Fin - x_Start);
            b = (double)(y_Start - m * x_Start);

            return Convert.ToInt16(m * x + b);
        }

        #endregion

        #region PortSérie

        /// <summary>
        /// Lorsqu'on clique sur Port série dans le menu Communication, ouvre une
        /// fenêtre de configuration qui permet de choisir un port com à ouvrir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void portSerieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comPort.IsOpen) // si le port série est ouvert
            {
                // on ferme le port et on affiche qu'il est fermé sur la barre de statut en rouge
                comPort.Close();
                toolStripStatusEtat.ForeColor = Color.Red;
                toolStripStatusEtat.Text = "Fermé";
                btnTx.Enabled = false;
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
                    toolStripStatusEtat.ForeColor = Color.Red;
                    toolStripStatusEtat.Text = "Fermé";
                    btnTx.Enabled = false;
                }
                else // sinon (le port est fermé)
                {
                    try // on essaie de mettre à jour la barre de statut et d'ouvrir le port
                    {
                        // mise à jour de la barre de statut avec la config. actuelle du port série
                        toolStripStatusLabelPort.Text = comPort.PortName + ":";
                        toolStripStatusLabelPort.Text += comPort.BaudRate + ",";
                        toolStripStatusLabelPort.Text += comPort.Parity + ",";
                        toolStripStatusLabelPort.Text += comPort.DataBits + ",";
                        toolStripStatusLabelPort.Text += comPort.StopBits;

                        // on ouvre le port, on affiche qu'il est ouvert sur la barre de statut en vert
                        comPort.Open();
                        toolStripStatusEtat.ForeColor = Color.Green;
                        toolStripStatusEtat.Text = "Ouvert";
                        // comme le port est ouvert, on peut activer les boutons radio et check le bouton test
                        btnRadioTest.Enabled = true;
                        btnRadioRecette.Enabled = true;
                        btnRadioRecette.Checked = false;
                        btnRadioTest.Checked = true;
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
        /// Losrque le bouton radio Recette devient coché et que le port série est ouvert,
        /// on active le bouton tx. Sinon, on désactive le bouton tx.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRadioRecette_CheckedChanged(object sender, EventArgs e)
        {
            if (btnRadioRecette.Checked && comPort.IsOpen)
                btnTx.Enabled = true;
            else
                btnTx.Enabled = false;
        }

        /// <summary>
        /// Si le port série est ouvert et que le bouton radio test est coché, 
        /// on part le timer. Sinon, on éteint le timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRadioTest_CheckedChanged(object sender, EventArgs e)
        {
            if (btnRadioTest.Checked && comPort.IsOpen)
                timer1.Enabled = true;
            else
                timer1.Enabled = false;
        }

        /// <summary>
        /// En mode Test, le programme transmet (aux 500ms) la trame spécifiant l'intensité 
        /// des 11 lumières au moment indiqué par le curseur du temps.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            byte[] msg = new byte[BYTE_PAR_TRAME];  // tableau pour la trame
            int temps = tempsTrackBar.Value;    // le temps actuel (0 à 47)
            int i;
            int checksum = 0;

            msg[0] = SOH;   //soh
            msg[1] = 0x31;  //cmd
            msg[2] = 1;     //consigne
            for(i = 0; i < NB_DEL; i++) // boucle pour ajouter les valeurs des lumières à la trame
            {
                msg[i + 3] = (byte)m_LumTrackBar[i].Value;
            }
            i += 3;
            if (temps % 2 == 0) // si l'heure finit par 00
                msg[i++] = 0;   // ajouter 0 (les minutes) dans la trame
            else    // sinon (l'heure finit par 30)
                msg[i++] = 30;  // ajouter 30 (les minutes) dans la trame

            msg[i++] = (byte)(temps / 2);   // ajouter l'heure dans la trame
            foreach(byte b in msg)  // additionne tous les octets du tableau
            {
                checksum += b;
            }
            // soustrait le soh et le cmd de la somme
            checksum -= msg[0];
            checksum -= msg[1];
            msg[i] = (byte)(checksum & 0xff);   // met le checksum (lsb de la somme) dans la trame

            comPort.Write(msg, 0, BYTE_PAR_TRAME);  // envoie les données sur le port série
            string hex = BitConverter.ToString(msg).Replace("-", " ");  // transforme le tableau de bytes en string formattée
            listBox1.Items.Add(hex);    // affiche les octets envoyés dans l'onglet debug
        }

        /// <summary>
        /// Vide la listbox de l'onglet debug lorsqu'on clique sur le bouton Efface.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEfface_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); 
        }

        #endregion
    }
}
