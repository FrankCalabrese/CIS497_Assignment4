/*Frank Calabrese
 * Assignment 4
 * allows player to jump
 * also controls animations, sound and SFX relevant to player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;

    public Animator playerAnimator;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetFloat("Speed_f", 1.0f);
        playerAudio = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody>();

        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround == true && !gameOver)
        {
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);

            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;

            playerAnimator.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;

            dirtParticle.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            Debug.Log("Game Over");
            gameOver = true;

            playerAudio.PlayOneShot(crashSound, 1.0f);
            dirtParticle.Stop();
            explosionParticle.Play();
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
        }
    }
}
