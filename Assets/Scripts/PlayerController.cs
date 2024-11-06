using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    private Vector2 movementVector;
    [SerializeField] Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    [SerializeField] AudioMixerSnapshot loudMusicSnapshot;

// serializefield allows us to access speed and change it within the game ??? if i heard right
    [SerializeField] int walk = 3;
    [SerializeField] int run = 6;

    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource jumpClip;
    private bool canJump = false;
    private int speed; 
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = walk; 
        sr = GetComponent<SpriteRenderer>();
    }

// calls rigidbody of the player and adds force to the body that goes up
// simulates bouncy

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Platforms") || collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
             // code to make bouncy: 
           //  rb.AddForce(new Vector2(0, 300));
        }

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * movementVector.x, rb.velocity.y);
    }

    void OnMove(InputValue value)
    {
        // make new variable of type vector2 and its set to the value u get from pressing the key ?
        movementVector = value.Get<Vector2>();

      
        animator.SetBool("Walk_Right", !Mathf.Approximately(movementVector.x,0));
        if(!Mathf.Approximately(movementVector.x, 0))
        {
            sr.flipX = movementVector.x < 0;
        }

    }

    void OnJump(InputValue value)
    {
        if(canJump)
        {
            rb.AddForce(new Vector2(0, 300));
            SFXSource.Play();
            canJump = false;
        }

    }

    public void StartLoudMusic()
    {
        loudMusicSnapshot.TransitionTo(2.0f);
    }
// need work
    void OnRun(InputValue value)
    {
        if (value.isPressed) 
        {
            speed = run;
        }
        else
        {
            speed = walk;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            score++;
            Debug.Log("My score is:" + score); 
        }
    }

}
