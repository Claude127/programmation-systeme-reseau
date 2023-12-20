using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using projetResto.controller;
using projetResto.model;

namespace projetResto;

public class Game1 : Game
{
    private int tile = 32;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public const int WINDOW_WIDTH = 1390;// taille de l'ecran d'affichage 
    public const int WINDOW_HEIGHT = 600;
    
    Texture2D bg2Texture;
    public Rectangle Rectangle;
    
    //Texture des personnages
    private List<Texture2D> TextPerso = new List<Texture2D>();
    
    private restau rhall; // instance de la map

    private Hall hall;
    public HotelMasterController welcomeC;
    
    //liste de donnees 
    private List<string> data = new List<string>();
     
    //liste de groupes de clients 
    public List<GroupClientController> CGroupes;
    
    //server controller
    private ServerController server;
    
    // position des chef de rang 
    public Vector2 rangech1;
    public Vector2 rangech2;

    //table controller 
    private TableController tableC;
    
    // tables 
    public List<Table> tables, tablesInUse;
    
    //commis de salle 
    private CommisSalleController commisS;
    
    bool bill = true;
    
    
    public Hall Hall { get => hall; set => hall = value; }
    public TableController TableController { get => tableC; set => tableC = value; }


    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
        _graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        rhall = new restau();
        
        //instancie le controller du maitre d'hotel 
        welcomeC = new HotelMasterController(hall.HotelMaster);
        
        //instancie un groupe de client 
        CGroupes = new List<GroupClientController>();
        CGroupes.Add(new GroupClientController(welcomeC.CreateGroup(5)));
        
        // instancie un serveur(son controlleur)
        server = new ServerController(new Vector2(25 * tile, 17 * tile));
        
        //instancie les chef de rang 
        rangech1 = hall.HotelMaster.RangeChiefs[0].Terminus;
        rangech2 = hall.HotelMaster.RangeChiefs[1].Terminus;
        
        //instancie le controlleur des tables
        tableC = new TableController();

        tables = new List<Table>();
        
        // instancie le role de commissalle 
        commisS = new CommisSalleController();
        
        // instancie la liste de data
        data.Add("");
        data.Add("");
        data.Add("");
        data.Add("");
        data.Add("");
        data.Add("");
        
        //

        TextPerso.Add(Content.Load<Texture2D>("commisalledown")); //0
        TextPerso.Add(Content.Load<Texture2D>("groupe3")); //1
        TextPerso.Add(Content.Load<Texture2D>("maitrehoteldown")); //2
        TextPerso.Add(Content.Load<Texture2D>("RangeChief")); //3
        TextPerso.Add(Content.Load<Texture2D>("serveurmovingdown")); //4
        TextPerso.Add(Content.Load<Texture2D>("perso1")); //5
        TextPerso.Add(Content.Load<Texture2D>("perso8")); //6
        TextPerso.Add(Content.Load<Texture2D>("perso10")); //7
        
        
        
        
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
      
        // TODO: use this.Content to load your game content here
        
        //positionnement du background
        rhall.Texture = Content.Load<Texture2D>("Background");
        bg2Texture = Content.Load<Texture2D>("blanc");
        Rectangle = new Rectangle(1280,0,320 ,600);
        rhall.Rect= new Rectangle(0,0,1280,600);
        
        
        //texture des personnages

        hall.HotelMaster.RangeChiefs[0].Texture = TextPerso[3];
        hall.HotelMaster.RangeChiefs[1].Texture = TextPerso[3];

        server.Texture = TextPerso[4];

