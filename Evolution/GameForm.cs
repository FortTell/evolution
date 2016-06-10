using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Evolution.Entities;
using Evolution.Logic;

namespace Evolution.GUI
{
    class GameForm : Form
    {
        Game game;
        Random rnd = new Random();
        int tickCount = 0;
        string pressedKey = "";
        Dictionary<Type, List<Bitmap>> creatureImages;
        Dictionary<Type, Bitmap> terrainObjImages;

        public GameForm()
        {
            Height = 600;
            Width = 800;
            Text = "Evolution";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.DoubleBuffered = true;

            StartGame();

            var creatureTypes = ReflectionUtil.GetTypesInheritedFrom(typeof(Creature));
            InitializeUI(creatureTypes);
            creatureImages = FillCreatureImageDict(creatureTypes);

            var terrainObjTypes = ReflectionUtil.GetTypesInheritedFrom(typeof(Terrain));
            terrainObjImages = FillTerrainObjImageDict(terrainObjTypes);

            var timer = new Timer();
            timer.Interval = 80;
            timer.Tick += (sender, args) => TimerTick();
            timer.Start();
        }

        private void StartGame()
        {
            string filename = @"Levels\levelList.txt";
            if (File.Exists(filename))
            {
                var levels = File.ReadAllLines(filename);
                game = Game.LoadLevelFromFile(@"Levels\" + levels[0], typeof(Caterpillar));
            }
        }

        private void InitializeUI(List<Type> creatureTypes)
        {
            Menu = new MainMenu();
            var spawner = new MenuItem("Spawn a creature");
            foreach (var type in creatureTypes)
            {
                var item = new MenuItem(type.Name);
                item.Click += (sender, args) =>
                {
                    var creature = (Creature)ReflectionUtil.CreateAtCoords(type, rnd.Next(Size.Width - 64), rnd.Next(Size.Height - 64));
                    game.creatures.Add(creature);
                    Invalidate();
                };
                spawner.MenuItems.Add(item);
            }
            Menu.MenuItems.Add(spawner);
        }

        private Dictionary<Type, List<Bitmap>> FillCreatureImageDict(List<Type> creatureTypes)
        {
            var dct = new Dictionary<Type, List<Bitmap>>();
            foreach (var type in creatureTypes)
            {
                dct.Add(type, new List<Bitmap>());
                var name = type.Name.ToLower();
                for (int i = 1; i <= 8; i++)
                {
                    var filename = @"Gfx\" + name + i + ".png";
                    if (File.Exists(filename))
                        dct[type].Add(new Bitmap(filename));
                    else
                        break;
                }
            }
            return dct;
        }

        private Dictionary<Type, Bitmap> FillTerrainObjImageDict(List<Type> terrainObjTypes)
        {
            var dct = new Dictionary<Type, Bitmap>();
            foreach (var type in terrainObjTypes)
            {
                var filename = @"Gfx\" + type.Name.ToLower() + ".png";
                if (File.Exists(filename))
                    dct.Add(type, new Bitmap(filename));
                else
                    throw new Exception(String.Format(
                        "The image for type {0}, which is expected to be at {1}, is not found!", type.Name, filename));
            }
            return dct;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            pressedKey = e.KeyCode.ToString();
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            pressedKey = "";
            base.OnKeyUp(e);
        }

        void TimerTick()
        {
            if (tickCount == 0)
            {
                foreach (var c in game.creatures)
                    c.MakeNextMove();
                var ctplr = (Caterpillar)game.playerCreature;
                ctplr.MakeRealAnim(game.terrainObjs, pressedKey);           
            }
            foreach (var c in game.creatures)
                c.SetLocation(
                    c.Location.X + c.currentAnim[tickCount].dx,
                    c.Location.Y + c.currentAnim[tickCount].dy);
            if (tickCount == 7)
            {

                //handle collisions
            }
            tickCount++;
            if (tickCount == 8)
                tickCount = 0;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            foreach (var o in game.terrainObjs)
                g.DrawImage(terrainObjImages[o.GetType()], o.Location);
            foreach (var c in game.creatures)
            {
                var imgList = creatureImages[c.GetType()];
                g.DrawImage(imgList[tickCount % imgList.Count], c.Location);
            }
            base.OnPaint(e);
        }
    }
}
