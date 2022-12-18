/**
 * @file   Recette.cs
 * @author Mohammad Barin Wahidi
 * @date   17 décembre 2022
 * @brief  Classe qui permet de contenir une recette de l'état
 *         des DEL et qui permet de savoir si la recette a été
 *         enregistrée par l'usager ou non.
 *
 * Environnement: Visual Studio 2022
 */

using System.Collections.Generic;

namespace LampeDel_Barin
{
    internal class Recette
    {
        public List<int> del { get; set; } //listes d'intensités des DEL
        public bool pointEnr { get; set; } //on veut savoir si cette recette a été enregistrée pour l'usager


        /// <summary>
        /// Constructeur. Construit la liste des DEL. Met à 0 l'intensité de chaque DEL.
        /// Met à false pointEnr 
        /// </summary>
        /// <param name="nb"> nombre de del pour cette recette</param>
        public Recette(int nb)
        {
            del = new List<int>();
            for(int i = 0; i < nb; i++)
                del.Add(0);
            pointEnr = false;
        }
    }
}
