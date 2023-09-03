using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Pipes class controls the movement and destruction of pipe objects in the game.
public class Pipes : MonoBehaviour
{
    // Public variable to set the speed of pipe movement.
    public float speed;

    // Reference to the Rigidbody2D component.
    private Rigidbody2D rb;

    // Start is called before the first frame update.
    // Used for initialization.
    void Start()
    {
        // Get the Rigidbody2D component attached to this GameObject.
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame.
    // Used for updating object logic.
    void Update()
    {
        // Set the velocity of the Rigidbody2D to move the pipe to the left.
        rb.velocity = Vector2.left * speed;
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only).
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object collided with has the "EndPipe" tag.
        if (collision.gameObject.tag == "EndPipe")
        {
            // Destroy the pipe object.
            Destroy(gameObject);
        }
    }
}
