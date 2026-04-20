using System.Collections.Generic;
using UnityEngine;

public class ObstacleObjectPool : MonoBehaviour
{
    public GameObject obstacleBarrelPrefab;
    public GameObject obstacleBarrierPrefab;
    public GameObject obstacleStoneWallPrefab;
    public int poolSize = 10;

    private List<GameObject> obstacleBarrelPool = new List<GameObject>();
    private List<GameObject> obstacleBarrierPool = new List<GameObject>();
    private List<GameObject> obstacleStoneWallPool = new List<GameObject>();

    void Awake()
    {
        PreparePool(obstacleBarrelPool, obstacleBarrelPrefab);
        PreparePool(obstacleBarrierPool, obstacleBarrierPrefab);
        PreparePool(obstacleStoneWallPool, obstacleStoneWallPrefab);
    }

    private void PreparePool(List<GameObject> pool, GameObject prefab)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject Acquire(int obstacleType)
    {
        List<GameObject> targetPool = GetPoolByType(obstacleType);
        GameObject prefab = GetPrefabByType(obstacleType);

        foreach (GameObject obj in targetPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(prefab);
        targetPool.Add(newObj);
        return newObj;
    }

    public void Release(GameObject obstacle, int obstacleType)
    {
        obstacle.SetActive(false);
    }
    private List<GameObject> GetPoolByType(int type) => type switch
    {
        0 => obstacleBarrelPool,
        1 => obstacleBarrierPool,
        _ => obstacleStoneWallPool
    };

    private GameObject GetPrefabByType(int type) => type switch
    {
        0 => obstacleBarrelPrefab,
        1 => obstacleBarrierPrefab,
        _ => obstacleStoneWallPrefab
    };
}

