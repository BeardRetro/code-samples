using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Calls the appropriate methods when the player picks up a rapid fire pickup
public class RapidFirePickup : MonoBehaviour 
{
	public AudioSource pickupAudio;
	PlayerShooting playerShooting;

	void Start () 
	{
		playerShooting = FindObjectOfType<PlayerShooting> ();
		pickupAudio = GameObject.Find ("Pickup Audio").GetComponent<AudioSource> ();
	}

    //Update is simply rotating the object for aesthetic purposes
    void Update () 
	{
		gameObject.transform.Rotate (new Vector3(0.0f, 1.0f, 0.0f));
	}

	void OnTriggerEnter (Collider other)
	{

		if (other.CompareTag ("Player") && playerShooting.rapidFire == false)
		{
			playerShooting.Pickups ();
			pickupAudio.Play ();
			Destroy (gameObject);
		}
	}
}
