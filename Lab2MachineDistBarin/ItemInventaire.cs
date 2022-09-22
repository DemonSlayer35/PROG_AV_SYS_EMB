/**
 * @file   ItemInventaire.cs
 * @author Mohammad Barin Wahidi
 * @date   septembre 2022
 * @brief  Classe pour un item d'inventaire avec un prix, une quantité et un index de nom d'aliment.
 *         La classe contient aussi des fonctions pour modifier l'inventaire, diminuer l'inventaire
 *         et retourner le nom de l'aliment.
 * 
 * Environnement: Visual Studio 2022
 */

namespace Lab2MachineDistBarin
{
    internal class ItemInventaire
    {
        // variables membres pour le prix, la quantité et l'index
        private int m_prix;
        private int m_quantite;
        private int m_index;
        // tableau contenant les noms des différents aliments de la machine distributrice
        private string[] nomAliment = { "chips BBQ", "arachides", "chips Lays original", "chips au ketchup", "chips au vinaigre", 
        "Pringles crème sure", "Skittles","M&M's","Kit Kat","amandes salées","graines de tournesol","Caramilk","Twix","Mentos",
        "Kinder Bueno","barre tendre avoine","eau","jus d'orange","jus de pomme","Coke"};

        //Création des propriétés prix et quantite et des méthodes get permettant de lire les variables privées 
        //m_prix et m_quantite.
        //Aucune méthode set, car on protège nos variables privées. L'usager devra utiliser les méthodes
        //modifierInventaire et diminuerInventaire pour modifier les variables
        public int prix
        {
            get
            {
                return m_prix;
            }
        }

        public int quantite
        {
            get
            {
                return m_quantite;
            }
        }

        /// <summary>
        /// Constructeur. Doit utiliser la méthode modifierInventaire pour assigner les prix et quantite
        /// </summary>
        /// <param name="prixItem"> on reçoit le prix de l'item lors de sa création</param>
        /// <param name="qteItem"> on reçoit la quantité de l'item lors de sa création<</param>
        /// <param name="index"> on reçoit l'index de l'aliment lors de sa création<</param>
        public ItemInventaire(int prixItem, int qteItem, int index)
        {
            modifierInventaire(prixItem, qteItem);
            m_index = index;
        }

        /// <summary>
        /// Permet de modifier le prix et la quantité d'un item de l'inventaire s'ils sont valides
        /// </summary>
        /// <param name="oPrix">Doit être entre 0.25$ et 3.00$ et un multiple de 5 cents</param>
        /// <param name="oQuantite">Doit être entre 1 et 9 inclusivement</param>
        /// <returns>Vrai si la modification a réussi. Faux si non.</returns>
        public bool modifierInventaire(int oPrix, int oQuantite)
        {
            // si le prix et la quantité sont valides, on procède aux modifications
            if (oPrix >= 25 && oPrix <= 300 && (oPrix % 5 == 0) && oQuantite >= 1 && oQuantite <= 9)
            {
                m_prix = oPrix;
                m_quantite = oQuantite;
                return true;    // retourne true pour dire que la modification a été faite
            }
            else
                return false;   // retourne false pour dire que la modification n'a pas été faite
        }

        /// <summary>
        /// Moins un sur la qte si > 0
        /// </summary>
        public void diminuerInventaire()
        {
            if (m_quantite > 0)
            {
                m_quantite--;
            }
        }

        /// <summary>
        /// Retourne le nom de l'aliment selon son index dans le tableau d'aliments.
        /// </summary>
        /// <returns>Le nom de l'aliment depuis l'index du tableau.</returns>
        public string getNomAliment()
        {
            return nomAliment[m_index];
        }
    }
}
