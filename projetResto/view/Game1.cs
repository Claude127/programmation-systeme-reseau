using System.Collections.Generic;
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

    public Hall hall;
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
    public TableController tableC;
    
    // tables 
    public List<Table> tables, tablesInUse;
    
    //commis de salle 
    private CommisSalleController commisS;
    
    

    
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

        TextPerso.Add(Content.Load<Texture2D>("commisalledown"));
        TextPerso.Add(Content.Load<Texture2D>("groupe3"));
        TextPerso.Add(Content.Load<Texture2D>("maitrehoteldown"));
        TextPerso.Add(Content.Load<Texture2D>("RangeChief"));
        TextPerso.Add(Content.Load<Texture2D>("serveurmovingdown"));
        
        
        
        
        
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

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        
        _graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
        _graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        rhall.Draw(_spriteBatch);
        _spriteBatch.Draw(bg2Texture,Rectangle,Color.White);
        _spriteBatch.End();


        base.Draw(gameTime);
    }
}