using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatsBreath : MonoBehaviour
{
    public KeyCode ShootKey = KeyCode.Mouse0;
    public ParticleSystem test;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        bool isShootPressed = Input.GetKey(ShootKey);

        if (isShootPressed)
        {
            test.enableEmission = true;
        }
        else if(!isShootPressed)
        {
            test.enableEmission = false;
        }

    }
}
