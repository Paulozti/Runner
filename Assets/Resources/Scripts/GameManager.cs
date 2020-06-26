using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float _speed = 1;
    public float _upRangeDelay = 1;
    public float _downRangeDelay = 1;
    [Header("Difficult Level")]
    public float _DifficultSpeed = 5f;

    public static float speed;
    public static float obstacleSpawnDelay;
    public static bool isPlaying = true;

    //GameOver
    public static bool callGameOver = false;
    public GameObject gameOverGroup;
    private int score = 0; 

    private bool changeSpawnDelay = true;
    private void Awake()
    {
        score = 0;
        callGameOver = false;
        gameOverGroup.SetActive(false);        
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
        if (callGameOver)
            GameOver();
        if (isPlaying)
            score += 1;
        
            
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

        _speed += 0.5f;
        
        obstacleSpawnDelay = Random.Range(_downRangeDelay, _upRangeDelay);
        changeSpawnDelay = true;
    }

    public void GameOver(){        
        gameOverGroup.SetActive(true);
    }

    public void RestartGame(){
        gameOverGroup.SetActive(false);
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(1);
    }

    public int GetScore(){
        return this.score;
    }
}
