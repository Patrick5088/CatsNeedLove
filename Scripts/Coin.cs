using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private GameController gameController;
    public int scoreValue;
	// Use this for initialization
	void Start () {
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
	
	
	

    void OnTriggerEnter2D(Collider2D other)
    {
        gameController.AddScore(scoreValue);
        if (other.gameObject.CompareTag("Player"))
            Destroy(gameObject);

    }
}
