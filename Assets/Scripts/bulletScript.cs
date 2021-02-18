using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float direction = 1.0f;
    public float speedHoriz = 1.0f;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.transform.rotation.eulerAngles.y == 180.0f)
        {
            direction = -1.0f;
        }

        if (player.transform.rotation.eulerAngles.y == 0.0f)
        {
            direction = 1.0f;
        }
        Vector3 position = transform.localPosition;
        position.x += speedHoriz * direction;
        transform.localPosition = position;
    }

}
