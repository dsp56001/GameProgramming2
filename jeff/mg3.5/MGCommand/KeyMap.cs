using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGCommand
{
    class KeyMap
    {
        public Dictionary<Keys, string> OnReleasedKeyMap, OnKeyDownMap;

        public KeyMap()
        {
            OnReleasedKeyMap = new Dictionary<Keys, string>();
            OnKeyDownMap = new Dictionary<Keys, string>();
            this.Initalize();
        }

        public virtual void Initalize()
        {

            //Released keys Map May load from text file
            OnReleasedKeyMap.Add(Keys.W, "Move Up");
            OnReleasedKeyMap.Add(Keys.Up, "Move Up");
            OnReleasedKeyMap.Add(Keys.S, "Move Down");
            OnReleasedKeyMap.Add(Keys.Down, "Move Down");
            OnReleasedKeyMap.Add(Keys.A, "Move Left");
            OnReleasedKeyMap.Add(Keys.Left, "Move Left");
            OnReleasedKeyMap.Add(Keys.D, "Move Right");
            OnReleasedKeyMap.Add(Keys.Right, "Move Right");
            OnReleasedKeyMap.Add(Keys.Z, "Undo");


            //Holding Key map maybe load from testfile
            //onKeyDownMap.Add(Keys.C, "Pac Chomp");

        }

    }
}