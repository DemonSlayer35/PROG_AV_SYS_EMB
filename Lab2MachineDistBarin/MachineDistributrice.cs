/**
 * @file   MachineDistributrice.cs
 * @author Mohammad Barin Wahidi
 * @date   20 septembre 2022
 * @brief  Programme qui simule une machine distributrice. Il y a un écran, un clavier pour
 *         choisir les aliments, des boutons pour ajouter du crédit et des boutons pour annuler
 *         ou confirmer une transaction. L'inventaire a 6 rangées (A à F) et 10 colonnes (0 à 9).
 *         Il faut entrer l’identifiant de rangée en premier (A à F) et la colonne par la suite (0 à 9).
 *         Dans l'onglet Inventaire, on peut modifier la quantité et le nombre d'items en stock.
 *         Les prix ne peuvent être que des multiples de 5 entre 25 et 300, tandis que les quantités
 *         doivent être entre 1 et 9.
 *
 * Environnement: Visual Studio 2022
 */

using System;
using System.Windows.Forms;

namespace Lab2MachineDistBarin
{
    public partial class MachineDistributrice : Form
    {
        /********* constantes ***********/
        public const int NBRANGEE = 6;  // nb rangées machine
        public const int NBCOLONNE = 10;    // nb colonnes machine

        const int NB_BUTTONS = 10;  // nb boutons clavier (0 à 9)

        /********** variables membres ***********/
        private Lcd4Lignes m_objetAffichage;    // déclaration de l'objet m_objetAffichage pour l'affichage
        //déclaration du tableau contenant l'inventaire
        private ItemInventaire[,] m_tabInventaire = new ItemInventaire[NBRANGEE, NBCOLONNE];
        private Button[] m_Clavier = new Button[NB_BUTTONS]; //tableau contenant les objets (Button) du clavier

        /*** Les variables ci-dessous sont utilisées par m_objAffichage pour générer l'affichage ***/
        private int m_prixCourant;
        private int m_credit;
        private int m_retourCredit;
        private int m_indexRangee = 255;
        private int m_indexColonne = 255;
        private Boolean m_manqueCredit;
        private Boolean m_annulationVente;
        private Boolean m_distributionActive = false;
        private Boolean m_qteZero;
        private string m_nomAliment;

        public MachineDistributrice()
        {
            Control ctrlSuivant;  //déclaration d'un objet Control

            InitializeComponent();

            int prixTemp = 0;   // initialisation à 0 d'une variable pour le prix des items
            int indexAliment = 0;   // initialisation à 0 d'une variable pour l'index du nom des aliments
            var rnd = new Random(); // initialise une nouvelle instance de la classe Random

            
            //Dans 2 boucles for imbriquées, on appelle le constructeur de ItemInventaire en lui passant le prix, la quantité
            //et l'index pour le nom d'aliment. Cela permet d'instancier un objet ItemInventaire que l'on place dans le tableau.
            for (int i = 0; i < NBRANGEE; i++)
            {
                for (int j = 0; j < NBCOLONNE; j++)
                {
                    prixTemp = rnd.Next(5, 61) * 5; // génération d'un prix aléatoire multiple de 5 entre 25 et 300
                    //Met le prix, des quantités de 2 et l'index du nom d'aliment
                    m_tabInventaire[i, j] = new ItemInventaire(prixTemp, 2, indexAliment);
                    indexAliment++; // incrémentation de l'index du nom d'aliment après chaque nouveau item ajouté
                }
                if(indexAliment == 20)  // si l'index du nom d'aliment est égal à 20 (seulement 20 noms différents d'aliments)
                {
                    indexAliment = 0;   // on remet l'index à 0
                }
            }

            m_objetAffichage = new Lcd4Lignes();    // instanciation de l'objet m_objetAffichage
            // valeurs pour générer les 4 lignes de l'affichage de départ
            m_objetAffichage.genererAffichage(255, 255, 0, 0, 0, false, false, false, false, "");
            // on rafraichit l'affichage (affiche les 4 lignes de l'affichage)
            listBoxDisplay.Items.Clear();
            for (int i = 0; i < 4; i++)
            {
                listBoxDisplay.Items.Add(m_objetAffichage.lignesAffichage[i]);
            }

            ctrlSuivant = panelClavier;  // Le point de départ de la recherche sera le Panel

            for (int i = 0; i < NB_BUTTONS; i++)    // boucle pour mettre les 10 boutons dans le tableau m_clavier
            {
                ctrlSuivant = GetNextControl(ctrlSuivant, true);
                m_Clavier[i] = (Button)ctrlSuivant; //casting de l'objet Control trouvé (ctrlSuivant) en Button
            }
            setClavierLettres();    // affiche le clavier de lettres
        }

