using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{

    public Image logo;
    public Text MadeBy;

    
    bool isBG;
    public bool isGood = true;

    bool isStart;
    bool isEnd = false;

    bool NotStart;
    // Start is called before the first frame update
    void Start()
    {
        if(tag == "text")
        {
            MadeBy = gameObject.GetComponent<Text>();
        }
        else if(tag == "start")
        {
            isGood = false;
            isBG = true;
            NotStart = false;
            logo = gameObject.GetComponent<Image>();
        }
        else
        {
            logo = gameObject.GetComponent<Image>();
            NotStart = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGood == false)
        {
            StartFade();
        }
        else if (isGood == true && NotStart == true)
        {
            EndFade();
        }
    }

    private void StartFade()
    {
        logo.color = new Color(logo.color.r, logo.color.g, logo.color.b, logo.color.a + 0.01f);

        if (logo.color.a >= 1)
        {
            StartCoroutine(WaitFade());
        }
    }

    private IEnumerator WaitFade()
    {
        yield return new WaitForSeconds(1);
        isGood = true;
        NotStart = true;
    }

    private void EndFade()
    {
        logo.color = new Color(logo.color.r, logo.color.g, logo.color.b, logo.color.a - 0.01f);
        if (logo.color.a <= 0)
        {
            StartCoroutine(Trans());
        }
    }

    private IEnumerator Trans()
    {
        if(isBG == true && isEnd == false)
        {
            isEnd = true;
            GameObject.Find("Canvas").transform.GetChild(4).GetComponent<Text>().text = "Made By:";
            yield return new WaitForSeconds(.25f);
            GameObject.Find("Canvas").transform.GetChild(1).GetComponent<Splash>().isGood = false;
            yield return new WaitForSeconds(.25f);
            GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Splash>().isGood = false;
            yield return new WaitForSeconds(.25f);
            GameObject.Find("Canvas").transform.GetChild(3).GetComponent<Splash>().isGood = false;
            yield return new WaitForSeconds(.25f);
            GameObject.Find("Canvas").transform.GetChild(2).GetComponent<Splash>().isGood = false;
        }
        else if (isBG != true && tag == "end")
        {
            GameObject.Find("Canvas").transform.GetChild(4).gameObject.SetActive(false);
            yield return new WaitForSeconds(.5f);
            SceneManager.LoadScene(1);
        }
    }
}
