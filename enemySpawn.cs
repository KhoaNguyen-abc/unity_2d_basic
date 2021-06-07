using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour {

	public GameObject enemy_spawn;
	public float time_interval = 0;
	float time_delay = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time_delay += Time.deltaTime;

		if (time_delay > time_interval)
        {
			Instantiate(enemy_spawn, new Vector3(14, -2.591723f, 0), Quaternion.identity);
			time_delay = 0;
		}
	}
}
