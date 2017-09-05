using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyOnContact : MonoBehaviour
{
	public int damageToGive;
	public float bounceOnEnemy;

	private Rigidbody2D myRigidBody2D;

	void Start () 
	{
		//GET RIGIDBODY OF PARENT
		myRigidBody2D = transform.parent.GetComponent<Rigidbody2D>();
	}
	
	void Update () 
	{
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy")
		{
			other.GetComponent<EnemyHealthManager> ().giveDamage (damageToGive);
		
			myRigidBody2D.velocity = new Vector2 (myRigidBody2D.velocity.x, bounceOnEnemy);
		}
	}
}
