using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public float fireRate;
    private float nextFire;
    public GameObject obj;
	// Use this for initialization
	void Start () {
        
	}
	
    void Shooter()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(obj, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }
	// Update is called once per frame
	void Update () {

        
        Invoke("Shooter", 3f);
    }
}