        commisS.Texture = TextPerso[0];

    }
    
    private Vector2 rectToVect(Rectangle rect)
    {
        return new Vector2(rect.X, rect.Y);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        
        _graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
        _graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
        
        
        //////////////////////////////////////////////////////////////////
        
// on initialise la liste des tables et des tables occupees
        tables = new List<Table>(); 
        tablesInUse = new List<Table>();

//on parcourt les tables attribuees aux 02 chefs de rang puis on les ajoutes a la liste de tables . si la table est attribuee a un groupe , on l'ajoute dans la liste de tables occupees
        foreach (Table t in hall.HotelMaster.RangeChiefs[0].Squares[0].Tables)
        {
            tables.Add(t);
            if(t.GroupClient != null)
            {
                tablesInUse.Add(t);
            }
        }
        foreach (Table t in hall.HotelMaster.RangeChiefs[1].Squares[0].Tables)
        {
            tables.Add(t);
            if (t.GroupClient != null)
            {
                tablesInUse.Add(t);
            }
        }
        
        if ((gameTime.TotalGameTime.Seconds % 30 == 0)) //cette condition s'execute toutes les 30s du jeu
        {
            if (bill)
            {
                Random random = new Random();
                int randomNumber = random.Next(3, 9);
                //Recette recette = MapController.GetMap().Recettes[0];
                GroupClient group = welcomeC.CreateGroup(randomNumber); // on cree un groupe donc le nombre varie entre 03 et 09 
                //group.Clients.ForEach(c => c.Entry = recette); // on attribue une recette a chaque recette
                group.State = GroupState.WaitDessert; // change l'etat du groupe 
                CGroupes.Add(new GroupClientController(group)); //ajoute le groupe a la liste de groupe
                ThreadPool.QueueUserWorkItem(SalleCommandsController.ConnectAndSendCommand, group); // envoie la commande a la cuisine 
                bill = false;
            }
        }
        else
        {
            bill = true;
        }
        
        commisS.Update(gameTime, CGroupes[0].inTable, tables);
        
        foreach(GroupClientController groupe in CGroupes)
        {
            groupe.Texture = updateTexure(groupe.group.Clients.Count);

//pour chaque groupe dans la liste , on debute le service sinon , on lui attribue une table

            if (groupe.start)
            {
                groupe.Start(gameTime);
            }
            else
            {
                if (!groupe.inTable)
                {
                    putGroupToTable(groupe);
                }
                groupe.Update(gameTime, groupe.PosTable);
            }


        }
        
        server.Update(gameTime, tables);
        hall.HotelMaster.RangeChiefs[0].Update(gameTime,rangech1);
        hall.HotelMaster.RangeChiefs[1].Update(gameTime,rangech2);

        
        base.Update(gameTime);
    }
    
    
     private Texture2D updateTexure(int nbpersonnes)
    {
            

        switch (nbpersonnes)
        {
            case 3:
                return TextPerso[1];

                break;
            case 4:
                return TextPerso[5];

                break;
            case 5:

                return TextPerso[1];
                break;
            case 6:

                return TextPerso[1];
                break;
            case 7:

                return TextPerso[1];
                break;
            case 8:
                return TextPerso[1];
                break;
            case 9:
                return TextPerso[1];
                break;
        }
        return TextPerso[7];
    }


    
    
        public void putGroupToTable(GroupClientController groupe)
        {
            if (hall.HotelMaster.RangeChiefs[0].Available)
            {
                foreach (Table t in hall.HotelMaster.RangeChiefs[0].Squares[0].Tables)
                {
                    if (t.GroupClient != null || t.NbPlaces < groupe.group.Clients.Count)
                    {
                        hall.HotelMaster.RangeChiefs[0].Available = false;
                    }
                    else
                    {
                        hall.HotelMaster.RangeChiefs[0].Available = true;
                        break;
                    }
                }

                Table table = tableC.OptimizedFindTable(hall.HotelMaster.RangeChiefs[0].Squares[0].Tables, groupe.group.Clients.Count);
                if (table != null)
                {
                    tableC.AttributionTableGroup(groupe.group, table);
                    hall.HotelMaster.RangeChiefs[0].isMoving = true;
                    hall.HotelMaster.RangeChiefs[0].Available = false;
                    rangech1 = rectToVect(table.Source);
                    groupe.PosTable = rangech1;
                    groupe.isMoving = true;
                    groupe.inTable = true;
                    
                }
                

            }
            else if (hall.HotelMaster.RangeChiefs[1].Available)
            {


                Table table = tableC.OptimizedFindTable(hall.HotelMaster.RangeChiefs[1].Squares[0].Tables, groupe.group.Clients.Count);
                if (table != null)
                {
                    
                    tableC.AttributionTableGroup(groupe.group, table);
                    hall.HotelMaster.RangeChiefs[1].isMoving = true;
                    hall.HotelMaster.RangeChiefs[1].Available = false;
                    rangech2 = rectToVect(table.Source);
                    groupe.PosTable = rangech2;
                    groupe.isMoving = true;
                    groupe.inTable = true;

                }

            }

        }


    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        rhall.Draw(_spriteBatch);
        _spriteBatch.Draw(bg2Texture,Rectangle,Color.White);
        
        foreach(GroupClientController groupe in CGroupes)
        {
            groupe.Draw(_spriteBatch);
        }
        
        hall.HotelMaster.RangeChiefs[0].Draw(_spriteBatch);
        hall.HotelMaster.RangeChiefs[1].Draw(_spriteBatch);
        server.Draw(_spriteBatch);
        commisS.Draw(_spriteBatch);
        
        _spriteBatch.End();


        base.Draw(gameTime);
    }
}