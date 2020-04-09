using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JSONOjbectMap
{
    
    public class GhostManager 
    {

        JSONFileParser<JSONDTOMap> jsonGhostParser;
        XMLFileParser<XMLDTOMap> xmlGhostParser;
        public List<GhostSprite> Ghosts;
        //List<MonogameGhost> ghostsToRemove;
        JSONDTOMap JSONmap;
        XMLDTOMap XMLmap;

        public GameObject PacMan;
        
       
        public enum GhostManagerState {  Start, StartAuto, Loading, Loaded, Setup, SetupFinished, Editing, Save, Saving, Saved };
        public delegate void GhostManagerStateChangedHandler(object sender,
                        GhostManagerStateEventArgs ghostState);
        public event GhostManagerStateChangedHandler StateChanged;

        GhostManagerState _state;
        public GhostManagerState State
        {
            get { return _state; }
            set
            {
                if(this._state != value)
                {
                    StateChanged.Invoke(this, new GhostManagerStateEventArgs() { NewState = value, OldState = this._state });
                    this._state = value;
                    
                }
            }
        }

        public GhostManager(GameObject PacMan)
        {
            this.PacMan = PacMan;            this.Ghosts = new List<GhostSprite>();
            
            this.State = GhostManagerState.Start;
            this.StateChanged += GhostManager_StateChanged;

            jsonGhostParser = new JSONFileParser<JSONDTOMap>();
            xmlGhostParser = new XMLFileParser<XMLDTOMap>();
            
        }

        private void GhostManager_StateChanged(object sender, GhostManagerStateEventArgs e)
        {
            UnityEngine.Debug.Log($"GhostManager_StateChanged:{e.OldState}->{e.NewState}");
        }

        public  void Initialize()
        {
            if (this.State == GhostManagerState.Loading)
            {
                LoadGhostsFromJSON();
                LoadGhostsFromXML();
                SetupGhostsJSON();
                SetupGhostsXML();
            }  
        }

        public void Update()
        {
            switch(this.State)
            {
                case GhostManagerState.Start:
                    break;
                case GhostManagerState.StartAuto:
                    this.State = GhostManagerState.Loading;
                    break;
                case GhostManagerState.Loading:
                    LoadGhostsFromJSON();
                    SetupGhostsJSON();
                    LoadGhostsFromXML();
                    SetupGhostsXML();
                    this.State = GhostManagerState.Loaded;
                    break;
                case GhostManagerState.Loaded:
                    //CheckForEdit();
                    //CheckForLoad();
                    //nothing
                    break;
                case GhostManagerState.Setup:
                case GhostManagerState.SetupFinished:
                    //CheckForEdit();
                    break;
                case GhostManagerState.Editing:
                    //CheckForSave();
                    break;
                case GhostManagerState.Save:
                    
                    this.State = GhostManagerState.Saving;
                    break;
                case GhostManagerState.Saving:
                    //Save
                    this.State = GhostManagerState.Saved;
                    break;
                case GhostManagerState.Saved:
                    this.State = GhostManagerState.Editing;
                    break;
            }
            
        }


        private void CheckForLoad()
        {
#if DEBUG
            //if (input.WasKeyPressed(Microsoft.Xna.Framework.Input.Keys.L))
            //{
                this.State = GhostManagerState.Loading;
            //}

        }
#endif

        private void CheckForSave()
        {
#if DEBUG
            //if (input.WasKeyPressed(Microsoft.Xna.Framework.Input.Keys.S))
            //{
                this.State = GhostManagerState.Save;
            //}
#endif
        }

        /// <summary>
        /// Check to change to edit mode
        /// </summary>
        private void CheckForEdit()
        {
#if DEBUG
            //if (input.WasKeyPressed(Microsoft.Xna.Framework.Input.Keys.E))
            //{
                this.State = GhostManagerState.Editing;
            //}
#endif
        }

        protected GameObject getSpawnObject()
        {
            GameObject spawn = ObjectPoolingManager.Instance.GetObject("Ghost");
            if (spawn != null)
                spawn.SetActive(true);
            return spawn;
        }

        public GhostSprite SetupSpawnObject(GameObject go, Sprite s)
        {
            GhostSprite gs = null;
            if (go.GetComponent<GhostSprite>() != null)
            {
                gs = go.GetComponent<GhostSprite>();
                gs.Speed = s.Speed;
                gs.PacMan = PacMan;
                gs.gameObject.transform.position = new Vector2(s.Location.X, s.Location.Y);
            }
            return gs;
        }

        public GhostSprite SetupSpawnObject(GameObject go, XMLDTOMapSprite s)
        {
            GhostSprite gs = null;
            if (go.GetComponent<GhostSprite>() != null)
            {
                gs = go.GetComponent<GhostSprite>();
                gs.Speed = s.Speed;
                gs.PacMan = PacMan;
                gs.gameObject.transform.position = new Vector2(s.Location.X, s.Location.Y);
            }
            return gs;
        }


        private void SetupGhostsJSON()
        {
            if (JSONmap == null) throw new Exception("Map is null exception. Please Load a map.");
            this.State = GhostManagerState.Setup;
            foreach (Sprite s in JSONmap.Sprites )
            {
                UnityEngine.Debug.Log(s.ToString());
                GhostSprite gs = SetupSpawnObject(getSpawnObject(), s);
                this.Ghosts.Add(gs);
            
            }
            
        }

        private void SetupGhostsXML()
        {
            if (XMLmap == null) throw new Exception("Map is null exception. Please Load a map.");
            this.State = GhostManagerState.Setup;
            foreach (XMLDTOMapSprite s in XMLmap.Sprite)
            {
                UnityEngine.Debug.Log(s.ToString());
                GhostSprite gs = SetupSpawnObject(getSpawnObject(), s);
                this.Ghosts.Add(gs);
            }
            
        }

        private void LoadGhostsFromJSON()
        {
            this.State = GhostManagerState.Loading;
            JSONmap = jsonGhostParser.LoadFromJSON("JSONMap.json", "Assets\\Resources");
            
            //Sprite test2 = JsonUtility.FromJson<Sprite>("{\"Location\": {\"X\": \"100\",\"Y\": \"100\"},\"Direction\": {\"X\": \"0\",\"Y\": \"1\"},\"Speed\":  \"20\"}");
            this.State = GhostManagerState.Loaded;
        }

        private void LoadGhostsFromXML()
        {
            this.State = GhostManagerState.Loading;
            XMLmap = xmlGhostParser.LoadFromXML("XMLMap.xml", "Assets\\Resources");
            this.State = GhostManagerState.Loaded;
        }

        
        #region JSON DTO Classes
        [System.Serializable]
        public class JSONDTOMap
        {
            public Sprite[] Sprites;
        }

        [System.Serializable]
        public class Sprite
        {
            public Location Location;
            public Location Direction;
            public int Speed;
        }
        [System.Serializable]
        public class Location
        {
            public float X;
            public float Y;
        }

        public class GhostManagerStateEventArgs : EventArgs
        {
            public GhostManagerState OldState { get; set; }
            public GhostManagerState NewState { get; set; }
        }



        #endregion
        #region DTO XML CLasses


        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class XMLDTOMap
        {

            private XMLDTOMapSprite[] spriteField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Sprite")]
            public XMLDTOMapSprite[] Sprite
            {
                get
                {
                    return this.spriteField;
                }
                set
                {
                    this.spriteField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class XMLDTOMapSprite
        {

            private XMLDTOMapSpriteLocation locationField;

            private XMLDTOMapSpriteDirection directionField;

            private byte speedField;

            /// <remarks/>
            public XMLDTOMapSpriteLocation Location
            {
                get
                {
                    return this.locationField;
                }
                set
                {
                    this.locationField = value;
                }
            }

            /// <remarks/>
            public XMLDTOMapSpriteDirection Direction
            {
                get
                {
                    return this.directionField;
                }
                set
                {
                    this.directionField = value;
                }
            }

            /// <remarks/>
            public byte Speed
            {
                get
                {
                    return this.speedField;
                }
                set
                {
                    this.speedField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class XMLDTOMapSpriteLocation
        {

            private byte xField;

            private short yField;

            /// <remarks/>
            public byte X
            {
                get
                {
                    return this.xField;
                }
                set
                {
                    this.xField = value;
                }
            }

            /// <remarks/>
            public short Y
            {
                get
                {
                    return this.yField;
                }
                set
                {
                    this.yField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class XMLDTOMapSpriteDirection
        {

            private byte xField;

            private byte yField;

            /// <remarks/>
            public byte X
            {
                get
                {
                    return this.xField;
                }
                set
                {
                    this.xField = value;
                }
            }

            /// <remarks/>
            public byte Y
            {
                get
                {
                    return this.yField;
                }
                set
                {
                    this.yField = value;
                }
            }
        }
        #endregion

    }
}