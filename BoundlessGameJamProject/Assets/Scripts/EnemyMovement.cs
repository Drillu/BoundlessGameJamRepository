using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    EnemyHealth healthScr;

    public int TYPE;

    public float End;
    private bool isEnd;

    private bool isMoving; //if isMoving == true, then Enemy is moving
    private bool isHover;
    private bool isShooting;

    private int kamiCount;

    private bool isBoom;

    public GameObject[] Instances;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isHover = false;

        if(TYPE == 0) //Shooter - shoots bullets
        {
            isMoving = true;
            End = Random.Range(2.5f, 8f);
        }
        else if (TYPE == 1) //Looper - Explodes on impact
        {
            isMoving = true;
            End = Random.Range(-15f, -11f);
        }
        else if (TYPE == 2) //Kamikaze - Moves Speratically for 10 seconds then RUSHES Player
        {

        }
        healthScr = gameObject.GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        if(healthScr.health < 0)
        {
            isMoving = false;
            isShooting = false;
            rb.velocity = Vector3.zero;
            StartCoroutine(Boom());
        }

        if (gameObject.transform.position.x < End)
        {
            isMoving = false;
            
            if (TYPE == 0 && isHover == false)
            {
                isShooting = true;
                StartCoroutine(Hover());
                StartCoroutine(Shoot());
            }

            else if (TYPE == 1 && isMoving == false)
            {
                StartCoroutine(Loop());
            }
        }
    }

    void FixedUpdate()
    {

        if (isMoving == true && (TYPE == 0 || TYPE == 1))
        {
            
            rb.AddForce(Vector2.left / 2f);
        }
    }

    
    private IEnumerator Loop()
    {
        isMoving = true;
        yield return new WaitForSeconds(1f);
        transform.position = new Vector3(13, transform.position.y, transform.position.z);
    }

    private IEnumerator Hover()
    {
        isHover = true;

        if (isShooting != false)
        {
            rb.velocity = Vector3.zero;

            rb.AddForce(Vector2.up * 3f);
            yield return new WaitForSeconds(2f);
            rb.AddForce(Vector2.down * 3f);
            yield return new WaitForSeconds(1f);
            rb.AddForce(Vector2.down * 6f);
            yield return new WaitForSeconds(2f);
            rb.AddForce(Vector2.up * 3f);

            StartCoroutine(Hover());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && TYPE == 1)
        {
            other.gameObject.GetComponent<BaseP>().health -= 25;
            if (isBoom != true)
            {
                StartCoroutine(Boom());
            }
        }
    }

    private IEnumerator Boom()
    {
        isBoom = true;
        Instantiate(Instances[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1.5f);

        Instantiate(Instances[1], gameObject.transform.GetChild(1).transform.position, transform.rotation);
        StartCoroutine(Shoot());
    }
}
