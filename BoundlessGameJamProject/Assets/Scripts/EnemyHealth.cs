using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    private int TYPE;

    public int health;
    private int maxHealth, currHealth;

    public int scoreToGet;
    private Score scoreReference;

    bool isDeath;

    Color32 hitColor;
    Color32 baseColor;

    SpriteRenderer sprRen;
    void Start()
    {
        scoreReference = GameObject.Find("LevelManager").GetComponent<Score>();
        if(TYPE == 0)
        {
            maxHealth = 50;
            health = maxHealth;
            currHealth = health;
        }
        else if (TYPE == 1)
        {
            maxHealth = 100;
            health = maxHealth;
            currHealth = health;
        }
        else if (TYPE == 150)
        {

        }

        sprRen = gameObject.GetComponent<SpriteRenderer>();

        gameObject.transform.GetChild(0).GetComponent<EnemyHbar>().SetHealth(health, maxHealth);

        baseColor = sprRen.color;
        hitColor = new Color32(135, 66, 66, 255);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (currHealth != health && isDeath==false)
        {
            gameObject.transform.GetChild(0).GetComponent<EnemyHbar>().SetHealth(health, maxHealth);
            currHealth = health;
            StartCoroutine(hit());
        }

        if (health <= 0)
        {
            StartCoroutine(death());
        }

    }

    private IEnumerator hit()
    {
        sprRen.color = hitColor;
        yield return new WaitForSeconds(.1f);
        sprRen.color = baseColor;
    }

    private IEnumerator death()
    {
        isDeath = true;
        sprRen.color = hitColor;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        scoreReference.scoreNumber += scoreToGet;
    }
}
