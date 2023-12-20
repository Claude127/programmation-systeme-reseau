using System.Collections.Generic;
using System.Text.RegularExpressions;
using projetResto.model;

namespace projetResto.controller;

public class TableController
{
        public Table OptimizedFindTable(List<Table> tables, int groupSize) //attribuer une table a un groupe en fonction de la taille du groupe et la disponibilite de la table
        {
            if (groupSize <= 10)
            {
                int i = groupSize;
                while (i <= 10)
                {
                    if (tables.Exists(table => table.NbPlaces == i && table.State == UtilsState.Available))
                        return tables.Find(table => table.NbPlaces == i && table.State == UtilsState.Available); // renvoie la premiere table disponible trouvee 
                    i++;
                } 



            }
            return null;
        }

        public bool AttributionTableGroup(GroupClient group, Table table) // on attribue une table a un groupe si la table est disponible et comporte un nombre de places suffisant pour le groupe
        {
            if((table.State == UtilsState.Available) 
                && (table.NbPlaces >= group.Clients.Count))
            {
                table.GroupClient = group; // on attribue la table au client 
                table.State = UtilsState.InUse; //modifie le statut de la table en occupee
                group.State = GroupState.WaitEntree; // modifie le statut du groupe ;
                return true;
            }
            return false;
        }

        public static void CleanTable(Table table) // une table est disponible du moment ou elle est sale 
        {
            if (table.State == UtilsState.Dirty)
                table.State = UtilsState.Available;
        }

        public void DriveGroupTable(Table table, RangeChief rangeChief) // le chef de rang conduit le groupe de client a sa table
        {
            if (table.GroupClient != null)
            {
                table.GroupClient.Move(table.X, table.Y);
                rangeChief.Move(table.X - 32, table.y);
            }
        }

        public static bool Restock(Table table) // si une table est occupee , le commis apporte du pain
        {
            if((table.State == UtilsState.InUse) && (table.GroupClient != null))
            {
                Hall.Commis.Move(table.X, table.Y);
                return StockUtils.Instance.SubstractUtils("BreadBasket");
            }
            return false;
        }
}