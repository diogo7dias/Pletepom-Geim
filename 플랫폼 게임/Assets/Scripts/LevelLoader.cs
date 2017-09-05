using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour 
{
	public string levelToLoad;

	private bool playerInZone;

	void Start () 
	{
		playerInZone = false;
	}
	
	void Update () 
	{
		if(Input.GetAxisRaw("Vertical") > 0 && playerInZone)
		{
			SceneManager.LoadScene (levelToLoad);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		playerInZone = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		playerInZone = false;
	}
}
