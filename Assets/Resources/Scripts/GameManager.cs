using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float _speed = 1;
    public float _upRangeDelay = 1;
    public float _downRangeDelay = 1;
    [Header("Difficult Level")]
    public float _DifficultSpeed = 5f;

    public static float speed;
    public static float obstacleSpawnDelay;

    private bool changeSpawnDelay = true;
    private void Start()
    {
        obstacleSpawnDelay = _upRangeDelay;
    }
    void Update()
    {
        if(speed != _speed)
        {
            speed = _speed;
        }
        if (changeSpawnDelay)
        {
            StartCoroutine(ChangeSpawnDelay());
        }
    }

    private IEnumerator ChangeSpawnDelay()
    {
        changeSpawnDelay = false;
        yield return new WaitForSeconds(_DifficultSpeed);
        
        if((_upRangeDelay > 2))
        {
            _upRangeDelay -= 0.25f;
            if (_upRangeDelay < 2)
                _upRangeDelay = 2;
        }
        if(_downRangeDelay > 1)
        {
            _downRangeDelay -= 0.25f;
            if (_downRangeDelay < 1)
                _downRangeDelay = 1;
        }
        
        obstacleSpawnDelay = Random.Range(_downRangeDelay, _upRangeDelay);
        changeSpawnDelay = true;
    }
}
