using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is a very simple boss AI script where the boss attacks the player
//until the boss is defeated
public class BossWeaponController : MonoBehaviour 
{
	public GameObject shot;
	public GameObject rocket;
	public Transform shotSpawn;
	public Transform rightRocketSpawn;
	public Transform leftRocketSpawn;
	public float fireRate;
	public float RocketFireRate;
	public float delay;

	private AudioSource audioSource;

	void Start () 
	{
		audioSource = GetComponent<AudioSource> ();
		InvokeRepeating ("Fire", delay, fireRate);
		InvokeRepeating ("FireRightRocket", delay, RocketFireRate);
		InvokeRepeating ("FireLeftRocket", delay, RocketFireRate);
	}

	void Fire ()
	{
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		audioSource.Play ();
	}

	void FireRightRocket ()
	{
		Instantiate (rocket, rightRocketSpawn.position, rightRocketSpawn.rotation);
		audioSource.Play ();
	}

	void FireLeftRocket ()
	{
		Instantiate (rocket, leftRocketSpawn.position, leftRocketSpawn.rotation);
		audioSource.Play ();
	}
}
