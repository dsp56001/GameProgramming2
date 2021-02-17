using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace UnityCommand
{
    class KeyMap
    {
        //Two dictionaried one for Released one for KeyDown
        public Dictionary<KeyCode, string> OnReleasedKeyMap, OnKeyDownMap;
        public KeyMap()
        {
            OnReleasedKeyMap = new Dictionary<KeyCode, string>();
            OnKeyDownMap = new Dictionary<KeyCode, string>();
            this.Initalize();
        }

        public virtual void Initalize()
        {

        }

    }
}