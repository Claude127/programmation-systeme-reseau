using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace projetResto.model;

public class Square
{
    public List<Table> tables;
    public List<Server> servers;
    public List<RangeChief> rangechiefs;
    
    public List<Server> Servers
    {
        get => servers;
        set => servers = value;
    }
    public List<RangeChief> RangeChiefs 
    {
        get => rangechiefs;
        set => rangechiefs = value;
    }
    public List<Table> Tables
    {
        get => tables;
        set => tables = value;
    }

    public Square()
    {
        this.tables = new List<Table>();
        this.servers = new List<Server>();
        this.rangechiefs = new List<RangeChief>();

        for (int i = 0; i < Parameters.SERVER_BY_SQUARE; i++)
        {
            this.servers.Add(new Server());
        } 
    }
    
    
    
}