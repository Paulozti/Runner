using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    private Text score;
    private GameManager gm;
    private void Start()
    {
        score = GetComponent<Text>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if(gm != null)
            score.text = gm.GetScore().ToString();
    }
}
