using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int timeToDelete;
    public float fireRate;
    public float spd;
    public int dmg;
    public float crit;
    Rigidbody2D rgd;

    public int TYPE;  //0 = Player, 1 = Enemy, 
    void Start()
    {
        rgd = gameObject.GetComponent<Rigidbody2D>();

        crit = PlayerPrefs.GetInt("crit") - 1;
        float i = Random.Range(0, 100);
        if(i > crit)
        {
            dmg = dmg + ((PlayerPrefs.GetInt("Power") * 2) - 2);
        }
        else
        {
            dmg = (dmg + ((PlayerPrefs.GetInt("Power") * 2) - 2)) * 2;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (TYPE == 0)
        {
            rgd.velocity = Vector2.right*spd;
            //transform.position += Vector3.right * spd;
        }
        else if (TYPE == 1)
        {
            rgd.velocity = Vector2.left * spd;
            //transform.position += -Vector3.right * spd;
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
