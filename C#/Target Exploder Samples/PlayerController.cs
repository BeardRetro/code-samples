using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int jumpSpeed = 5;
    public float shotDelayTime = 0.5f;
    public Projectile projectile;
    public AudioClip projectileSound;

    bool jumpPressed = false;
    bool canShoot = true;
    Rigidbody2D playerRigidBody;
    Animator playerAnimator;
    AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    //Allows the player to jump and shoot with the specified controls
    void Update()
    {
        jumpPressed = Input.GetKey(KeyCode.Space);

        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot == true)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            playerAudio.PlayOneShot(projectileSound);
            canShoot = false;
            StartCoroutine(DelayShot(shotDelayTime));
        }

    }

    //FixedUpdate is being used to make sure that jumping happens as smoothly as possible
    void FixedUpdate()
    {
        if (jumpPressed == true)
        {
            playerRigidBody.velocity = new Vector2(0, jumpSpeed);
            playerAnimator.SetBool("Jumping", true);
        }
    }

    //A simple coroutine which keeps the player from spamming bullets
    IEnumerator DelayShot(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        canShoot = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerAnimator.SetBool("Jumping", false);
        }
    }

}
