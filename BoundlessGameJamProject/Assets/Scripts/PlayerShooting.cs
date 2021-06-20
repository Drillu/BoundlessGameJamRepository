using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject Bullet;

    private bool isPaused;
    public float fireRate;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoFire(fireRate));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator AutoFire(float fireSpd)
    {

        yield return new WaitForSeconds(fireSpd);
        Instantiate(Bullet, transform.GetChild(0).transform.position, transform.rotation);
        StartCoroutine(AutoFire(fireRate));
    }
}
