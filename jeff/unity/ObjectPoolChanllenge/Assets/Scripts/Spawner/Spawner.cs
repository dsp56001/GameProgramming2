using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Spawner
{
    public class Spawner : MonoBehaviour, ISpawner
    {

        public bool SpawnerEnabled { get; set; }

        public GameObject SpawnObject;
        public bool Enabled = true;

        protected List<GameObject> gameObjects;
        protected List<GameObject> objectsToRemove;
        // Use this for initialization 
        void Start()
        {
            this.gameObjects = new List<GameObject>();
            this.objectsToRemove = new List<GameObject>();
            this.SpawnerEnabled = true;
        }

        // Update is called once per frame
        void Update()
        {
            removeObjectInListToRemove();
           
            //Test spawn new object with the G key
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (SpawnObject != null)
                {
                    Spawn();
                }
            }

        }

        protected virtual void removeObjectInListToRemove()
        {
            //remove objects in Object to remove list
            foreach (GameObject go in this.objectsToRemove)
            {
                this.gameObjects.Remove(go);
                DestroyObject(go);
            }
            this.objectsToRemove.Clear();
        }

        public void Spawn()
        {
            if (SpawnerEnabled)
            {
                GameObject spawn = this.getSpawnObject();
                if (spawn != null)
                {
                    SetupSpawnObject(spawn); //virtual hook for setting up game object
                    this.AddGameObject(spawn);
                }
            }
        }

        protected virtual GameObject getSpawnObject()
        {
            GameObject spawn = (GameObject)Instantiate(SpawnObject, this.transform.position,
                Quaternion.identity);
            return spawn;
        }

        public virtual void AddGameObject(GameObject spawn)
        {
            gameObjects.Add(spawn);
        }

        public virtual void SetupSpawnObject(GameObject go)
        {
            go.transform.parent = this.gameObject.transform; //make the spawed object a child of the spawner
        }
    }
}
