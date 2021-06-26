using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    public Spawner spawnerReference;
    public int scoreNumber=0;
    int[] scoreNeededForBoss = { 250, 500, 1000 };
    int currBossIndex = 0;
    
    BaseP pHlth;

    bool set = false;

    public GameObject pauseMenu;

    private void Start()
    {
        pHlth = GameObject.Find("Player").GetComponent<BaseP>();
    }


    private void Update()
    {
        scoreText.text = scoreNumber.ToString("00000");
        if(scoreNumber>=scoreNeededForBoss[currBossIndex])
        {
            spawnerReference.isBossTime = true;
            spawnerReference.SpawnBoss(currBossIndex);
            currBossIndex++;     
        }

        if(pHlth.isDead == true)
        {
            pauseMenu.SetActive(true);
            if (set == false)
            {
                StartCoroutine(setValue());
                
            }
        }
    }

    private IEnumerator setValue()
    {
        set = true;

        PlayerPrefs.SetInt("HighScore", scoreNumber);
        PlayerPrefs.SetInt("Currency", PlayerPrefs.GetInt("Currency") + (scoreNumber / 10));

        GameObject.Find("DeathScreen").GetComponent<DeathScript>().score = scoreNumber;
        StartCoroutine(GameObject.Find("DeathScreen").GetComponent<DeathScript>().Death());
        yield return new WaitForSeconds(.01f);
    }

 
}
