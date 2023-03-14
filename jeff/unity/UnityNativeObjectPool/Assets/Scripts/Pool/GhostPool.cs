using Assets.Scripts.PacMan;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace DesignPatterns.ObjectPolling
{
    public class GhostPool : MonoBehaviour
    {
        [SerializeField] private PoolAbleGhostSprite m_ghostPrefab;

        private IObjectPool<PoolAbleGhostSprite> m_ghostPool;

        private void Awake()
        {
             m_ghostPool = new ObjectPool<PoolAbleGhostSprite>(CreatePoolableObject, OnGetPooledObject, OnReleasePooledObject, OnDestroyPoolableObject,
                                                  maxSize: 5);
        }


        private PoolAbleGhostSprite CreatePoolableObject()
        {
            PoolAbleGhostSprite ghost = Instantiate(m_ghostPrefab, transform.position, Quaternion.identity);
            ghost.transform.parent = this.gameObject.transform;
            ghost.SetPool(m_ghostPool);
            return ghost;
        }

        private void OnGetPooledObject(PoolAbleGhostSprite ghost)
        {
            ghost.gameObject.SetActive(true);
            ghost.transform.position = transform.position;
            
            ghost.GetComponent<GhostSprite>().SetupGhost();
            
        }

        private void OnReleasePooledObject(PoolAbleGhostSprite ghost)
        {
            ghost.gameObject.SetActive(false);
        }

        private void OnDestroyPoolableObject(PoolAbleGhostSprite bullet)
        {
            Destroy(bullet.gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                 m_ghostPool?.Get();
            }
        }
    }
}

