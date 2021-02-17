using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityCommand
{
    class KeyMapReleaseMove : KeyMap
    {
        public override void Initalize()
        {
            //Released keys Map May load from text file
            OnReleasedKeyMap.Add(KeyCode.W, "Move Up");
            OnReleasedKeyMap.Add(KeyCode.UpArrow, "Move Up");
            OnReleasedKeyMap.Add(KeyCode.S, "Move Down");
            OnReleasedKeyMap.Add(KeyCode.DownArrow, "Move Down");
            OnReleasedKeyMap.Add(KeyCode.A, "Move Left");
            OnReleasedKeyMap.Add(KeyCode.LeftArrow, "Move Left");
            OnReleasedKeyMap.Add(KeyCode.D, "Move Right");
            OnReleasedKeyMap.Add(KeyCode.RightArrow, "Move Right");
            OnReleasedKeyMap.Add(KeyCode.Z, "Undo");

            base.Initalize();
        }
    }
}
