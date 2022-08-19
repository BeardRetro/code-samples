using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickup : MonoBehaviour {

	public AudioSource pickupAudio;

	void Start () 
	{
		pickupAudio = GameObject.Find ("Pickup Audio").GetComponent<AudioSource> ();
	}

    //Update is simply rotating the object for aesthetic purposes
    void Update () 
	{
		gameObject.transform.Rotate (new Vector3(0.0f, 0.5f, 0.0f));
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag("Player"))
		{
			GemManager.gems += 1;
			Destroy (gameObject);
			pickupAudio.Play ();
		}
	}
}
