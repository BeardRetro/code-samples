using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{

    public GameObject brickParticle;
    public GameObject ballSpeedUpPickup;
    public GameObject ballSlowDownPickup;
    public GameObject paddleSpeedUpPickup;
    public GameObject paddleSlowDownPickup;
    public int hitsToDestroyBrick;
    public int randomNumber;


    void Start()
    {
        hitsToDestroyBrick = 3;
    }

    void Update()
    {
        if (GM.instance.playerOnesTurn == true)
        {
            GM.instance.playerScore.text = "Player 1: " + GM.instance.playerOnesScore;
        }

        if (GM.instance.playerOnesTurn == false)
        {
            GM.instance.playerScore.text = "Player 2: " + GM.instance.playerTwosScore;
        }
    }

    //Handles the "health" of bricks and instantiates particle effects, drops pick-ups,
    //and increases player 1 or 2's score on destruction in the Game Manager.
    void OnCollisionEnter()
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            hitsToDestroyBrick--;

            switch (hitsToDestroyBrick)
            {
                case 4:
                    gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
                    break;

                case 3:
                    gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);
                    break;

                case 2:
                    gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
                    break;

                case 1:
                    gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                    break;

                case 0:
                    Instantiate(brickParticle, transform.position, Quaternion.identity);

                    if (randomNumber <= 1)
                    {
                        Instantiate(ballSpeedUpPickup, transform.position, Quaternion.identity);
                    }
                    else if (randomNumber <= 2)
                    {
                        Instantiate(ballSlowDownPickup, transform.position, Quaternion.identity);
                    }
                    else if (randomNumber <= 3)
                    {
                        Instantiate(paddleSpeedUpPickup, transform.position, Quaternion.identity);
                    }
                    else if (randomNumber <= 4)
                    {
                        Instantiate(paddleSlowDownPickup, transform.position, Quaternion.identity);
                    }

                    GM.instance.DestroyBrick();
                    Destroy(gameObject);

                    if (GM.instance.playerOnesTurn == true)
                    {
                        GM.instance.playerOnesScore++;
                        GM.instance.playerScore.text = "Player 1: " + GM.instance.playerOnesScore;
                    }

                    if (GM.instance.playerOnesTurn == false)
                    {
                        GM.instance.playerTwosScore++;
                        GM.instance.playerScore.text = "Player 2: " + GM.instance.playerTwosScore;
                    }

                    break;

                default:
                    break;
            }
        }
    }
}
