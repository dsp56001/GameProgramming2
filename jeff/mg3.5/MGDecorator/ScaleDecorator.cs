using MGDecorator.Decorator;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGDecorator
{

    

    class ScaleDecorator : SpriteDecorator
    {

        
        protected Sprite sprite;

        protected float scaleMultiplier, originalScale;

        public ScaleDecorator(Game game, Sprite sprite, float scale) : base(game)
        {
            this.sprite = sprite;
            this.scaleMultiplier = scale;
        }

        

        protected override void LoadContent()
        {
            
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            this.originalScale = this.sprite.Scale;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this.sprite.Scale *= this.scaleMultiplier;
            base.Draw(gameTime);
            this.sprite.Scale = this.originalScale;
        }

        
    }
}
