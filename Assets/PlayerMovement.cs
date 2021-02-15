using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode jumpKey = KeyCode.W;
    public float speed = 0.0f;
    float direction = 0.0f;
    float directiony = 0.00f;
    public bool isGrounded;
    float startXpos;
    float startYpos;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = transform.localPosition;
        startXpos = position.x;
        //print("Starting X: " + startXpos);
        startYpos = position.y;
        //print("Starting Y: " + startYpos);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool isLeftPressed = Input.GetKey(moveLeftKey);
        bool isRightPressed = Input.GetKey(moveRightKey);
        bool isJumpPressed = Input.GetKey(jumpKey);

        Vector3 position = transform.localPosition;
        position.x += speed * direction;
        position.y += speed * directiony;
        transform.localPosition = position;

        if (isLeftPressed)
        {
            direction = -1.0f;
        }
        else if (isRightPressed)
        {
            direction = 1.0f;
        }
        else
        {
            direction = 0.0f;
        }
        if (isJumpPressed && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 3f), ForceMode2D.Impulse);
        }
    }
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag == "Ground")
            {
                isGrounded = true;
            }
            if (collision.collider.tag == "Enemy")
             {
            movePlayerToStart();
               }

        }

    public void movePlayerToStart()
    {
        Vector3 backPosition = transform.localPosition;
        backPosition.x = startXpos;
        backPosition.y = startYpos;
        transform.localPosition = backPosition;
    }

    void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.collider.tag == "Ground")
            {
                isGrounded = false;
            }

        }
    
}
