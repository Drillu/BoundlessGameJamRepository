using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    public float scoreNumber=0;
       
    void Update()
    {
        scoreText.text = scoreNumber.ToString("00000");
    }
    
}
