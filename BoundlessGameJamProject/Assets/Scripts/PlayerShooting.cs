using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Timer timerReference;
    public GameObject[] BulletTypes;
    public GameObject[] bulletArray;
    public GameObject Bullet;
    public GameObject NextBullet;

    public float firerate;

    private bool isPaused;
    private Bullet bulletScriptReference;
    public GameObject autoBullet;


    // Start is called before the first frame update
    void Start()
    {
        bulletScriptReference = bulletArray[0].GetComponent<Bullet>();
        StartCoroutine(AutoFire(firerate));

        firerate = firerate - ((PlayerPrefs.GetInt("Speed") * .02f) + .02f);

        StartCoroutine(CheckAbilities());
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
        yield return new WaitForSeconds(fireSpd);
        Instantiate(bulletArray[timerReference.NextBullet(timerReference.bulletIndex)], transform.GetChild(0).transform.position, transform.rotation);
        
    }


    private IEnumerator AutoFire(float fireSpd)
    {
        yield return new WaitForSeconds(fireSpd);
        Instantiate(autoBullet, transform.GetChild(0).transform.position, transform.rotation);
        StartCoroutine(AutoFire(firerate));
    }

    private IEnumerator CheckAbilities()
    {
        if (PlayerPrefs.GetInt("Nuclear") > 0)
        {
            bulletArray[0] = BulletTypes[0];
        }
        else if (PlayerPrefs.GetInt("ICBM") > 0)
        {
            bulletArray[0] = BulletTypes[1];
        }
        else
        {
            bulletArray[0] = BulletTypes[2];
        }

        if (PlayerPrefs.GetInt("MultiNade") > 0)
        {
            bulletArray[1] = BulletTypes[3];
        }
        else if (PlayerPrefs.GetInt("Cluster") > 0)
        {
            bulletArray[1] = BulletTypes[4];
        }
        else
        {
            bulletArray[1] = BulletTypes[5];
        }

        if (PlayerPrefs.GetInt("Wmd") > 0)
        {
            bulletArray[2] = BulletTypes[6];
        }
        else if (PlayerPrefs.GetInt("Lazer") > 0)
        {
            bulletArray[2] = BulletTypes[7];
        }
        else
        {
            bulletArray[2] = BulletTypes[8];
        }

        if (PlayerPrefs.GetInt("Barrage") > 0)
        {
            bulletArray[3] = BulletTypes[9];
        }
        else if (PlayerPrefs.GetInt("Gatling") > 0)
        {
            bulletArray[3] = BulletTypes[10];
        }
        else
        {
            bulletArray[3] = BulletTypes[11];
        }

        if (PlayerPrefs.GetInt("EMP") > 0)
        {
            bulletArray[4] = BulletTypes[12];
        }
        else if (PlayerPrefs.GetInt("Stunner") > 0)
        {
            bulletArray[4] = BulletTypes[13];
        }
        else
        {
            bulletArray[4] = BulletTypes[14];
        }

        yield return new WaitForSeconds(.1f);
    }

}
