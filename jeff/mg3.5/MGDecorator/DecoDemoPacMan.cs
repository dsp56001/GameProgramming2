using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGDecorator
{
    class DecoDemoPacMan :  DecoMonogamePacMan
    {

        ScaleDecorator scaleDeco;
        SineScaleDecorator sineDeco;
        DropShadowDecorator smallDrop;
        DropShadowDecorator bigDrop;

        public DecoDemoPacMan(Game game) : base(game)
        {
            scaleDeco = new ScaleDecorator(game, this, 2);
            sineDeco = new SineScaleDecorator(game, this, 2);
            smallDrop = new DropShadowDecorator(game, this, new Vector2(1, 1));
            bigDrop = new DropShadowDecorator(game, this, new Vector2(-3, 3));
        }

        public override void Update(GameTime gameTime)
        {
            //A key
            if(controller.Input.HasReleasedKey(Microsoft.Xna.Framework.Input.Keys.A))
            {
                if(this.HasDecorator(scaleDeco)) { this.RemoveDecorator(scaleDeco); }
                else { this.AddDecorator(scaleDeco); }

            }
            base.Update(gameTime);

        }
    }
}
