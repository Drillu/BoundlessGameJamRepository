using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButton : MonoBehaviour
{

    public int Type;
    Button me;

    // Start is called before the first frame update
    void Start()
    {
        me = gameObject.GetComponent<Button>();
        me.onClick.AddListener(Clicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Clicked()
    {
        GameObject.Find("Canvas").GetComponent<Switch>().MODE = Type;

    }
}
