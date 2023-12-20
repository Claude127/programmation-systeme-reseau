using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using projetResto.model;

namespace projetResto.controller;

public class SalleCommandsController
{
        private IPAddress localIP;
        private IPEndPoint iPEndPoint;
        private Socket sender;
        private static IPAddress IP;
        private static IPEndPoint EndPoint;
        private readonly object syncLock = new object();

        private HotelMaster hotelMaster;

        private static SalleCommandsController instance;

        public static SalleCommandsController Instance
        {
            get
            {
                if (instance == null)
                    instance = new SalleCommandsController();
                return instance;
            }
        }

        public HotelMaster HotelMaster { get => hotelMaster; set => hotelMaster = value; }

        private SalleCommandsController() { }

        public async Task InitClientSocketAsync()
        {
            this.localIP = IPAddress.Parse(Parameters.SALLE_CLIENT_LOCAL_IP);
            this.iPEndPoint = new IPEndPoint(localIP, Parameters.SALLE_CLIENT_COMMAND_PORT);
            IP = IPAddress.Parse(Parameters.SALLE_CLIENT_LOCAL_IP);
            EndPoint = new IPEndPoint(localIP, Parameters.SALLE_CLIENT_COMMAND_PORT);
            this.sender = new Socket(localIP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Parameters.SALLE_CLIENT_STARTED = true;
           // await LoggerController.AppendLineToFile(Parameters.LOG_PATH, "Salle commands client started");
        }

        public void CloseSocket()
        {
            Parameters.SALLE_CLIENT_STARTED = false;
            this.sender.Shutdown(SocketShutdown.Both);
            this.sender.Close();
            this.sender.Dispose();
        }

        public void SocketConnect()
        {
            byte[] bytes = new byte[2048];
            sender.Connect(this.iPEndPoint);
            while(Parameters.SALLE_CLIENT_STARTED == true)
            {
                int counter = sender.Receive(bytes);
                if(counter > 0)
                {
                    GroupClient group = DeserializeGroup(bytes);
                    Console.WriteLine(group.ID);
                }
            }
        }

        public static void ConnectAndSendCommand(Object objectGroup)
        {
            try
            {
                Socket sender = new Socket(IP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                byte[] bytes = new byte[2048];

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(EndPoint);

                    // Encode the data string into a byte array.  
                    byte[] msg = SerializeGroup((GroupClient)objectGroup);

                    // Send the data through the socket.  
                    int bytesSent = sender.Send(msg);

                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    GroupClient group = DeserializeGroup(bytes);
                    Console.WriteLine("Salle: commande reçu du groupe " + group.ID);
                    if (group != null)
                    {
                        Table groupTable = Instance.RetrieveTableFromGroup(group);
                        Instance.ChangeStateByGroup(groupTable);
                        groupTable.GroupClient.Notify();
                        Console.WriteLine("Table " + groupTable.GroupClient.ID + ", " + groupTable.GroupClient.State + " : " + groupTable.Dessert);
                    }

                    // Release the socket.  
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public Table RetrieveTableFromGroup(GroupClient group)
        {
            /*List<Table> tablesRepository = new List<Table>();
            hotelMaster.RangeChiefs
            .ForEach(r => tablesRepository.AddRange(r.Squares[0].Tables));
            if (tablesRepository != null)
            {
                Table table = tablesRepository.Find(t => t.GroupClient.ID == group.ID);
                return table;
            }*/
            Table table = null;
            if (hotelMaster != null && hotelMaster.RangeChiefs
                != null)
            hotelMaster.RangeChiefs
                .ForEach(r => {
                if(r.Squares[0].Tables != null)
                {
                    if (r.Squares[0].Tables.Exists(t => (t.GroupClient != null) ? t.GroupClient.ID == group.ID : false))
                    {
                        Console.WriteLine("Table found");
                        table = r.Squares[0].Tables.Find(t => (t.GroupClient != null) ? t.GroupClient.ID == group.ID : false);
                    }
                    else
                    {
                        Console.WriteLine("Table not found");
                    }
                        
                }
            });
            return table;
        }

        public void ChangeStateByGroup(Table table)
        {
            switch(table.GroupClient.State)
            {
                case GroupState.WaitEntree:
                    table.Entry = true;
                    table.GroupClient.State = GroupState.WaitPlate;
                    break;
                case GroupState.WaitPlate:
                    table.Plate = true;
                    table.GroupClient.State = GroupState.WaitDessert;
                    break;
                case GroupState.WaitDessert:
                    table.Dessert = true;
                    table.GroupClient.State = GroupState.WaitBill;
                    break;
            }
        }

        public static byte[] SerializeGroup(GroupClient group)
        {
            string groupJSON = JsonConvert.SerializeObject(group);
            byte[] bytes = Encoding.ASCII.GetBytes(groupJSON);
            return bytes;
        }

        public static GroupClient DeserializeGroup(byte[] bytes)
        {
            string groupJSON = Encoding.ASCII.GetString(bytes);
            GroupClient group = JsonConvert.DeserializeObject<GroupClient>(groupJSON);
            return group;
        }
    
}