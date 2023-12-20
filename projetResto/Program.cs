using System;
using projetResto.model;

/*using var game = new projetResto.Game1();
game.Run();*/

public static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        RestaurantLauncher restaurant = new RestaurantLauncher();
        using (var game = restaurant.Game)
            game.Run();
    }
}