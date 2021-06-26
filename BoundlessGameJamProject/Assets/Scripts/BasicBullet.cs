using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BasicBullet : MonoBehaviour
{
    public int speed;
    public float cooldown;
    public int dmg;

    public int timeToDelete;

    public int TYPE;

    public GameObject[] Instances;

    Rigidbody2D rgd;

    BoxCollider2D boxCol;

    GameObject hitEnemy;

    public float Dist;
    Vector3 trans;

    bool isBomb = false;
    bool isLazer = false;

    public Sprite LOGO;
    // Start is called before the first frame update
    void Start()
    {
        trans = transform.position;
        boxCol = gameObject.GetComponent<BoxCollider2D>();
        rgd = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TYPE != 10)
        {
            rgd.velocity = Vector2.right * speed;
        }
        
        Dist += Vector3.Distance(transform.position, trans);
        trans = transform.position;


        timeToDelete--;

        if(TYPE == 11 && isLazer == false)
        {
            StartCoroutine(WMD());
        }


        if (timeToDelete <= 0)
        {
            Destroy(gameObject);
        }

        if(TYPE == 10 && isBomb == false)
        {
            StartCoroutine(newBomb());
        }

        if (TYPE == 4 || TYPE == 7 || TYPE == 8)
        {
            if(Dist > 7f)
            {
                if(isBomb == false && TYPE == 4)
                {
                    StartCoroutine(Bomb());
                }
                else if (isBomb == false && TYPE == 7)
                {
                    StartCoroutine(Cluster());
                }
                else if (isBomb == false && TYPE == 8)
                {
                    StartCoroutine(Multi());
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (boxCol.IsTouching(other) && TYPE != 4)
        {
            if (other.tag == "enemy")
            {
                if (TYPE == 1)//Missile/ICBM/NUKE
                {
                    StartCoroutine(Explode1());
                }
                else if(TYPE == 2)//MachineGun
                {
                    hitEnemy = other.gameObject;
                    StartCoroutine(Hit());
                }
                else if(TYPE == 3)//Force
                {
                    
                }
                else if(TYPE == 4)
                {
                    
                }
                else if(TYPE == 5)
                {
                    hitEnemy = other.gameObject;
                    StartCoroutine(Lazer());
                }
            }
        }
    }

    private IEnumerator Explode1()
    {
        foreach(GameObject Enemy in transform.GetChild(0).GetComponent<Radius>().points)
        {
            Enemy.GetComponent<EnemyHealth>().health -= dmg;
        }
        Instantiate(Instances[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(.01f);
        Destroy(gameObject);
    }

    private IEnumerator Hit()
    {
        hitEnemy.GetComponent<EnemyHealth>().health -= dmg;
        yield return new WaitForSeconds(.01f);
        Destroy(gameObject);
    }

    private IEnumerator Lazer()
    {
        hitEnemy.GetComponent<EnemyHealth>().health -= dmg;
        yield return new WaitForSeconds(.01f);
    }

    private IEnumerator Bomb()
    {
        isBomb = true;
        foreach (GameObject Enemy in transform.GetChild(0).GetComponent<Radius>().points)
        {
            Enemy.GetComponent<EnemyHealth>().health -= dmg;
        }
        Instantiate(Instances[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(.01f);
        Destroy(gameObject);
    }

    private IEnumerator Cluster()
    {
        isBomb = true;

        foreach (GameObject Enemy in transform.GetChild(0).GetComponent<Radius>().points)
        {
            Enemy.GetComponent<EnemyHealth>().health -= dmg;
        }
        Instantiate(Instances[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(.01f);

        Instantiate(Instances[1], new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
        yield return new WaitForSeconds(.01f);
        Instantiate(Instances[1], new Vector3(transform.position.x + 1, transform.position.y - 1, transform.position.z), transform.rotation);
        yield return new WaitForSeconds(.01f);
        Instantiate(Instances[1], new Vector3(transform.position.x - 1, transform.position.y - 1, transform.position.z), transform.rotation);
        yield return new WaitForSeconds(.01f);

        Destroy(gameObject);


    }

    private IEnumerator Multi()
    {
        isBomb = true;

        foreach (GameObject Enemy in transform.GetChild(0).GetComponent<Radius>().points)
        {
            Enemy.GetComponent<EnemyHealth>().health -= dmg;
        }
        Instantiate(Instances[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(.01f);

        Instantiate(Instances[1], new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
        yield return new WaitForSeconds(.01f);
        Instantiate(Instances[1], new Vector3(transform.position.x + 1, transform.position.y - 1, transform.position.z), transform.rotation);
        yield return new WaitForSeconds(.01f);
        Instantiate(Instances[1], new Vector3(transform.position.x - 1, transform.position.y - 1, transform.position.z), transform.rotation);
        yield return new WaitForSeconds(.01f);
        Instantiate(Instances[1], new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), transform.rotation);
        yield return new WaitForSeconds(.01f);
        Instantiate(Instances[1], new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z), transform.rotation);
        yield return new WaitForSeconds(.01f);
        Instantiate(Instances[1], new Vector3(transform.position.x - 1, transform.position.y + 1, transform.position.z), transform.rotation);
        yield return new WaitForSeconds(.01f);
        Destroy(gameObject);
    }

    private IEnumerator newBomb()
    {
        isBomb = true;
        rgd.velocity = Vector3.zero;
        yield return new WaitForSeconds(.5f);
        foreach (GameObject Enemy in transform.GetChild(0).GetComponent<Radius>().points)
        {
            Enemy.GetComponent<EnemyHealth>().health -= dmg;
        }
        Instantiate(Instances[0], transform.position, transform.rotation);
        yield return new WaitForSeconds(.01f);
        Destroy(gameObject);

    }

    private IEnumerator WMD()
    {
        isLazer = true;

        foreach (GameObject Enemy in transform.GetChild(0).GetComponent<Radius>().points)
        {
            Enemy.GetComponent<EnemyHealth>().health -= dmg;
        }

        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }
}
