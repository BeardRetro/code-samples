using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//This is a spell that stops an enemy in their tracks for a certain period of time
public class SeeSeed : MonoBehaviour 
{
	public float spellTimeInSeconds = 4.0f;
    float enemySpeed;

    //Activates the spell when an enemy walks into the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            StartCoroutine(StopEnemy(other.gameObject));

            //Destroys the spell after a certain duration
            Invoke("DestroySpell", spellTimeInSeconds);
        }
    }

    //Gets the speed of the enemy's NavMesh component, sets it to 0, and then restores it to the original speed after a duration
    IEnumerator StopEnemy(GameObject other)
    {
        float secondsToFreeze = spellTimeInSeconds;

        //Set enemy speed to enemy normal speed
        enemySpeed = other.GetComponent<Enemy>().speed;

        //Stop enemy
        other.GetComponent<Enemy>().speed = 0;
        yield return new WaitForSeconds(secondsToFreeze - 0.3f);

        //Reset enemy speed to enemy normal speed
        other.GetComponent<Enemy>().speed = enemySpeed;
        
    }

	private void DestroySpell()
	{
        Destroy(gameObject);
	}
}
