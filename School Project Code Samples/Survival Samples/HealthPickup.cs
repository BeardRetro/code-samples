using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour 
{
	public PlayerHealth player;
	public AudioSource pickupAudio;

	void Start () 
	{
		player = FindObjectOfType<PlayerHealth> ();
		pickupAudio = GameObject.Find ("Pickup Audio").GetComponent<AudioSource> ();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Player"))
		{
			player.currentHealth += 25;

			if (player.currentHealth > 100)
			{
				player.currentHealth = 100;
			}
			player.healthSlider.value = player.currentHealth;
			pickupAudio.Play ();

			Destroy (gameObject);
		}
	}
}
