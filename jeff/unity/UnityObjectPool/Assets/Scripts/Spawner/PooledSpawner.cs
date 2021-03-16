using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Spawner
{
    public class PooledSpawner : Spawner
    {


        protected override GameObject getSpawnObject()
        {
            GameObject spawn  = ObjectPoolingManager.Instance.GetObject("Ghost");
            if(spawn != null)
                spawn.SetActive(true);
            return spawn;
        }

        protected override void removeObjectInListToRemove()
        {
            //remove objects in Object to remove list
            foreach (GameObject go in this.objectsToRemove)
            {
                this.gameObjects.Remove(go);
                //Give object to pool
                //go.transform.parent = ObjectPoolingManager.Instance.PoolGameObject.transform; 
                go.transform.parent = null;
                go.SetActive(false);
            }
            this.objectsToRemove.Clear();
        }

    }
}
