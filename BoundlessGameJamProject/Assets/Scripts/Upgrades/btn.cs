using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class btn : MonoBehaviour
{

    public Text[] text;

    public string Name;
   
    public string Info;
 
    public string lockedName;
    public int LevelCap;

    public int BaseCost;
    int cost;
    public int Level;

    Button me;
    Color32 unlocked;
    public GameObject Unlock;

    public bool isLocked;
    // Start is called before the first frame update
    void Start()
    {
        me = gameObject.GetComponent<Button>();

        
        if(tag == "Lockable")
        {
            PlayerPrefs.SetInt(gameObject.name, 0);
        }
        else
        {
            PlayerPrefs.SetInt(gameObject.name, 1);
        }

        
        if (PlayerPrefs.GetInt(gameObject.name) > LevelCap + 1 | (PlayerPrefs.GetInt(gameObject.name) <= 0))
        {
            if (tag == "Lockable")
            {
                PlayerPrefs.SetInt(gameObject.name, 0);
                Level = PlayerPrefs.GetInt(gameObject.name);
                unlocked = gameObject.GetComponent<Image>().color;
                lockedName = transform.GetChild(0).GetComponent<Text>().text;
                isLocked = true;
                StartCoroutine(LockedFunc());
                
            }
            else
            {
                Debug.Log(gameObject.name);
                PlayerPrefs.SetInt(gameObject.name, 1);
                Level = PlayerPrefs.GetInt(gameObject.name);
            }
        }
        else if(PlayerPrefs.GetInt(gameObject.name) == LevelCap + 1)
        {
            me.interactable = false;
        }

        else
        {
            Level = PlayerPrefs.GetInt(gameObject.name);
        }

        me.onClick.AddListener(buymenu);
    }

    // Update is called once per frame
    void Update()
    {
        Level = PlayerPrefs.GetInt(gameObject.name);
    }

    public void buymenu()
    {
        if (PlayerPrefs.GetInt(gameObject.name) < (LevelCap + 1))
        {
            text[0].text = Name + "Lvl " + PlayerPrefs.GetInt(gameObject.name);
            text[1].text = Info;
            cost = (BaseCost * PlayerPrefs.GetInt(gameObject.name));
            text[2].text = cost + "";

            GameObject.Find("BuyButton").GetComponent<Buy>().reference = gameObject;
        }
        else
        {
            text[0].text = Name + "Lvl: MAX";
            text[1].text = Info;
            cost = 99999999;
            text[2].text = "N/A";

            GameObject.Find("BuyButton").GetComponent<Buy>().reference = gameObject;
            me.interactable = false;

            if(Unlock != null)
            {
                Unlock.GetComponent<btn>().UnlockFunc();
            }
        }
    }

    private IEnumerator LockedFunc()
    {
        Debug.Log("yeet");
        transform.GetChild(0).GetComponent<Text>().text = "LOCKED  ";
        me.interactable = false;

        yield return new WaitForSeconds(.1f);
    }

    public void UnlockFunc()
    {
        if (PlayerPrefs.GetInt(gameObject.name) <= 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = lockedName;
            me.interactable = true;
            PlayerPrefs.SetInt(gameObject.name, 1);
            isLocked = false;
        }

    }
}
