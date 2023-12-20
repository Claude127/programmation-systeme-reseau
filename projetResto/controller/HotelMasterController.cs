using System;
using System.Text.RegularExpressions;
using projetResto.model;

namespace projetResto.controller;

public class HotelMasterController
{
    private HotelMaster hotelMaster;

        public HotelMasterController(HotelMaster hotelMaster)
        {
            this.hotelMaster = hotelMaster;
        }

        public Client GenerateClient() // genere un client aleatoire 
        {
            Client client;
            Random random = new Random();
            int randomNumber = random.Next(1, 100);
            switch (randomNumber)
            {
                case int rn when (rn <= 20):
                    client = HurriedClientFactory.Instance.CreateClient();
                    break;

                case int rn when (rn > 20 && rn < 80):
                    client = NormalClientFactory.Instance.CreateClient();
                    break;

                case int rn when (rn >= 80 && rn <= 100):
                    client = CoolClientFactory.Instance.CreateClient();
                    break;

                default:
                    client = NormalClientFactory.Instance.CreateClient();
                    break;
            }

            return client;
        }

        public GroupClient CreateGroup(int clientNumber) //l'on cree un groupe de client
        {
            GroupClient group = new GroupClient();
            for (int i = 0; i < clientNumber; i++)
            {
                group.Clients.Add(this.GenerateClient());
            }
            return group;
        }

        public bool CheckAvailableTables(GroupClient group) // on verifie les tables disponibles dans chaque carree , 
        {
            return this.hotelMaster.RangeChiefs.Exists(
                RangeChief => RangeChief.Squares[0].Tables.Exists( //on check si l'un des chef de rang a des tables suffisantes et libres pour le groupe de clients
                    table => (table.State == UtilsState.Available)
                        && (table.NbPlaces >= group.Clients.Count)));
        }

        public RangeChief FindRangeChief(GroupClient group) // on trouve le chef de rang associe a une groupe de clients
        {
            RangeChief designatedRangechief = this.hotelMaster.RangeChiefs.Find(
                rangechief => rangechief.Squares[0].Tables.Exists( //on trouve le chef de rang assigne au carre de la table 
                    table => table.GroupClient == group)); //on verifie l'existence la table du groupe de clients
            return designatedRangechief;
        }

        public void CallRangeChief(RangeChief rangeChief) //methode pour deplacer le chef de ran g a la position souhaitee
        {
            if (rangeChief != null)
                rangeChief.Move(hotelMaster.X - 10, hotelMaster.Y);
        }
    

}