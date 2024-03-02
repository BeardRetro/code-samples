using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectile;
    public Material[] materials;
    public GameObject[] projectiles;

    bool objectFired = false;

    void Update()
    {
        LaunchCannonball();
    }

    //The main method that fires projectiles when the appropriate UI button is pressed
    public void LaunchCannonball()
    {
        if (objectFired == true)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            objectFired = false;
        }
    }

    //Prevents a steady stream of projectiles from being fired in the Update tick
    public void SetObjectFiredBoolToTrue()
    {
        if (objectFired != true)
        {
            objectFired = true;
        }
    }

    //Method is called when the appropriate UI button is pressed
    public void ChangeMaterial(int materialIndex)
    {
        projectile.GetComponent<Renderer>().material = materials[materialIndex];
    }

    //Method is called when the appropriate UI button is pressed
    public void ChangeProjectile(int projectileIndex)
    {
        projectile = projectiles[projectileIndex];
    }
}
