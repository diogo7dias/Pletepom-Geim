﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarController : MonoBehaviour 
{
	public float speed;
	public PlayerController player;
	public GameObject enemyDeathEffect;
	public GameObject impactEffect;
	public int pointsForKill;
	public float rotationSpeed;
	public int damageToGive;

	void Start ()
	{
		player = FindObjectOfType<PlayerController> ();

		if (player.transform.localScale.x < 0)//FACING LEFT
		{
			speed = -speed;
			rotationSpeed = -rotationSpeed;
		}
	}
	
	void Update () 
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);

		GetComponent<Rigidbody2D> ().angularVelocity = rotationSpeed;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy")
		{
			other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
		}

		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
