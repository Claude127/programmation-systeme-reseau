using System.Collections.Generic;
using System.Threading;
using projetResto.controller;

namespace projetResto.model;

public class RestaurantLauncher
{
    private List<Hall> halls;

    private SalleController salleController;

    //private KitchenController kitchenController;
    private Game1 game;
    public int speed = 16;

    public List<Hall> Halls
    {
        get => halls;
        set => halls = value;
    }

    public Game1 Game
    {
        get => game;
        set => game = value;
    }

    public RestaurantLauncher()
    {
        halls = new List<Hall>();
        halls.Add(new Hall());
        salleController = new SalleController();
        // kitchenController = new KitchenController();
        //Thread kitchenCommands = new Thread(LaunchKitchenCommands);
        //Thread salleCommands = new Thread(LaunchSalleCommandsAsync);
        //kitchenCommands.Start();
        //salleCommands.Start();
        game = new Game1();
        game.Hall = halls[0];
        //MapController.UpdateMap();
    }

}

/* private void LaunchKitchenCommands()
 {
     kitchenController.kitchenCommandsController.InitSocketServerAsync();
     kitchenController.kitchenCommandsController.SocketListen();
 }

 private void LaunchSalleCommandsAsync()
 {
     SalleCommandsController.Instance.InitClientSocketAsync();
     SalleCommandsController.Instance.HotelMaster = halls[0].HotelMaster;
     SalleCommandsController.Instance.SocketConnect();
 }*/

