using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public Timer timerReference;
    public GameObject autoBullet;
    public GameObject[] BulletTypes;
    public GameObject[] bulletArray;
    public GameObject Bullet;

    public float firerate;

    private bool isPaused;
    

    private bool isChecked;

    int random;

    float cooldown = 3f;
    bool isReady = true;

    public Image SetIcon;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoFire(firerate));

        firerate = firerate - ((PlayerPrefs.GetInt("Speed") * .015f) + .02f);

        isChecked = false;
        random = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

        

        if (isChecked == false)
        {
            StartCoroutine(CheckAbilities());
        }

        cooldown = Bullet.GetComponent<BasicBullet>().cooldown;

        if (Input.GetKey(KeyCode.E) && isReady == true)
        {
            StartCoroutine(AbilityFire(cooldown));
        }
        
    }

    private IEnumerator AbilityFire(float Cooldown)
    {
        isReady = false;
        Instantiate(Bullet, transform.GetChild(0).transform.position, transform.rotation);
        Debug.Log("shoot");
        yield return new WaitForSeconds(Cooldown);
        isReady = true;
    }


    private IEnumerator AutoFire(float fireSpd)
    {
        yield return new WaitForSeconds(fireSpd);
        Instantiate(autoBullet, transform.GetChild(0).transform.position, transform.rotation);
        StartCoroutine(AutoFire(firerate));
    }

    private IEnumerator CheckAbilities()
    {
        isChecked = true;

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

        StartCoroutine(Ability());

        yield return new WaitForSeconds(.1f);
    }

    private IEnumerator Ability()
    {
        int i = Random.Range(0, 100);
        if(i == random)
        {
            int x = Random.Range(0, 100);
            random = x;
        }
        else
        {
            random = i;
        }


        if(random > 75)
        {
            Bullet = bulletArray[0];
        }
        else if(random > 50)
        {
            Bullet = bulletArray[1];
        }
        else if(random > 25)
        {
            Bullet = bulletArray[2];
        }
        else
        {
            Bullet = bulletArray[3];
        }

        SetIcon.sprite = Bullet.GetComponent<BasicBullet>().LOGO;
        yield return new WaitForSeconds(15f);

        Debug.Log("hit");
        StartCoroutine(Ability());
    }

}
