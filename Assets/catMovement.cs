using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catMovement : MonoBehaviour
{

    public KeyCode moveRightKey = KeyCode.L;
    public KeyCode moveLeftKey = KeyCode.J;
    public KeyCode jumpKey = KeyCode.I;
    public float speed = 0.2f;
    float direction = 0.0f;
    float directiony = 0.0f;
    public bool isGrounded;
    public GameObject player;
    public bool playerpos;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
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
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 1f), ForceMode2D.Impulse);
        }
        if (playerpos == true)
        {
            position.x = player.transform.position.x;
            position.y = player.transform.position.y;
        }
    }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag == "Ground")
            {
                isGrounded = true;
            }
            if (collision.collider.tag == "Player")
            {
                isGrounded = true;
                playerpos = true;
            }
        }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
        if (collision.collider.tag == "Player")
        {
            isGrounded = false;
            playerpos = false;
        }


    }

}
