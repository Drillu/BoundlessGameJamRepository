using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Buy : MonoBehaviour
{
    public GameObject reference;
    string refName;

    Button me;

    int cost;

    int Money;

    public Text MoneyText;

    btn buttonScr;
    // Start is called before the first frame update
    void Start()
    {
        me = gameObject.GetComponent<Button>();
        me.onClick.AddListener(BuyFunc);

        Money = 9999999;
        MoneyText.text = Money + "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuyFunc()
    {
        if(reference != null)
        {
            buttonScr = reference.GetComponent<btn>();
            refName = reference.gameObject.name;
            cost = (buttonScr.BaseCost * buttonScr.Level);

            if(Money >= cost && (PlayerPrefs.GetInt(refName) < (buttonScr.LevelCap + 1)))
            {
                PlayerPrefs.SetInt(refName, PlayerPrefs.GetInt(refName) + 1);
                Money = Money - cost;
                MoneyText.text = Money + "";
                buttonScr.buymenu();
            }
        }
    }
}
