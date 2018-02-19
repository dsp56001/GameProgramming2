using UnityEngine;
using System.Collections;


namespace Assets.Scripts.Spawner
{
    public class ContinuousTimedGhostSpawner : TimedGhostSpawner
    {
        
        void Update()
        {
            base.addDeadGhostsToRemoveList();
            base.removeObjectInListToRemove();

            lastSpawnTime += Time.deltaTime;
            if (lastSpawnTime > SpawnTime)
            {
                //Keep spawning on timer
                lastSpawnTime = 0.0f;
                this.Spawn();
            }

        }

    }
}
