using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Text[] texts;
    public Button[] buttons;

    public int score;


    void Start()
    {

        buttons[0].onClick.AddListener(Menu);
        buttons[1].onClick.AddListener(Upgrades);
        buttons[2].onClick.AddListener(PlayAgain);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Menu()
    {
        SceneManager.LoadScene(1);
    }

    private void Upgrades()
    {
        SceneManager.LoadScene(3);
    }

    private void PlayAgain()
    {
        SceneManager.LoadScene(2);
    }

    public IEnumerator Death()
    {
        texts[0].text = "Score: " + score;
        texts[1].text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
        texts[2].text = "" + PlayerPrefs.GetInt("Currency");


        yield return new WaitForSeconds(.01f);
    }
}
