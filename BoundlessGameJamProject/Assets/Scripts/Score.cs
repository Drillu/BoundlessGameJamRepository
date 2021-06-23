using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    public Spawner spawnerReference;
    public float scoreNumber=0;
    float[] scoreNeededForBoss = { 250, 500, 1000 };
    int currBossIndex = 0;

    private void Update()
    {
        scoreText.text = scoreNumber.ToString("00000");
        if(scoreNumber>=scoreNeededForBoss[currBossIndex])
        {
            spawnerReference.isBossTime = true;
            spawnerReference.SpawnBoss(currBossIndex);
            currBossIndex++;     
        }
    }

 
}