        /// <summary>
        /// Fonction qui gère les clics au clavier (lettres ou chiffres)
        /// afin d'afficher les informations de l'item sélectionné par l'usager.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clavier_Click(object sender, EventArgs e)
        {
            Button bouton;  // déclaration d'un bouton
            char touche;    // déclaration d'un char touche pour le bouton appuyé par l'usager

            bouton = (Button)sender; //casting du sender en Button
            if (bouton.Text != "")  // si le texte du bouton n'est pas vide
            {
                touche = bouton.Text[0]; //on récupère le texte inscrit sur le bouton
                if (touche >= '0' && touche <= '9') // si la texte sur le bouton est un chiffre entre 0 et 9
                {
                    m_indexColonne = touche - '0';  // on transforme le chiffre en index de colonne
                    m_prixCourant = m_tabInventaire[m_indexRangee, m_indexColonne].prix;
                    m_nomAliment = m_tabInventaire[m_indexRangee, m_indexColonne].getNomAliment();

                    // si la case sélectionnée est vide (qté 0 de l'item)
                    if (m_tabInventaire[m_indexRangee, m_indexColonne].quantite == 0)
                    {
                        m_qteZero = true;   // on met m_qteZero à true
                        timer1.Enabled = true; // part timer 1 sec
                    }
                    barreClavier(); // barre les bouotons du clavier
                }
                else    // sinon (le bouton contient une lettre entre A et F)
                {
                    m_indexRangee = touche - 'A';   // on transforme la lettre en index de colonne
                    setClavierChiffres();   // affiche le clavier de chiffres
                }
                affiche();  // rafraichit l'affichage
            }
        }

        /// <summary>
        /// Si on appuie sur le bouton Clear, la transaction est annulée.
        /// retourne le crédit entré par l'usager et barre le clavier pendant 1 seconde.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            m_annulationVente = true;   // on met m_annulationVente à true
            m_retourCredit = m_credit;  // le retour de crédit prend la valeur du crédit entré par l'usager
            m_credit = 0;
            timer1.Enabled = true; //part timer 1 sec
            barreClavier(); // barre les boutons du clavier
            affiche();  // rafraichit l'affichage
            setClavierLettres();    // affiche le clavier de chiffres
        }

