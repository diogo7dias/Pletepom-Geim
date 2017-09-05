using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlockOnContact : MonoBehaviour
{

	void Start () 
	{
		
	}
	
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Ground")
		{
			Destroy (other.gameObject);
		}
	}
}
