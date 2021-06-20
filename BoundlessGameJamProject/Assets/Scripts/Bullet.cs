using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().health -= dmg;
        }
    }
}
