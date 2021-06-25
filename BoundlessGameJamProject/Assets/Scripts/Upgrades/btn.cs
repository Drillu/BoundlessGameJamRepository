using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class btn : MonoBehaviour
{

    public Text[] text;

    public string Name;
    public string Info;

    public int LevelCap;

    public int BaseCost;
    int cost;
    int Level;

    Button me;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt(gameObject.name) > 5 || (PlayerPrefs.GetInt(gameObject.name) <= 0))
        {
            PlayerPrefs.SetInt(gameObject.name, 1);
            Level = PlayerPrefs.GetInt(gameObject.name);
        }
        else
        {
            Level = PlayerPrefs.GetInt(gameObject.name);
        }

        me = gameObject.GetComponent<Button>();
        me.onClick.AddListener(buymenu);
    }

    // Update is called once per frame
    void Update()
    {
        Level = PlayerPrefs.GetInt(gameObject.name);
    }

    private void buymenu()
    {
        if (PlayerPrefs.GetInt(gameObject.name) < LevelCap)
        {
            text[0].text = Name + "Lvl " + Level;
            text[1].text = Info;
            cost = (BaseCost * Level);
            text[2].text = cost + "";

            //set activeobject on buybutton
        }
    }
}
