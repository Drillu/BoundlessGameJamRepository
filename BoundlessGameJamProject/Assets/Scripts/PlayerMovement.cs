using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public Camera cam;
    private Vector2 mousePos;

    public Transform firePoint;
   
    public float bulletForce = 10f;

    private LineRenderer lr;
    private Vector2 laserEnd;
    public Transform laserOrigin;
    public bool shootLaser = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (shootLaser == true)
        {
            lr.enabled = true;
            if (Physics2D.Raycast(laserOrigin.position, transform.right))
            {
                RaycastHit2D hit = Physics2D.Raycast(laserOrigin.position, transform.right);
                Draw2DLine(laserOrigin.position, hit.point);
            }
            else
            {
                laserEnd.Set(35f, mousePos.y);
                Draw2DLine(laserOrigin.position, laserEnd);
            }
        }
        else
        {
            lr.enabled = false;
        }
       
        rb.MovePosition(mousePos);
        //gameObject.transform.position = mousePos;

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
    void Draw2DLine(Vector2 origin, Vector2 end)
    {
        lr.SetPosition(0, origin);
        lr.SetPosition(1, end);
    }
}
