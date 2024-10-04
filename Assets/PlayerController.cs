using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 movementVector;
    private Rigidbody2D rb;

// serializefield allows us to access speed and change it within the game ??? if i heard right
    [SerializeField] int speed = 0;
    private bool canJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        // if (collision.gameObject.CompareTag("Ground"))
        // {
        //     Debug.Log("i am on  the ground.");
        // }
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

        Debug.Log(movementVector);
    }

    void OnJump(InputValue value)
    {
        if(canJump){
            Debug.Log("space");
            rb.AddForce(new Vector2(0, 300));
            canJump = false;
        }
        // if (collision.gameObject.CompareTag("Platforms") || collision.gameObject.CompareTag("Ground"))
        // {
        //     Debug.Log("space");
        //     rb.AddForce(new Vector2(0, 300));
        // }

    }

}
