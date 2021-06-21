using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int timeToDelete;
    public float fireRate;
    public float spd;
    public int dmg;
    Rigidbody2D rgd;

    public int TYPE;  //0 = Player, 1 = Enemy, 
    void Start()
    {
        rgd = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TYPE == 0)
        {
            transform.position += Vector3.right * spd;
        }
        else if (TYPE == 1)
        {
            transform.position += -Vector3.right * spd;
        }

        timeToDelete --;
        
        
        if(timeToDelete<=0)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (gameObject.tag == "Bullet")
        {
            if (other.gameObject.tag == "enemy")
            {
                other.gameObject.GetComponent<EnemyHealth>().health -= dmg;
            }
        }

        if(gameObject.tag == "eBullet")
        {
            if(other.tag == "Player")
            {
                other.gameObject.GetComponent<BaseP>().health -= dmg;
            }
        }
    }
}
