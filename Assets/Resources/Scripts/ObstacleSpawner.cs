using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private Transform upPosition;
    private Transform downPosition;

    private Object upObstacles;
    private Object downObstacles;

    private bool canSpawn = true;

    private void Start()
    {
        upPosition = GameObject.Find("Up").GetComponent<Transform>();
        downPosition = GameObject.Find("Down").GetComponent<Transform>();
    }

    void Update()
    {
        if (canSpawn && GameManager.isPlaying)
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
           Instantiate(Resources.Load("Obstacle_meteor"), upPosition.position, Quaternion.identity);
        }
        else
        {
           Instantiate(Resources.Load("Obstacle_fireHole"), downPosition.position, Quaternion.identity);
        }
    }
}
