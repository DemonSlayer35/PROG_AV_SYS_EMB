/**
 * @file   ThreadRxUDP.cs
 * @author Mohammad Barin Wahidi
 * @date   17 novembre 2022
 * @brief  Classe thread pour la réception UDP.
 * 
 * Environnement: Visual Studio 2022
 */

using System.Net; //ajout manuel
using System.Net.Sockets; //ajout manuel
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab4StationMeteoBarin
{
    class ThreadRxUDP
    {
        // définition du prototype de la fonction d'affichage des données reçues par le port série ou par UDP
        public delegate void monProtoDelegate(List<byte> bytes, string srcIp);
        public monProtoDelegate objDelegate; // déclaration d'un objet delegate

        Form m_ptrDefrmPrin;    // variable pour le pointeur de la form principale

        const int PORT_RX = 2223;  //Port de réception UDP
        const int MAX_TRAME = 512; //Grosseur max du buffer de réception

        private byte[] m_trameRx = new byte[MAX_TRAME];  //buffer de Rx


        private IPAddress ipClient;  //à titre d'info pour savoir qui a émit la trame UDP
        private int portClient; //idem pour le port

        private UdpClient udpClient;

        /// <summary>
        /// Constructeur
        /// </summary>
        public ThreadRxUDP(Form ptrDeLaFormPrincipale)
        {
            udpClient = new UdpClient(PORT_RX);
            m_ptrDefrmPrin = ptrDeLaFormPrincipale; // on associe le pointeur à la form principale
        }

        /// <summary>
        /// Méthode principale appelée par le Thread (pour attendre la réception des trames UDP)
        /// </summary>
        public void FaitTravail()
        {
            IPEndPoint IpDistant = new IPEndPoint(IPAddress.Any, 0);

            //le thread tourne toujours dans cette boucle en attente d'une trame UDP
            while (true)
            {
                m_trameRx = udpClient.Receive(ref IpDistant);
                ipClient = ((IPEndPoint)IpDistant).Address;  //ip du client UDP qui a émis la trame
                portClient = ((IPEndPoint)IpDistant).Port;   //port du client UDP qui a émis la trame
                if (m_trameRx != null && m_trameRx.Length < MAX_TRAME)   // si la trame n'est pas vide et est plus petite que le max
                {
                    List<byte> m_lstTrameRx = new List<byte>(); // on crée une liste d'octets
                    foreach (byte b in m_trameRx)   // on met les octets de la trame dans la liste
                        m_lstTrameRx.Add(b);
                    // Appel de la méthode d'affichage de la form principale
                    // on passe la liste d'octets et le socket
                    m_ptrDefrmPrin.BeginInvoke(objDelegate, m_lstTrameRx, ipClient.ToString() + ": " + portClient.ToString());
                }

            }
        }

        /// <summary>
        /// Fonction pour arrêter le client UDP
        /// </summary>
        public void ArreteClientUDP()
        {
            udpClient.Close();
        }
    }
}
