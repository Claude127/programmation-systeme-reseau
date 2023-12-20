namespace projetResto.model;

public class NormalClientFactory : AbstractClientFactory
{
    public static NormalClientFactory instance;

    public static NormalClientFactory Instance
    {
        get
        {
            if (instance == null)
                instance = new NormalClientFactory();
            return instance;
        }
    }

    private NormalClientFactory()
    {
        
    }

    public override Client CreateClient()
    {
        Client client = new Client();
        client.strategy.Add("state", 1);
        client.Strategy.Add("dessert",0);
        return client;
    }
}