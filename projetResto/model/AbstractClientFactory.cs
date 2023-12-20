namespace projetResto.model;

public abstract class AbstractClientFactory : IClientFactory
{
    public abstract Client CreateClient();
}