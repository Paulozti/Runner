using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Transform upPosition;
    [SerializeField] private Transform downPosition;

    public List<GameObject> upObstacles;
    public List<GameObject> downObstacles;

    private bool canSpawn = true;

    private int obstacleCount;

    
    void Update()
    {
        if (canSpawn)
        {
            SpawnObject();
            StartCoroutine(SpawnObjectDelay());
        }
    }

    IEnumerator SpawnObjectDelay()
    {
        canSpawn = false;
        yield return new WaitForSeconds(GameManager.obstacleSpawnDelay);
        canSpawn = true;
    }

    private void SpawnObject()
    {
        int upOrDown = Random.Range(0, 2);
        if(upOrDown == 0)
        {
            obstacleCount = upObstacles.Count;
            int obstacle = Random.Range(0, obstacleCount);
            Instantiate(upObstacles[obstacle], upPosition.position, Quaternion.identity);
        }
        else
        {
            obstacleCount = downObstacles.Count;
            int obstacle = Random.Range(0, obstacleCount);
            Instantiate(downObstacles[obstacle], downPosition.position, Quaternion.identity);
        }
    }
}
