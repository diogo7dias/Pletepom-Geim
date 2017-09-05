using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour 
{
	public GameObject playerObject;
	public GameObject currentCheckpoint;
	public GameObject deathParticle;
	public GameObject respawnParticle;
	public float respawnDelay;
	public int pointPenaltyOnDeath;
	public HealthManager healthManager;

	private PlayerController player;
	private CameraController camera;

	void Start () 
	{
		player = FindObjectOfType<PlayerController> ();
		camera = FindObjectOfType<CameraController> ();
		healthManager = FindObjectOfType<HealthManager> ();
	}
	
	void Update () 
	{
	}

	public void RespawnPlayer()
	{
		StartCoroutine (RespawnPlayerCo());
	}

	public IEnumerator RespawnPlayerCo()
	{
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Renderer> ().enabled = false;
		camera.isFollowing = false;
		//player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		playerObject.SetActive(false);
		ScoreManager.AddPoints (-pointPenaltyOnDeath);

		yield return new WaitForSeconds (respawnDelay);

		playerObject.SetActive (true);
		player.transform.position = currentCheckpoint.transform.position;
		//STOP PLAYER FROM 'JUMPING' FROM RESPAWN BECAUSE O KNOCKBACK
		player.knockbackCount = 0;
		player.enabled = true;
		player.GetComponent<Renderer> ().enabled = true;
		healthManager.FullHealth ();
		healthManager.isDead = false;
		camera.isFollowing = true;
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
	}
}
