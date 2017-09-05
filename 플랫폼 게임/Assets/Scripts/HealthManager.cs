using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

	public int maxPlayerHealth;
	public static int playerHealth;
	public bool isDead;

	private LevelManager levelManager;
	private LifeManager lifeSystem;

	Text text;

	void Start ()
	{
		text = GetComponent<Text> ();

		//playerHealth = maxPlayerHealth;
		playerHealth = PlayerPrefs.GetInt ("PlayerCurrentHealth");

		levelManager = FindObjectOfType<LevelManager> ();
		lifeSystem = FindObjectOfType<LifeManager> ();
		isDead = false;
	}
	
	void Update ()
	{
		if(playerHealth <= 0 && !isDead)
		{
			playerHealth = 0;
			levelManager.RespawnPlayer ();
			lifeSystem.TakeLife ();
			isDead = true;
		}

		text.text = "" + playerHealth;
	}

	public static void HurtPlayer(int damageToGive)
	{
		playerHealth -= damageToGive;
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
	}

	public void FullHealth()
	{
		playerHealth = PlayerPrefs.GetInt("PlayerMaxHealth");
		PlayerPrefs.SetInt ("PlayerCurrentHealth", playerHealth);
	}
}
