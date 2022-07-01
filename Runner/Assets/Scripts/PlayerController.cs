using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [Header("Physics")]
    public float jumpForce;
    public float gravityModifier;
    private Rigidbody rigid;

    [Header("Jump State")]
    public JumpState jumpState;

    public bool gameOver = false;
    
    private Animator playerAnim;

    [Header("Particles")]
    public ParticleSystem particleExplosion;
    public ParticleSystem particleFeet;

    [Header("Sound fx")]
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource audioSource;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpState == JumpState.grounded && !gameOver)
        {
            rigid.velocity = Vector3.zero;
            playerAnim.SetTrigger("Jump_trig");
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            audioSource.PlayOneShot(jumpSound, .6f);
            jumpState = JumpState.jumping;
            particleFeet.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            jumpState = JumpState.grounded;
            particleFeet.Play();
        }

        if(collision.gameObject.tag == "Obstacle")
        {
            gameOver = true;
            particleExplosion.Play();
            audioSource.PlayOneShot(crashSound, .6f);
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            particleFeet.Stop();

            GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = .1f;
        }
    }

    public enum JumpState
    {
        jumping,
        grounded
    }
}
