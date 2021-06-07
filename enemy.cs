using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	public enemySpawn spawn;

	public float speed = 0;
	Vector3 move;

	// Use this for initialization
	void Start () {
		move = this.transform.position;
		spawn = FindObjectOfType<enemySpawn>();
	}
	
	// Update is called once per frame
	void Update () {
		move.x -= speed;
		this.transform.position = move;

	}

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("box"))
        {
			Destroy(gameObject);
        }

		if (col.CompareTag("Player"))
		{
			Time.timeScale = 0;
			speed = 0;
		}
    }
}
