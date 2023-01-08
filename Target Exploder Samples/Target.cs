using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public float movementDistance = 1.0f;
    public float movementSpeedMin = 0.5f;
    public float movementSpeedMax = 2.0f;
    public float movementDistanceMin = 0.5f;
    public float movementDistanceMax = 2.0f;

    public int targetPoints = 1;
    public ParticleSystem targetDestroyedParticles;
    public ScoreManager scoreManager;
    public GameplayPolish polish;

    private Vector3 startPosition;
    private Vector3 newPosition;
    Vector3 movementWave;
    private Animator animator;
    private int patternNumber;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        scoreManager = GameObject.Find("Game Manager").GetComponent<ScoreManager>();
        polish = GameObject.Find("Game Manager").GetComponent<GameplayPolish>();
        animator = GetComponent<Animator>();

        // Randomization code for Target's speed and magnitude
        movementSpeed = Random.Range(movementSpeedMin, movementSpeedMax);
        movementDistance = Random.Range(movementDistanceMin, movementDistanceMax);

        patternNumber = RandomizeTargetPattern();
    }

    // Update is called once per frame
    void Update()
    {
        float ySin = Mathf.Sin(Time.time * movementSpeed) * movementDistance;
        float xCos = Mathf.Cos(Time.time * movementSpeed) * movementDistance;

        //Debug.Log("Sin = " + ySin);
        //Debug.Log("Cos = " + xCos);

        switch (patternNumber)
        {
            case 0:
                // Vertical Pattern

                //Debug.Log("Pattern 0 selected");
                newPosition = new Vector3(0.0f, ySin, transform.position.z);
                movementWave = Vector3.zero;
                break;            
            case 1:
                // Horizontal Pattern

                //Debug.Log("Pattern 1 selected");
                newPosition = new Vector3(xCos, 0.0f, transform.position.z);
                movementWave = Vector3.zero;
                break;

            case 2:
                // Circle Pattern

                //Debug.Log("Pattern 2 selected");
                newPosition = new Vector3(xCos, ySin, transform.position.z);
                movementWave = Vector3.zero;
                break;

            default:
                break;
        }

        transform.position = newPosition + startPosition + movementWave;
    }

    // This destroys both the projectile and the target. An animator event instantiates
    // Target particle effects. After the object is destroyed, the score is increased.
    void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("TargetDestroyed", true);

        Destroy(gameObject, 0.5f);

        if (collision.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
        }

        scoreManager.IncreaseScore(targetPoints);
    }

    // This method exists for the sake of an animation event only being able to call functions with 0 or 1 parameters
    public void InstantiateParticles()
    {
        Instantiate(targetDestroyedParticles, transform.position, transform.rotation);
    }

    // This is purely for returning a random number for the switch statement in Update
    int RandomizeTargetPattern()
    {
        int x = Random.Range(0, 3);

        return x;

    }

}
