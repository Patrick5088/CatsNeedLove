using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{

    private GameController gameController;
    public float bulletSpeed;
    //private Rigidbody2D bulletBody;
    private Transform playerTransform;
    private Transform selfTransform;
    private Vector3 playerPosition;
    private Vector3 direction;


 
    // Use this for initialization
    void Start()
    {
        //bulletBody = GetComponent<Rigidbody2D>();
  
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
      
        playerPosition = playerTransform.position;
        selfTransform = GetComponent<Transform>();
        direction = (playerPosition - selfTransform.position).normalized;

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

    }
    // Update is called once per frame
    void Update()
    {
        selfTransform.position += direction * bulletSpeed * Time.deltaTime;
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if(transform.position.x<min.x||transform.position.x>max.x||transform.position.y<min.y||transform.position.y>max.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameController.GameOver();

        }
    }
}