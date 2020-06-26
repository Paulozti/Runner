using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderCheck : MonoBehaviour
{   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.transform.parent.gameObject.GetComponent<Player>().isDead = true;
    }
}
