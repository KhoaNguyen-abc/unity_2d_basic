using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public float upPow = 0;
	private bool grounded = false;
	private bool doubleJump = false;

	private Animator anim;
	private Rigidbody2D r2d;

	UIManager uimanager;
	enemySpawn enemy;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		r2d = gameObject.GetComponent<Rigidbody2D>();
		uimanager = FindObjectOfType<UIManager>();
		enemy = FindObjectOfType<enemySpawn>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		anim.SetBool("grounded", grounded);

        if (Input.GetKeyUp(KeyCode.X))
        {
            if (grounded)
            {
				grounded = false;
				doubleJump = true;
				r2d.AddForce(Vector2.up * upPow);
			}
            else
            {
				if (doubleJump)
				{
					doubleJump = false;
					r2d.velocity = new Vector2(0, 2.29f);
					r2d.AddForce(Vector2.up * upPow * 0.7f);
				}

			}
		}
	}


	void OnCollisionEnter2D(Collision2D col)
    {
		grounded = true;
    }

	void OnCollisionStay2D(Collision2D col)
	{
		grounded = true;
	}

	void OnCollisionExit2D(Collision2D col)
	{
		grounded = false;
	}

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("enemy"))
        {
			Time.timeScale = 0;
			gameObject.GetComponent<Animation>().Play("die");
			uimanager.showOverPanel(true);
        }
    }
}
