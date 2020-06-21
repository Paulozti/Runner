using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector3(-1, 0) * GameManager.speed * Time.deltaTime);        
    }
}
