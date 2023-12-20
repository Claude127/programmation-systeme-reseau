namespace projetResto.model;

public class CoolClientFactory : AbstractClientFactory
{
    public static CoolClientFactory instance;

    public static CoolClientFactory Instance
    {
        get
        {
            if (instance == null)
                instance = new CoolClientFactory();
            return instance;
        }
    }
    
    public CoolClientFactory(){ }

    public override Client CreateClient()
    {
        Client client = new Client();
        client.Strategy.Add("state",2);
        client.Strategy.Add("dessert", 1);
        return client;
    }
}