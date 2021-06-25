using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public int MODE;

    
    // Start is called before the first frame update
    void Start()
    {
        
        MODE = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(MODE == 1)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (MODE == 2)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    
}
