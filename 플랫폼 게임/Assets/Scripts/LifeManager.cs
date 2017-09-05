using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour 
{
	//public int startingLives;
	public GameObject gameOverScreen;
	public PlayerController player;
	public string mainMenu;
	public float waitAfterGameOver;

	private int lifeCounter;
	private Text theText;


	void Start () 
	{
		theText = GetComponent<Text> ();
		lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives");
		player = FindObjectOfType<PlayerController> ();
	}
	
	void Update () 
	{
		if(lifeCounter <= 0)
		{
			gameOverScreen.SetActive (true);
			player.gameObject.SetActive (false);

		}
		theText.text = "x" + lifeCounter;

		if(gameOverScreen.activeSelf)
		{
			waitAfterGameOver -= Time.deltaTime;
		}

		if(waitAfterGameOver < 0)
		{
			SceneManager.LoadScene (mainMenu);
		}
	}

	public void GiveLife()
	{
		lifeCounter++;
		PlayerPrefs.SetInt ("PlayerCurrentLives", lifeCounter);
	}

	public void TakeLife()
	{
		lifeCounter--;
		PlayerPrefs.SetInt ("PlayerCurrentLives", lifeCounter);
	}
}
