using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public static Vector3 ReachedCheckpoint = new Vector3(0, 1.31f, 0);
    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           // if(transform.position.x> ReachedCheckpoint.x)
                ReachedCheckpoint = transform.position;

        }
           
    }
}