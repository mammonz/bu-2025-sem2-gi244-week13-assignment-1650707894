using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint;
    public ObstacleObjectPool objectPool;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, 2f);
    }

    void Spawn()
    {
        // 1.18 stop moving left when the game is over
        GameObject player = GameObject.Find("Player");
        if (player != null && player.GetComponent<PlayerController>().gameOver)
        {
            return;
        }

        int randomType = Random.Range(0, 3);
        GameObject obstacle = objectPool.Acquire(randomType);
        if (obstacle != null)
        {
            obstacle.transform.position = spawnPoint.position;
        }
    }
}