        /// <summary>
        /// Lorsqu'on appuie sur le bbouton Enter, si un item a été sélectionné et que le
        /// crédit est suffisant, l'achat est effectué. Sinon, on affiche le crédit manquant.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if(m_indexRangee != 255 && m_indexColonne != 255)   // si les deux index sont sélectionnés
            {
                if (m_credit >= m_prixCourant)  // si le crédit est suffisant pour payer le prix de l'item
                {
                    m_distributionActive = true;    // on met m_distributionActive à true
                    // le retour de crédit prend la valeur du crédit supplémentaire entré par l'usager
                    m_retourCredit = m_credit - m_prixCourant;  
                    m_credit = 0;   // on remet le crédit entré par l'usager à 0
                    // on diminue l'inventaire 1 fois pour l'item acheté
                    m_tabInventaire[m_indexRangee, m_indexColonne].diminuerInventaire();    
                }
                else    // sinon (manque de crédit)
                {
                    m_manqueCredit = true;  // on met m_manqueCredit à true
                }
                timer1.Enabled = true; // part timer 1 sec
                barreClavier(); // barre les boutons du clavier
                affiche();  // rafraichit l'affichage
            }
        }

        /// <summary>
        /// Lorsqu'on clique sur un bouton de crédit, le montant de crédit sélectionné est ajouté
        /// au crédit de l'usager.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void credit_Click(object sender, EventArgs e)
        {
            Button bouton;  // déclaration d'un bouton
            // déclaration d'un string pour la transformation du texte sur
            // le bouton de crédit en int
            string credit;  

            bouton = (Button)sender; //casting du sender en Button
            credit = bouton.Text.Replace("$", "");  // remplace le symbole $ du texte par un espace vide
            credit = credit.Replace(".", "");   // remplace le symbole . du texte par un espace vide
            m_credit += Convert.ToInt32(credit);    // ajout du crédit au crédit actuel de l'usager
            affiche();  // rafraichit l'affichage
        }

        /// <summary>
        /// Fonction qui affiche le clavier de chiffres.
        /// </summary>
        private void setClavierChiffres()
        {
            // boucle à travers les boutons du tableau m_clavier pour leur assigner leur index comme texte (0 à 9)
            foreach (Button btn in m_Clavier)
            {
                btn.Text = btn.TabIndex.ToString();
            }
        }

        /// <summary>
        /// Fonction qui affiche le clavier de lettres.
        /// </summary>
        private void setClavierLettres()
        {
            char c; // déclaration d'un char pour transformer les index du tableau en lettres de A à F

            for (int i = 0; i < NB_BUTTONS; i++)    // boucle parcourant les boutons du tableau m_clavier
            {
                // les boutons de la deuxième rangée contiendront les lettres de D à F
                if (i >= 4 && i <= 6)
                {
                    c = (char)('D' + i - 4);
                    m_Clavier[i].Text = c.ToString();
                }
                // les boutons de la première rangée contiendront les lettres de A à C
                else if (i >= 7 && i <= 9)  
                {
                    c = (char)('A' + i - 7);
                    m_Clavier[i].Text = c.ToString();
                }
                else // les autres boutons sont vides
                    m_Clavier[i].Text = "";
            }
        }

        /// <summary>
        /// Fonction pour rafraichir l'affichage.
        /// </summary>
        public void affiche()
        {
            // si les conditions de rafraichissement de l'affichage sont remplies
            if (true == m_objetAffichage.genererAffichage(m_indexRangee, m_indexColonne, m_credit, m_retourCredit,
            m_prixCourant, m_distributionActive, m_manqueCredit, m_annulationVente, m_qteZero, m_nomAliment))
            {
                // on rafraichit l'affichage
                listBoxDisplay.Items.Clear();
                for (int i = 0; i < 4; i++)
                {
                    listBoxDisplay.Items.Add(m_objetAffichage.lignesAffichage[i]);
                }
            }
        }

        /// <summary>
        /// Fonction qui barre les boutons du clavier selon l'état de l'affichage actuel.
        /// </summary>
        private void barreClavier()
        {
            foreach (Button btn in m_Clavier)   // désactive les boutons du clavier (chiffres et lettres)
            {
                btn.Enabled = false;
            }
            // si l'affichage est dans un des modes ci-dessous, on désactive aussi les boutons Clear, Enter et de crédit
            if (m_manqueCredit || m_qteZero || m_annulationVente || m_distributionActive)
            {
                buttonClear.Enabled = false;
                buttonEnter.Enabled = false;
                panelCredit.Enabled = false;
            }
        }

        /// <summary>
        /// Fonction qui active les boutons du clavier selon l'état de l'affichage actuel.
        /// </summary>
        private void permetClavier()
        {
            // activation des boutons de crédit, Clear et Enter
            buttonClear.Enabled = true;
            buttonEnter.Enabled = true;
            panelCredit.Enabled = true;
            // si l'affichage est dans un des modes ci-dessous, on active aussi les boutons du clavier (chiffres et lettres)
            if (m_qteZero || m_annulationVente || m_distributionActive)
            {
                foreach (Button btn in m_Clavier)
                {
                    btn.Enabled = true;
                }
                setClavierLettres();    // affiche le clavier de lettres
            }
        }

        /// <summary>
        /// Après 1 seconde d'activation du timer, on désactive le timer et on change 
        /// l'affichage en fonction de l'état précédent de l'affichage.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false; // désactivation du timer
            permetClavier();    // active les boutons du clavier

            if (m_manqueCredit) // si m_manqueCredit est true
            {
                m_manqueCredit = false; // met m_manqueCredit à false
            }   
            else if (m_annulationVente) // si m_annulationVente est true
            {
                m_annulationVente = false;  // met m_annulationVente à false
                m_prixCourant = 0;  // réinitialise le prix courant à 0
                m_retourCredit = 0; // réinitialise le retour de crédit à 0
                // réinitialise les index de rangée et de colonne
                m_indexRangee = 255;
                m_indexColonne = 255;
            }
            else if (m_qteZero) // si m_qteZero est true
            {   
                m_qteZero = false;  // met m_qteZero à false
                // réinitialise les index de rangée et de colonne
                m_indexRangee = 255;
                m_indexColonne = 255;
            }
            else if (m_distributionActive)  // si m_distributionActive est true
            {
                m_distributionActive = false;   // met m_distributionActive à false
                m_prixCourant = 0;  // réinitialise le prix courant à 0
                m_retourCredit = 0; // réinitialise le retour de crédit à 0
                // réinitialise les index de rangée et de colonne
                m_indexRangee = 255;
                m_indexColonne = 255;
            }
            affiche();  // rafraichit l'affichage
        }

        /// <summary>
        /// Lorsqu'on appuie sur le bouton Modifier inventaire, l'item sélectionné est modifié 
        /// avec la quantité et le prix de l'usager si tout est correct. (description en-dessous)
        /// - Si la rangée ou la colonne n'existe pas, on affiche que la case est mal sélectionnée. 
        /// - Si le prix entré par l'usager n'est pas un multiple de 5 entre 25 et 300 ou si la
        /// quantité n'est pas entre 0 et 9, on affiche que le prix ou la quantité est invalide.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonModInv_Click(object sender, EventArgs e)
        {
            // on transforme les valeurs de rangée et de colonne des ComboBox
            // en index pour le tableau m_tabInventaire
            int rangee = Convert.ToInt32(comboBoxRangee.Text[0] - 'A');
            int colonne = Convert.ToInt32(comboBoxColonne.Text[0] - '0');

            // si la rangée ou la colonne est en dehors du tableau
            if(rangee < 0  || rangee >= NBRANGEE || colonne < 0 || colonne >= NBCOLONNE)
                // on affiche un message pour dire que la case est mal sélectionnée
                MessageBox.Show("Case mal sélectionnée");   
            else    // sinon (la case est bien sélectionnée)
            {
                // on transforme les prix et quantité entrés en int
                int prix = Convert.ToInt32(textBoxPrix.Text);
                int quantite = Convert.ToInt32(textBoxQuantite.Text);

                // appel de la fonction modifierInventaire pour modifier l'inventaire
                bool modification = m_tabInventaire[rangee, colonne].modifierInventaire(prix, quantite);
                if (!modification)  // si la modification n'a pas eu lieu (modifierInventaire retourne false)
                    // on affiche un message pour dire que le prix ou la quantité est invalide
                    MessageBox.Show("Prix ou quantité invalide");
            }
        }

        /// <summary>
        /// Lorsqu'on passe à l'onglet Inventaire ou lorsqu'on change la rangée ou la colonne 
        /// dans cet onglet, on rafraichit l'affichage du prix et de la quantité de l'item
        /// sélectionné.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeIndex(object sender, EventArgs e)
        {
            // on transforme les valeurs de rangée et de colonne des ComboBox
            // en index pour le tableau m_tabInventaire
            int rangee = Convert.ToInt32(comboBoxRangee.Text[0] - 'A');
            int colonne = Convert.ToInt32(comboBoxColonne.Text[0] - '0');

            // si la case est bien sélectionnée
            if(rangee >= 0 && rangee < NBRANGEE && colonne >=0 && colonne < NBCOLONNE)
            {
                // on rafraichit l'affichage du prix et de la quantité de l'item sélectionné
                textBoxPrix.Text = m_tabInventaire[rangee, colonne].prix.ToString();
                textBoxQuantite.Text = m_tabInventaire[rangee, colonne].quantite.ToString();
            }   
        }
    }
}
