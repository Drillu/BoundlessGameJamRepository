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

    bool isBuy = false;

    btn buttonScr;
    // Start is called before the first frame update
    void Start()
    {
        me = gameObject.GetComponent<Button>();

        Money = PlayerPrefs.GetInt("Currency");
        MoneyText.text = Money + "";
    }

    // Update is called once per frame
    void Update()
    {
        if(isBuy == true && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(BuyFunc());
        }
    }

    private IEnumerator BuyFunc()
    {
        if(reference != null)
        {
            buttonScr = reference.GetComponent<btn>();
            refName = reference.gameObject.name;
            cost = (buttonScr.BaseCost * buttonScr.Level);

            if(Money >= cost && (PlayerPrefs.GetInt(refName) < (buttonScr.LevelCap + 1)))
            {
                PlayerPrefs.SetInt(refName, PlayerPrefs.GetInt(refName) + 1);
                PlayerPrefs.SetInt("Currency", PlayerPrefs.GetInt("Currency") - cost);

                Money = PlayerPrefs.GetInt("Currency");
                MoneyText.text = Money + "";
                buttonScr.buymenu();
            }
        }

        yield return new WaitForSeconds(.4f);
    }

    public void buy()
    {
        isBuy = true;
    }

    public void buyOut()
    {
        isBuy = false;
    }
}
