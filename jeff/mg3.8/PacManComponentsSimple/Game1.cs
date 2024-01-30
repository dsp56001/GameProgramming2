﻿using MGPacManComponents.Food;
using MGPacManComponents.Ghost;
using MGPacManComponents.Pac;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Net.NetworkInformation;

namespace PacManComponentsSimple
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        MonogamePacMan pac;
        MonogameGhost ghostRed;
        Food food;
        SuperFood superFood;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            pac = new MonogamePacMan(this);
            this.Components.Add(pac);

            ghostRed = new MonogameGhost(this, pac);
            this.Components.Add(ghostRed);

            food = new Food(this);
            this.Components.Add(food);

            superFood = new SuperFood(this);
            this.Components.Add(superFood);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            food.Location = new Vector2(50, 100);
            superFood.Location = new Vector2(50, 150);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            UpdatePacManFoodCollision(gameTime);

            base.Update(gameTime);
        }

        private void UpdatePacManFoodCollision(GameTime gameTime)
        {
            if(pac.Intersects(food))
            {
                food.Hit();
            }
            if(pac.Intersects(superFood)) 
            {
                superFood.Hit();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}