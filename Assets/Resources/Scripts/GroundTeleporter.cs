using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTeleporter : MonoBehaviour
{
    [SerializeField] Transform positionToTeleport;
    private Vector3 position;
    private void Start()
    {
        position = positionToTeleport.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.position = position;
    }
}
