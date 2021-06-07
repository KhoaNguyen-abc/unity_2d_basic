using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public box Box; 

	public Text scoreText;
	public Text highscoreText;

	public GameObject overPanel;

	public int score = 0;
	public int highscore = 0;

	// Use this for initialization
	void Start () {
		scoreText.text = "Score: " + 0;
		highscoreText.text = "High Score: " + 0;
		Box = GameObject.FindGameObjectWithTag("box").GetComponent<box>();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + Box.score;
		if(highscore < Box.score)
        {
			highscore = Box.score;
			highscoreText.text = "High Score: " + highscore;
        }
	}

	public void showOverPanel(bool isTrue)
    {
		overPanel.SetActive(isTrue);
    }

	public void replay()
    {
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
