using System.Buffers.Text;
using System.Collections.Generic;
using projetResto.controller;

namespace projetResto.model;

public enum GroupState {
    WaitTableAttribution,
    WaitRankChief,
    Ordering,
    TableDispose,
    Ordered,
    WaitEntree,
    WaitPlate,
    WaitDessert,
    WaitBill,
    Dead
};


public class GroupClient : Position, IMove
{
    public int id;
    public List<Client> clients;
    public GroupState state;
    public static int GroupCounter = 1;

    public int ID
    {
        get => id;
        set => id = value;
    }

    public List<Client> Clients
    {
        get => clients;
        set => clients = value;
    }

    public GroupState State
    {
        get => state;
        set => state = value;
    }
    
    public GroupClient() : base()
    {
        this.clients = new List<Client>();
        this.id = GroupCounter;
        GroupCounter++;
        this.state = GroupState.WaitTableAttribution;
    }

    public GroupClient(int x, int y) : base(x, y)
    {
        this.clients = new List<Client>();
        this.id = GroupCounter;
        GroupCounter++;
        this.state = GroupState.WaitTableAttribution;
    }

    public void Move(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void Notify()
    {
        EventHandlerGroup.Instance.Update(this);
    }
}