using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGPacManComponents.Food
{

    // A delegate type for hooking up change notifications.
    
    
    public class SuperFood : Food
    {

        private static int superFoodActivatedCount;

        public static int SuperFoodActivatedCount { get => superFoodActivatedCount; set => superFoodActivatedCount = value; }

        System.Timers.Timer foodTimer = new System.Timers.Timer(5000);

        // An event that clients can use to be notified whenever the
        // elements of the list change.
        public event FoodHitEventHandler FoodHitTimeOut;

        public SuperFood(Game game) : base(game)
        {
            //TODO remove system timer use game loop to time
            // This creates a new timer that will fire every second (1000 milliseconds)
            foodTimer.Elapsed += new System.Timers.ElapsedEventHandler(foodTimer_Elapsed);
            this.state = FoodState.Normal;
        }

        // Invoke the FoodHitHit event;
        public virtual void OnFoodHitTimeOut(EventArgs e)
        {
            if (FoodHitTimeOut != null)
                FoodHitTimeOut(this, e);
        }

        void foodTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.state = FoodState.Normal;
            SuperFood.SuperFoodActivatedCount--;
            //No more powerfoods eaten
            //if (EatenCount == 0)
            //{
                this.OnFoodHitTimeOut(EventArgs.Empty);
            //}
        }

        public override void Initialize()
        {
            base.Initialize();
            this.Scale = 1.0f;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            spriteTexture = this.Game.Content.Load<Texture2D>("20px_1trans");
            this.Origin = new Vector2(this.spriteTexture.Width / 2, this.spriteTexture.Height / 2);
        }

        public override void Hit()
        {
            if (this.State == FoodState.Normal)
            {
                this.State = FoodState.Activating;
                foodTimer.Start();
            }
        }

        protected override void FoodActivating()
        {
            SuperFoodActivatedCount++;           //Add 1 to static counter
            console.GameConsoleWrite(string.Format("SuperFoodHit: SuperFoodAcvtrivatedCount{0}", SuperFoodActivatedCount));
            this.State = FoodState.Activated;
        }

        protected override void FoodActivated()
        {
            
        }
    }
}
