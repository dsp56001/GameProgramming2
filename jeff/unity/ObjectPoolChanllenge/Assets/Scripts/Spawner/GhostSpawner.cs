using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Spawner
{
    public class GhostSpawner : PooledSpawner
    {

        public GameObject PacMan;

        public override void SetupSpawnObject(GameObject go)
        {
            base.SetupSpawnObject(go);
            if (go.GetComponent<GhostSprite>() != null)
            {
                GhostSprite gs = go.GetComponent<GhostSprite>();
                gs.Speed = 5;
                gs.PacMan = PacMan;
                gs.gameObject.transform.position = this.transform.position;
                gs.SetupGhost();

            }
        }

        void Update()
        {
            base.removeObjectInListToRemove();
            addDeadGhostsToRemoveList();
        }

        protected void addDeadGhostsToRemoveList()
        {
            GhostSprite gs;
            foreach (GameObject go in this.gameObjects)
            {
                gs = go.GetComponent<GhostSprite>();
                if (go.GetComponent<GhostSprite>() != null)
                {
                    if (gs.State == GhostState.Dead)
                    {
                        //remove dead ghosts
                        this.objectsToRemove.Add(gs.gameObject);

                    }
                }
            }
        }
    }
}
