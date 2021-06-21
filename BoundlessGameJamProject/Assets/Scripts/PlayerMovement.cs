using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public Camera cam;
    private Vector2 mousePos;

    public Transform firePoint;
   // public GameObject bulletArray;
    public float bulletForce = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = mousePos;

        if(Input.GetKeyDown(KeyCode.E))
        {
            Teleport();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }

    // Update() for physics
    private void FixedUpdate()
    {
        Rotate();
    }

   
    private void Teleport()
    {
        transform.position = mousePos;
    }

    private void Shoot()
    {
        //GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //Create the bullet
        //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); //Get the rb of that bullet
        //rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); // give the bullet a trajectory and shoot
    }
    private void Rotate()
    {
       // Vector2 lookDir = mousePos - rb.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;
    }
}
