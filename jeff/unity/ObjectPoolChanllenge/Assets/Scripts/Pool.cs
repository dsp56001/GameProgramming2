using UnityEngine;
using System.Collections;

public class Pool : MonoBehaviour {

    public GameObject GhostPrefab;

    public int IntialPoolSize = 1;
    public int MaxPoolSize = 5;


    // Use this for initialization
    void Start () {
        CreateObjectPools();
	}

    private void CreateObjectPools()
    {
        ObjectPoolingManager.Instance.CreatePool(GhostPrefab, this.IntialPoolSize, 5, false);
        ObjectPoolingManager.Instance.PoolGameObject = this.gameObject;
     }

    // Update is called once per frame
    void Update () {
	
	}
}
