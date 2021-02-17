using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityCommand
{
    class KeyMapDownMove : KeyMap
    {
        public override void Initalize()
        {
            //Released keys Map May load from text file

            OnKeyDownMap.Add(KeyCode.W, "Move Up");
            OnKeyDownMap.Add(KeyCode.UpArrow, "Move Up");
            OnKeyDownMap.Add(KeyCode.S, "Move Down");
            OnKeyDownMap.Add(KeyCode.DownArrow, "Move Down");
            OnKeyDownMap.Add(KeyCode.A, "Move Left");
            OnKeyDownMap.Add(KeyCode.LeftArrow, "Move Left");
            OnKeyDownMap.Add(KeyCode.D, "Move Right");
            OnKeyDownMap.Add(KeyCode.RightArrow, "Move Right");
            OnKeyDownMap.Add(KeyCode.Z, "Undo");

            base.Initalize();
        }
    }
}
