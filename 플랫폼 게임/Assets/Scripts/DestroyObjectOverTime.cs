﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOverTime : MonoBehaviour
{
	public float lifeTime;

	void Start ()
	{
		
	}
	
	void Update ()
	{
		lifeTime -= Time.deltaTime;

		if (lifeTime < 0)
			Destroy (gameObject);
	}
}
