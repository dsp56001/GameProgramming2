using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.PacMan
{
    internal class PoolAbleGhostSprite : GhostSprite
    {
        private IObjectPool<PoolAbleGhostSprite> m_pool;
        public void SetPool(IObjectPool<PoolAbleGhostSprite> pool)
        {
            m_pool = pool;
        }

       
        private void OnBecameInvisible()
        {
            m_pool?.Release(this);
        }
    }
}
