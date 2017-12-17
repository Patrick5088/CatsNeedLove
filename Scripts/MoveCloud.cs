using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour {

    
    void Update()
    {
        transform.position = new Vector2(transform.position.x, Mathf.PingPong(Time.time, 3)-1);
    }
}

