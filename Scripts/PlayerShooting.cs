using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform shootPoint;
    public GameObject bulletFab;
    public GameObject bulletSound;

    public float bulletForce = 20f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
            

        }
    }

    void shoot()
    {
        Instantiate(bulletSound, shootPoint.position, Quaternion.identity);
        GameObject bullet = Instantiate(bulletFab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(shootPoint.up * bulletForce, ForceMode2D.Impulse);


    }
}
