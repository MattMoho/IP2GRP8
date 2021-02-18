using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject ShotType;
    public float shootDelay;
    public float destroyAfter;
    public KeyCode shoot = KeyCode.E;
    public bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
    void Update()
    {
       
        bool shootPressed = Input.GetKey(shoot);
        if (shootPressed && canShoot)
        {
            StartCoroutine(shootStart());
            StartCoroutine(shootCooldown());
        }
    }
    IEnumerator shootStart()
    {
        Vector3 shootposition = transform.localPosition;
        GameObject shoted = Instantiate(ShotType, transform.position, transform.rotation);
        yield return new WaitForSeconds(destroyAfter);
        Destroy(shoted);
    }
    IEnumerator shootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
}
