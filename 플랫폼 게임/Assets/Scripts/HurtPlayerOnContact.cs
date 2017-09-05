using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour 
{
	public int damageToGive;

	void Start () 
	{
	}
	
	void Update () 
	{
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Player")
		{
			HealthManager.HurtPlayer(damageToGive);
			other.GetComponent<AudioSource> ().Play ();

			//CREATES A TEMP VARIABLE CALLED PLAYER THAT ACCES THE PLAYERCONTROLLER SCRIPT TO THEN BE ABLE TO ACESS VARIABLES IN THAT SCRIPT
			var player = other.GetComponent<PlayerController> ();
			player.knockbackCount = player.knockbackLenght;

			if (other.transform.position.x < transform.position.x)
				player.knockFromRight = true;
			else
				player.knockFromRight = false;


		}
	}
}
