using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//This script is a spell which slows down enemies when they encounter it
public class DivineIntervention : MonoBehaviour 
{

    float enemySpeed;
    public float spellTimeInSeconds = 4.0f;
    public float enemySlowdownAmount = 0.5f;

    void DestroySpell()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(SlowDownEnemy(other.gameObject));

            Invoke("DestroySpell", spellTimeInSeconds);
        }
    }

    IEnumerator SlowDownEnemy(GameObject other)
    {
        float secondsToFreeze = spellTimeInSeconds;

        //get enemy speed before slow down effects it
        enemySpeed = other.GetComponent<Enemy>().speed;

        other.GetComponent<Enemy>().speed *= enemySlowdownAmount;

        yield return new WaitForSeconds(secondsToFreeze - 0.25f);

        //set enemy speed back to normal
        other.GetComponent<Enemy>().speed = enemySpeed;

    }
}
