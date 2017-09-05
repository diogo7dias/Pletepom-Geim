using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	public float jumpHeight;
	public float groundCheckRadius;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public Transform firePoint;
	public GameObject ninjaStar;
	public float shotDelay;
	public float knockback;
	public float knockbackLenght;
	public float knockbackCount;
	public bool knockFromRight;

	private float moveVelocity;
	private bool grounded;
	private bool doubleJumped;
	private Animator anim;
	private float shotDelayCounter;

	void Start () 
	{
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}

	void Update ()
	{
		if (grounded)
			doubleJumped = false;

		//ANIMATION
		anim.SetBool ("Grounded", grounded);

		//INPUT
		if(Input.GetButtonDown("Jump") && grounded)
		{
			Jump ();
		}

		if(Input.GetButtonDown("Jump") && !doubleJumped && !grounded)
		{
			Jump ();
			doubleJumped = true;
		}	

		//moveVelocity = 0f;

		//INPUT
		moveVelocity = moveSpeed * Input.GetAxisRaw ("Horizontal");

		if (knockbackCount <= 0)
		{
			//MOVEMENT CODE
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);
		}
		else
		{
			if (knockFromRight)
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-knockback, knockback);
			if(!knockFromRight)
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (knockback, knockback);

			knockbackCount -= Time.deltaTime;
		}

		//ANIMATION
		anim.SetFloat("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

		//FLIP PLAYER ACCORDING TO VELOCITY
		if (GetComponent<Rigidbody2D> ().velocity.x > 0)
			transform.localScale = new Vector3 (1f, 1f, 1f);
		else if(GetComponent<Rigidbody2D> ().velocity.x < 0)
			transform.localScale = new Vector3 (-1f, 1f, 1f);

		if(Input.GetButtonDown("Fire1"))
		{
			Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
			shotDelayCounter = shotDelay;
		}

		if(Input.GetButton("Fire1"))
		{
			shotDelayCounter -= Time.deltaTime;

			if (shotDelayCounter <= 0)
			{
				shotDelayCounter = shotDelay;
				Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
			}
		}

		//SWORD ATTACK
		if (anim.GetBool ("Sword"))
		{
			anim.SetBool ("Sword", false);

		}

		if(Input.GetButtonDown("Fire2"))
		{
			anim.SetBool ("Sword", true);
		}
	}

	public void Jump()
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2 ( GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		//GetComponent<Rigidbody2D> ().velocity = Vector2.up * jumpHeight;//TO USE WITH BETTER JUMP SCRIPT
	}
}
