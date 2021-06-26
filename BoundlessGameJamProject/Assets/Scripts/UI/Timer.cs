using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float countdown=15f;
    public int bulletIndex = 0;
    public Text timer;

    void Start()
    {
        timer.text = "-";
    }

    

    void Update()
    {   
        if(countdown>0)
        countdown -= Time.deltaTime;

        else
        {
            bulletIndex++;
            if (bulletIndex == 2)
            {
                bulletIndex = 0;
            }
            countdown += 15f;
            NextBullet(bulletIndex);
        }
        
        timer.text = countdown.ToString("00");
    }

    public int NextBullet(int index)
    {
        return index;
    }
}
