using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using MonoGameLibrary.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGPacManComponents.Food
{
    public delegate void FoodHitEventHandler(object sender, EventArgs e);

    public enum FoodState { Normal, Activating, Activated, Eaten }

    public class Food : DrawableSprite
    {
        readonly InputHandler input;
        protected GameConsole console;

        private static int eatenCount;

        protected FoodState state;
        public FoodState State
        {
            protected set { state = value; }
            get { return state; }
        }

        public static int EatenCount { get => eatenCount; set => eatenCount = value; }

        public Food(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
            input = (InputHandler)game.Services.GetService(typeof(IInputHandler));
            if(input == null)
            {
                input = new InputHandler(this.Game);
                this.Game.Components.Add(input);
            }
            console = (GameConsole)game.Services.GetService(typeof(IGameConsole));
            if (console == null)
            {
                console = new GameConsole(this.Game);
                this.Game.Components.Add(input);
            }
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public virtual void Hit()
        {
            if(this.State == FoodState.Normal)
            {
                this.State = FoodState.Activated;
            }
            
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            spriteTexture = this.Game.Content.Load<Texture2D>("food");
            Location = new Vector2(10, 10);

            this.Origin = new Vector2(this.spriteTexture.Width / 2, this.spriteTexture.Height / 2);
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            switch(state)
            {
                case FoodState.Normal:
                    this.Visible = true;
                    this.Enabled = true;
                    break;
                case FoodState.Activating:
                    FoodActivating();
                    break;
                case FoodState.Activated:
                    FoodActivated();
                    break;
                case FoodState.Eaten:
                    this.Visible = false;
                    this.Enabled = false; ;

                    break;
            }
            base.Update(gameTime);
        }

        protected virtual void FoodActivating()
        {
            this.FoodActivated();
        }

        protected virtual void FoodActivated()
        {
            EatenCount++;           //Add 1 to static counter
            console.GameConsoleWrite(string.Format("FoodHit: EatenCount{0}", EatenCount));
            this.State = FoodState.Eaten;
        }
    }
}
