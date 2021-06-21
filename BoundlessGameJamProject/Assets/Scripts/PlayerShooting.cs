using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Timer timerReference;
    public GameObject[] bulletArray;
   // public GameObject Bullet;

    private bool isPaused;
    private Bullet bulletScriptReference;

    public GameObject autoBullet;
    // Start is called before the first frame update
    void Start()
    {
        bulletScriptReference = bulletArray[0].GetComponent<Bullet>();
        StartCoroutine(AutoFire(bulletScriptReference.fireRate));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {

            StartCoroutine(AbilityFire(bulletScriptReference.fireRate));
        }

    }

    private IEnumerator AbilityFire(float fireSpd)
    {
        bulletScriptReference = bulletArray[timerReference.NextBullet(timerReference.bulletIndex)].GetComponent<Bullet>();
        yield return new WaitForSeconds(fireSpd);
        Instantiate(bulletArray[timerReference.NextBullet(timerReference.bulletIndex)], transform.GetChild(0).transform.position, transform.rotation);
        StartCoroutine(AutoFire(bulletScriptReference.fireRate));
    }


    private IEnumerator AutoFire(float fireSpd)
    {
        yield return new WaitForSeconds(fireSpd);
        Instantiate(autoBullet, transform.GetChild(0).transform.position, transform.rotation);
        StartCoroutine(AutoFire(fireSpd));
    }

    public int NextBullet(int index)
    {
        return index;
    }

}
