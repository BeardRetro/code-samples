using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform[] shotSpawns;
	public float fireRate;
    public bool rapidFire = false;
    private float nextFire;

    //Handles shooting projectiles with a certain delay between shots
	void Update ()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			if (rapidFire == false)
			{
				nextFire = Time.time + fireRate;
				foreach (var shotSpawn in shotSpawns)
				{
					Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				}

				GetComponent<AudioSource> ().Play();
			}

			if (rapidFire == true)
			{
				nextFire = Time.time + (fireRate * 0.5f);
				foreach (var shotSpawn in shotSpawns)
				{
					Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				}

				GetComponent<AudioSource> ().Play();
			}
		}
	}

	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		gameObject.GetComponent<Rigidbody> ().velocity = movement * speed;

		gameObject.GetComponent<Rigidbody> ().position = new Vector3 
			(
				Mathf.Clamp(gameObject.GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp(gameObject.GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
			);

		gameObject.GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, gameObject.GetComponent<Rigidbody>().velocity.x * -tilt);
	}

	public void ActivatePickups ()
	{
		StartCoroutine (ActivateRapidFire (10));
	}

	IEnumerator ActivateRapidFire(float time)
	{
		float currentTime = 0.0f;

		do
		{
			rapidFire = true;
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= time);

		rapidFire = false;
	}
}
