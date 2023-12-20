namespace projetResto.model;

public class HurriedClientFactory : AbstractClientFactory
{
    public static HurriedClientFactory instance;

    public static HurriedClientFactory Instance
    { 
        get
        {
            if (instance == null)
                instance = new HurriedClientFactory();
            return instance;
        }
    }
    
    public HurriedClientFactory() { }

    public override Client CreateClient()
    {
        Client client = new Client();
        client.Strategy.Add("state",0);
        client.Strategy.Add("dessert",0);
        return client;
    }
}