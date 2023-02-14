﻿using MGPacManComponents.Food;
using MGPacManComponents.Pac;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonFilesystem
{
    public class FoodManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected List<Food> foods;
        protected Vector2 foodGrid = new Vector2(2, 2);
        protected int xOffset;
        protected int yOffset;
        Game g;
        MonogamePacMan PacMan;


        SpriteBatch sb;

        public FoodManager(Game game, MonogamePacMan p)
            : base(game)
        {

            g = game;
            PacMan = p;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {

            foods = new List<Food>();
            

            sb = new SpriteBatch(Game.GraphicsDevice);
            LoadLevel();
            base.Initialize();
        }

        protected virtual void LoadLevel()
        {
            Vector2 startLoc = new Vector2(10, 10);

            xOffset = 150;
            yOffset = 150;

            for (int i = 0; i < foodGrid.X; i++)
            {
                for (int ii = 0; ii < foodGrid.Y; ii++)
                {
                    Food f = new Food(this.Game);
                    f.Initialize();
                    f.Location = new Vector2(startLoc.X + (xOffset * i), startLoc.Y + (yOffset * ii));
                    foods.Add(f);
                }
            }
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {


            foreach (var f in foods)
            {
                if (f.Enabled)
                {
                    f.Update(gameTime);
                    if (f.Intersects(PacMan))
                    {
                        f.Enabled = false;
                        f.Visible = false;
                        
                    }
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            sb.Begin();
            foreach (Food f in foods)
            {
                if (f.Visible)
                {
                    f.Draw(sb);
                }
            }
            sb.End();
            base.Draw(gameTime);
        }
    }
}
